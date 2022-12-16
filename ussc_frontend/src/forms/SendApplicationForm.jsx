import FormFrame from '../components/FormFrame';
import Button from '../components/Button';
import { useAuth } from '../hooks/use-auth';
import SignInForm from './SignInForm';
import InputRadio from '../components/InputRadio';
import { useForm } from 'react-hook-form';

export default function SendApplicationForm({ direction, ...props }) {
  const user = useAuth();
  const [register, handleSubmit] = useForm();

  if (!user.isAuth) return <SignInForm />;

  return (
    <FormFrame>
      <div
        className='form_heading'
        style={{ justifyContent: 'center', marginBottom: '35px' }}
      >
        <p className='form_title'>Выберите интересующую Вас роль</p>
      </div>
      <div className='form_radio' style={{ marginBottom: '50px' }}>
        {direction.roles.map((direction) => {
          return (
            <InputRadio
              key={direction.id}
              text={direction.directions}
              id={direction.id}
              name='radio'
              value={direction.directions}
            />
          );
        })}
      </div>

      <Button type='submit'>Отправить</Button>
    </FormFrame>
  );
}
