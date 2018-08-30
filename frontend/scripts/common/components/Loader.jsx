import classNames from 'classnames';
import React from 'react';
import PropTypes from 'prop-types';
import Status from 'constants/StatusConstants';

const defineIcon = status => {
  switch (status) {
    case Status.SUCCESS:
      return 'success';
    case Status.ERROR:
      return 'error';
    case Status.NO_RESULTS:
    default:
      return 'no-result';
  }
};

const defineMessage = status => {
  switch (status) {
    case Status.SUCCESS:
      return 'Успешно';
    case Status.ERROR:
      return 'Ошибка сервера';
    case Status.NO_RESULTS:
      return 'Нет данных';
    default:
      return 'Загрузка...';
  }
};

const Loader = ({ noMessage, message, status, className }) => (
  <div className={classNames('loader', className)} data-status={status}>
    {status === Status.LOADING
      ? <div className="spinner" />
      : <div className={classNames('icon', defineIcon(status))} />
    }
    {noMessage || <div className="message">{message || defineMessage(status)}</div>}
  </div>
);

Loader.propTypes = {
  noMessage: PropTypes.bool,
  status: PropTypes.string,
  className: PropTypes.string,
  message: PropTypes.string
};

Loader.defaultProps = {
  status: Status.DEFAULT,
};

export default Loader;
