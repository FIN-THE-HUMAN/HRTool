import React from 'react';
import PropTypes from 'prop-types';

import avatar from '../../../images/admin.svg';

const User = ({ firstName, lastName, position, email, phoneNumber }) => (
  <div className="user">
    <img className="avatar" src={avatar} />
    <div className="info">
      <div className="name">
        <div className="last">{lastName}</div>
        <div className="first">{firstName}</div>
      </div>
      <div className="position">{position}</div>
      <div className="email">{email}</div>
      <div className="phone">{phoneNumber}</div>
    </div>
  </div>
);

User.propTypes = {
  firstName: PropTypes.string,
  lastName: PropTypes.string,
  position: PropTypes.string,
  email: PropTypes.string,
  phoneNumber: PropTypes.string
};

export default User;
