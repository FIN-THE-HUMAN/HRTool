const LocalStorage = {
  set(key, value) {
    localStorage.setItem(key, JSON.stringify(value));
  },

  get(key) {
    return JSON.parse(localStorage.getItem(key)) || undefined;
  },

  remove(key) {
    localStorage.removeItem(key);
  }
};

const TOKEN = 'token';
const USER = 'user';

export { LocalStorage as default, TOKEN, USER };
