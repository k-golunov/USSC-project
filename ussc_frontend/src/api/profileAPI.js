import { HOST } from './host';

export const GET_BY_USER_ID_URL = `${HOST}/profile/getByUserId`;
export const FILL_INFO_URL = `${HOST}/profile/fillInfo`;
export const UPDATE_INFO_URL = `${HOST}/profile/updateInfo`;

const PROFILE_API = {
  GET_BY_USER_ID_URL,
  FILL_INFO_URL,
  UPDATE_INFO_URL,
};

export default PROFILE_API;
