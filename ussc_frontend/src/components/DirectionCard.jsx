import Button from './Button';

export default function DirectionCard({ title, description, roles }) {
  return (
    <div
      className='direction_card'
      onClick={(e) => {
        e.stopPropagation();
      }}
    >
      <div className='wrapper'>
        <h1 className='title'>{title}</h1>
        <div className='content'>
          <div className='left_block'>
            <p className='description'>{description}</p>
          </div>
          <div className='right_block'>
            <div className='wrapper'>
              <p>Нам требуется:</p>
              <div className='roles'>
                {roles ? (
                  roles?.map((value) => {
                    return <p className='role'>{value}</p>;
                  })
                ) : (
                  <></>
                )}
              </div>
            </div>
            <Button>Оставить заявку</Button>
          </div>
        </div>
      </div>
    </div>
  );
}
