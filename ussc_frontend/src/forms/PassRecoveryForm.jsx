import React from 'react';
import Button from '../components/Button';
import FormFrame from '../components/FormFrame';
import { useForm } from 'react-hook-form';

const PassRecoveryForm = () => {
  const { register, handleSubmit } = useForm();
  const onSubmit = (e) => alert(JSON.stringify(e));

  return (
    <FormFrame title='Восстановление пароля' onSubmit={handleSubmit(onSubmit)}>
      <label className='form_input_wrapper'>
        <p className='form_input_label'>E-mail*</p>
        <input type='email' className='form_input' {...register('email')} />
      </label>
      <Button type='submit' style={{ marginTop: '70px' }}>
        Отправить
      </Button>
    </FormFrame>
  );
};

export default PassRecoveryForm;
