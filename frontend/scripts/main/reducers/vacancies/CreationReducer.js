import { createReducer } from 'realt';
import update from 'immutability-helper';
import Status from 'constants/StatusConstants';

import CreationActions from '../../actions/vacancies/CreationActions';

class VacanciesCreationReducer {
  constructor() {
    this.bindAction(CreationActions.vacancyCreateCallback, this.handleSubmit);
  }

  get initialState() {
    return {
      status: Status.DEFAULT
    };
  }

  handleSubmit(state, { status, response }) {
    return update(state, { $merge: { status, message: response && response.message } });
  }
}

export default createReducer(VacanciesCreationReducer, 'vacancyCreation');
