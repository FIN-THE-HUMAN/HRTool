import React from 'react';
import { Link } from 'components/router';

import notFound from '../../../images/404.png';

const MainLinksNotFound = () => (
  <div className="not-found">
    <h2>Страница не найдена</h2>
    <img src={notFound} />
    <Link to="/">На главную страницу</Link>
  </div>
);

export default MainLinksNotFound;
