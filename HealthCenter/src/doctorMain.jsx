import React from 'react';
import * as ReactDOMClient from 'react-dom/client';
import ReactDOM from 'react-dom';
import { Route, Routes } from "react-router-dom"
import { InitializeDoctorHeader } from "./Header"
import { InitializeSchedule } from "./schedule"
import DoctorTable from './doctor';

const DoctorMain = () => { // навигация для доктора
    return (<React.Fragment>
        <InitializeDoctorHeader />
        <Routes>
            <Route path='/*' element={<DoctorTable />} />
        </Routes>
    </React.Fragment>);
}

export default DoctorMain;