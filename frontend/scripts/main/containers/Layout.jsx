import React, { Component } from 'react';
import PropTypes from 'prop-types';
import connect from 'decorators/ConnectDecorators';
import { Link } from 'components/router';
import { Button } from 'react-bootstrap';
import ModalsActions from 'actions/ModalsActions';
import UserActions from 'actions/UserActions';
import { Modal } from 'containers';
import { OverlayStatus } from 'components';

import { MODAL_TYPES } from '../constants/ModalsConstants';
import UserInfo from '../components/UserInfo';
import LoginForm from '../components/LoginForm';
import logo from '../../../images/logo.png';

class Layout extends Component {
  handleSignInModalToggle = () => this.props.actions.modalToggle(MODAL_TYPES.signIn);

  render() {
    const { info, children, status } = this.props;
    const { signIn } = this.props.actions;

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
          {info ?
            <UserInfo user={info} /> :
            <Button className="log-in" onClick={this.handleSignInModalToggle}>
              Войти
            </Button>
          }
        </div>
        <div className="layout-content">
          {children}
        </div>
        <div className="footer">
          <div className="copyright">© 2018, ЗАО «Калуга Астрал»</div>
        </div>
        <Modal type={MODAL_TYPES.signIn} title="Авторизация" bsSize="small">
          <OverlayStatus status={status}>
            <LoginForm onSubmit={signIn} onCancel={this.handleSignInModalToggle} />
          </OverlayStatus>
        </Modal>
      </div>
    );
  }
}

Layout.propTypes = {
  status: PropTypes.string,
  info: PropTypes.object,
  children: PropTypes.node,
  actions: PropTypes.object,
};

export default connect({
  name: ['user', 'modal'],
  actions: { ...ModalsActions, ...UserActions }
})(Layout);
