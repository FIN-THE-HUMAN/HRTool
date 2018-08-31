import update from 'immutability-helper';
import { createReducer } from 'realt';
import Status from 'constants/StatusConstants';

import EditingActions from '../../actions/vacancies/EditingActions';
import VacanciesSingleActions from '../../actions/vacancies/SingleActions';
import { FormatVacancyToClient, FormatStatusToClient } from '../../utils/VacanciesUtils';

class VacanciesSingleReducer {
  constructor() {
    this.bindAction(VacanciesSingleActions.vacancyGet, this.handleVacancyGet);
    this.bindAction(VacanciesSingleActions.vacancyStatusEdit, this.handleVacancyStatusEdit);
    this.bindAction(VacanciesSingleActions.stateClear, () => this.initialState);
    this.bindAction(EditingActions.vacancyEditCallback, this.handleVacancyEdit);
  }

  get initialState() {
    return {
      contentStatus: Status.LOADING,
      data: {},
      message: ''
    };
  }

  handleVacancyGet(state, { isSuccess, isError, status, response }) {
    if (isError) {
      return update(state, { $merge: {
        contentStatus: status,
        message: 'Вакансия не найдена!'
      } });
    }

    if (!isSuccess) return state;

    return update(state, { $merge: {
      contentStatus: Status.DEFAULT,
      data: FormatVacancyToClient(response)
    } });
  }

  handleVacancyStatusEdit(state, { isSuccess, query }) {
    if (!isSuccess) return state;

    const { status } = FormatStatusToClient(query);

    return update(state, {
      $merge: { status: Status.DEFAULT },
      data: { $merge: { status } }
    });
  }

  handleVacancyEdit(state, { isSuccess, query }) {
    if (!isSuccess) return state;

    return update(state, {
      data: { $merge: FormatVacancyToClient(query) }
    });
  }
}

export default createReducer(VacanciesSingleReducer, 'vacancy');
