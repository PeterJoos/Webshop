window.onload = function (){
    document.getElementById('btn-forgot-email').addEventListener('click',function (){
        let email;
        email = document.getElementById('forgot-email').value;
        formData = new FormData();
        formData.append('email', email);
        postFormData(formData);
    })
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

function showSuccesorNot(data){
    if (data === false){
        document.getElementById('emailsent').style.backgroundColor = "red";
        document.getElementById('emailsent').innerHTML = "Not a valid e-mailadress";
    } else {
        document.getElementById('emailsent').style.backgroundColor = "green";
        document.getElementById('emailsent').innerHTML = "Email has been sent!";
        /*window.location.href="../../customer/customerLogin/Login.html";*/
    }

}
function postFormData(formData){
    fetch("https://localhost:44388/Email",
        {
            body: formData,
            method: "post"
        })
        .then(validateResponse)
        .then(readResponseAsJSON)
        .then(showSuccesorNot)
}