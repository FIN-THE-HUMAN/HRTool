import { createActions } from 'realt';
import ModalsActions from 'actions/ModalsActions';

import { MODAL_TYPES } from '../../constants/ModalsConstants';
import VacanciesSource from '../../sources/VacanciesSource';
import { FormatStatusToServer } from '../../utils/VacanciesUtils';

class VacanciesViewActions {
  constructor() {
    this.generate(
      'stateClear'
    );
  }

  vacanciesGet(query) {
    return VacanciesSource.getVacancies(query);
  }

  vacancyRemove(vacancyId) {
    return VacanciesSource.removeVacancy(vacancyId);
  }

  paramsChange(field, value) {
    return { field, value };
  }

  vacancyStatusEdit(vacancyId, query) {
    return VacanciesSource.editVacancyStatus(vacancyId, FormatStatusToServer(query));
  }

  vacancyCreationModalOpen() {
    return dispatch => dispatch(ModalsActions.modalToggle(MODAL_TYPES.vacancyCreation));
  }
}

export default createActions(VacanciesViewActions, 'vacancies');
