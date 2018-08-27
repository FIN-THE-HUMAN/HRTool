import React from 'react';
import PropTypes from 'prop-types';
import { withRouter } from 'react-router-dom';
import { MenuItem } from 'react-bootstrap';

const DropdownMenuItemLink = ({ to, children, history, match, location, staticContext, ...rest }) => (
  <MenuItem
    {...rest}
    href={to}
    onClick={event => {
      event.preventDefault();
      history.push(to);
    }}
  >
    {children}
  </MenuItem>
);

DropdownMenuItemLink.propTypes = {
  to: PropTypes.string,
  history: PropTypes.object,
  children: PropTypes.node,
};

export default withRouter(DropdownMenuItemLink);
