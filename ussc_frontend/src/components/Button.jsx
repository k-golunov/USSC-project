import React from 'react';

const Button = ({ children, style, enabled }) => {
  return (
    <button
      className={`button${!enabled ? ' disabled' : ''}`}
      disabled={!enabled}
    >
      {children}
    </button>
  );
};

export default Button;
