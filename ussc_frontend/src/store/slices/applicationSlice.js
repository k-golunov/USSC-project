import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';

const initialState = {
  applications: [],
};

const applicationState = {
  id: null,
  directionId: null,
  isAllowed: null,
};

const applicationSlice = createSlice({
  name: 'applications',
  initialState: initialState,
  reducers: {},
});
