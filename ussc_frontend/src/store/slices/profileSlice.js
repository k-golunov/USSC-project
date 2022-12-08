import { createSlice } from '@reduxjs/toolkit';
import { createAsyncThunk } from '@reduxjs/toolkit';
import PROFILE_API from '../../api/profileAPI';

export const getProfile = createAsyncThunk(
  'profile/getProfile',
  async function (_, { rejectWithValue, dispatch }) {
    try {
      const accessToken = 'Bearer ' + localStorage.getItem('accessToken');
      const userId = localStorage.getItem('userId');

      console.dir({ userId, accessToken });

      let response = await fetch(
        `${PROFILE_API.GET_BY_USER_ID_URL}?userId=${userId}`,
        {
          method: 'get',
          headers: {
            Authorization: accessToken,
          },
        }
      );

      if (!response.ok) {
        console.log(response.status);
        throw new Error(
          `${response.status}${
            response.statusText ? ' ' + response.statusText : ''
          }`
        );
      }

      response = await response.json();

      dispatch(setProfile(response));

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
      const accessToken = 'Bearer ' + localStorage.getItem('accessToken');
      console.log(payload);
      payload = { ...payload, userId };
      let response = await fetch(PROFILE_API.FILL_INFO_URL, {
        method: 'post',
        headers: {
          Authorization: accessToken,
          'Content-Type': 'application/json',
        },
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
  university: null,
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
      state.secondName = action.payload.secondName;
      state.firstName = action.payload.firstName;
      state.patronymic = action.payload.patronymic;
      state.phone = action.payload.phone;
      state.telegram = action.payload.telegram;
      state.university = action.payload.university;
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
