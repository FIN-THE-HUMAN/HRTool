import React, { Component, Fragment } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';
import connect from 'decorators/ConnectDecorators';
import { ContentStatus } from 'components';
import { Link } from 'components/router';
import { Modal } from 'containers';

import VacanciesSingleActions from '../../actions/vacancies/SingleActions';
import { defineSalaryString } from '../../utils/VacanciesUtils';
import { VACANCY_SHORT_FORMAT } from '../../constants/DateConstants';
import { MODAL_TYPES } from '../../constants/ModalsConstants';
import VacancyStatus from '../../components/VacancyStatus';
import EditingForm from './EditingForm';

class Single extends Component {
  componentDidMount = () => this.props.actions.vacancyGet(this.props.match.params.id);

  componentWillUnmount = () => this.props.actions.stateClear();

  handleVacancyStatusEdit = status => this.props.actions.vacancyStatusEdit(this.props.match.params.id, { status });

  render() {
    const { data, contentStatus, message } = this.props;
    const { id } = this.props.match.params;
    const { vacancyEditingModalOpen } = this.props.actions;

    return (
      <div className="vacancy">
        <ContentStatus status={contentStatus} message={message}>
          <div className="date">{data.creationDate && data.creationDate.format(VACANCY_SHORT_FORMAT)}</div>
          <div className="name">{data.name}</div>
          <VacancyStatus status={data.status} onEdit={this.handleVacancyStatusEdit} />
          <div className="salary">{defineSalaryString(data.salaryRangeFrom, data.salaryRangeTo)}</div>
          <div className="departure"><span className="name-field">Отдел: </span>{data.departureName}</div>
          <div className="experience"><span className="name-field">Опыт: </span>{data.requiredExperienceRange}</div>
          <div className="employment-type"><span className="name-field">Тип занятости: </span>{data.employmentType}</div>
          <div className="work-hours"><span className="name-field">График работы: </span>{data.workHours}</div>
          {data.duties && data.duties.length > 0 &&
            <Fragment>
              <strong>Обязанности:</strong>
              <ul className="duties">
                {data.duties.map(({ id, name }) => (
                  <li key={id}>{name}</li>
                ))}
              </ul>
            </Fragment>
          }
          {data.requirements && data.requirements.length > 0 &&
            <Fragment>
              <strong>Требования:</strong>
              <ul className="requirements">
                {data.requirements.map(({ id, name }) => (
                  <li key={id}>{name}</li>
                ))}
              </ul>
            </Fragment>
          }
          {data.additionalRequirements && data.additionalRequirements.length > 0 &&
            <Fragment>
              <strong>Дополнительные требования:</strong>
              <ul className="additionalRequirements">
                {data.additionalRequirements.map(({ id, name }) => (
                  <li key={id}>{name}</li>
                ))}
              </ul>
            </Fragment>
          }
          <div className="description">{data.description}</div>
          <div className="contact-person">
            <div className="contact-name">{data.contactPerson}</div>
            <div className="contact-phone">{data.contactPhone}</div>
            <div className="contact-email">{data.contactMail}</div>
          </div>
          <div className="author"><span className="name-field">Разместитель: </span>{data.holderName}</div>
          <div className="city"><span className="name-field">Город: </span> {data.branchOfficeCity}</div>
          <Button bsStyle="link">
            <Link to="/vacancies">Назад</Link>
          </Button>
          <Button onClick={vacancyEditingModalOpen}>Редактировать</Button>
        </ContentStatus>
        <Modal type={MODAL_TYPES.vacancyEditing} title="Редактирование вакансии">
          <EditingForm data={data} vacancyId={id} />
        </Modal>
      </div>
    );
  }
}

Single.propTypes = {
  contentStatus: PropTypes.string,
  message: PropTypes.string,
  match: PropTypes.object,
  actions: PropTypes.object,
  data: PropTypes.object
};

export default connect({
  name: 'vacancy',
  actions: VacanciesSingleActions
})(Single);
