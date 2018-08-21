import React from 'react';
import { Link } from 'components/router';
import { FormGroup, ControlLabel, FormControl, Button } from 'react-bootstrap';

const AuthForm = () => (
  <div className="auth-form">
    <h1 className="auth-form__header">Вход</h1>
    <form className="auth-form__form">
      <FormGroup>
        <ControlLabel>Email</ControlLabel>
        <FormControl
          type="email"
          placeholder="Введите email"
        />
      </FormGroup>
      <FormGroup>
        <ControlLabel>Пароль</ControlLabel>
        <FormControl
          type="password"
          placeholder="Введите пароль"
        />
        <FormControl.Feedback />
      </FormGroup>
      <Button bsStyle="success" className="submit-button auth-form__submit-button" type="submit">Войти</Button>
    </form>
    <p className="help-text"><Link to="/registration">Зарегистрируйтесь</Link> если у Вас еще нет аккаунта</p>
  </div>
);

export default AuthForm;
