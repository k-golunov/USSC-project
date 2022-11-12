import React from 'react';

const FormInput = ({ label, type, name, id, required }) => {
  return (
    <label className='form_input_wrapper'>
      <p className='form_input_label'>
        {label}
        {required ? '*' : ''}
      </p>
      <input
        required={required}
        className='form_input'
        type={type}
        name={name}
        id={id}
      />
    </label>
  );
};

export default FormInput;
