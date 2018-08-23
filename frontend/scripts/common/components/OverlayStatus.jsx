import classNames from 'classnames';
import React from 'react';
import PropTypes from 'prop-types';
import Status from 'constants/StatusConstants';

import Loader from './Loader';

const OverlayStatus = ({ status, children, black, ...other }) => {
  if (!status || status === Status.DEFAULT) {
    return children;
  }

  return (
    <div className={classNames('overlay-status', { black })} data-status={status}>
      {children}
      <div className="overlay">
        <Loader {...other} status={status} />
      </div>
    </div>
  );
};

OverlayStatus.propTypes = {
  status: PropTypes.string,
  children: PropTypes.node,
};

OverlayStatus.defaultProps = {
  status: Status.DEFAULT,
};

export default OverlayStatus;
