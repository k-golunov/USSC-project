import React from 'react';

import { useDispatch } from 'react-redux';
import { togglePopup } from '../store/popupSlice';

import FormFrame from '../components/FormFrame';
import FormInput from '../components/FormInput';
import Button from '../components/Button';
import Checkbox from '../components/Checkbox';

const SignUpForm = () => {
  const dispatch = useDispatch();

  const toggleSignUpPopup = () => dispatch(togglePopup('signUp'));
  const toggleSignInPopup = () => dispatch(togglePopup('signIn'));

  return (
    <FormFrame>
      <div className='form_heading'>
        <p className='form_title'>Регистрация</p>
        <a
          className='link'
          onClick={() => {
            toggleSignUpPopup();
            toggleSignInPopup();
          }}
        >
          У вас уже есть аккаунт?
        </a>
      </div>
      <FormInput type='text' label='Фамилия' required={true} />
      <FormInput type='text' label='Имя' required={true} />
      <FormInput type='text' label='Отчество' required={true} />
      <FormInput type='email' label='E-mail' required={true} />
      <FormInput type='password' label='Пароль' required={true} />
      <FormInput type='password' label='Повторите пароль' required={true} />
      <Checkbox
        checked={true}
        label='Нажимая кнопку зарегистрироваться, я принимаю условия пользовательского соглашения'
        style={{ marginTop: '30px' }}
      />
      <Button style={{ marginTop: '66px' }}>Зарегистрироваться</Button>
    </FormFrame>
  );
};

export default SignUpForm;
