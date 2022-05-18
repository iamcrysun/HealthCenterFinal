import React, { useEffect, useState } from 'react';
import axios from 'axios';
import ReactDOM from 'react-dom';

// разное полезное
const setOption = ({ value, text, id }) => { // установка опции с учетом выбранной
    if (value === id) {
        return <option key={value} value={value} selected>{text}</option>
    }
    else {
        return <option key={value} value={value}>{text}</option>
    }
}

const setSelectOption = ({ value, text, id }) => { // установка опции с учетом выбранной
    if (value === id) {
        return <Select.Option key={value} value={value} selected>{text}</Select.Option>
    }
    else {
        return <Select.Option key={value} value={value}>{text}</Select.Option>
    }
}

const momentToDate = (cmoment) => { // перевод даты из moment в гггг-мм-дд
    cmoment = cmoment._d;
    return String(cmoment.getYear() + 1900) + "-" + String(cmoment.getMonth() + 1) + "-" + String(cmoment.getDate());
}

export function SetOption(value, text, id) { return setOption(value, text, id); }
export function SetSelectOption(value, text, id) { return setSelectOption(value, text, id); }
export function MomentToDate(cmoment) { return momentToDate(cmoment); }