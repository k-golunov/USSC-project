import { useSelector, useDispatch } from 'react-redux';
import { setUser } from '../store/slices/userSlice';

export function useAuth() {
  const user = useSelector((state) => state.user);
  const dispatch = useDispatch();

  const localUser = {
    accessToken: localStorage.getItem('accessToken'),
    email: localStorage.getItem('email'),
    id: localStorage.getItem('userId'),
  };

  if (
    localUser.accessToken &&
    localUser.email &&
    localUser.id &&
    !user.accessToken
  ) {
    dispatch(setUser(localUser));
  }

  return {
    isAuth: !!user.accessToken,
    ...user,
  };
}
