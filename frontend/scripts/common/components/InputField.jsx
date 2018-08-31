import React from 'react';
import PropTypes from 'prop-types';
import { Field } from 'react-final-form';
import { FormGroup, HelpBlock, FormControl, ControlLabel, Col, Row } from 'react-bootstrap';

import { composeValidators } from '../utils/ValidationUtils';

const FormControlAdapter = ({ input, meta, size, withIcon, children, ...other }) => {
  if (other.type === 'textarea' || other.type === 'select') {
    other.componentClass = other.type;
    other.type = undefined;
  }

  const error = meta.touched && meta.error ? 'error' : null;
  const labelSize = size && size.labelSize;
  const fieldSize = size && size.fieldSize;

  return (
    <FormGroup controlId={input.name} validationState={error}>
      <Row>
        {other.label &&
          <Col {...labelSize} componentClass={ControlLabel}>
            {other.label}
          </Col>
        }
        <Col {...fieldSize}>
          <FormControl {...input} {...other}>
            {children}
          </FormControl>
          {withIcon && error && <FormControl.Feedback />}
          {error && <HelpBlock>{meta.error}</HelpBlock>}
          {other.help && <HelpBlock>{other.help}</HelpBlock>}
        </Col>
      </Row>
    </FormGroup>
  );
};

FormControlAdapter.propTypes = {
  withIcon: PropTypes.bool,
  type: PropTypes.string,
  input: PropTypes.object,
  meta: PropTypes.object,
  size: PropTypes.object,
  children: PropTypes.node,
};

FormControlAdapter.defaultProps = {
  size: {
    labelSize: { sm: 12 },
    fieldSize: { sm: 12 },
  },
  type: 'text'
};

const InputField = ({ number, validate, ...other }) => {
  if (Array.isArray(validate)) validate = composeValidators(...validate);

  const parseFormat = number && {
    parse: value => value && Number(value),
    format: value => value && value.toString()
  };

  return (
    <Field {...other} {...parseFormat} validate={validate} component={FormControlAdapter} />
  );
};

InputField.propTypes = {
  number: PropTypes.bool,
  validate: PropTypes.oneOfType([
    PropTypes.arrayOf(PropTypes.func),
    PropTypes.func
  ])
};

export default InputField;
