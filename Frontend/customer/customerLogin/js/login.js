let formData = new FormData();
let sessionemail
window.onload = function (){
    document.getElementById('signinbutton').addEventListener('click',function (){
        let email, password;
        email = document.getElementById('email-field').value;
        password = document.getElementById('password-field').value;
        sessionemail = email;
        formData = new FormData();
        formData.append('email', email);
        formData.append('password', password);
        postFormData(formData);
    })
}

function toonSucces(result){
    if (result === true){
        sessionStorage.setItem("email",sessionemail );
    window.location.href="../../homepage/homepage.html";
    }
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

function postFormData(formData){
    fetch("https://localhost:44388/Login",
        {

            body: formData,
            method: "post"
        })
        .then(validateResponse)
        .then(readResponseAsJSON)
        .then(toonSucces)

}