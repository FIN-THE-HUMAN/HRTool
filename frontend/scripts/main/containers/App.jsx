import React from 'react';
import PropTypes from 'prop-types';
import { withRouter } from 'react-router-dom';
import { Redirect, Switch, Route } from 'components/router';
import { UserProvider } from 'containers';
import connect from 'decorators/ConnectDecorators';

import Layout from './Layout';
import UserProfile from './Profile';
import Login from './Login';
import SignUp from './SignUp';
import VacanciesView from './vacancies/View';
import SingleVacancy from './vacancies/Single';
import NotFound from '../components/NotFound';

const App = ({ info }) => (
  <UserProvider>
    <Layout>
      <Switch>
        <Redirect exact from="/" to="/vacancies" />
        <Route path="/login" component={Login} />
        <Route path="/signup" component={SignUp} />
        {!info && <Redirect to="/login" />}
        <Route path="/profile" component={UserProfile} />
        <Route path="/vacancies" component={VacanciesView} />
        <Route path="/vacancy/:id" component={SingleVacancy} />
        <Route path="*" component={NotFound} />
      </Switch>
    </Layout>
  </UserProvider>
);

App.propTypes = {
  info: PropTypes.object
};

export default withRouter(connect({ name: 'user' })(App));
