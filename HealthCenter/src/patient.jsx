import React, { useEffect, useState } from 'react';
import { Table, Space } from 'antd'
import 'antd/dist/antd.css';
import axios from 'axios';

const PatientTable = () => { // добавление аккаунтов пациентов

    const [patients, setPatients] = useState();

    useEffect(() => {
        axios.defaults.withCredentials = true;

        axios.post('http://localhost:5000/api/Account/' + 'checkRole') // проверка роли
            .then((response) => {
                if (response.status == 200) {
                    if (response.data.role !== "admin") {
                        navigate("../../login", { replace: true });
                    }
                }
            })
            .catch((response) => {
                throw new Error("Ошибка проверки роли");
            });

        axios({ // получение списка пациентов
            "method": "GET",
            "url": "http://localhost:5000/api/Patient/",
            "mode": 'no-cors',
            "headers": {
                'Access-Control-Allow-Origin': "http://localhost:5000",
                'Access-Control-Allow-Credentials': "true",
                "content-type": "application/json",
            }
        })
            .then((response) => {
                setPatients(response.data);
            })
            .catch((response) => {
                if (response.status === 401) {
                    navigate("../../login", { replace: true });
                }
                else {
                    throw new Error("Ошибка получения списка пациентов");
                }
            });
    }, []);

    const updatePatient = (reg) => { // обновление почты пациента
        let buffer = Object.assign([], patients);
        buffer.filter(item => item.id === Number(reg.id))[0].email = reg.email;
        setPatients(buffer);
    };

    const handleSubmit = (e) => { // отправка обновленной почты
        e.preventDefault();
        let reg = { email: e.target.email.value, password: e.target.password.value, id: e.target.id, role: 'user' };
        axios.post("http://localhost:5000/api/Account/" + 'Register', reg, { withCredentials: true })
            .then((response) => {
                if (response.status == 200) {
                    updatePatient(reg);
                }
            })
            .catch((response) => {
                if (response.status === 401) {
                    navigate("../../login", { replace: true });
                }
                else {
                    throw new Error("Ошибка добавления почты");
                }
            });
    };

    const columns = [
        {
            title: 'ФИО',
            dataIndex: 'fullName',
            key: 'fullName',
        },
        {
            title: 'Почта',
            dataIndex: 'email',
            key: 'email',
            render: (email, record) => <div>
                <form id={record.id} onSubmit={handleSubmit} />
                {email === "" ? <input name="email" form={record.id}></input> :
                    <label>{email}</label>}</div>
        },
        {
            title: 'Пароль',
            dataIndex: 'email',
            key: 'password',
            render: (email, record) => <div>{email === "" ? <input name="password" form={record.id}
            ></input> :
                <label>Уже назначен</label>}</div>
        },
        {
            title: 'Действия',
            key: 'action',
            render: (value, record) => (
                <Space size="middle">
                    <div>{record.email === "" ? <button form={record.id} type="submit" name="submit"
                        className="btn btn-warning">Зарегистрировать</button> :
                        null}
                    </div>
                </Space>
            ),
        },
    ];

    return (
        <div className="container">
            <Table dataSource={patients} columns={columns} />
        </div>
    );
}


export default PatientTable;