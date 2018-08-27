export const Type = {
  POST: 'POST',
  GET: 'GET',
  PUT: 'PUT',
  DELETE: 'DELETE',
};

export const AXIOS_CONFIG = ({ method, url, query, headers }) => ({
  url,
  method,
  [method === Type.GET || method === Type.DELETE ? 'params' : 'data']: query,
  headers: {
    'content-type': 'application/json',
    ...headers
  }
});
