import { createActions } from 'realt';
import Status from 'constants/StatusConstants';
import ModalsActions from 'actions/ModalsActions';

import VacanciesSource from '../../sources/VacanciesSource';
import { MODAL_TYPES } from '../../constants/ModalsConstants';
import { FormatVacancyToServer } from '../../utils/VacanciesUtils';

class DashboardVacanciesEditingActions {
  constructor() {
    this.generate(
      'vacancyEditCallback'
    );
  }

  vacancyGet(id) {
    return VacanciesSource.getVacancy(id);
  }

  editingCancel() {
    return dispatch => dispatch(ModalsActions.modalToggle(MODAL_TYPES.vacancyEditing));
  }

  vacancyEdit(vacancyId, query) {
    return dispatch => {
      VacanciesSource.editVacancy(vacancyId, FormatVacancyToServer(query))
        .loading(result => dispatch(this.vacancyEditCallback(result)))
        .then(result => {
          dispatch(this.vacancyEditCallback(result));

          setTimeout(() => {
            dispatch(this.vacancyEditCallback({ status: Status.DEFAULT }));
            dispatch(ModalsActions.modalToggle(MODAL_TYPES.vacancyEditing));
          }, 1000);
        })
        .catch(result => {
          dispatch(this.vacancyEditCallback(result));

          setTimeout(() => dispatch(this.vacancyEditCallback({ status: Status.DEFAULT })), 1000);
        });
    };
  }
}

export default createActions(DashboardVacanciesEditingActions, 'vacanciesEditing');
