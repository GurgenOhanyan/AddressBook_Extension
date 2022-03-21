
function ValidateEmail() {
    var email = document.getElementById("email").value;
    var lblError = document.getElementById("emailValidate");
    lblError.innerHTML = "";
    var expr = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (!expr.test(email)) {
        lblError.innerHTML = "Invalid Email Address.";
        document.getElementById("create").disabled = true;
    }
    else {
        document.getElementById("create").disabled = false;
    }
}

function ValidatePhone() {
    var phone = document.getElementById("phone").value;
    var lblError = document.getElementById("phoneValidate");
    lblError.innerHTML = "";
    var expr = /^\+?\d{2}[- ]?\d{3}[- ]?\d{6}$/;

    if (!expr.test(phone)) {
        lblError.innerHTML = "Invalid Phone Number.";
        document.getElementById("create").disabled = true;
    }
    else {
        document.getElementById("create").disabled = false;
    }
}
function ValidateName() {
    var name = document.getElementById("name").value;
    var lblError = document.getElementById("nameValidate");
    lblError.innerHTML = "";
    if (name == "") {
        lblError.innerHTML = "Field cannot be empty.";
        document.getElementById("create").disabled = true;
    }
    else {
        document.getElementById("create").disabled = false;
    }
}
function ValidateEmailForEdit() {
    var email = document.getElementById("emailEdit").value;
    var lblError = document.getElementById("emailValidateEdit");
    lblError.innerHTML = "";
    var expr = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    if (!expr.test(email)) {
        lblError.innerHTML = "Invalid Email Address.";
        document.getElementById("edit").disabled = true;
    }
    else {
        document.getElementById("edit").disabled = false;
    }
}

function ValidatePhoneForEdit() {
    var phone = document.getElementById("phoneEdit").value;
    var lblError = document.getElementById("phoneValidateEdit");
    lblError.innerHTML = "";
    var expr = /^\+?\d{2}[- ]?\d{3}[- ]?\d{6}$/;

    if (!expr.test(phone)) {
        lblError.innerHTML = "Invalid Phone Number.";
        document.getElementById("edit").disabled = true;
    }
    else {
        document.getElementById("edit").disabled = false;
    }
}
function ValidateNameForEdit() {
    var phone = document.getElementById("nameEdit").value;
    var lblError = document.getElementById("nameValidateEdit");
    lblError.innerHTML = "";
    if (phone == "") {
        lblError.innerHTML = "Field cannot be empty.";
        document.getElementById("edit").disabled = true;
    }
    else {
        document.getElementById("edit").disabled = false;
    }
}
