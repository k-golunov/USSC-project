import { useSelector } from 'react-redux';

export function useProfile() {
  const profile = useSelector((state) => state.profile);

  return { ...profile };
}
