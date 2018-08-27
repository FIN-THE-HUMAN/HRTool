import _ from 'lodash';
import React, { Component } from 'react';
import PropTypes from 'prop-types';
import connect from 'decorators/ConnectDecorators';
import ModalsActions from 'actions/ModalsActions';
import Modal from 'components/Modal';

class ModalContainer extends Component {
  constructor(props) {
    super(props);

    const { type, actions: { modalToggle, modalInit, modalClear } } = props;

    this.componentDidMount = () => modalInit(type);

    this.componentWillUnmount = () => modalClear(type);

    this.onToggle = () => modalToggle(type);
  }

  render() {
    const { children, ...props } = this.props;

    return (
      <Modal
        {...props}
        backdrop
        onToggle={this.onToggle}
      >
        {children}
      </Modal>
    );
  }
}

ModalContainer.propTypes = {
  children: PropTypes.node.isRequired,
  actions: PropTypes.object.isRequired,
  type: PropTypes.string.isRequired
};

export default connect({
  mapStateToProps: ({ modal }, props) => ({ ..._.get(modal, props.type, false) }),
  actions: ModalsActions
})(ModalContainer);
