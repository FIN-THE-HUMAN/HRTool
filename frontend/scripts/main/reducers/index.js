import { combineReducers } from 'redux';

import UserReducer from 'reducers/UserReducer';
import ModalsReducer from 'reducers/ModalsReducer';

import VacanciesSingleReducer from './vacancies/SingleReducer';
import VacanciesViewReducer from './vacancies/ViewReducer';
import VacanciesCreationReducer from './vacancies/CreationReducer';
import VacanciesEditingReducer from './vacancies/EditingReducer';

const rootReducer = combineReducers({
  user: UserReducer,
  modal: ModalsReducer,

  vacancy: VacanciesSingleReducer,
  vacancies: VacanciesViewReducer,
  vacancyCreation: VacanciesCreationReducer,
  vacancyEditing: VacanciesEditingReducer,
});

export default rootReducer;
