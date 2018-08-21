import React from 'react';
import { Link } from 'components/router';

const MainLinksNotFound = () => (
  <div className="not-found">
    <h2 className="not-found__h2">К сожалению мы не смогли найти запрашиваемую страницу</h2>
    <video autoPlay loop src="https://media.giphy.com/media/xTiN0L7EW5trfOvEk0/giphy.mp4"></video>
    <p className="not-found__p">Попробуйте начать с <Link to="/">главной страницы</Link></p>
  </div>
);


export default MainLinksNotFound;
