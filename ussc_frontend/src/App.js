import React from 'react';
import './App.css';

import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage';
import NotFoundPage from './pages/NotFoundPage';
import ProfilePage from './pages/ProfilePage';
import HomeLayout from './components/HomeLayout';
import ProfileLayout from './components/ProfileLayout';
import TaskPage from './pages/TaskPage';

function App() {
  return (
    <React.StrictMode>
      <Router>
        <Routes>
          <Route path='/' element={<HomeLayout />}>
            <Route index element={<HomePage />} />
            <Route path='*' element={<NotFoundPage />} />
          </Route>
          <Route path='/profile/' element={<ProfileLayout />}>
            <Route index element={<ProfilePage />} />
            <Route path='task' element={<TaskPage />} />
          </Route>
        </Routes>
      </Router>
    </React.StrictMode>
  );
}

export default App;
