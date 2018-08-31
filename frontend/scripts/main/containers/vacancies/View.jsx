import _ from 'lodash';
import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button, Glyphicon, Row, Col } from 'react-bootstrap';
import connect from 'decorators/ConnectDecorators';
import { Modal } from 'containers';
import { ContentStatus, SearchInput, Pagination } from 'components';
import { Link } from 'components/router';

import VacanciesViewActions from '../../actions/vacancies/ViewActions';
import { MODAL_TYPES } from '../../constants/ModalsConstants';
import { defineSalaryString } from '../../utils/VacanciesUtils';
import { VACANCY_LONG_FORMAT } from '../../constants/DateConstants';
import VacancyStatus from '../../components/VacancyStatus';
import CreationForm from './CreationForm';

const DATA_COUNTS = [5, 10, 25];

class VacanciesList extends Component {
  componentDidMount = () => this.fetchData();

  componentWillReceiveProps({ params }) {
    if (_.isEqual(params, this.props.params)) return;

    this.fetchData(params);
  }

  handleVacancyRemove = id => () => this.props.actions.vacancyRemove(id);

  handleSearchChange = search => this.props.actions.paramsChange('search', search);

  handleCountChange = count => this.props.actions.paramsChange('count', count);

  handlePageChange = offset => this.props.actions.paramsChange('offset', offset);

  handleStatusEdit = id => status => this.props.actions.vacancyStatusEdit(id, { status });

  fetchData(params) {
    const { offset, count, search } = this.props.params;
    const { vacanciesGet } = this.props.actions;

    vacanciesGet(params || { offset, count, search });
  }

  render() {
    const { total, data, contentStatus } = this.props;
    const { offset, count, search } = this.props.params;
    const { vacancyCreationModalOpen } = this.props.actions;

    return (
      <div className="vacancies-view">
        <div className="title">Список вакансий</div>
        <Row>
          <Col sm={1}>
            <Button className="cross" bsStyle="primary" onClick={vacancyCreationModalOpen} />
          </Col>
          <Col sm={4}>
            <SearchInput value={search} onSearch={this.handleSearchChange} />
          </Col>
        </Row>
        <ContentStatus status={contentStatus}>
          <div className="vacancies-list">
            {data.map(({ id, name, departureName, salaryRangeFrom, salaryRangeTo, description, creationDate, status, branchOfficeCity }) => (
              <div key={id} className="vacancy">
                <Link className="name" to={`/vacancy/${id}`}>{name}</Link>
                <VacancyStatus status={status} onEdit={this.handleStatusEdit(id)} />
                <Glyphicon glyph="remove" className="control control-remove" onClick={this.handleVacancyRemove(id)} />
                <div className="departure">Отдел: {departureName}</div>
                <div className="salary">{defineSalaryString(salaryRangeFrom, salaryRangeTo)}</div>
                <div className="description">{description}</div>
                <div className="date">{creationDate.format(VACANCY_LONG_FORMAT)}</div>
                <div className="city">{branchOfficeCity}</div>
              </div>
            ))}
          </div>
          <Pagination
            offset={offset}
            total={total}
            dataCount={data.length}
            count={count}
            counts={DATA_COUNTS}
            onPageChange={this.handlePageChange}
            onCountChange={this.handleCountChange}
          />
        </ContentStatus>
        <Modal type={MODAL_TYPES.vacancyCreation} title="Добавление вакансии">
          <CreationForm />
        </Modal>
      </div>
    );
  }
}

VacanciesList.propTypes = {
  total: PropTypes.number,
  actions: PropTypes.object,
  params: PropTypes.object,
  data: PropTypes.array,
  contentStatus: PropTypes.string,
};

export default connect({
  name: 'vacancies',
  actions: VacanciesViewActions
})(VacanciesList);
