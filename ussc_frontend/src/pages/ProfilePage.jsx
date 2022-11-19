import React from 'react';
import { useNavigate } from 'react-router-dom';
import Button from '../components/Button';
import Header from '../components/Header';
import leftArrow from '../img/left_arrow.svg';

const ProfilePage = () => {
  const navigate = useNavigate();

  const goBack = () => navigate(-1);

  return (
    <>
      <Header />
      <div className='profile_wrapper'>
        <div className='profile'>
          <a className='go_back' onClick={goBack}>
            <span>
              <img src={leftArrow} />
            </span>
            Назад
          </a>
          <h1 className='profile_heading'>Редактирование профиля</h1>

          <div className='profile_person'>
            <div className='profile_photo'></div>
            <div className='profile_name_wrapper'>
              <p className='profile_name'>Имя Фамилия Отчество</p>
              <a>Изменить</a>
            </div>
          </div>

          <div className='profile_data'>
            <div className='profile_datasection'>
              <h2 className='datasection_heading'>
                Контактная
                <br />
                информация
              </h2>

              <div className='datasection_field'>
                <p className='field_title'>Телефон</p>
                <input className='field_input' type='tel' />
              </div>

              <div className='datasection_field'>
                <p className='field_title'>E-mail</p>
                <input className='field_input' type='email' />
              </div>

              <div className='datasection_field'>
                <p className='field_title'>Ник в Telegram</p>
                <input className='field_input' type='text' />
              </div>
            </div>

            <div className='profile_datasection'>
              <h2 className='datasection_heading'>Образование</h2>

              <div className='datasection_field'>
                <p className='field_title'>Учебное заведение</p>
                <textarea className='field_textarea'></textarea>
              </div>

              <div className='datasection_field'>
                <p className='field_title'>Факультет</p>
                <textarea className='field_textarea'></textarea>
              </div>

              <div className='datasection_field'>
                <p className='field_title'>Специальность</p>
                <textarea className='field_textarea'></textarea>
              </div>

              <div className='datasection_field'>
                <p className='field_title'>Курс</p>
                <input type='text' className='field_input' />
              </div>

              <div className='datasection_field'>
                <p className='field_title'>Опыт работы</p>
                <textarea className='field_textarea'></textarea>
              </div>
            </div>

            <div className='profile_datasection'>
              <h2 className='datasection_heading'>Изменить пароль</h2>
              <div className='datasection_field'>
                <p className='field_title'>Старый пароль</p>
                <input type='password' className='field_input' />
              </div>

              <div className='datasection_field'>
                <p className='field_title'>Новый пароль</p>
                <input type='password' className='field_input' />
              </div>

              <div className='datasection_field'>
                <p className='field_title'>Повторите пароль</p>
                <input type='password' className='field_input' />
              </div>
            </div>
            <Button enabled={true} style={{ width: '289px' }}>
              Сохранить изменения
            </Button>
          </div>
        </div>
      </div>
    </>
  );
};

export default ProfilePage;
