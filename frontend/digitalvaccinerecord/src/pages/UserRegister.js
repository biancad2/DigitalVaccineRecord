import axios from 'axios';
import React, { useState, useRef } from 'react';
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';
import { useNavigate } from "react-router-dom";

export const UserRegister = () => {
  const checkboxRef = useRef(null);
  const baseUrl = process.env.REACT_APP_API_URL_V1 + "/user";
  const navigate = useNavigate();
  
  const [user, setUser] = useState({
    firstName: '',
    surname: '',
    document: '',
    birthDate: '',
    nationalHealthCardNumber: '',
    gender: 0,
    isPregnant: false,
    profiles: ''
  })

  const handleChanges = e => {
    const { target } = e;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    const { name } = target;
    
    setUser({
      ...user,
      [name]:value
    });console.log(user)
  }

  const onChangeMulti = e => {
    let opts = [], opt;
    const { name } = e.target;
    for (let i = 0, len = e.target.options.length; i < len; i++) {
        opt = e.target.options[i];
        if (opt.selected) {
            opts.push(parseInt(opt.value));
        }
    }

    setUser({
      ...user,
      [name]:opts
    });console.log(user)
 }

  async function submitForm(e) {
    e.preventDefault();
    user.gender = parseInt(user.gender);
    await axios.post(baseUrl, user)
    .then(response => {navigate("/users");})
    .catch(error => {console.log(error)})
  }
    return (
      <Form className="form" onSubmit={(e) => submitForm(e)}>
        <FormGroup>
          <Label for="firstName">Nome</Label>
          <Input name="firstName" id="firstName" placeholder="Digite seu nome" onChange={handleChanges}/>
        </FormGroup>
        <FormGroup>
          <Label for="surname">Sobrenome</Label>
          <Input name="surname" id="surname" placeholder="Digite seu sobrenome" onChange={handleChanges}/>
        </FormGroup>
        <FormGroup>
          <Label for="document">CPF</Label>
          <Input name="document" id="document" placeholder="Exemplo: 000.000.000-00" onChange={handleChanges}/>
        </FormGroup>
        <FormGroup>
          <Label for="birthDate">Data de nascimento</Label>
          <Input type="date" name="birthDate" id="birthDate"  onChange={handleChanges}/>
        </FormGroup>
        <FormGroup>
          <Label for="nationalHealthCardNumber">Numero de cartao SUS</Label>
          <Input name="nationalHealthCardNumber" id="nationalHealthCardNumber" placeholder="Exemplo: 00 00000 0000" onChange={handleChanges}/>
        </FormGroup>
        <FormGroup tag="fieldset">
          <legend>Genero</legend>
          <FormGroup check>
            <Label check>
              <Input type="radio" name="gender" value={0} onChange={handleChanges}/>{' '}
              Prefiro nao informar
            </Label>
          </FormGroup>
          <FormGroup check>
            <Label check>
              <Input type="radio" name="gender" value={1} onChange={handleChanges}/>{' '}
              Feminino
            </Label>
          </FormGroup>
          <FormGroup check>
            <Label check>
              <Input type="radio" name="gender" value={2} onChange={handleChanges}/>{' '}
              Masculino
            </Label>
          </FormGroup>
        </FormGroup>
        <FormGroup tag="fieldset">
          <FormGroup check>
            <Label check>
              <Input type="checkbox" name="isPregnant" onChange={handleChanges}/>{' '}
              Gestante
            </Label>
          </FormGroup>         
        </FormGroup>
        <FormGroup>
          <Label for="profiles">Selecione os perfis do usuario</Label>
          <Input type="select" name="profiles" id="profiles" multiple onChange={onChangeMulti}>
            <option value={0}>Paciente</option>
            <option value={1}>Enfermeira</option>
          </Input>
        </FormGroup>
        <Button>Salvar</Button>
      </Form>
    );
}

