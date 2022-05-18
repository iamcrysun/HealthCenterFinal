import React from 'react';
import * as ReactDOMClient from 'react-dom/client';
import ReactDOM from 'react-dom';
import { BrowserRouter } from "react-router-dom";
import { InitializeFooter } from './footer.jsx';
import Nav from './navigation'
import ErrorBoundary from './errorBoundary'

const appRoot = ReactDOMClient.createRoot(document.getElementById('app')); // начальная страница

{
    appRoot.render(<BrowserRouter> {/*навигация*/}
        <ErrorBoundary> {/*обработка исключений*/}
            <Nav /><InitializeFooter />
        </ErrorBoundary>
    </BrowserRouter>);
}