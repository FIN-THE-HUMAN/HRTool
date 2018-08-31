import _ from 'lodash';
import update from 'immutability-helper';
import { createReducer } from 'realt';
import Status from 'constants/StatusConstants';

import ViewActions from '../../actions/vacancies/ViewActions';
import CreationActions from '../../actions/vacancies/CreationActions';
import { FormatStatusToClient, FormatVacancyToClient } from '../../utils/VacanciesUtils';

class VacanciesViewReducer {
  constructor() {
    this.bindAction(ViewActions.vacanciesGet, this.handleVacanciesGet);
    this.bindAction(ViewActions.vacancyRemove, this.handleVacancyRemove);
    this.bindAction(ViewActions.vacancyStatusEdit, this.handleVacancyStatusEdit);
    this.bindAction(ViewActions.paramsChange, this.handleParamsChange);
    this.bindAction(ViewActions.stateClear, () => this.initialState);
    this.bindAction(CreationActions.vacancyCreateCallback, this.handleVacancyCreate);
  }

  get initialState() {
    return {
      contentStatus: Status.LOADING,
      data: [],
      total: 0,
      params: {
        offset: 0,
        count: 10,
        search: ''
      }
    };
  }

  handleVacanciesGet(state, { isSuccess, status, response }) {
    if (!isSuccess) return update(state, { $merge: { contentStatus: status } });

    const contentStatus = response.data.length > 0 ? Status.DEFAULT : Status.NO_RESULTS;
console.log('1', response);
console.log('2', response.data.map(FormatVacancyToClient));
    return update(state, { $merge: {
      ...response,
      data: response.data.map(FormatVacancyToClient),
      contentStatus
    } });
  }

  handleVacancyRemove(state, { isSuccess, status, data }) {
    if (!isSuccess) return state;

    const index = _.findIndex(state.data, vacancy => vacancy.id === data);

    if (index < 0) return update(state, { $merge: { status } });

    return update(state, {
      $merge: {
        contentStatus: state.total - 1 === 0 ? Status.NO_RESULTS : status,
        total: state.total - 1
      },
      data: { $splice: [[index, 1]] }
    });
  }

  handleVacancyCreate(state, { isSuccess, query, response }) {
    if (!isSuccess) return state;

    return update(state, {
      data: { $unshift: [FormatVacancyToClient({ ...query, ...response, status: 0 })] },
      $merge: {
        contentStatus: Status.DEFAULT,
        total: state.total + 1,
      }
    });
  }

  handleVacancyStatusEdit(state, { isSuccess, query, vacancyId }) {
    if (!isSuccess) return state;

    const index = _.findIndex(state.data, vacancy => vacancy.id === vacancyId);

    if (index < 0) return state;

    return update(state, {
      data: { [index]: { $merge: FormatStatusToClient(query) } }
    });
  }

  handleParamsChange(state, { field, value }) {
    const newParams = { [field]: value };

    if (field === 'count' || field === 'search') {
      newParams.offset = 0;
    }

    return update(state, { params: { $merge: newParams } });
  }
}

export default createReducer(VacanciesViewReducer, 'vacancies');
