import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import * as ReactDOMClient from 'react-dom/client';
import picture from './images/bootstrap.svg';

const Footer = () => { // футер для сайта
    return (<div className="container"><footer className="d-flex flex-wrap justify-content-between align-items-center py-3 my-4 border-top">
        <div className="col-md-4 d-flex align-items-center">
            <a href="/" className="mb-3 me-2 mb-md-0 text-muted text-decoration-none lh-1">
                <img className="bi" src={picture} alt="Bootstrap" width="32" height="32"/>
                </a>
                <span className="text-muted">© 2022 Адамова А.А. 3-41</span>
            </div>
    </footer>
        </div>
        );
}

export function InitializeFooter() { return Footer(); }