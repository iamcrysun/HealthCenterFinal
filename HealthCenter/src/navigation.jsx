import React from 'react';
import * as ReactDOMClient from 'react-dom/client';
import ReactDOM from 'react-dom';

import { Route, Routes } from "react-router-dom"
import { InitializeHeader } from "./Header"
import Login from "./login"
import AdminMain from './adminMain'
import UserMain from './userMain'
import DoctorMain from './doctorMain';


const Nav = () => { // основное окно программы
    return (<React.Fragment>
        <Routes> { /*навигация*/}
            <Route path="/admin/*" element={<AdminMain />} />
            <Route path='/user/*' element={<UserMain />} />
            <Route path='/doctor/*' element={<DoctorMain />} />
            <Route path='/*' element={<div> <InitializeHeader /> <Login /> </div>} />
        </Routes>
    </React.Fragment>);
}

export default Nav;