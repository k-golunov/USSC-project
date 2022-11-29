import React from 'react';

const DirectionCard = ({ title, image, alt }) => {
  return (
    <div className='direction'>
      {title ? <p className='direction_title'>{title}</p> : <></>}
      {image ? (
        <img className='direction_image' src={image} alt={alt} />
      ) : (
        <div
          className='direction_image'
          style={{ background: '#D9D9D9' }}
        ></div>
      )}
    </div>
  );
};

export default DirectionCard;
