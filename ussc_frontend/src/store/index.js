import { configureStore } from '@reduxjs/toolkit';
import popupReducer from './slices/popupSlice';
import userReducer from './slices/userSlice';
import profileReducer from './slices/profileSlice';
import directionsReducer from './slices/directionSlice';

export default configureStore({
  reducer: {
    popups: popupReducer,
    user: userReducer,
    profile: profileReducer,
    directions: directionsReducer,
  },
});
