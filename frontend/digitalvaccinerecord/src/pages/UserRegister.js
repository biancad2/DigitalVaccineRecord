import axios from 'axios';
import React, { useState, useEffect } from 'react';
import { Modal, ModalHeader, ModalBody, Button, Form, FormGroup, Label, Input, FormText, Col, Row, ModalFooter, NavLink } from 'reactstrap';
import { useNavigate, useParams } from "react-router-dom";
import moment from 'moment';

function Title({ userId }) {
  if (userId != undefined && userId != null)
    return <h1 className='text-center'>Editar usuario</h1>;
  return <h1 className='text-center'>Registro de usuario</h1>;
}

export const UserRegister = () => {
  const baseUrl = process.env.REACT_APP_API_URL_V1 + "/user";
  let { id } = useParams();
  const navigate = useNavigate();

  const [processing, setProcessing] = useState(false);
  const [isErrorOpen, setErrorModal] = useState(false);

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

  const toggle = () => {
    setProcessing(!processing);
    setErrorModal(!isErrorOpen);
  }

  const handleChanges = e => {
    const { target } = e;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    const { name } = target;

    setUser({
      ...user,
      [name]: value
    });
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
      [name]: opts
    });
  }

  const getUserDetails = async () => {
    await axios.get(baseUrl + "/" + id)
      .then(response => {
        var user = response.data;
        user.birthDate = moment(user.birthDate).format("YYYY-MM-DD");
        setUser(response.data);
      })
      .catch(error => {
        console.log(error);
      })
  }

  useEffect(() => {
    if (id)
      getUserDetails();
  }, [])

  const submitForm = async (e) => {
    e.preventDefault();
    user.gender = parseInt(user.gender);
    setProcessing(!processing);
    await axios.post(baseUrl, user)
      .then(response => {
        navigate("/users");
      })
      .catch(error => {
        setErrorModal(!isErrorOpen);
      })
  }

  return (
    <Form onSubmit={(e) => submitForm(e)} className='card border-light p-4'>
      <Title userId={id} />
      <Row>
        <Col md={6}>
          <FormGroup>
            <Label for="firstName">Nome <span style={{ color: "red" }}>*</span></Label>
            <Input name="firstName" id="firstName" placeholder="Digite seu nome" onChange={handleChanges} maxLength={50} required value={user && user.firstName} />
          </FormGroup>
        </Col>
        <Col md={6}>
          <FormGroup >
            <Label for="surname">Sobrenome <span style={{ color: "red" }}>*</span></Label>
            <Input name="surname" id="surname" placeholder="Digite seu sobrenome" onChange={handleChanges} maxLength={50} required value={user && user.surname} />
          </FormGroup>
        </Col>
      </Row>
      <Row>
        <Col md={6}>
          <FormGroup>
            <Label for="document">CPF <span style={{ color: "red" }}>*</span></Label>
            <Input name="document" id="document" placeholder="Exemplo: 000.000.000-00" onChange={handleChanges} maxLength={14} required value={user && user.document} />
          </FormGroup>
        </Col>
        <Col md={6}>
          <FormGroup>
            <Label for="birthDate">Data de nascimento <span style={{ color: "red" }}>*</span></Label>
            <Input type="date" name="birthDate" id="birthDate" onChange={handleChanges} required value={user && user.birthDate} />
          </FormGroup>
        </Col>
      </Row>
      <FormGroup>
        <Label for="nationalHealthCardNumber">Numero de cartao SUS <span style={{ color: "red" }}>*</span></Label>
        <Input name="nationalHealthCardNumber" id="nationalHealthCardNumber" placeholder="Exemplo: 00 00000 0000" onChange={handleChanges} maxLength={15} value={user && user.nationalHealthCardNumber} />
      </FormGroup>
      <FormGroup tag="fieldset">
        <label>Gênero <span style={{ color: "red" }}>*</span></label>
        <Row>
          <Col md={4}>
            <FormGroup check>
              <Label check>
                <Input type="radio" name="gender" value={0} onChange={handleChanges} required checked={user && user.gender == 0} />{' '}
                Prefiro nao informar
              </Label>
            </FormGroup>
          </Col>
          <Col md={4}>
            <FormGroup check>
              <Label check>
                <Input type="radio" name="gender" value={1} onChange={handleChanges} required checked={user && user.gender == 1} />{' '}
                Feminino
              </Label>
            </FormGroup>
          </Col>
          <Col md={4}>
            <FormGroup check>
              <Label check>
                <Input type="radio" name="gender" value={2} onChange={handleChanges} required checked={user && user.gender == 2} />{' '}
                Masculino
              </Label>
            </FormGroup>
          </Col>
        </Row>
      </FormGroup>
      {user.gender != '' && user.gender == 1 &&
        <FormGroup tag="fieldset">
          <FormGroup check>
            <Label check>
              <Input type="checkbox" name="isPregnant" onChange={handleChanges} checked={user && user.isPregnant} />{' '}
              Marque se for gestante
            </Label>
          </FormGroup>
        </FormGroup>
      }
      <FormGroup>
        <Label for="profiles">Selecione os perfis do usuário <span style={{ color: "red" }}>*</span></Label>
        <Input type="select" name="profiles" id="profiles" multiple onChange={onChangeMulti} required value={user && user.profiles.$values}>
          <option value={0} selected={user && user.profiles.$values?.includes(0)}>Paciente</option>
          <option value={1} selected={user && user.profiles.$values?.includes(1)}>Enfermeira</option>
        </Input>
      </FormGroup>
      <Button color='success' disabled={processing}>{processing ? "Processando..." : "Salvar"}</Button>
      <Modal isOpen={isErrorOpen} toggle={toggle}>
        <ModalHeader toggle={toggle}>Erro</ModalHeader>
        <ModalBody>
          Algo deu errado, por favor, verifique as informações e tente novamente.
        </ModalBody>
        <ModalFooter>
          <Button color="secondary" onClick={toggle}>
            Fechar
          </Button>
        </ModalFooter>
      </Modal>
    </Form>
  );
}

