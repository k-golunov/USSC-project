import React from 'react';

const Button = ({ children, style, disabled, ...props }) => {
  return (
    <button
      className={`button${disabled ? ' disabled' : ''}`}
      style={style}
      disabled={disabled}
      {...props}
    >
      {children}
    </button>
  );
};

export default Button;
