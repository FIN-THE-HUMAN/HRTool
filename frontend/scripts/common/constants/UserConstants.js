import Status from 'constants/StatusConstants';

import LocalStorage from '../services/LocalStorageService';

const user = LocalStorage.get('user');

export const USER_INITIAL_STATE = {
  status: Status.DEFAULT,
  contentStatus: user ? Status.LOADING : Status.DEFAULT,
  info: user
};
