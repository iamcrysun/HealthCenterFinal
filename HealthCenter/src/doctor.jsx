import React, { useEffect, useState } from 'react';
import { Table, Space } from 'antd'
import 'antd/dist/antd.css';
import axios from 'axios';

const DoctorTable = () => { // проведение приемов

    const [sees, setSees] = useState();

    useEffect(() => { // получение списка приемов
        axios.defaults.withCredentials = true;

        axios.post('http://localhost:5000/api/Account/' + 'checkRole') // проверка роли
            .then((response) => {
                if (response.status == 200) {
                    if (response.data.role !== "doctor") {
                        navigate("../../login", { replace: true });
                    }
                }
            })
            .catch((response) => {
                throw new Error("Ошибка проверки роли");
            });

        axios({
            "method": "GET",
            "url": "http://localhost:5000/api/See/",
            "mode": 'no-cors',
            "headers": {
                'Access-Control-Allow-Origin': "http://localhost:5000",
                'Access-Control-Allow-Credentials': "true",
                "content-type": "application/json",
            }
        })
            .then((response) => {
                setSees(response.data);
            })
            .catch((response) => {
                if (response.status === 401) {
                    navigate("../../login", { replace: true });
                }
                else {
                    throw new Error("Ошибка получения списка приемов");
                }
            });
    }, []);

    const removeSee = (id) => { // удаление непосещенного приема
        let buffer = Object.assign([], sees);
        setSees(buffer.filter(item => item.id !== Number(id)));
    };

    const deleteItem = (id) => { // отправка запроса на удаление непосещенного према
        axios.delete("http://localhost:5000/api/See/" + id)
            .then((response) => {
                response.status = 200 ? removeSee(id) : null;
            })
            .catch((response) => {
                if (response.status === 401) {
                    navigate("../../login", { replace: true });
                }
                else {
                    throw new Error("Ошибка закрытия приема");
                }
            });
    };

    const handleSubmit = (e) => { // отправка данных о результатах приема
        e.preventDefault();
        let buf = sees.filter(i => i.id === Number(e.target.id))[0].patientId;
        let reg = {
            doctorId: sees[0].doctorId, patientId : buf,
            result: e.target.naz.value, diagnosis: e.target.diag.value
        };
        axios.put("http://localhost:5000/api/See/" + e.target.id, reg, { withCredentials: true })
            .then((response) => {
                if (response.status == 200) {
                    e.target.diag.value = ""; // иначе перейдет на следующую запись
                    e.target.naz.value = "";
                    removeSee(e.target.id);
                }
            })
            .catch((response) => {
                if (response.status === 401) {
                    navigate("../../login", { replace: true });
                }
                else {
                    throw new Error("Ошибка добавления остановки");
                }
            });
    };

    const columns = [
        {
            title: 'ФИО',
            dataIndex: 'name',
            key: 'name',
        },
        {
            title: 'Дата и время',
            dataIndex: 'dateTime',
            key: 'dateTime',
            render: value => <label>{value.replace('T', ' ')}</label>
        },
        {
            title: 'Диагноз',
            dataIndex: 'diag',
            key: 'diag',
            render: (value, record) => <form id={record.id} onSubmit={handleSubmit}>
                <input name="diag" form={record.id} /></form>
        },
        {
            title: 'Назначение',
            dataIndex: 'naz',
            key: 'naz',
            render: (value, record) => <textarea name="naz" form={record.id} rows="5"/>
        },
        {
            title: 'Действия',
            key: 'action',
            render: (value, record) => (
                <Space size="middle">
                    <button form={record.id} type="submit" name="submit" className="btn btn-warning">Записать</button>
                    <button className='btn btn-danger' onClick={(e) => deleteItem(record.id)}>Не пришел</button>
                </Space>
            ),
        },
    ];

    return (
        <div className="container">
            <Table dataSource={sees} columns={columns} />
        </div>
    );
}


export default DoctorTable;