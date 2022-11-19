import React from 'react';
import { useDispatch } from 'react-redux';
import { togglePopup } from '../store/popupSlice';
import { Link } from 'react-router-dom';

const NavAuth = () => {
  const dispatch = useDispatch();
  const toggleSignInPopup = () => dispatch(togglePopup('signIn'));
  const toggleSignUpPopup = () => dispatch(togglePopup('signUp'));

  return (
    <div className='nav_auth'>
      <a className='nav_item' onClick={toggleSignInPopup}>
        Войти
      </a>
      <span className='sep'></span>
      <a className='nav_item' onClick={toggleSignUpPopup}>
        Зарегистрироваться
      </a>
    </div>
  );
};

export default NavAuth;
