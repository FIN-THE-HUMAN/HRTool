import React from 'react';
import PropTypes from 'prop-types';
import connect from 'decorators/ConnectDecorators';
import { OverlayStatus } from 'components';

import VacanciesCreationActions from '../../actions/vacancies/CreationActions';
import VacancyCreationForm from '../../components/VacancyForm';

const CreationForm = ({ status, actions: { vacancyCreate, creationCancel } }) => (
  <OverlayStatus status={status}>
    <VacancyCreationForm onSubmit={vacancyCreate} onCancel={creationCancel} />
  </OverlayStatus>
);

CreationForm.propTypes = {
  status: PropTypes.string,
  actions: PropTypes.object,
};

export default connect({
  name: 'vacancyCreation',
  actions: VacanciesCreationActions
})(CreationForm);
