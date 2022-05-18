let result = null;
var schedule;
var shifts;
var days;


function setDoctors() {
  
    
    var request = new XMLHttpRequest();
    request.open("GET", "api/Doctor/", false);
    request.onload = function () {
        result = JSON.parse(request.responseText);
        var select = document.getElementById('Doctors');
        for (let i = 0; i < result.length; i++) {
            var opt = document.createElement('option');
            opt.value = result[i].id;
            opt.innerHTML = result[i].fullName;
            select.appendChild(opt);

        };
        
    }
    request.send();
    DoctorSelected();
}

function setShifts() {


    var request = new XMLHttpRequest();
    request.open("GET", "api/Shift/", false);
    request.onload = function () {
        result = JSON.parse(request.responseText);
        var select = document.getElementById('Shifts');
        shifts = result;
        for (let i = 0; i < result.length; i++) {
            var opt = document.createElement('option');
            opt.value = result[i].id;
            opt.innerHTML = result[i].number;
            select.appendChild(opt);
        };

    }
    request.send();
}

function setDays() {


    var request = new XMLHttpRequest();
    request.open("GET", "api/Day/", false);
    request.onload = function () {
        result = JSON.parse(request.responseText);
        var select = document.getElementById('Days');
        days = result;
        for (let i = 0; i < result.length; i++) {
            var opt = document.createElement('option');
            opt.value = result[i].id;
            opt.innerHTML = result[i].dayOfWeek;
            select.appendChild(opt);

        };

    }
    request.send();
}

function DoctorSelected() {
    var doctor = document.getElementById('Doctors').value;
    const v = "Кабинет ";
    const w = "Смена ";
    var request = new XMLHttpRequest();
    request.open("GET", "api/Doctor/"+doctor, false);
    request.onload = function () {
        result = JSON.parse(request.responseText);
        var x="";
        schedule = result;
        for (let i = 0; i < result.schedules.length; i++) {
            x += "<hr>";
            x += "<form>";
            x += "<label>" + result.schedules[i].dayofWeekNavigation.dayOfWeek + "</label><br>";
            x += "<label>"+ w + result.schedules[i].shift.number + "</label><br>"; 
            x += "<label>"+ v + "</label>";
            x += "<input class='form-control' type='text' value='" + result.schedules[i].room + "'id='update" + result.schedules[i].id + "'/>";
            x += "<button type='button' style='margin: 8px;' class='btn btn-sm btn-warning' onclick='Update(" + result.schedules[i].id + ");'>Обновить</button>";
            x += "<button type='button' style='margin: 8px;' class='btn btn-sm btn-danger' onclick='Delete(" + result.schedules[i].id + ");'>Удалить</button>";
            x += "</form>";
        }
        document.getElementById("schedules").innerHTML = x;

        };

    request.send();
}


function Delete(id) {
    var request = new XMLHttpRequest();
    var url = "api/schedule/" + id;
    request.open("DELETE", url, false);
    request.onload = function () {
        DoctorSelected();
    };
    request.send();
}

function Update(id) {
    var name = document.getElementById("update"+ id.toString() ).value;
    var request = new XMLHttpRequest();
    var url = "api/schedule/" + id;
    request.open("PUT", url, false);
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.onload = function () {
        DoctorSelected();
    };
    var s;
    for (let i = 0; i < schedule.schedules.length; i++) {
        if (id == schedule.schedules[i].id) {
            schedule.schedules[i].room = name;
            s = schedule.schedules[i];
            break;
        } 
    }
    request.send(JSON.stringify(s));
}

function Create() {
    var name = document.getElementById("nroom").value;
    var shift = document.getElementById("Shifts").value;
    var day = document.getElementById("Days").value;
    var s;
    var d;
    for (let i = 0; i < shifts.length; i++) {
        if (shift == shifts[i].id) {
            
            s = shifts[i];
            break;
        }
    }

    for (let i = 0; i < days.length; i++) {
        if (day == days[i].id) {

            d = days[i];
            break;
        }
    }
    var request = new XMLHttpRequest();
    request.open("POST", "api/schedule/" );
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.onload = function () {
        DoctorSelected();
    };
    request.send(JSON.stringify({ room: name, doctorId: document.getElementById('Doctors').value, shift: s, dayofWeekNavigation: d }));
    
}