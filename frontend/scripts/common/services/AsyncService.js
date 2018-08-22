import _ from 'lodash';
import Status from 'constants/StatusConstants';

class AsyncService {
  loading(query, response, data, promise) {
    return callback => {
      callback(_.assign(this.baseModel(Status.LOADING, query, response, data), { isLoading: true }));

      return promise;
    };
  }

  success(query, response, data) {
    return _.assign(this.baseModel(Status.SUCCESS, query, response, data), { isSuccess: true });
  }

  error(query, response, data) {
    return _.assign(this.baseModel(Status.ERROR, query, response, data), { isError: true });
  }

  baseModel(status, query, response, data) {
    return {
      status,
      query: query || null,
      response: response || null,
      data: data || null
    };
  }
}

export default AsyncService;

