import React from 'react';
import { useForm } from 'react-hook-form';
import { useDispatch } from 'react-redux';
import Button from '../components/Button';
import FormFrame from '../components/FormFrame';
import { togglePopup } from '../store/slices/popupSlice';
import { setUser } from '../store/slices/userSlice';
import md5 from 'md5';
import { useNavigate } from 'react-router-dom';
import { useSignIn } from '../hooks/use-signin';

const SignInForm = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const signIn = useSignIn();

  const toggleSignUpPopup = () => dispatch(togglePopup('signUp'));
  const toggleSignInPopup = () => dispatch(togglePopup('signIn'));
  const togglePassRecoveryPopup = () => dispatch(togglePopup('passRecovery'));

  const { register, handleSubmit } = useForm();
  const onSubmit = async (user) => {
    user.password = md5(user.password);

    let response = await signIn(user);

    if (response.ok) {
      let user = await response.json();
      dispatch(setUser(user));
      localStorage.setItem('token', user.token);
      localStorage.setItem('userId', user.id);
      toggleSignInPopup();
    }
  };

  return (
    <FormFrame onSubmit={handleSubmit(onSubmit)}>
      <div className='form_heading'>
        <p className='form_title'>Вход</p>
        <a
          className='link'
          onClick={() => {
            toggleSignInPopup();
            toggleSignUpPopup();
          }}
        >
          Регистрация
        </a>
      </div>

      <label className='form_input_wrapper'>
        <p className='form_input_label'>E-mail*</p>
        <input
          type='text'
          className='form_input'
          {...register('email')}
          required
        />
      </label>

      <label className='form_input_wrapper'>
        <p className='form_input_label'>Пароль*</p>
        <input
          type='password'
          className='form_input'
          {...register('password')}
          required
        />
      </label>

      <a
        onClick={() => {
          toggleSignInPopup();
          togglePassRecoveryPopup();
        }}
        style={{
          width: '100%',
          fontSize: '16px',
          marginTop: '17px',
          cursor: 'pointer',
        }}
      >
        Забыли пароль?
      </a>
      <Button type='submit' style={{ marginTop: '42px' }}>
        Войти
      </Button>
    </FormFrame>
  );
};

export default SignInForm;
