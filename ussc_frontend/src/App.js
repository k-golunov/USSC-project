import React from 'react';
import './App.css';

import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import HomePage from './pages/HomePage';
import NotFoundPage from './pages/NotFoundPage';
import ProfilePage from './pages/ProfilePage';
import HomeLayout from './components/HomeLayout';
import ProfileLayout from './components/ProfileLayout';
import TaskPage from './pages/TaskPage';
import RequireAuth from './hoc/RequireAuth';
import { useAuth } from './hooks/use-auth';
import DirectionsPage from './pages/DirectionsPage';

function App() {
  return (
    <React.StrictMode>
      <Router>
        <Routes>
          <Route path='/' element={<HomeLayout />}>
            <Route index element={<HomePage />} />
            <Route path='*' element={<NotFoundPage />} />
          </Route>
          <Route
            path='/profile'
            element={
              <RequireAuth>
                <ProfileLayout />
              </RequireAuth>
            }
          >
            <Route index element={<ProfilePage />} />
          </Route>
          <Route
            path='tasks'
            element={
              <RequireAuth>
                <ProfileLayout />
              </RequireAuth>
            }
          >
            <Route index element={<TaskPage />} />
          </Route>
          <Route
            path='/directions'
            element={
              <RequireAuth>
                <ProfileLayout />
              </RequireAuth>
            }
          >
            <Route index element={<DirectionsPage />} />
          </Route>
        </Routes>
      </Router>
    </React.StrictMode>
  );
}

export default App;
