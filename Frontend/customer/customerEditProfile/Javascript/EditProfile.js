let email;
window.onload = function () {
    getLoggedInUser()
    getDataFromLoggedInUser(email)
    document.getElementById('saveChanges').addEventListener('click',function (){
        let password, newemail, oldemail, firstname, name, adres, country, postcode
        password = document.getElementById("password").value;
        newemail = document.getElementById("email").value;
        oldemail = document.getElementById("oldEmail").value;
        firstname = document.getElementById("firstName").value;
        name = document.getElementById("naam").value;
        adres = document.getElementById("adres").value;
        country = document.getElementById("country").value;
        postcode = document.getElementById("postcode").value;


        formData = new FormData();
        formData.append("password", password);
        formData.append("email", newemail);
        formData.append("oldemail", oldemail);
        formData.append("voornaam", firstname);
        formData.append("naam", name);
        formData.append("adres", adres);
        formData.append("country",country);
        formData.append("postcode",postcode);
        PutFormData(formData)
    })
}

function PutFormData(formdata){
    fetch("https://localhost:44388/Edit",
        {
            body: formdata,
            method: "put"
        })
        .then(readResponseAsJSON)
        .then(toonSucces)
}

function toonSucces(data){
    console.log(data);
    if (data[0] === false){
        document.getElementById('changesMade').style.backgroundColor = "red";
        document.getElementById('changesMade').innerHTML = "Please fill in all fields";
    } else {
        if (data[1] === true){
            document.getElementById('changesMade').style.backgroundColor = "red";
            document.getElementById('changesMade').innerHTML = "Email already in use";
        } else  {
            document.getElementById('changesMade').style.backgroundColor = "green";
            document.getElementById('changesMade').innerHTML = "Successfully updated";
        }
    }

}

function  getLoggedInUser(){
    email = sessionStorage.getItem("email");
}
function getDataFromLoggedInUser(email){
    formData = new FormData();
    formData.append('email', email);
    postFormData(formData);

}
function  validateResponse(response){
    if (!response.ok) {
        throw  Error(response.statusText);
    }
    return response;
}
function  readResponseAsJSON(response){
    return response.json();
}

function logout(){
    sessionStorage.clear();
    window.location.href="../../homepage/homepage.html";
}

function fillInData(data){

    document.getElementById("naam").value = data.naam;
    document.getElementById("firstName").value = data.voornaam;
    document.getElementById("email").value = data.emailadres;
    document.getElementById("country").value = data.country;
    document.getElementById("postcode").value = data.postcode;
    document.getElementById("adres").value = data.adres;
    document.getElementById("password").value = data.password;
    document.getElementById("oldEmail").value = data.emailadres;
}
function postFormData(formData){
    fetch("https://localhost:44388/Edit",
        {
            body: formData,
            method: "post"
        })
        .then(validateResponse)
        .then(readResponseAsJSON)
        .then(fillInData)
}
