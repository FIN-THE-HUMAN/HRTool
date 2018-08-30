import AjaxService from 'services/AjaxService';
import { API_URL } from 'constants/UrlConstants';

export default {
  getDuties(query) {
    return AjaxService.get(`${API_URL}/duties`, query);
  },

  createDuty(query) {
    return AjaxService.post(`${API_URL}/duties`, query);
  },
};
