import axios from 'axios';
import React, { useState } from 'react';
import { Button, Form, FormGroup, Label, Input, Row, Col, Card, CardHeader, CardBody } from 'reactstrap';
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
        if (index >= 0) {
            if (vaccine.doses[index]) {
                vaccine.doses[index][name] = value;
            } else {
                var dose = { [name]: value };
                vaccine.doses.push(dose);
            }
        }
        setVaccine({
            ...vaccine,
            [name]: value
        });

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
            .catch(error => {  })
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
                <Label for="description">Descrição</Label>
                <Input name="description" id="description" placeholder="Exemplo: Vacina indicada para..." onChange={(e) => handleChange(e, undefined)} />
            </FormGroup>
            <Row>
                <Col md={6} >
                    <Card className='mb-4'>
                        <CardHeader className="text-center">1ª dose (faixa etária em anos)</CardHeader>
                        <CardBody>
                            <FormGroup >
                                <Label for="fromAge">
                                    De:
                                </Label>
                                <Input name="fromAge" id="fromAge" placeholder="0" onChange={(e) => handleChange(e, 0)} />
                            </FormGroup>
                            <FormGroup>
                                <Label for="toAge">
                                    Até:
                                </Label>
                                <Input name="toAge" id="toAge" placeholder="0" onChange={(e) => handleChange(e, 0)} />
                            </FormGroup>
                        </CardBody>
                    </Card>
                </Col>
                <Col md={6} >
                    {vaccine.doses[0] != undefined
                        && vaccine.doses[0].fromAge != undefined
                        && vaccine.doses[0].toAge != undefined
                        && <Card className='mb-4'>
                            <CardHeader className="text-center">2ª dose (faixa etária em anos)</CardHeader>
                            <CardBody>
                                <FormGroup >
                                    <Label for="fromAge">
                                        De:
                                    </Label>
                                    <Input name="fromAge" id="fromAge" placeholder="0" onChange={(e) => handleChange(e, 1)} />
                                </FormGroup>
                                <FormGroup>
                                    <Label for="toAge">
                                        Até:
                                    </Label>
                                    <Input name="toAge" id="toAge" placeholder="0" onChange={(e) => handleChange(e, 1)} />
                                </FormGroup>
                            </CardBody>
                        </Card>}
                </Col>
                <Col md={6} >
                    {vaccine.doses[1] != undefined
                        && vaccine.doses[1].fromAge != undefined
                        && vaccine.doses[1].toAge != undefined
                        &&
                        <Card className='mb-4'>
                            <CardHeader className="text-center">3ª dose (faixa etária em anos)</CardHeader>
                            <CardBody>
                                <FormGroup >
                                    <Label for="fromAge">
                                        De:
                                    </Label>
                                    <Input name="fromAge" id="fromAge" placeholder="0" onChange={(e) => handleChange(e, 2)} />
                                </FormGroup>
                                <FormGroup>
                                    <Label for="toAge">
                                        Até:
                                    </Label>
                                    <Input name="toAge" id="toAge" placeholder="0" onChange={(e) => handleChange(e, 2)} />
                                </FormGroup>
                            </CardBody>
                        </Card>}
                </Col>
            </Row>
            <Row>
                <Col md={6} >
                    {vaccine.doses[2] != undefined
                        && vaccine.doses[2].fromAge != undefined
                        && vaccine.doses[2].toAge != undefined
                        &&
                        <Card className='mb-4'>
                            <CardHeader className="text-center">1ª dose de reforço (faixa etária em anos)</CardHeader>
                            <CardBody>
                                <FormGroup >
                                    <Label for="fromAge">
                                        De:
                                    </Label>
                                    <Input name="fromAge" id="fromAge" placeholder="0" onChange={(e) => handleChange(e, 3)} />
                                </FormGroup>
                                <FormGroup>
                                    <Label for="toAge">
                                        Até:
                                    </Label>
                                    <Input name="toAge" id="toAge" placeholder="0" onChange={(e) => handleChange(e, 3)} />
                                </FormGroup>
                            </CardBody>
                        </Card>}
                </Col>
                <Col md={6} >
                    {vaccine.doses[3] != undefined
                        && vaccine.doses[3].fromAge != undefined
                        && vaccine.doses[3].toAge != undefined
                        &&
                        <Card className='mb-4'>
                            <CardHeader className="text-center">2ª dose de reforço (faixa etária em anos)</CardHeader>
                            <CardBody>
                                <FormGroup >
                                    <Label for="fromAge">
                                        De:
                                    </Label>
                                    <Input name="fromAge" id="fromAge" placeholder="0" onChange={(e) => handleChange(e, 4)} />
                                </FormGroup>
                                <FormGroup>
                                    <Label for="toAge">
                                        Até:
                                    </Label>
                                    <Input name="toAge" id="toAge" placeholder="0" onChange={(e) => handleChange(e, 4)} />
                                </FormGroup>
                            </CardBody>
                        </Card>}
                </Col>
            </Row>
            <Button color='success'>Salvar</Button>
        </Form>
    );
}
