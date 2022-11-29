import { configureStore } from '@reduxjs/toolkit';
import popupReduser from './slices/popupSlice';
import userReducer from './slices/userSlice';

export default configureStore({
  reducer: {
    popups: popupReduser,
    user: userReducer,
  },
});
