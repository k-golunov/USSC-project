import React from 'react';
import { useDispatch } from 'react-redux';
import { Link } from 'react-router-dom';
import Button from '../components/Button';
import FormFrame from '../components/FormFrame';
import FormInput from '../components/FormInput';
import { togglePopup } from '../store/popupSlice';

const SignInForm = () => {
  const dispatch = useDispatch();

  const toggleSignUpPopup = () => dispatch(togglePopup('signUp'));
  const toggleSignInPopup = () => dispatch(togglePopup('signIn'));
  const togglePassRecoveryPopup = () => dispatch(togglePopup('passRecovery'));

  return (
    <FormFrame>
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
      <FormInput label='E-mail' required={true} />
      <FormInput label='Пароль' required={true} />
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
      <Button enabled={true} style={{ marginTop: '42px' }}>
        Войти
      </Button>
    </FormFrame>
  );
};

export default SignInForm;
