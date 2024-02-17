import axios from 'axios';
import React, { useState, useRef } from 'react';
import { Button, Form, FormGroup, Label, Input, FormText, Row, Col, Card, CardHeader, CardBody } from 'reactstrap';
import { useNavigate } from "react-router-dom";

export const VaccineRegister = () => {
    const baseUrl = process.env.REACT_APP_API_URL_V1 + "/vaccine";
    const navigate = useNavigate();

    const [vaccine, setVaccine] = useState({
        type: 0,
        name: '',
        description: '',
        doses: []
    })


    const handleChange = (e, index) => {
        const { target } = e;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const { name } = target;
        debugger
        if (index >= 0) {
            if (vaccine.doses[index]) {
                vaccine.doses[index][name] = value;
            } else {
                var dose = { [name]: value };
                vaccine.doses.push(dose);
            }
        } else {
            setVaccine({
                ...vaccine,
                [name]: value
            });
        }
    }

    async function submitForm(e) {
        e.preventDefault();
        vaccine.type = parseInt(vaccine.type);
        for (var i = 0; i < vaccine.doses.length; i++) {
            vaccine.doses[i].fromAge = parseInt(vaccine.doses[i].fromAge);
            vaccine.doses[i].toAge = parseInt(vaccine.doses[i].toAge);
            vaccine.doses[i].number = i + 1;
        }
        await axios.post(baseUrl, vaccine)
            .then(response => { navigate("/vaccines"); })
            .catch(error => { console.log(error) })
    }
    return (
        <Form className='card border-light p-4' onSubmit={(e) => submitForm(e)}>
            <legend className='text-center mb-5'>Registro de novas vacinas</legend>
            <Row>
                <Col md={6}>
                    <FormGroup>
                        <Label for="type">Tipo</Label>
                        <Input id="type" name="type" type="select" onChange={(e) => handleChange(e, undefined)}>
                            <option value={0}>
                                Nacional
                            </option>
                            <option value={1}>
                                Anti Rabica
                            </option>
                            <option value={2}>
                                BCG de contato
                            </option>
                            <option value={3}>
                                Vacinas Particulares
                            </option>
                            <option value={4}>
                                Outras vacinas
                            </option>
                        </Input>
                    </FormGroup>
                </Col>
                <Col md={6}>
                    <FormGroup>
                        <Label for="name">Nome</Label>
                        <Input name="name" id="name" placeholder="Exemplo: BCG" onChange={(e) => handleChange(e, undefined)} />
                    </FormGroup>
                </Col>
            </Row>
            <FormGroup>
                <Label for="description">Descricao</Label>
                <Input name="description" id="description" placeholder="Exemplo: Vacina indicada para..." onChange={(e) => handleChange(e, undefined)} />
            </FormGroup>
            <Row>
                <Col md={6} >
                    <Card>
                        <CardHeader className="text-center">1 dose</CardHeader>
                        <CardBody>
                            <FormGroup >
                                <Label for="fromAge">
                                    De:
                                </Label>
                                <Input name="fromAge" id="fromAge" placeholder="0" onChange={(e) => handleChange(e, 0)} />
                            </FormGroup>
                            <FormGroup>
                                <Label for="toAge">
                                    Ate:
                                </Label>
                                <Input name="toAge" id="toAge" placeholder="0" onChange={(e) => handleChange(e, 0)} />
                            </FormGroup>
                        </CardBody>
                    </Card>
                </Col>
                <Col md={6} >
                    <Card>
                        <CardHeader className="text-center">2 dose</CardHeader>
                        <CardBody>
                            <FormGroup >
                                <Label for="fromAge">
                                    De:
                                </Label>
                                <Input name="fromAge" id="fromAge" placeholder="0" onChange={(e) => handleChange(e, 1)} />
                            </FormGroup>
                            <FormGroup>
                                <Label for="toAge">
                                    Ate:
                                </Label>
                                <Input name="toAge" id="toAge" placeholder="0" onChange={(e) => handleChange(e, 1)} />
                            </FormGroup>
                        </CardBody>
                    </Card>
                </Col>
            </Row>
            <Button>Salvar</Button>
        </Form>
    );
}
