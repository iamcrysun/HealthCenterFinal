import React, { useEffect, useState } from 'react';
import 'antd/dist/antd.css';
import { Modal, Form, Input, Select } from 'antd';
import axios from 'axios';

const uri = "http://localhost:5000/api/Schedule/";


const AddSchedule = ({ schedule, setSchedule, shifts, days, doctorid }) => { // компонент добавления строки расписания
    const [isModalVisible, setIsModalVisible] = useState(false); // модальное окно добавления
    const [form] = Form.useForm();

    const showModal = () => { // показать модальное окно
        setIsModalVisible(true);
    };

    const handleOk = () => { // закрыть окно
        setIsModalVisible(false);
    };

    const handleCancel = () => { // закрыть окно
        setIsModalVisible(false);
    };

    const addSchedule = (newschedule) => setSchedule([...schedule, newschedule]); // добавление нового элемента в расписание

    let shiftsFilter = []; // перевод смен в формат для фильтра
    for (let i = 0; i < shifts.length; i++) {
        shiftsFilter[i] = {
            text: shifts[i].timeofBegin + "-" + shifts[i].timeofEnd,
            value: shifts[i].id,
        }
    }

    const handleSubmit = (e) => { // отправка запроса на добавление
        handleOk(); // закрытие окна
        let newshift = shifts.filter(i => i.id === e.shift)[0]; // смена
        let newday = days.filter(i => i.id === e.day)[0]; // день недели
        // отправка запроса
        axios.post(uri, { doctorId: doctorid, room: e.room, shift: newshift, dayofWeekNavigation: newday }, { withCredentials: true })
            .then((response) => {
                // если успех, то добавляем в список
                response.status = 201 ? addSchedule(response.data) : null;
            })
            .catch((response) => {
                if (response.status === 401) {
                    navigate("../../login", { replace: true });
                }
                else {
                    throw new Error("Ошибка добавления строки расписания");
                }
            });
    };

    return (
        <div>
            <br />
            <button onClick={showModal} className="btn btn-success mb-1">Создать</button>
            <Modal title="Добавить рабочую смену" visible={isModalVisible} onOk={form.submit} onCancel={handleCancel}>
                <Form form={form} onFinish={handleSubmit}>
                    <Form.Item
                        label="Кабинет"
                        name="room"
                        rules={[
                            {
                                required: true,
                                message: 'Введите кабинет',
                            },
                        ]}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item
                        name="shift"
                        label="Смена"
                        rules={[
                            {
                                required: true,
                                message: 'Выберите смену!',
                            },
                        ]}
                    >
                        <Select>
                            {shiftsFilter.map(({ value, text }) => (
                                <Select.Option key={value} value={value}>{text}</Select.Option>
                            ))}
                        </Select>
                    </Form.Item>

                    <Form.Item
                        name="day"
                        label="День недели"
                        rules={[
                            {
                                required: true,
                                message: 'Выберите день недели!',
                            },
                        ]}
                    >
                        <Select>
                            {days.map(({ id, dayOfWeek }) => (
                                <Select.Option key={id} value={id}>{dayOfWeek}</Select.Option>
                            ))}
                        </Select>
                    </Form.Item>

                </Form>
            </Modal>
        </div>
    );
};

export default AddSchedule;