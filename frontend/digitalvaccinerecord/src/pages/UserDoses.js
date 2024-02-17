import React, { useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

import axios from 'axios';
import { Button, Modal, ModalBody, ModalFooter, ModalHeader, Form, FormGroup, Label, Input, FormText } from 'reactstrap';
import { BrowserRouter as Router, Routes, Route, Link, useParams } from 'react-router-dom'
import moment from 'moment';

function Dose({ vaccine, userData, index, openAndCloseModal }) {
    var refValue = vaccine.userDoses?.$values[index]?.$ref;
    if (refValue !== undefined && refValue !== null) {
        var dose = userData.userDoses.$values.filter(dose => dose.$id == refValue)[0];

        return <td key={dose.id}>
            {`Data: ${moment(dose.date).format('DD/MM/YYYY')}`} <br />
            {`Enfermeira: ${dose.nurseSignature}`}
        </td>;
    }
    var currentDose = vaccine.vaccine.doses.$values[index];

    if (currentDose !== undefined && currentDose !== null) {
        var previousDose = vaccine.userDoses?.$values[index - 1]?.$ref
        return <td key={currentDose.id}>
            <Button className='btn-success' onClick={(e) => openAndCloseModal(currentDose.id)} disabled={(previousDose == null || previousDose == undefined) && index != 0}>Adiconar dose</Button>
        </td>;
    }
    else
        return <td key={vaccine.id + "_" + index}></td>
}

export const Records = () => {
    const baseUrl = process.env.REACT_APP_API_URL_V1;
    let { id } = useParams();

    const [userData, setUserData] = useState([]);
    const [userDoseData, setuserDoseData] = useState({
        date: '',
        nurseSignature: '',
        userId: userData.id,
        doseId: ''
    });
    const [includeModal, setIncludeModal] = useState(false);
    const [filter, setFilter] = useState(0);
    const toggle = () => {
        setIncludeModal(!includeModal);}

    const openAndCloseModal = (doseId) => {
        userDoseData.doseId = doseId;
        setIncludeModal(!includeModal);
    }

    const getRecords = async () => {
        await axios.get(baseUrl + "/user/" + id)
            .then(response => {
                setUserData(response.data);
            })
            .catch(error => {
                console.log(error);
            })
    }

    const handleChanges = e => {
        const { target } = e;
        const { name } = target;
        const value = target.value;

        setuserDoseData({
            ...userDoseData,
            [name]: value
        });
    }

    async function submitDose(e) {
        e.preventDefault();
        userDoseData.userId = userData.id;
        await axios.post(baseUrl + "/user/dose", userDoseData)
            .then(response => {
                openAndCloseModal();
                window.location.reload(false);
            })
            .catch(error => { console.log(error) })
    }

    useEffect(() => {
        getRecords();
    }, [])

    return (
        <div className="App">
            <h1>Carteira Nacional de Vacinacao</h1>
            <table className='table table-bordered'>
                <thead>
                    <tr>
                        <th>Doses</th>
                        {userData.userVaccines?.$values.map(userVaccine => (
                            <th key={userVaccine.id}>{userVaccine.vaccine.name}</th>
                        ))}
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope='row'>1ª dose</th>
                        {userData.userVaccines?.$values.map(userVaccine => (
                            <Dose index={0} userData={userData} vaccine={userVaccine} openAndCloseModal={openAndCloseModal} />
                        ))}
                    </tr>
                    <tr>
                        <th scope='row'>2ª dose</th>
                        {userData.userVaccines?.$values.map(userVaccine => (
                            <Dose index={1} userData={userData} vaccine={userVaccine} openAndCloseModal={openAndCloseModal} />
                        ))}
                    </tr>
                    <tr>
                        <th scope='row'>3ª dose</th>
                        {userData.userVaccines?.$values.map(userVaccine => (
                            <Dose index={2} userData={userData} vaccine={userVaccine} openAndCloseModal={openAndCloseModal} />
                        ))}
                    </tr>
                    <tr>
                        <th scope='row'>1ª reforço</th>
                        {userData.userVaccines?.$values.map(userVaccine => (
                            <Dose index={3} userData={userData} vaccine={userVaccine} openAndCloseModal={openAndCloseModal} />
                        ))}
                    </tr>
                    <tr>
                        <th scope='row'>2ª reforço</th>
                        {userData.userVaccines?.$values.map(userVaccine => (
                            <Dose index={4} userData={userData} vaccine={userVaccine} openAndCloseModal={openAndCloseModal} />
                        ))}
                    </tr>
                </tbody>
            </table>
            <Modal isOpen={includeModal} toggle={toggle}>
                <ModalHeader toggle={toggle}>Incluir dose</ModalHeader>
                <ModalBody>
                    <Form className="form" onSubmit={(e) => submitDose(e)}>
                        <FormGroup>
                            <Label for="date">Data da dose</Label>
                            <Input type="date" name="date" id="date" onChange={handleChanges} />
                        </FormGroup>
                        <FormGroup>
                            <Label for="nurseSignature">Assinatura enfermeiro(a)</Label>
                            <Input name="nurseSignature" id="nurseSignature" placeholder="Assinatura" onChange={handleChanges} />
                        </FormGroup>
                        <ModalFooter>
                            <Button color="success" type='submit'>
                                Salvar
                            </Button>{' '}
                            <Button color="secondary" onClick={toggle}>
                                Cancel
                            </Button>
                        </ModalFooter>
                    </Form>
                </ModalBody>

            </Modal>
        </div>
    );
}