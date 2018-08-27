import LocalStorage, { TOKEN, USER } from 'services/LocalStorageService';

const SessionService = {
  signIn(user, token) {
    LocalStorage.set(TOKEN, token);
    LocalStorage.set(USER, user);
  },

  signOut() {
    LocalStorage.remove(TOKEN);
    LocalStorage.remove(USER);
  }
};

export default SessionService;
