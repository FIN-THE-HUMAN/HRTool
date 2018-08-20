import { createStore, applyMiddleware } from 'redux';
import { createLogger } from 'redux-logger';

import promiseMiddleware from '../middlewares/PromiseMiddleware';

const configureStore = (reducers, initialState) => createStore(
  reducers,
  initialState,
  applyMiddleware(
    promiseMiddleware,
    createLogger({ collapsed: true })
  )
);

export default configureStore;
