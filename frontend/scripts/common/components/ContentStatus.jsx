import React from 'react';
import PropTypes from 'prop-types';
import Status from 'constants/StatusConstants';

import Loader from './Loader';

const ContentStatus = ({ noMessage, status, className, children }) => {
  if (status === Status.SUCCESS || status === Status.DEFAULT) {
    return children;
  }

  return (
    <Loader noMessage className={className} status={status} />
  );
};

ContentStatus.propTypes = {
  noMessage: PropTypes.bool,
  status: PropTypes.string,
  className: PropTypes.string,
  children: PropTypes.node,
};

ContentStatus.defaultProps = {
  status: Status.DEFAULT,
};

export default ContentStatus;
