import React from 'react';

const Button = ({ children, style, enabled, ...props }) => {
  return (
    <button
      className={`button${!enabled ? ' disabled' : ''}`}
      style={style}
      disabled={!enabled}
      {...props}
    >
      {children}
    </button>
  );
};

export default Button;
