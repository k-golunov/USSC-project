import FormFrame from '../components/FormFrame';
import Button from '../components/Button';
import { useAuth } from '../hooks/use-auth';
import SignInForm from './SignInForm';

export default function SendApplicationForm() {
  const user = useAuth();
  if (!user.isAuth) return <SignInForm />;
  return (
    <FormFrame>
      <div className='form_heading'>
        <p className='form_title'>Выберите интересующую Вас роль</p>
      </div>
      <label>
        <input type='radio' name='a' id='' />A
      </label>
      <label>
        <input type='radio' name='b' id='' />B
      </label>
      <Button type='submit'>Отправить</Button>
    </FormFrame>
  );
}
