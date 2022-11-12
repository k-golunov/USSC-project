import React from 'react';
import usscLogo from '../img/ussc_logo.svg';
import cross from '../img/cross.svg';
import udvLogo from '../img/udv_logo.png';

const NavLogo = () => {
  return (
    <div className='nav_logo'>
      <a href='https://www.ussc.ru/'>
        <img src={usscLogo} alt='' />
      </a>
      <img src={cross} alt='' className='logo_cross' />
      <a href='https://udv.dev/'>
        <img src={udvLogo} alt='' className='udv_logo' />
      </a>
    </div>
  );
};

export default NavLogo;
