import React from 'react';
import { useForm } from 'react-hook-form';
import { useDispatch } from 'react-redux';
import Button from '../components/Button';
import FormFrame from '../components/FormFrame';
import FormInput from '../components/FormInput';
import { togglePopup } from '../store/slices/popupSlice';
import { setUser } from '../store/slices/userSlice';
import md5 from 'md5';
import { Navigate, useNavigate } from 'react-router-dom';

const signInUser = async (user) => {
  let response = await fetch('https://localhost:7296/user/signin', {
    method: 'post',
    headers: {
      'Content-Type': 'application/json;charset=utf-8',
    },
    body: JSON.stringify(user),
  });
  return response;
};

const SignInForm = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const toggleSignUpPopup = () => dispatch(togglePopup('signUp'));
  const toggleSignInPopup = () => dispatch(togglePopup('signIn'));
  const togglePassRecoveryPopup = () => dispatch(togglePopup('passRecovery'));

  const { register, handleSubmit } = useForm();
  const onSubmit = async (user) => {
    user.password = md5(user.password);

    let response = await signInUser(user);

    if (response.ok) {
      dispatch(setUser(await response.json()));
      toggleSignInPopup();
      navigate('/profile');
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
