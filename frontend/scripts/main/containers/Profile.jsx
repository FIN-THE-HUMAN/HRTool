import React, { Component } from 'react';
import PropTypes from 'prop-types';
import connect from 'decorators/ConnectDecorators';
import UserActions from 'actions/UserActions';

import User from '../components/User';

class Profile extends Component {
  componentDidMount = () => this.props.actions.userGet(this.props.info.id);

  render() {
    const { info } = this.props;

    return (
      <div className="profile">
        <div className="title">Профиль пользователя</div>
        <User {...info} />
      </div>
    );
  }
}

Profile.propTypes = {
  actions: PropTypes.object,
  info: PropTypes.object,
};

export default connect({
  name: 'user',
  actions: UserActions
})(Profile);
