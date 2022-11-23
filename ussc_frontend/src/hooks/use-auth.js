import { useSelector } from 'react-redux';

export function useAuth() {
  const { token, ...user } = useSelector((state) => state.user);

  return {
    isAuth: !!token,
    ...user,
  };
}
