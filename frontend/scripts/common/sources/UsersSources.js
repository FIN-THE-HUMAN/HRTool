import AjaxService from 'services/AjaxService';
import { API_URL } from 'constants/UrlConstants';

export default {
  getUser(userId) {
    return AjaxService.get(`${API_URL}/account/${userId}`);
  },

  signIn(query) {
    return AjaxService.post(`${API_URL}/account/login`, query);
  },

  register(query) {
    return AjaxService.post(`${API_URL}/account/register`, query);
  }
};
