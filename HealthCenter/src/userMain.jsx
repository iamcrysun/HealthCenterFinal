import React from 'react';
import * as ReactDOMClient from 'react-dom/client';
import ReactDOM from 'react-dom';
import { Route, Routes } from "react-router-dom"
import { InitializeUserHeader } from "./Header"
import { InitializeSchedule } from "./schedule"
import DoctorTable from './doctor';
import Registration from './registration';
import Record from './record';

const UserMain = () => { // навигация для пациента
    return (<React.Fragment>
        <InitializeUserHeader />
        <Routes>
            <Route path='/registration' element={<Registration />} />
            <Route path='/record' element={<Record />} />
            <Route path='/*' element={<Registration />} />
        </Routes>
    </React.Fragment>);
}

export default UserMain;