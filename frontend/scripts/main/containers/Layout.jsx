import React, { Component } from 'react';
import PropTypes from 'prop-types';
import connect from 'decorators/ConnectDecorators';
import { Link } from 'components/router';

import UserInfo from '../components/UserInfo';
import logo from '../../../images/logo.png';

class Layout extends Component {
  render() {
    const { info, children } = this.props;

    return (
      <div className="layout">
        <div className="header">
          <Link to="/">
            <img src={logo} alt="" className="logo" />
          </Link>
          <ul className="nav-links">
            <li className="nav-item">
              <Link className="nav-link" to="/vacancies">Вакансии</Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/resumes">Резюме</Link>
            </li>
          </ul>
          <UserInfo user={info} />
        </div>
        {children}
        <div className="footer">
          <div className="copyright">© 2018, ЗАО «Калуга Астрал»</div>
        </div>
      </div>
    );
  }
}

Layout.propTypes = {
  info: PropTypes.object,
  children: PropTypes.node,
};

export default connect({ name: 'user' })(Layout);
