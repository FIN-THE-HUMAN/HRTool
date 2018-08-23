import { combineReducers } from 'redux';

import UserReducer from 'reducers/UserReducer';
import ModalsReducer from 'reducers/ModalsReducer';

const rootReducer = combineReducers({
  user: UserReducer,
  modal: ModalsReducer,
});

export default rootReducer;
