import { createActions } from 'realt';
import Status from 'constants/StatusConstants';
import ModalsActions from 'actions/ModalsActions';

import VacanciesSource from '../../sources/VacanciesSource';
import { MODAL_TYPES } from '../../constants/ModalsConstants';
import { FormatVacancyToServer } from '../../utils/VacanciesUtils';

class VacanciesCreationActions {
  constructor() {
    this.generate(
      'vacancyCreateCallback'
    );
  }

  creationCancel() {
    return dispatch => dispatch(ModalsActions.modalToggle(MODAL_TYPES.vacancyCreation));
  }

  vacancyCreate(query) {
    return dispatch => {
      VacanciesSource.createVacancy(FormatVacancyToServer(query))
        .loading(result => dispatch(this.vacancyCreateCallback(result)))
        .then(result => {
          dispatch(this.vacancyCreateCallback(result));

          setTimeout(() => {
            dispatch(this.vacancyCreateCallback({ status: Status.DEFAULT }));
            dispatch(ModalsActions.modalToggle(MODAL_TYPES.vacancyCreation));
          }, 1000);
        })
        .catch(result => {
          dispatch(this.vacancyCreateCallback(result));

          setTimeout(() => dispatch(this.vacancyCreateCallback({ status: Status.DEFAULT })), 1000);
        });
    };
  }
}

export default createActions(VacanciesCreationActions, 'vacanciesCreation');
