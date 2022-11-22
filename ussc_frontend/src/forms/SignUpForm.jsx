import React from 'react';

import { useDispatch } from 'react-redux';
import { togglePopup } from '../store/popupSlice';

import FormFrame from '../components/FormFrame';
import FormInput from '../components/FormInput';
import Button from '../components/Button';
import Checkbox from '../components/Checkbox';
import { useForm } from 'react-hook-form';
import md5 from 'md5';

const SignUpForm = () => {
  const dispatch = useDispatch();

  const toggleSignUpPopup = () => dispatch(togglePopup('signUp'));
  const toggleSignInPopup = () => dispatch(togglePopup('signIn'));

  const methods = useForm();
  const { register, handleSubmit } = methods;
  const onSubmit = (e) => {
    if (e.password !== e.password_again) {
      alert('Вы указали разные пароли!');
      return;
    }
    delete e.password_again;
    e.password = md5(e.password);
    alert(JSON.stringify(e));
  };

  const [isChecked, setIsChecked] = React.useState(false);

  return (
    <FormFrame onSubmit={handleSubmit(onSubmit)}>
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

      <label className='form_input_wrapper'>
        <p className='form_input_label'>Фамилия*</p>
        <input
          type='text'
          className='form_input'
          {...register('lastName', { required: true })}
        />
      </label>

      <label className='form_input_wrapper'>
        <p className='form_input_label'>Имя*</p>
        <input
          type='text'
          className='form_input'
          {...register('firstName', { required: true })}
        />
      </label>

      <label className='form_input_wrapper'>
        <p className='form_input_label'>Отчество*</p>
        <input
          type='text'
          className='form_input'
          {...register('patronymic', { required: true })}
        />
      </label>

      <label className='form_input_wrapper'>
        <p className='form_input_label'>E-mail*</p>
        <input
          type='email'
          className='form_input'
          {...register('email', { required: true })}
        />
      </label>

      <label className='form_input_wrapper'>
        <p className='form_input_label'>Пароль*</p>
        <input
          type='password'
          className='form_input'
          {...register('password', { required: true })}
        />
      </label>

      <label className='form_input_wrapper'>
        <p className='form_input_label'>Повторите пароль*</p>
        <input
          type='password'
          className='form_input'
          {...register('password_again', { required: true })}
        />
      </label>

      <div className='checkbox_wrapper' style={{ marginTop: '30px' }}>
        <input
          className={isChecked ? 'checked' : ''}
          type='checkbox'
          // onChange={() => setIsChecked((prev) => !prev)}
          {...register('rule', {
            required: true,
            onChange: () => setIsChecked((prev) => !prev),
          })}
        />
        <span>
          Нажимая кнопку зарегистрироваться, я принимаю условия
          пользовательского соглашения
        </span>
      </div>
      {/* <FormInput {...methods} type='text' label='Фамилия' required={true} />
      <FormInput type='text' label='Имя' required={true} />
      <FormInput type='text' label='Отчество' required={true} />
      <FormInput type='email' label='E-mail' required={true} />
      <FormInput type='password' label='Пароль' required={true} />
      <FormInput type='password' label='Повторите пароль' required={true} /> */}
      {/* <Checkbox
        checked={true}
        label='Нажимая кнопку зарегистрироваться, я принимаю условия пользовательского соглашения'
        style={{ marginTop: '30px' }}
      /> */}
      <Button type='submit' style={{ marginTop: '66px' }}>
        Зарегистрироваться
      </Button>
    </FormFrame>
  );
};

export default SignUpForm;
