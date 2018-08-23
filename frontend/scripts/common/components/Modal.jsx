import React from 'react';
import PropTypes from 'prop-types';
import Container, { Header, Title, Body, Footer } from 'react-bootstrap/lib/Modal';

const Modal = ({ isOpen, title, className, children, footer, onToggle, ...others }) => (
  <Container {...others} show={isOpen} className={className} onHide={onToggle}>
    <Header closeButton>
      {title ? <Title>{title}</Title> : null}
    </Header>
    <Body>
    {children}
    </Body>
    {footer ? <Footer>{footer}</Footer> : null}
  </Container>
);

Modal.propTypes = {
  isOpen: PropTypes.bool,
  className: PropTypes.string,
  title: PropTypes.string,
  children: PropTypes.node,
  footer: PropTypes.element,
  onToggle: PropTypes.func
};

export default Modal;
