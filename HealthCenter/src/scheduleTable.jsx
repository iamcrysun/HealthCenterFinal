import React, { useEffect, useState } from 'react';
import { Table, Space } from 'antd'
import 'antd/dist/antd.css';
import axios from 'axios';
import { SetOption } from './helpful'

const uri = "http://localhost:5000/api/Schedule/";

const ScheduleTable = ({ schedule, setSchedule, shifts, days }) => { // таблица расписания

    let daysFilter = []; // перевод списка дней в список для фильтрации
    for (let i = 0; i < days.length; i++) {
        daysFilter[i] = {
            text: days[i].dayOfWeek,
            value: days[i].id,
        }
    }

    let shiftsFilter = []; // перевод списка смен в список для фильтрации
    for (let i = 0; i < shifts.length; i++) {
        shiftsFilter[i] = {
            text: shifts[i].timeofBegin + "-" + shifts[i].timeofEnd,
            value: shifts[i].id,
        }
    }

    const removeSchedule = (id) => { // удаление строки расписания
        let buffer = Object.assign([], schedule);
        setSchedule(buffer.filter(item => item.id !== id));
    };

    const deleteItem = (id) => { // отправка запроса на удаление
        axios.delete(uri + id)
            .then((response) => {
                response.status = 204 ? removeSchedule(id) : null;
            })
            .catch((response) => {
                if (response.status === 401) {
                    navigate("../../login", { replace: true });
                }
                else {
                    throw new Error("Ошибка удаления строки расписания");
                }
            });
    };

    const updateSchedule = (newSchedule) => { // обновление строки расписания
        let buffer = Object.assign([], schedule);
        buffer.filter(item => item.id === newSchedule.id)[0].dayofWeekNavigation = newSchedule.dayofWeekNavigation;
        buffer.filter(item => item.id === newSchedule.id)[0].shift = newSchedule.shift;
        buffer.filter(item => item.id === newSchedule.id)[0].room = newSchedule.room;
        setSchedule(buffer);
    };

    const HandleSubmit = (e) => { // отправка запроса на обновление
        e.preventDefault();
        let newSchedule = schedule.filter(item => item.id == e.target.id)[0];
        newSchedule.dayofWeekNavigation = days.filter(item => item.id == e.target.elements.dayofWeekNavigation.value)[0];
        newSchedule.shift = shifts.filter(item => item.id == e.target.elements.shift.value)[0];
        newSchedule.room = e.target.elements.room.value;
        axios.put(uri + newSchedule.id, newSchedule)
            .then((response) => {
                response.status = 201 ? updateSchedule(newSchedule) : null;
            })
            .catch((response) => {
                if (response.status === 401) {
                    navigate("../../login", { replace: true });
                }
                else {
                    throw new Error("Ошибка обновления строки расписания");
                }
            });
    };

    const RoomChanged = event => { // смена комнаты, необходимо, т.к. value привязано к schedule.room 
        let buffer = Object.assign([], schedule);
        buffer.filter(item => item.id == event.target.form.id)[0].room = event.target.room;
        setSchedule(buffer);
    }

    const columns = [
        {
            title: 'День недели',
            dataIndex: 'dayofWeekNavigation',
            key: 'dayofWeekNavigation',
            filters: daysFilter,
            onFilter: (value, record) => record.dayofWeekNavigation.id == value,
            sorter: (a, b) => a.dayofWeekNavigation.id - b.dayofWeekNavigation.id,
            render: (value, record) => <select form={record.id} name="dayofWeekNavigation">
                {days.map(({ id, dayOfWeek }) => (
                    <SetOption
                        value={id}
                        text={dayOfWeek}
                        id={record.dayofWeekNavigation.id}/>
                ))}
            </select>,
        },
        {
            title: 'Кабинет',
            dataIndex: 'room',
            key: 'room',
            render: (room, record) => <div><form id={record.id} onSubmit={HandleSubmit} />
                <input name="room" form={record.id} value={room} onChange={ RoomChanged } /></div>
        },
        {
            title: 'Смена',
            dataIndex: 'shift',
            key: 'shift',
            filters: shiftsFilter,
            onFilter: (value, record) => record.shift.id == value,
            sorter: (a, b) => a.shift.id - b.shift.id,
            render: (value, record) => <select form={record.id} name="shift">
                {shiftsFilter.map(({ value, text }) => (
                    <SetOption
                        value={value}
                        text={text}
                        id={record.shift.id} />
                ))}
            </select>,
        },
        {
            title: 'Действия',
            key: 'action',
            render: (value, record) => (
                <Space size="middle">
                    <button form={record.id} type="submit" name="submit" className="btn btn-warning">Обновить</button>
                    <button className='btn btn-danger' onClick={(e) => deleteItem(record.id)}>Удалить</button>
                </Space>
            ),
        },
    ];

    return (
        <React.Fragment>
            <Table dataSource={schedule} columns={columns} />
        </React.Fragment>
    );
}


export default ScheduleTable;