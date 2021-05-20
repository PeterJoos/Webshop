let formData = new FormData();
window.onload = function (){
    document.getElementById('submitButton').addEventListener('click',function (){
        let firstName, lastName, email, adress, postalCode, country, password;
        firstName = document.getElementById('firstName').value;
        lastName = document.getElementById('lastName').value;
        email = document.getElementById('email').value;
        adress = document.getElementById('adress').value;
        postalCode = document.getElementById('postalCode').value;
        country = document.getElementById('country').value;
        password = document.getElementById('password-field').value;

        formData = new FormData();
        formData.append('firstName', firstName);
        formData.append('lastName', lastName);
        formData.append('email', email);
        formData.append('adress', adress);
        formData.append('postalCode', postalCode);
        formData.append('country', country);
        formData.append('password', password);
        postFormData(formData);
    })
}

function AutoLoginPageLoad(){
    window.location.href="../../customer/customerLogin/Login.html";
}

function toonSucces(data){
    console.log(data);
if (data[0] === false){
    document.getElementById('ControleGegevens').style.backgroundColor = "red";
    document.getElementById('ControleGegevens').innerHTML = "Please fill in all fields";
} else {
    if (data[1] === true){
        document.getElementById('ControleGegevens').style.backgroundColor = "red";
        document.getElementById('ControleGegevens').innerHTML = "Email already in use";
    } else  {
        AutoLoginPageLoad()
    }
}

}

function  validateResponse(response){
    return response;
}

function  readResponseAsJSON(response){
    return response.json();
}


function postFormData(formData){
    fetch("https://localhost:44388/User",
        {
            body: formData,
            method: "post"
        })
        .then(validateResponse)
        .then(readResponseAsJSON)
        .then(toonSucces)
}
