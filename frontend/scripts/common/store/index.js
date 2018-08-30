import { createStore, applyMiddleware } from 'redux';
import thunkMiddleware from 'redux-thunk-fsa';
import { createLogger } from 'redux-logger';

import promiseMiddleware from '../middlewares/PromiseMiddleware';

const configureStore = (reducers, initialState) => createStore(
  reducers,
  initialState,
  applyMiddleware(
    thunkMiddleware,
    promiseMiddleware,
    createLogger({ collapsed: true })
  )
);

export default configureStore;
