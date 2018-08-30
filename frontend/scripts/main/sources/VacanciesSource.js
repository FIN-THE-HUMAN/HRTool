import AjaxService from 'services/AjaxService';
import { API_URL } from 'constants/UrlConstants';

export default {
  getVacancies(query) {
    return AjaxService.get(`${API_URL}/vacancies`, query);
  },

  getVacancy(vacancyId, query) {
    return AjaxService.get(`${API_URL}/vacancies/${vacancyId}`, query);
  },

  createVacancy(query) {
    return AjaxService.post(`${API_URL}/vacancies`, query);
  },

  editVacancy(vacancyId, query) {
    return AjaxService.put(`${API_URL}/vacancies/${vacancyId}`, query);
  },

  removeVacancy(vacancyId) {
    return AjaxService.delete(`${API_URL}/vacancies/${vacancyId}`, null, vacancyId);
  },

  editVacancyStatus(vacancyId, query) {
    return AjaxService.put(`${API_URL}/vacancies/${vacancyId}/status`, query, vacancyId);
  }
};
