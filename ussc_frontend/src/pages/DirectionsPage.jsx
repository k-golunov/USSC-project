import React from 'react';
import DirectionCard from '../components/DirectionCard';
import FillProfileRequest from '../components/FillProfileRequest';
import { useProfile } from '../hooks/use-profile';

const DirectionsPage = () => {
  const profile = useProfile();

  const isFilledProfile = () => {
    for (let [_, value] of Object.entries(profile)) {
      if (value === null) return false;
    }
    return true;
  };

  return (
    <div className='main'>
      <div className='directionspage_content'>
        {isFilledProfile() ? (
          <></>
        ) : (
          <FillProfileRequest style={{ marginTop: '109px' }} />
        )}
        <div className='content_section'>
          <h2 className='section_heading'>Направления подготовки</h2>
          <div className='directions'>
            <DirectionCard title='Разработка DATAPK' />
            <DirectionCard title='Разработка DATAPK' />
            <DirectionCard title='Разработка DATAPK' />
          </div>
        </div>
      </div>
    </div>
  );
};

export default DirectionsPage;
