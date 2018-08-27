import { createActions } from 'realt';
import UsersSources from 'sources/UsersSources';
import Status from 'constants/StatusConstants';
import SessionService from 'services/SessionService';
import WindowService from 'services/WindowService';

class UserActions {
  constructor() {
    this.generate(
      'stateClear',
      'logOut',
      'userGetCallback',
      'signInCallback',
      'registerCallback'
    );
  }

  userGet(query) {
    return dispatch => {
      UsersSources.getUser(query)
        .loading(result => dispatch(this.userGetCallback(result)))
        .then(result => {
          SessionService.setUser(result.response);
          dispatch(this.userGetCallback(result));
        })
        .catch(result => {
          dispatch(this.userGetCallback(result));
        });
    };
  }

  signIn(query) {
    return dispatch => {
      UsersSources.signIn(query)
        .loading(result => dispatch(this.signInCallback(result)))
        .then(result => {
          const { token, user } = result.response;

          SessionService.signIn(user, token);
          dispatch(this.signInCallback(result));

          setTimeout(() => WindowService.redirect(WindowService.location), 1000);
        })
        .catch(result => {
          dispatch(this.signInCallback(result));

          setTimeout(() => dispatch(this.signInCallback({ status: Status.DEFAULT })), 1000);
        });
    };
  }

  register(query) {
    return dispatch => {
      UsersSources.register(query)
        .loading(result => dispatch(this.registerCallback(result)))
        .then(result => {
          dispatch(this.registerCallback(result));

          setTimeout(() => WindowService.redirect('/login'), 1000);
        })
        .catch(result => {
          dispatch(this.registerCallback(result));

          setTimeout(() => dispatch(this.registerCallback({ status: Status.DEFAULT })), 1000);
        });
    };
  }
}

export default createActions(UserActions, 'user');
