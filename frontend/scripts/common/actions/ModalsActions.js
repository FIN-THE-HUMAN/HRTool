import { createActions } from 'realt';

class ModalsActions {
  constructor() {
    this.generate(
      'modalToggle',
      'modalInit',
      'modalClear'
    );
  }
}

export default createActions(ModalsActions);
