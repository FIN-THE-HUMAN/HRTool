import React from 'react';
import PropTypes from 'prop-types';
import { AsyncCreatable } from 'react-select';
import { Field } from 'react-final-form';
import { Row, Col, ControlLabel, FormGroup } from 'react-bootstrap';

const FormatInput = input => input && input.map(({ id, name }) => ({ value: id, label: name }));

const FormatOutput = output => output && output.map(({ value, label }) => ({ id: value, name: label }));

const AsyncCreatableMultiSelect = ({ input: { value, onChange }, label, size, onCreate, onLoad }) => {
  const labelSize = size && size.labelSize;
  const fieldSize = size && size.fieldSize;

  return (
    <Row componentClass={FormGroup}>
      {label &&
        <Col {...labelSize} componentClass={ControlLabel}>
          {label}
        </Col>
      }
      <Col {...fieldSize}>
        <AsyncCreatable
          isMulti
          value={FormatInput(value)}
          placeholder="Выберете значения"
          loadingMessage={() => 'Загрузка...'}
          noOptionsMessage={() => 'Начните вводить название.'}
          formatCreateLabel={val => `Создать ${val}.`}
          onChange={val => onChange(FormatOutput(val))}
          onCreateOption={onCreate}
          loadOptions={onLoad}
          styles={{
            control: styles => ({ ...styles, backgroundColor: 'white', overflow: 'hidden' }),
            valueContainer: styles => ({ ...styles, maxWidth: '100%' })
          }}
        />
      </Col>
    </Row>
  );
};

AsyncCreatableMultiSelect.propTypes = {
  label: PropTypes.string,
  input: PropTypes.object,
  onCreate: PropTypes.func,
  onLoad: PropTypes.func,
};

const AsyncCreatableMultiSelectAdapter = props => (
  <Field {...props} component={AsyncCreatableMultiSelect} />
);

export default AsyncCreatableMultiSelectAdapter;
