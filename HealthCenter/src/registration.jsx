import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { DatePicker, Space } from 'antd';
import ReactDOM from 'react-dom';
import { useNavigate, NavLink } from 'react-router-dom';
import moment from 'moment';
import { MomentToDate } from './helpful'

const dateFormat = 'DD/MM/YYYY';

export function InitializeHalts() { return App(); }

const Registration = () => { //запись ко врачу
    let navigate = useNavigate();

    const [doctor, setDoctor] = useState(null); // список докторов
    const [specializations, setSpecializations] = useState([]); // 
    const [sSpec, setSpec] = useState(-1); // специализация
    const [times, setTimes] = useState([]); // время
    const [ctimes, setCTimes] = useState(-1); // время
    const [date, setDate] = useState(MomentToDate(moment())); // выбранная дата
    const [days, setDays] = useState("");
    const [msg, setMsg] = useState("");

    axios.post('http://localhost:5000/api/Account/' + 'checkRole', {}, { withCredentials: true })
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

    useEffect(() => { // получение списка специализаций
        axios({
            "method": "GET",
            "url": "http://localhost:5000/api/Specialization/",
            "mode": 'no-cors',
            "headers": {
                "content-type": "application/json",
            }
        })
            .then((response) => {
                setSpecializations(response.data);
            })
            .catch((response) => {
                throw new Error("Ошибка получения списка специализаций");
            });
    }, []);

    useEffect(() => { // установка начальной специализации
        if (specializations.length > 0) {
            setSpec(specializations[0].id);
        }
    }, [specializations]);

    useEffect(() => { // получение доктора и списка доступных дней
        if (sSpec > -1) {
            axios.get('http://localhost:5000/api/Registration/Doctor/' + sSpec, {}, { withCredentials: true })
                .then((response) => {
                    if (response.status == 200) {
                        setDoctor(response.data.doctor);
                        setDays(response.data.days);
                    }
                })
                .catch((response) => {
                    throw new Error("Ошибка проверки роли");
                });
        }
    }, [sSpec]);

    const changeSpec = event => { // смена специализации
        setSpec(event.target.value);
    }

    const selectTime = event => { // смена выбранного времени
        setCTimes(event.target.value);
    }

    const changeDate = event => { // смена даты
        if (moment() < event && event.diff(moment(), 'days') < 15) { // дата выходит за допустимый диапазон
            setDate(MomentToDate(event)); // сброс даты
        }
        else {
            setDate(MomentToDate(moment()));
        }
    }

    useEffect(() => { // получение доступных времен при смене даты
        getTimes();
    }, [date]);

    useEffect(() => { // получение доступных времен при смене доктора
        getTimes();
    }, [doctor]);

    const getTimes = () => { // получение списка доступных времен
        if (doctor !== null) {
            let body = { id : doctor.id, date : date};
            axios.post('http://localhost:5000/api/Registration/Times/', body, { withCredentials: true })
                .then((response) => {
                    if (response.status == 200) {
                        // добавление номера как поле value 
                        let buf = [];
                        for (let i = 0; i < response.data.times.length; i++) {
                            buf[i] = {
                                time: response.data.times[i],
                                value: i,
                            }
                        }
                        setCTimes(0);
                        setTimes(buf);
                    }
                })
                .catch((response) => {
                    throw new Error("Ошибка получения времен");
                });
        }
    }

    const Write = () => { // запись в карту
        if (ctimes > -1 && times.length > 0) {  
            let body = {
                doctorId: doctor.id,
                dateTime: date + "T" + times[ctimes].time,
                visited: false,
                closed: false
            }
            axios.post('http://localhost:5000/api/Registration/Write/', body, { withCredentials: true })
                .then((response) => {
                    if (response.status == 200) {
                        setMsg(response.data);
                        getTimes();
                    }
                })
                .catch((response) => {
                    if (response.status === 401) {
                        navigate("../../login", { replace: true });
                    }
                    else {
                        throw new Error("Ошибка записи в карту");
                    }
                });
        }
    }

    return (
        <div className="container">
            <div className="row">
                <label>Дата приема: </label>
                <DatePicker value={moment(date)} format={dateFormat} onChange={changeDate} />
                <small>*Не более чем на 2 недели вперед</small>
            </div>
            <div className="row">
                <div className="col-6">
                    <label>Специализация врача:&ensp;</label>
                    <select onChange={changeSpec}>{specializations.map(({ id, specializationName }) => (
                        <option key={id} value={id}>{specializationName}</option>
                    ))}</select>
                </div>
                <div className="col-6">
                    <label>Врач: {doctor === null ? '' : doctor.fullName}</label>
                </div>
            </div>
            <p />
            <div className="row">
                <div className="col-6">
                    <label>Время начала приема:&ensp;</label>
                    <select onChange={selectTime} style={{ width: "15%" }}>{times.map(({ value, time }) => (
                        <option key={value} value={value}>{time}</option>
                    ))}</select>
                </div>
                <div className="col-6">
                    <label>Возможные дни: {days}</label>
                </div>
            </div>
            <div className="row">
                <div className="col-5">
                </div>
                <div className="col-2">
                    <button onClick={Write}>Записаться</button>
                </div>
            </div>
            <div>{msg}</div>
        </div>
    );
};

export default Registration;