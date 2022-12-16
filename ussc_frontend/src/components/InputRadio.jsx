export default function InputRadio({ text, id, ...props }) {
  return (
    <div className='input_radio'>
      <input type='radio' id={id} {...props} />
      <label htmlFor={id}>{text}</label>
    </div>
  );
}
