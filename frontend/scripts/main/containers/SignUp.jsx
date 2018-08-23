import React from 'react';
import PropTypes from 'prop-types';
import connect from 'decorators/ConnectDecorators';
import UserActions from 'actions/UserActions';
import { Redirect } from 'components/router';
import { OverlayStatus } from 'components';

import SignUpForm from '../components/SignUpForm';

const SignUp = ({ info, status, actions: { register } }) => {
  if (!info) return (
    <div className="login">
      <OverlayStatus status={status}>
        <h3 className="title">Регистрация</h3>
        <SignUpForm onSubmit={register} />
      </OverlayStatus>
    </div>
  );

  return <Redirect to="/" />;
};

SignUp.propTypes = {
  status: PropTypes.string,
  info: PropTypes.object,
  actions: PropTypes.object,
};

export default connect({
  name: 'user',
  actions: UserActions
})(SignUp);
