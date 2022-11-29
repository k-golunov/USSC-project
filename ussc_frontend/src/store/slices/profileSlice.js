import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  lastname: null,
  firstname: null,
  patronymic: null,
  phone: null,
  telegram: null,
  univercity: null,
  faculty: null,
  speciality: null,
  course: null,
  workExp: null,
};

const profileSlice = createSlice({
  name: 'profile',
  initialState: initialState,
  reducers: {
    setProfile(state, action) {
      state.lastname = action.payload.lastName;
      state.firstname = action.payload.firstName;
      state.patronymic = action.payload.patronymic;
      state.phone = action.payload.phone;
      state.telegram = action.payload.telegram;
      state.univercity = action.payload.univercity;
      state.faculty = action.payload.faculty;
      state.speciality = action.payload.speciality;
      state.course = action.payload.course;
      state.workExp = action.payload.workExp;
    },
  },
});

export const { setProfile } = profileSlice.actions;

export default profileSlice.reducer;
