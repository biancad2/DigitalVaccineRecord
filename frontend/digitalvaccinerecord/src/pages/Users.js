import React, { useState, useEffect } from 'react';
import { Modal, ModalBody, ModalFooter, ModalHeader, Button } from 'reactstrap';
import { Link } from 'react-router-dom'

import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import moment from 'moment';

export const Users = () => {
  const baseUrl = process.env.REACT_APP_API_URL_V1 + "/user";
  
  const [isRemoveOpen, setRemoveModal] = useState(false);
  const [users, setUsers] = useState([]);
  const [selectedUser, setSelectedUser] = useState({
    id: '',
    firstName: '',
    surname: '',
  });
  
  const toggle = () => {
    setRemoveModal(!isRemoveOpen);
  }

  const getAll = async () => {
    await axios.get(baseUrl)
      .then(response => {
        setUsers(response.data.$values);
      })
      .catch(error => {
        console.log(error);
      })
  }

  const removeUser = async () => {
    await axios.delete(baseUrl + "/" + selectedUser.id)
      .then(response => {
        setRemoveModal(!isRemoveOpen);
        setUsers(users.filter(user => user.id != selectedUser.id));
      })
      .catch(error => {
        
      })
  }

  const selectUser = (user, action) => {
    setSelectedUser(user);
    if (action == "remove")
      setRemoveModal(!isRemoveOpen);
  }

  useEffect(() => {
    getAll();
  }, [])

  return (
    <div>
      <h1 className='text-center'>Usuários</h1>
      <table className='table table-bordered text-center'>
        <thead>
          <tr>
            <th>Nome</th>
            <th>Sobrenome</th>
            <th>Documento</th>
            <th>Data de nascimento</th>
            <th>Carteira de vacinação</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {users.map(user => (
            <tr key={user.id}>
              <td>{user.firstName}</td>
              <td>{user.surname}</td>
              <td>{user.document}</td>
              <td>{moment(user.birthDate).format('DD/MM/YYYY')}</td>
              <td><Link to={{ pathname: `${user.id}/doses` }} className='btn btn-success'>Acessar</Link></td>
              <td><Link to={{ pathname: `${user.id}` }} className='btn btn-primary'>Editar</Link></td>
              <td><Button color='danger' onClick={(e) => selectUser(user, "remove")}> Excluir</Button></td>
            </tr>
          ))}
        </tbody>
      </table>
      <Modal isOpen={isRemoveOpen} toggle={toggle}>
        <ModalHeader toggle={toggle}>Exclusao de usuario</ModalHeader>
        <ModalBody>
          Voce tem certeza que deseja excluir o usuario {selectedUser.firstName} {selectedUser.surname}?
        </ModalBody>
        <ModalFooter>
          <Button color="danger" onClick={removeUser}>
            Excluir
          </Button>
          <Button color="secondary" onClick={toggle}>
            Cancelar
          </Button>
        </ModalFooter>
      </Modal>
    </div>
  );
}