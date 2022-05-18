import React, { useEffect, useState } from 'react';
import axios from 'axios';
import 'antd/dist/antd.css';
import ReactDOM from 'react-dom';
import * as ReactDOMClient from 'react-dom/client';
import ScheduleTable from './scheduleTable'
import AddSchedule from './AddSchedule'
import { Modal, Form, Input, Select } from 'antd';


export function InitializeSchedule() { return App(); }

const App = () => { // компонент для работы с расписанием


    const [schedule, setSchedule] = useState([]);
    const [days, setDays] = useState([]);
    const [shifts, setShifts] = useState([]);
    const [doctors, setDoctors] = useState([]);
    const [doctor, setDoctor] = useState(0);

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


    useEffect(() => { // получение списка смен
        axios({
            "method": "GET",
            "url": "http://localhost:5000/api/Shift/",
            "mode": 'no-cors',
            "headers": {
                "content-type": "application/json",
            }
        })
            .then((response) => {
                setShifts(response.data);
            })
            .catch((response) => {
                if (response.status === 401) {
                    navigate("../../login", { replace: true });
                }
                else {
                    throw new Error("Ошибка получения списка смен");
                }
            });
    }, []);


    useEffect(() => { // получение списка дней
        axios({
            "method": "GET",
            "url": "http://localhost:5000/api/Day/",
            "mode": 'no-cors',
            "headers": {
                "content-type": "application/json",
            }
        })
            .then((response) => {
                setDays(response.data);
            })
            .catch((response) => {
                if (response.status === 401) {
                    navigate("../../login", { replace: true });
                }
                else {
                    throw new Error("Ошибка получения списка дней");
                }
            });
    }, []);

    const SetSchedule = (id) => { // установка расписания при смене доктора
        setDoctor(id); // установка нового текущего доктора
        axios({ // получение доктора по номеру
            "method": "GET",
            "url": "http://localhost:5000/api/Doctor/" + id,
            "mode": 'no-cors',
            "headers": {
                "content-type": "application/json",
            }
        })
            .then((response) => {
                setSchedule(response.data.schedules); // установка расписания доктора
            })
            .catch((response) => {
                if (response.status === 401) {
                    navigate("../../login", { replace: true });
                }
                else {
                    throw new Error("Ошибка получения данных доктора");
                }
            });
    }

    return (
        <div className="container">
            <h1>Доктор</h1>
            
            <Select onChange={SetSchedule} style={{ width: "50%" }}>

                {doctors.map(({ id, fullName }) => (
                    <Select.Option value={id} key={id}>{fullName}</Select.Option>
                ))}
                </Select>
             
            <AddSchedule
                schedule={schedule}
                setSchedule={setSchedule}
                shifts={shifts}
                days={days}
                doctorid={doctor}
            />
                
            <ScheduleTable
            schedule={schedule}
                setSchedule={setSchedule}
                shifts={shifts}
                days={days} />
        </div>
    );
};