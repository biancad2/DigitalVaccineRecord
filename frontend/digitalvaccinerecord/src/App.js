import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom'
import './App.css';

import 'bootstrap/dist/css/bootstrap.min.css'
import axios from 'axios';
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap'
import {UserRegister} from './pages/UserRegister';
import {Home} from './pages/Home';
import {Users} from './pages/Users';
import {Records} from './pages/DigitalVaccineRecord';
import {Vaccines} from './pages/Vaccines';

function App() {
  return (
    <div className="App">
      <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/register' element={<UserRegister />} />
        <Route path='/users' element={<Users />} />
        <Route path='/digital-vaccines-records/:id' element={<Records />} />
        <Route path='/vaccines' element={<Vaccines />} />
      </Routes>
      <Link to="/register"> Registrar </Link>
        <Link to="/users"> Usuarios </Link>
        <Link to="/vaccines"> Vacinas </Link>
    </div>
  );
}

export default App;
