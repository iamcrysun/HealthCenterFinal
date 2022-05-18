import React, { useEffect, useState } from 'react';
import { Table, Space } from 'antd'
import 'antd/dist/antd.css';
import axios from 'axios';
import { SetOption } from './helpful'

const EDoctorTable = () => { // добавление аккаунтов докторов

    const [doctors, setDoctors] = useState();

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

        axios({ // получение списка докторов
            "method": "GET",
            "url": "http://localhost:5000/api/Doctor/",
            "mode": 'no-cors',
            "headers": {
                'Access-Control-Allow-Origin': "http://localhost:5000",
                'Access-Control-Allow-Credentials': "true",
                "content-type": "application/json",
            }
        })
            .then((response) => {
                setDoctors(response.data);
            })
            .catch((response) => {
                if (response.status === 401) {
                    navigate("../../login", { replace: true });
                }
                else {
                    throw new Error("Ошибка получения списка докторов");
                }
            });
    }, []);

    const updateDoctor = (reg) => { // обновление почты доктора
        let buffer = Object.assign([], doctors);
        buffer.filter(item => item.id === Number(reg.id))[0].email = reg.email;
        setDoctors(buffer);
    };

    const handleSubmit = (e) => { // сохранение в базе почты доктора
        e.preventDefault();
        let reg = { email: e.target.email.value, password: e.target.password.value, id: e.target.id, role: 'doctor' };
        axios.post("http://localhost:5000/api/Account/" + 'Register', reg, { withCredentials: true })
            .then((response) => {
                if (response.status == 200) {
                    updateDoctor(reg);
                }
            })
            .catch((response) => {
                if (response.status === 401) {
                    navigate("../../login", { replace: true });
                }
                else {
                    throw new Error("Ошибка сохранения почты");
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
            title: 'Специализация',
            dataIndex: 'specialization',
            key: 'specialization',
            render: specialization => <label>{specialization.specializationName}</label>
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
            <Table dataSource={doctors} columns={columns} />
        </div>
    );
}


export default EDoctorTable;