import React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import configureStore from 'store';

import reducers from './reducers';
import App from './containers/App';

import '../../styles/common/index.scss';
import '../../styles/main/index.scss';

import '../../images/favicon.ico';
import '../../images/favicon-16x16.png';
import '../../images/favicon-32x32.png';

render((
  <Provider store={configureStore(reducers)}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </Provider>
), document.getElementById('root'));
