import { createActions } from 'realt';
import ModalsActions from 'actions/ModalsActions';

import VacanciesSource from '../../sources/VacanciesSource';
import { MODAL_TYPES } from '../../constants/ModalsConstants';
import { FormatStatusToServer } from '../../utils/VacanciesUtils';

class VacanciesSingleActions {
  constructor() {
    this.generate(
      'stateClear'
    );
  }

  vacancyGet(vacancyId) {
    return VacanciesSource.getVacancy(vacancyId);
  }

  vacancyStatusEdit(vacancyId, query) {
    return VacanciesSource.editVacancyStatus(vacancyId, FormatStatusToServer(query));
  }

  vacancyEditingModalOpen() {
    return dispatch => dispatch(ModalsActions.modalToggle(MODAL_TYPES.vacancyEditing));
  }
}

export default createActions(VacanciesSingleActions, 'vacancy');
