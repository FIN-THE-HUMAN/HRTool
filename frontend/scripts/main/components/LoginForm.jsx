import React from 'react';
import PropTypes from 'prop-types';
import { Form } from 'react-final-form';
import { Button } from 'react-bootstrap';
import { Field } from 'components';
import { Link } from 'components/router';
import { required } from 'utils/ValidationRules';

const LoginForm = ({ onSubmit, onCancel }) => (
  <Form
    onSubmit={onSubmit}
    render={({ handleSubmit, form }) => (
      <form className="login-form" onSubmit={handleSubmit}>
        <Field name="email" type="email" label="E-mail" placeholder="example@gmail.com" validate={required} />
        <Field name="password" type="password" label="Пароль" placeholder="Введите пароль" validate={required} />
        <Button block bsStyle="primary" type="submit">
          Войти
        </Button>
        <Link className="register" to="/signup" onClick={onCancel}>
          Зарегистрироваться
        </Link>
      </form>
    )}
  />
);

LoginForm.propTypes = {
  onSubmit: PropTypes.func,
  onCancel: PropTypes.func
};

export default LoginForm;
