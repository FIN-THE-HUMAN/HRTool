import React from 'react';
import { Redirect, Switch, Route } from 'components/router';
import UserProvider from 'containers/UserProvider';

import Layout from './Layout';
import UserProfile from './Profile';
import Login from './Login';
import SignUp from './SignUp';
import NotFound from '../components/NotFound';

const App = () => (
  <UserProvider>
    <Layout>
      <Switch>
        <Redirect exact from="/" to="/home" />
        <Route path="/login" component={Login} />
        <Route path="/signup" component={SignUp} />
        <Route path="/profile" component={UserProfile} />
        <Route path="*" component={NotFound} />
      </Switch>
    </Layout>
  </UserProvider>
);

export default App;
