import React from 'react';

const Popup = ({ active, setActive, content }) => {
  return (
    <div className={active ? 'popup active' : 'popup'} onClick={setActive}>
      {content}
    </div>
  );
};

export default Popup;
