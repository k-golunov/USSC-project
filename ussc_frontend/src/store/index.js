import { configureStore } from '@reduxjs/toolkit';
import popupReduser from './slices/popupSlice';
import userReducer from './slices/userSlice';
import profileReducer from './slices/profileSlice';

export default configureStore({
  reducer: {
    popups: popupReduser,
    user: userReducer,
    profile: profileReducer,
  },
});
