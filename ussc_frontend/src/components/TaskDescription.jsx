import React from 'react';

const TaskDescription = ({ text, ...props }) => {
  return (
    <div className='task_description'>
      <pre className='text'>{text}</pre>
    </div>
  );
};

export default TaskDescription;
