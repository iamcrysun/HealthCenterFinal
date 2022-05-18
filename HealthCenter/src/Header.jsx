import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import * as ReactDOMClient from 'react-dom/client';
import picture from './images/bootstrap.svg';
import { useNavigate, NavLink } from "react-router-dom"
import axios from 'axios';

var navigate;

const Header = () => { // шапка без навигации
    navigate = useNavigate();
    return (<div className="px-3 py-2 bg-light text-black">
        <div className="container">
            <div className="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
                <a href="/" className="d-flex align-items-center my-2 my-lg-0 me-lg-auto text-white text-decoration-none">
                    <img className="bi me-2" src={picture} alt="Bootstrap" width="32" height="32"/>
                        <span className="fs-4 text-black">Регистратура</span>
                </a>
                
            </div>
            </div>
        </div>
    );
}

const AdminHeader = () => { // шапка с навигацией администратора
    navigate = useNavigate();
    return (<div className="px-3 py-2 bg-light text-black">
        <div className="container">
            <div className="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
                <a href="/" className="d-flex align-items-center my-2 my-lg-0 me-lg-auto text-white text-decoration-none">
                    <img className="bi me-2" src={picture} alt="Bootstrap" width="32" height="32" />
                    <span className="fs-4 text-black">Регистратура</span>
                </a>
                <ul className="nav col-12 col-lg-auto my-2 justify-content-center my-md-0 text-small">
                    <li>
                        <NavLink to={'/admin/patient'} className="nav-link text-black">
                            Пациенты
                        </NavLink>
                    </li>
                    <li>
                        <NavLink to={'/admin/doctor'} className="nav-link text-black">
                            Аккаунты докторов
                        </NavLink>
                    </li>
                    <li>
                        <NavLink to={'/admin/schedule'} className="nav-link text-black">
                            Расписание
                        </NavLink>
                    </li>
                    <li>
                        <a className="nav-link text-black" onClick={Exit}>
                            Выход
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    );
}

const UserHeader = () => { // шапка с навигацией для пациента
    navigate = useNavigate();
    return (<div className="px-3 py-2 bg-light text-black">
        <div className="container">
            <div className="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
                <a href="/" className="d-flex align-items-center my-2 my-lg-0 me-lg-auto text-white text-decoration-none">
                    <img className="bi me-2" src={picture} alt="Bootstrap" width="32" height="32" />
                    <span className="fs-4 text-black">Запись на прием</span>
                </a>
                <ul className="nav col-12 col-lg-auto my-2 justify-content-center my-md-0 text-small">
                    <li>
                        <NavLink to={'/user/registration'} className="nav-link text-black">
                            Запись
                        </NavLink>
                    </li>
                    <li>
                        <NavLink to={'/user/record'} className="nav-link text-black">
                            Карта
                        </NavLink>
                    </li>
                    <li>
                        <a className="nav-link text-black" onClick={Exit}>
                            Выход
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    );
}

const DoctorHeader = () => { // шапка с навигацией для доктора
    navigate = useNavigate();
    return (<div className="px-3 py-2 bg-light text-black">
        <div className="container">
            <div className="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
                <a href="/" className="d-flex align-items-center my-2 my-lg-0 me-lg-auto text-white text-decoration-none">
                    <img className="bi me-2" src={picture} alt="Bootstrap" width="32" height="32" />
                    <span className="fs-4 text-black">Результаты приема</span>
                </a>
                <ul className="nav col-12 col-lg-auto my-2 justify-content-center my-md-0 text-small">
                    <li>
                        <a className="nav-link text-black" onClick={Exit}>
                            Выход
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    );
}

const Exit = () => { // выход из аккаунта
    axios.post('http://localhost:5000/api/Account/' + 'LogOff', {}, { withCredentials: true })
        .then((response) => {
            if (response.status == 200) {
                navigate("../login", { replace: true });
            }
        })
        .catch((response) => {
            throw new Error("Ошибка выхода из аккаунта");
        });
}

export function InitializeHeader() { return Header(); }
export function InitializeDoctorHeader() { return DoctorHeader(); }
export function InitializeUserHeader() { return UserHeader(); }
export function InitializeAdminHeader() { return AdminHeader(); }