import { createReducer } from 'realt';
import update from 'immutability-helper';
import UserActions from 'actions/UserActions';
import { USER_INITIAL_STATE } from 'constants/UserConstants';

class UserReducer {
  constructor() {
    this.bindAction(UserActions.stateClear, () => this.initialState);
    this.bindAction(UserActions.userGetCallback, this.handleUserGet);
    this.bindAction(UserActions.logOut, this.handleLogOut);
    this.bindAction(UserActions.signInCallback, this.handleSignIn);
    this.bindAction(UserActions.registerCallback, this.handleRegister);
  }

  get initialState() {
    return USER_INITIAL_STATE;
  }

  handleUserGet(state, { isSuccess, status, response }) {
    if (!isSuccess) return update(state, { $merge: { status } });

    return update(state, { $merge: { contentStatus: status, info: response } });
  }

  handleSignIn(state, { isError, status, response }) {
    if (isError) {
      return update(state, { $merge: { status, error: response.message } });
    }

    return update(state, { $merge: { status } });
  }

  handleLogOut(state) {
    return update(state, { $merge: { info: {} } });
  }

  handleRegister(state, { isError, status, response }) {
    if (isError) {
      return update(state, { $merge: { status, error: response.message } });
    }

    return update(state, { $merge: { status } });
  }
}

export default createReducer(UserReducer, 'user');
