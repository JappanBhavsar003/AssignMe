function setStorage(name, data) {
    if (typeof (Storage) !== "undefined") {
        // Code for localStorage/sessionStorage.
        localStorage.setItem(name, JSON.stringify(data));
    } else {
        // Sorry! No Web Storage support..
        alert("Your browser does not supported!")
    }
}

function getStorage(name) {
    if (typeof (Storage) !== "undefined") {
        // Code for localStorage/sessionStorage.
        var obj = localStorage.getItem(name);
        if (obj != "") {
            return JSON.parse(obj);
        }
        else {
            return "";
        }
    } else {
        // Sorry! No Web Storage support..
        alert("Your browser does not supported!")
    }
}

function removeStorage(name) {
    if (typeof (Storage) !== "undefined") {
        // Remove item form local storage
        localStorage.removeItem(name);
    } else {

    }
}

