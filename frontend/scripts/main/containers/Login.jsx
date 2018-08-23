import React from 'react';
import PropTypes from 'prop-types';
import connect from 'decorators/ConnectDecorators';
import UserActions from 'actions/UserActions';
import { Redirect } from 'components/router';
import { OverlayStatus } from 'components';

import LoginForm from '../components/LoginForm';

const Login = ({ info, status, actions: { signIn } }) => {
  if (!info) return (
    <div className="login">
      <OverlayStatus status={status}>
        <h3 className="title">Авторизация</h3>
        <LoginForm onSubmit={signIn} />
      </OverlayStatus>
    </div>
  );

  return <Redirect to="/" />;
};

Login.propTypes = {
  status: PropTypes.string,
  info: PropTypes.object,
  actions: PropTypes.object,
};

export default connect({
  name: 'user',
  actions: UserActions
})(Login);
