import { configureStore } from '@reduxjs/toolkit';
import popupReducer from './slices/popupSlice';
import userReducer from './slices/userSlice';
import profileReducer from './slices/profileSlice';
import directionsReducer from './slices/directionSlice';
import applicationsReducer from './slices/applicationSlice';
import allUsersReducer from './slices/allUsersSlice';

export default configureStore({
  reducer: {
    popups: popupReducer,
    user: userReducer,
    profile: profileReducer,
    directions: directionsReducer,
    applications: applicationsReducer,
    allUsers: allUsersReducer,
  },
});
