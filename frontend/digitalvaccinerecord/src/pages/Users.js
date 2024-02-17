import React, { useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

import axios from 'axios';
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';
import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom'


export const Users = () => {
    const baseUrl = process.env.REACT_APP_API_URL_V1 + "/user";

  const [data, setData] = useState([]);

  const getAll = async() => {
    await axios.get(baseUrl)
    .then(response => {
      setData(response.data.$values);
    })
    .catch(error => {
      console.log(error);
    })
  }

  useEffect(() => {
    getAll();
  }, [])

  return (
    <div className="App">
      <h1>Usuarios</h1>
      <table className='table table-bordered'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Nome</th>
            <th>Sobrenome</th>
            <th>Documento</th>
            <th>Data de nascimento</th>
            <th>Editar</th>
          </tr>
        </thead>
        <tbody>
            {data.map(user => (
              <tr key={user.id}>
                <td>{user.id}</td>
                <td>{user.firstName}</td>
                <td>{user.surname}</td>
                <td>{user.document}</td>
                <td>{user.birthDate}</td>
                <td><Link to="/digital-vaccine" params={{id: user.id}} >Editar</Link></td>
              </tr>
            ))}
        </tbody>
      </table>
    </div>
  );
}