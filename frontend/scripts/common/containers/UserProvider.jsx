import _ from 'lodash';
import React, { Component } from 'react';
import PropTypes from 'prop-types';
import connect from 'decorators/ConnectDecorators';
import UserActions from 'actions/UserActions';
import { ContentStatus } from 'components';

class UserProvider extends Component {
  getChildContext() {
    const { info } = this.props;

    return {
      role: _.get(info, 'roleName', null)
    };
  }

  componentDidMount = () => {
    const { actions: { userGet }, info } = this.props;

    if (info) userGet(info.id);
  };

  componentWillUnmount = () => this.props.actions.stateClear();

  render() {
    const { contentStatus, children } = this.props;

    return (
      <ContentStatus noMessage status={contentStatus} className="is-page">
        {children}
      </ContentStatus>
    );
  }
}

UserProvider.childContextTypes = {
  role: PropTypes.object
};

UserProvider.propTypes = {
  actions: PropTypes.object,
  info: PropTypes.object,
  status: PropTypes.string,
  children: PropTypes.node
};

export default connect({ name: 'user', actions: UserActions })(UserProvider);
