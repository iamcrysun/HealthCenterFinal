import React, { useEffect, useState } from 'react';
import { Table, Space } from 'antd'
import 'antd/dist/antd.css';
import axios from 'axios';

const Record = () => { // получение карты пациента

    const [records, setRecord] = useState();

    useEffect(() => {
        axios.defaults.withCredentials = true;

        axios.post('http://localhost:5000/api/Account/' + 'checkRole') // проверка роли
            .then((response) => {
                if (response.status == 200) {
                    if (response.data.role !== "user") {
                        navigate("../../login", { replace: true });
                    }
                }
            })
            .catch((response) => {
                throw new Error("Ошибка проверки роли");
            });

        axios.defaults.withCredentials = true;
        axios({ // получение карты пациента
            "method": "GET",
            "url": "http://localhost:5000/api/Record/",
            "mode": 'no-cors',
            "headers": {
                'Access-Control-Allow-Origin': "http://localhost:5000",
                'Access-Control-Allow-Credentials': "true",
                "content-type": "application/json",
            }
        })
            .then((response) => {
                setRecord(response.data);
            })
            .catch((response) => {
                if (response.status === 401) {
                    navigate("../../login", { replace: true });
                }
                else {
                    throw new Error("Ошибка получения карты");
                }
            });
    }, []);

    const columns = [
        {
            title: 'Дата',
            dataIndex: 'date',
            key: 'date',
            render: value => <label>{value.replace('T', ' ')}</label>
        },
        {
            title: 'Врач',
            dataIndex: 'doctor',
            key: 'doctor',
            render: value => <label>{value.fullName}</label>
        },
        {
            title: 'Диагноз',
            dataIndex: 'diagnosis',
            key: 'diagnosis',
        },
        {
            title: 'Назначение',
            dataIndex: 'result',
            key: 'result',
            render: (value, record) => <textarea readOnly value={value} rows="5" />
        }
    ];

    return (
        <div className="container">
            <Table dataSource={records} columns={columns} />
        </div>
    );
}


export default Record;