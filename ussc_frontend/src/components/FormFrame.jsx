import React from 'react';
import { Link } from 'react-router-dom';
import NavLogo from './NavLogo';

const FormFrame = ({ children, title, linkTo, linkText }) => {
  return (
    <div className='form_frame'>
      <div className='formframe_head'>
        <NavLogo />
      </div>
      <div className='formframe_body'>
        <div className='formframe_title_wrapper'>
          <p className='formframe_title'>{title}</p>
          {linkTo && linkText ? (
            <Link to={linkTo} className='link'>
              {linkText}
            </Link>
          ) : (
            <></>
          )}
        </div>
        {children}
      </div>
    </div>
  );
};

export default FormFrame;
