import React from 'react';
import { Routes, Route } from 'react-router-dom'
import './App.css';

import 'bootstrap/dist/css/bootstrap.min.css'
import { UserRegister } from './pages/UserRegister';
import { Home } from './pages/Home';
import { Users } from './pages/Users';
import { Vaccines } from './pages/Vaccines';
import { VaccineRegister } from './pages/VaccineRegister';
import { Records } from './pages/UserDoses';

function App() {
  return (
    <div className="App container space-nav">
      <Routes>
        <Route path='/' element={<Users />} />
        <Route path='/users/register' element={<UserRegister />} />
        <Route path='/users/:id' element={<UserRegister />} />
        <Route path='/users' element={<Users />} />
        <Route path="/users/:id/doses" element={<Records />} />
        <Route path='/vaccines' element={<Vaccines />} />
        <Route path='/vaccines/register' element={<VaccineRegister />} />
      </Routes>
    </div>
  );
}

export default App;
