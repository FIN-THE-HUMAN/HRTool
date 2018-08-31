import React from 'react';
import PropTypes from 'prop-types';
import { Form } from 'react-final-form';
import { Button, Col, ControlLabel, Row, Well } from 'react-bootstrap';
import { AsyncCreatableMultiSelect, Field } from 'components';
import { positiveNumber, required } from 'utils/ValidationRules';
import { CreateDuty, CreateRequirement, LoadDuties, LoadRequirements } from '../utils/VacanciesUtils';

import { BranchOffices, Departures, EmploymentTypes } from '../constants/EnumsConstants';

const size = {
  labelSize: { sm: 3 },
  fieldSize: { sm: 9 },
};

const VacancyForm = ({ initialValues, onSubmit, onCancel }) => (
  <Form
    keepDirtyOnReinitialize
    onSubmit={onSubmit}
    initialValues={initialValues || {
      duties: [],
      requirements: [],
      additionalRequirements: [],
    }}
    render={({ handleSubmit, form }) => (
      <form className="vacancy-creation-form" onSubmit={handleSubmit}>
        <Well>
          <Field name="name" label="Название" placeholder="Название..." size={size} validate={required} />
          <Field name="departureName" type="select" label="Отдел" size={size} validate={required}>
            <option disabled hidden value="" />
            {Departures.map(({ value, name }) => (
              <option key={value} value={name}>{name}</option>
            ))}
          </Field>
          <Row>
            <Col sm={3} componentClass={ControlLabel}>
              Зарплата
            </Col>
            <Col sm={4}>
              <Field name="salaryRangeFrom" placeholder="От" validate={positiveNumber} />
            </Col>
            <Col sm={1} />
            <Col sm={4}>
              <Field name="salaryRangeTo" placeholder="До" validate={positiveNumber} />
            </Col>
          </Row>
          <Field name="requiredExperienceRange" label="Требуемый опыт работы" placeholder="1 год" size={size} validate={required} />
        </Well>
        <Well>
          <div className="block-title">Контактное лицо</div>
          <Field name="contactPerson" label="Имя" placeholder="Иван Иванович" size={size} validate={required} />
          <Field name="contactMail" label="Эл. почта" placeholder="example@gmaol.com" size={size} validate={required} />
          <Field name="contactPhone" label="Телефон" placeholder="+7 123 45 67" size={size} validate={required} />
        </Well>
        <Well>
          <Field name="description" type="textarea" label="Описание" placeholder="Описание вакансии" size={size} validate={required} />
          <Field name="employmentType" type="select" label="Тип занятости" size={size} validate={required}>
            <option disabled hidden value="" />
            {EmploymentTypes.map(({ value, name }) => (
              <option key={value} value={name}>{name}</option>
            ))}
          </Field>
          <Field name="workHours" label="График работы" placeholder="Полный рабочий день" size={size} validate={required} />
          <AsyncCreatableMultiSelect
            name="duties"
            label="Обязанности"
            size={size}
            onCreate={CreateDuty}
            onLoad={LoadDuties}
          />
          <AsyncCreatableMultiSelect
            name="requirements"
            label="Требования"
            size={size}
            onCreate={CreateRequirement}
            onLoad={LoadRequirements}
          />
          <AsyncCreatableMultiSelect
            name="additionalRequirements"
            label="Доп. требования"
            size={size}
            onCreate={CreateRequirement}
            onLoad={LoadRequirements}
          />
        </Well>
        <Well>
          <Field name="holderName" label="Разместитель" placeholder="Иванов Иван" size={size} validate={required} />
          <Field name="branchOfficeCity" type="select" label="Город" size={size} validate={required}>
            <option disabled hidden value="" />
            {BranchOffices.map(({ value, name }) => (
              <option key={value} value={name}>{name}</option>
            ))}
          </Field>
        </Well>
        <div className="controls">
          <Button bsStyle="link" onClick={onCancel}>
            Отмена
          </Button>
          <Button bsStyle="primary" type="submit">
            Добавить
          </Button>
        </div>
      </form>
    )}
  />
);

VacancyForm.propTypes = {
  initialValues: PropTypes.object,
  onSubmit: PropTypes.func,
  onCancel: PropTypes.func
};

export default VacancyForm;
