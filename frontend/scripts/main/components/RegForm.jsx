import React from 'react';
import { FormGroup, ControlLabel, FormControl, Button } from 'react-bootstrap';

const RegForm = () => (
  <div className="auth-form">
    <h1 className="auth-form__header">Регистрация</h1>
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
      <FormGroup>
        <ControlLabel>Пароль еще раз</ControlLabel>
        <FormControl
          type="password"
          placeholder="Введите пароль"
        />
        <FormControl.Feedback />
      </FormGroup>
      <Button bsStyle="success" className="submit-button auth-form__submit-button" type="submit">Войти</Button>
    </form>
  </div>
);

export default RegForm;
