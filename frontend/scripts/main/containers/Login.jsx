import React, { Component } from 'react';
import PropTypes from 'prop-types';
import connect from 'decorators/ConnectDecorators';
import UserActions from 'actions/UserActions';
import { Redirect } from 'components/router';

import LoginForm from '../components/LoginForm'

class Login extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    const { info } = this.props;
    const { signIn } = this.props.actions;

    if (!info)
      return (
        <div className="login">
          <h3 className="title">Авторизация</h3>
          <LoginForm onSubmit={signIn} />
        </div>
      );

    return <Redirect to="/" />
  }
}


Login.propTypes = {
  info: PropTypes.object,
};

export default connect({
  name: 'user',
  actions: UserActions
})(Login);
