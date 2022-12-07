import { createSlice } from '@reduxjs/toolkit';
import { createAsyncThunk } from '@reduxjs/toolkit';
import { fillInfoURL, getInfoURL } from '../../api/profileAPI';

export const getProfile = createAsyncThunk(
  'profile/getProfile',
  async function (_, { rejectWithValue, dispatch }) {
    try {
      const token = 'Bearer ' + localStorage.getItem('token');
      const userId = localStorage.getItem('userId');
      let response = await fetch(`${getInfoURL}?userId=${userId}`, {
        method: 'get',
        headers: {
          Authorization: token,
        },
      });

      if (!response.ok) {
        throw new Error(
          `${response.status}${
            response.statusText ? ' ' + response.statusText : ''
          }`
        );
      }

      response = await response.json();

      return response;
    } catch (error) {
      return rejectWithValue(error.message);
    }
  }
);

export const fillInfo = createAsyncThunk(
  'profile/fillInfo',
  async function (payload, { rejectWithValue, dispatch }) {
    try {
      const userId = localStorage.getItem('userId');
      const token = 'Bearer ' + localStorage.getItem('token');
      console.log(payload);
      payload = { ...payload, userId };
      let response = await fetch(fillInfoURL, {
        method: 'post',
        headers: { Authorization: token, 'Content-Type': 'application/json' },
        body: JSON.stringify(payload),
      });

      if (!response.ok) {
        throw new Error(
          `${response.status}${
            response.statusText ? ' ' + response.statusText : ''
          }`
        );
      }

      response = response.json();

      dispatch(getProfile());

      return response;
    } catch (error) {
      return rejectWithValue(error.message);
    }
  }
);

const initialState = {
  secondName: null,
  firstName: null,
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
      state.secondName = action.payload.lastName;
      state.firstName = action.payload.firstName;
      state.patronymic = action.payload.patronymic;
      state.phone = action.payload.phone;
      state.telegram = action.payload.telegram;
      state.university = action.payload.univercity;
      state.faculty = action.payload.faculty;
      state.speciality = action.payload.speciality;
      state.course = action.payload.course;
      state.workExperience = action.payload.workExperience;
    },
  },
  extraReducers: {
    [getProfile.pending]: (state, action) => {},
    [getProfile.fulfilled]: (state, action) => {
      console.log(action.payload);
    },
    [getProfile.rejected]: (state, action) => {},
    [fillInfo.pending]: (state, action) => {},
    [fillInfo.fulfilled]: (state, action) => {},
    [fillInfo.rejected]: (state, action) => {},
  },
});

export const { setProfile } = profileSlice.actions;

export default profileSlice.reducer;
