import LocalStorageService, { TOKEN, USER } from 'services/LocalStorageService';

const SessionService = {
  signIn(user, token) {
    LocalStorageService.set(TOKEN, token);
    LocalStorageService.set(USER, user);
  },

  signOut() {
    LocalStorageService.remove(TOKEN);
    LocalStorageService.remove(USER);
  }
};

export default SessionService;
