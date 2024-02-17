import React, { useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

import axios from 'axios';

export const Vaccines = () => {
    const baseUrl = process.env.REACT_APP_API_URL_V1 + "/vaccine";

    const [data, setData] = useState([]);

    const getAll = async () => {
        await axios.get(baseUrl)
            .then(response => {
                setData(response.data.result.$values);
            })
            .catch(error => {
            })
    }

    useEffect(() => {
        getAll();
    }, [])

    return (
        <div className="App">
            <h1>Vacinas</h1>
            <table className='table table-bordered'>
                <thead>
                    <tr>
                        <th>Doses</th>
                        {data.map(vaccine => (
                            <th>{vaccine.name}</th>
                        ))}
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th scope='row'>1ª dose</th>
                        {data.map(vaccine => (
                            <td>
                                {vaccine.doses.$values[0]?.number != undefined &&
                                    `De: ${vaccine.doses.$values[0].fromAge} ate ${vaccine.doses.$values[0].toAge} anos`}
                            </td>
                        ))}
                    </tr>
                    <tr>
                        <th scope='row'>2ª dose</th>
                        {data.map(vaccine => (
                            <td>
                                {vaccine.doses.$values[1]?.number != undefined &&
                                    `De: ${vaccine.doses.$values[1].fromAge} ate ${vaccine.doses.$values[1].toAge} anos`}
                            </td>
                        ))}
                    </tr>
                    <tr>
                        <th scope='row'>3ª dose</th>
                        {data.map(vaccine => (
                            <td>
                                {vaccine.doses.$values[2]?.number != undefined &&
                                    `De: ${vaccine.doses.$values[2].fromAge} ate ${vaccine.doses.$values[2].toAge} anos`}
                            </td>
                        ))}
                    </tr>
                    <tr>
                        <th scope='row'>1ª reforço</th>
                        {data.map(vaccine => (
                            <td>
                                {vaccine.doses.$values[3]?.number != undefined &&
                                    `De: ${vaccine.doses.$values[3].fromAge} ate ${vaccine.doses.$values[3].toAge} anos`}
                            </td>
                        ))}
                    </tr>
                    <tr>
                        <th scope='row'>2ª reforço</th>
                        {data.map(vaccine => (
                            <td>
                                {vaccine.doses.$values[4]?.number != undefined &&
                                    `De: ${vaccine.doses.$values[4].fromAge} ate ${vaccine.doses.$values[4].toAge} anos`}
                            </td>
                        ))}
                    </tr>
                </tbody>
            </table>
        </div>
    );
}