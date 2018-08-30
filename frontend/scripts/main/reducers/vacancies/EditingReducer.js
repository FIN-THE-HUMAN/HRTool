import update from 'immutability-helper';
import { createReducer } from 'realt';
import Status from 'constants/StatusConstants';

import EditingActions from '../../actions/vacancies/EditingActions';

class VacanciesEditingReducer {
  constructor() {
    this.bindAction(EditingActions.vacancyEditCallback, this.handleSubmit);
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

export default createReducer(VacanciesEditingReducer, 'vacancyEditing');
