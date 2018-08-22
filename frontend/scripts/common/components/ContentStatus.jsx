import React from 'react';
import PropTypes from 'prop-types';
import Status from 'constants/StatusConstants';

import Loader from './Loader';

const ContentState = ({ noMessage, status, className, children }) => {
  if (status === Status.SUCCESS || status === Status.DEFAULT) {
    return children;
  }

  return (
    <Loader noMessage className={className} status={status} />
  );
};

ContentState.propTypes = {
  noMessage: PropTypes.bool,
  status: PropTypes.string,
  className: PropTypes.string,
  children: PropTypes.node,
};

ContentState.defaultProps = {
  status: Status.DEFAULT,
};

export default ContentState;
