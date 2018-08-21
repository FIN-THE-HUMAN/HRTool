import React from 'react';
import { Redirect, Switch, Route } from 'components/router';

import Layout from './Layout';
import AuthForm from '../components/AuthForm';
import RegForm from '../components/RegForm';
import NotFound from '../components/NotFound';

const App = () => (
  <Layout>
    <Switch>
      <Redirect exact from="/" to="/home" />
      <Route path="/autorisation" component={AuthForm} />
      <Route path="/registration" component={RegForm} />
      <Route path="*" component={NotFound} />
    </Switch>
  </Layout>
);

export default App;
