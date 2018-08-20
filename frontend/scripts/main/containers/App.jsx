import React from 'react';
import { Redirect, Switch, Route } from 'components/router';

import Layout from './Layout';
import NotFound from '../components/NotFound';

const App = () => (
  <Layout>
    <Switch>
      <Redirect exact from="/" to="/home" />
      <Route path="*" component={NotFound} />
    </Switch>
  </Layout>
);

export default App;
