import React from 'react';
import PropTypes from 'prop-types';
import SessionService from 'services/SessionService';
import WindowService from 'services/WindowService';
import { DropdownButton, MenuItem } from 'react-bootstrap';

import avatar from '../../../images/avatar.svg';

const UserInfo = ({ user }) => {
  const onLogout = () => {
    SessionService.signOut();
    WindowService.redirect(WindowService.location);
  };

  return (
    <div className="user-info">
      <DropdownButton
        pullRight
        bsStyle="link"
        title={
          <span>
            <img className="avatar" src={avatar} />
            {user.firstName}
          </span>
        }
        id="user-info"
      >
        <MenuItem header>{user.lastName} {user.firstName}</MenuItem>
        <MenuItem eventKey="2">Профиль</MenuItem>
        <MenuItem eventKey="3">Настройки</MenuItem>
        <MenuItem divider />
        <MenuItem eventKey="4" onClick={onLogout}>Выйти</MenuItem>
      </DropdownButton>
    </div>
  );
};

UserInfo.propTypes = {
  user: PropTypes.object
};

export default UserInfo;


