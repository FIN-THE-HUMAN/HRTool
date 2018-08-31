import React from 'react';
import PropTypes from 'prop-types';
import connect from 'decorators/ConnectDecorators';
import { OverlayStatus } from 'components';

import VacanciesEditingActions from '../../actions/vacancies/EditingActions';
import VacancyForm from '../../components/VacancyForm';

const EditingForm = ({ status, data, vacancyId, actions: { vacancyEdit, editingCancel } }) => (
  <OverlayStatus status={status}>
    <VacancyForm initialValues={data} onSubmit={query => vacancyEdit(vacancyId, query)} onCancel={editingCancel} />
  </OverlayStatus>
);

EditingForm.propTypes = {
  vacancyId: PropTypes.string,
  status: PropTypes.string,
  data: PropTypes.object,
  actions: PropTypes.object,
};

export default connect({
  name: 'vacancyEditing',
  actions: VacanciesEditingActions
})(EditingForm);
