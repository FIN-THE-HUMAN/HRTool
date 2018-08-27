import React from 'react';
import PropTypes from 'prop-types';
import SessionService from 'services/SessionService';
import WindowService from 'services/WindowService';
import { DropdownButton, MenuItem } from 'react-bootstrap';
import { DropdownMenuItemLink } from 'components';

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
        <DropdownMenuItemLink eventKey="2" to="/profile">Профиль</DropdownMenuItemLink>
        <DropdownMenuItemLink eventKey="3" to="/settings">Настройки</DropdownMenuItemLink>
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
