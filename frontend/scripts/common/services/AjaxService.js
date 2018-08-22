import axios from 'axios';
import LocalStorage from '../services/LocalStorageService';
import { Type, AXIOS_CONFIG } from 'constants/AjaxConstants';

import AsyncService from './AsyncService';

class AjaxService extends AsyncService {
  post(url, query, data, options) {
    return this.request(Type.POST, url, query, data, options);
  }

  get(url, query, data, options) {
    return this.request(Type.GET, url, query, data, options);
  }

  delete(url, query, data, options) {
    return this.request(Type.DELETE, url, query, data, options);
  }

  put(url, query, data, options) {
    return this.request(Type.PUT, url, query, data, options);
  }

  request(method, url, query, data, options) {
    const jwt = LocalStorage.get('token');
    const headers = { Authorization: (jwt ? `Bearer ${jwt}` : null) };

    const promise = new Promise((resolve, reject) => {
      axios(AXIOS_CONFIG({ method, url, query, headers, ...options }))
        .then(response => resolve(this.success(query, response.data, data)))
        .catch(error => reject(this.error(query, error.response ? error.response.data : error, data)));
    });

    promise.loading = this.loading(query, null, data, promise);

    return promise;
  }
}

export default new AjaxService();
