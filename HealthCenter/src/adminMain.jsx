import React from 'react';
import * as ReactDOMClient from 'react-dom/client';
import ReactDOM from 'react-dom';
import { Route, Routes } from "react-router-dom"
import { InitializeAdminHeader } from "./Header"
import { InitializeSchedule } from "./schedule"
import EDoctorTable from './edoctor';
import PatientTable from './patient';

const AdminMain = () => { // навигация для администратора
    return (<React.Fragment>
        <InitializeAdminHeader />
        <Routes>
            <Route path='/doctor' element={<EDoctorTable />} />
            <Route path='/patient' element={<PatientTable />} />
            <Route path='/schedule' element={<InitializeSchedule />} />
            <Route path='/*' element={<InitializeSchedule />} />
        </Routes>
    </React.Fragment>);
}

export default AdminMain;