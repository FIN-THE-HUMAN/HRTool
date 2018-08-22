import AjaxService from 'services/AjaxService';
import { API_URL } from 'constants/UrlConstants';

export default {
  getUser(userGuid) {
    return AjaxService.get(`${API_URL}/users/${userGuid}`);
  }
};
