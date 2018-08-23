import React from 'react';
import PropTypes from 'prop-types';
import Status from 'constants/StatusConstants';

import Loader from './Loader';

const ContentStatus = ({ status, children, ...other }) => {
  if (status === Status.SUCCESS || status === Status.DEFAULT) {
    return children;
  }

  return (
    <Loader {...other} status={status} />
  );
};

ContentStatus.propTypes = {
  status: PropTypes.string,
  children: PropTypes.node,
};

ContentStatus.defaultProps = {
  status: Status.DEFAULT,
};

export default ContentStatus;
