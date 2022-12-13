import React from 'react';
import DirectionCard from './DirectionCard';
import Popup from './Popup';
import { toggleDirection } from '../store/slices/directionSlice';
import { useDispatch } from 'react-redux';

const DirectionPreview = ({ title, image, alt, direction, ...prop }) => {
  const dispatch = useDispatch();
  const toggle = () => dispatch(toggleDirection({ id: direction.id }));

  return (
    <>
      <div className='direction_preview' onClick={toggle}>
        {direction.title ? (
          <p className='direction_title'>{direction.title}</p>
        ) : (
          <></>
        )}
        {image ? (
          <div className='direction_image'>
            <img src={image} alt={alt} />
          </div>
        ) : (
          <div
            className='direction_image'
            style={{ background: '#D9D9D9' }}
          ></div>
        )}
      </div>
      <Popup
        active={direction.isShown}
        toggleActive={toggle}
        content={
          <DirectionCard
            title={direction.title}
            description={direction.description}
          />
        }
      />
    </>
  );
};

export default DirectionPreview;
