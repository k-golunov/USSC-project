import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  surname: null,
  name: null,
  patronymic: null,
  email: null,
  token: null,
  id: null,
};

const userSlice = createSlice({
  name: 'user',
  initialState: initialState,
  reducers: {
    setUser(state, action) {
      state.email = action.payload.email;
      state.id = action.payload.id;
      state.token = action.payload.token;
      state.name = action.payload.name;
      state.surname = action.payload.surname;
      state.patronymic = action.payload.patronymic;
    },
    removeUser(state) {
      state.email = null;
      state.id = null;
      state.token = null;
      state.name = null;
      state.surname = null;
      state.patronymic = null;
    },
  },
});

export const { setUser, removeUser } = userSlice.actions;

export default userSlice.reducer;
