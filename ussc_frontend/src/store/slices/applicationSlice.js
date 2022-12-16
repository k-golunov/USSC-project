import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import APPLICATIONS_API from '../../api/applicationsAPI';

const initialState = {
  applications: [],
};

const applicationState = {
  id: null,
  userId: null,
  directionId: null,
  isAllowed: null,
};

export const getAllApplications = createAsyncThunk(
  'applications/getAllApplications',
  async (_, { rejectWithValue, dispatch }) => {
    try {
      let response = await fetch(APPLICATIONS_API.GET_ALL_APPLICATIONS_URL, {
        method: 'get',
      });

      if (!response.ok) throw new Error(`${response.status}`);

      response = await response.json();

      dispatch(setApplications(response));
    } catch (error) {
      return rejectWithValue(error.message);
    }
  }
);

const applicationSlice = createSlice({
  name: 'applications',
  initialState: initialState,
  reducers: {
    setApplications(state, action) {
      for (let app of action.payload) {
        if (
          state.applications.filter((innerApp) => {
            return innerApp.id === app.id;
          }).length
        )
          continue;

        state.applications.push({
          id: app.id,
          userId: app.userId,
          directionId: app.directionId,
          isAllowed: app.allow,
        });
      }
    },
  },
  extraReducers: {
    [getAllApplications.pending]: () => {},
    [getAllApplications.fulfilled]: () => {},
    [getAllApplications.rejected]: () => {},
  },
});

export const { setApplications } = applicationSlice.actions;

export default applicationSlice.reducer;
