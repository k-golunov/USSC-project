import React from 'react';
import { Link } from 'react-router-dom';
import FormFrame from '../components/FormFrame';
import FormInput from '../components/FormInput';
import Button from '../components/Button';
import Checkbox from '../components/Checkbox';

const RegForm = () => {
  return (
    <FormFrame
      title='Регистрация'
      linkTo='/auth'
      linkText='У вас уже есть аккаунт?'
    >
      <FormInput label='Фамилия' required={true} />
      <FormInput label='Имя' required={true} />
      <FormInput label='Отчество' required={true} />
      <FormInput label='E-mail' required={true} />
      <FormInput label='Пароль' required={true} />
      <FormInput label='Повторите пароль' required={true} />
      <Checkbox
        checked={true}
        label='Нажимая кнопку зарегистрироваться, я принимаю условия пользовательского соглашения'
        style={{ marginTop: '30px' }}
      />
      <Button enabled={true}>Зарегистрироваться</Button>
    </FormFrame>
  );
};

export default RegForm;
