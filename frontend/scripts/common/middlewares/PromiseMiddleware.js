import _ from 'lodash';

function isPromise(value) {
  return value && _.isFunction(value.then);
}

export default ({ dispatch }) => next => action => {
  const { type, payload } = action;

  if (!isPromise(payload)) return next(action);

  const dispatchWithType = data => dispatch({ type, payload: data });

  payload
    .loading(dispatchWithType)
    .then(dispatchWithType)
    .catch(dispatchWithType);
};
