import React from 'react';
import './App.css';
import FormFrame from './components/FormFrame';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';
import HomePage from './pages/HomePage';
import NotFoundPage from './pages/NotFoundPage';
import RegForm from './forms/RegForm';

function App() {
  return (
    <React.StrictMode>
      <Router>
        <Routes>
          <Route path='/' element={<HomePage />} />
          <Route path='/auth' element={<RegForm />} />
          <Route path='profile' />
          <Route path='*' element={<NotFoundPage />} />
        </Routes>
      </Router>
    </React.StrictMode>
  );
}

export default App;
