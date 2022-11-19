import React from 'react';
import Button from '../components/Button';
import FormFrame from '../components/FormFrame';
import FormInput from '../components/FormInput';

const PassRecoveryForm = () => {
  return (
    <FormFrame title='Восстановление пароля'>
      <FormInput label='E-mail' required={true} />
      <Button enabled={true} style={{ marginTop: '70px' }}>
        Отправить
      </Button>
    </FormFrame>
  );
};

export default PassRecoveryForm;
