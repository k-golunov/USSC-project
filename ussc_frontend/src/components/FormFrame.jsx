import React from 'react';
import { Link } from 'react-router-dom';
import NavLogo from './NavLogo';

const FormFrame = ({ children }) => {
  return (
    <div className='form_frame' onClick={(e) => e.stopPropagation()}>
      <div className='formframe_head'>
        <NavLogo />
      </div>
      <div className='formframe_body'>{children}</div>
    </div>
  );
};

export default FormFrame;
