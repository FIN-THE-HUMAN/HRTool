import { createReducer } from 'realt';
import update from 'immutability-helper';
import ModalsActions from 'actions/ModalsActions';

class ModalsReducer {
  constructor() {
    this.bindAction(ModalsActions.modalToggle, this.handleModalToggle);
    this.bindAction(ModalsActions.modalInit, this.handleModalInit);
    this.bindAction(ModalsActions.modalClear, this.handleModalClear);
  }

  get initialState() {
    return {};
  }

  handleModalToggle(state, type) {
    const isOpen = state[type] && state[type].isOpen;

    return update(state, { [type]: { $merge: { isOpen: !isOpen } } });
  }

  handleModalInit(state, type) {
    return update(state, { $merge: { [type]: { isOpen: false } } });
  }

  handleModalClear(state, type) {
    return update(state, { $unset: [type] });
  }
}

export default createReducer(ModalsReducer);
