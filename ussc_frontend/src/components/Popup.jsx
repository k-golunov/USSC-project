import React from 'react';
import { useDispatch } from 'react-redux';

const Popup = ({ active, setActive, content }) => {
  return (
    <div className={active ? 'popup active' : 'popup'} onClick={setActive}>
      {content}
    </div>
  );
};

export default Popup;
