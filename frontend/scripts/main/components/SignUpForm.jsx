import React from 'react';
import PropTypes from 'prop-types';
import { Form } from 'react-final-form';
import { Button } from 'react-bootstrap';
import { Field } from 'components';
import { required } from 'utils/ValidationRules';

const LoginForm = ({ onSubmit }) => (
  <Form
    onSubmit={onSubmit}
    render={({ handleSubmit, form }) => (
      <form className="login-form" onSubmit={handleSubmit}>
        <Field name="lastName" type="text" label="Фамилия" placeholder="Иванов" validate={required} />
        <Field name="firstName" type="text" label="Имя" placeholder="Иван" validate={required} />
        <Field name="email" type="email" label="E-mail" placeholder="example@gmail.com" validate={required} />
        <Field name="password" type="password" label="Пароль" placeholder="Введите пароль" validate={required} />
        <Button block bsStyle="primary" type="submit">
          Зарегистрироваться
        </Button>
      </form>
    )}
  />
);

LoginForm.propTypes = {
  onSubmit: PropTypes.func
};

export default LoginForm;
