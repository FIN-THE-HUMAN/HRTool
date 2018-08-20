import React from 'react';
import { Link } from 'components/router';

import notFoundImg from '../../../images/404.jpg';

const MainLinksNotFound = () => (
  <div className="main-not-found">
    <h2>К сожалению мы не смогли найти запрашиваемую страницу</h2>
    <div>
      Так уж получилось, что из множества страниц нашего сайта Вы оказались как раз на той, которая уже не существует...
    </div>
    <img src={notFoundImg} alt="404" height={404} />
    <div>
      Попробуйте начать с <Link to="/">главной страницы</Link>
    </div>
  </div>
);

export default MainLinksNotFound;
