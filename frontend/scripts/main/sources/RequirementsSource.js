import AjaxService from 'services/AjaxService';
import { API_URL } from 'constants/UrlConstants';

export default {
  getRequirements(query) {
    return AjaxService.get(`${API_URL}/requirements`, query);
  },

  createRequirement(query) {
    return AjaxService.post(`${API_URL}/requirements`, query);
  },
};
