if (sessionStorage.length > 0){
    document.getElementById('userlogin').style.display = "none";
    document.getElementById('dropdownMenu').style.display = "inline-block";
}

function logout(){
    sessionStorage.clear();
    document.getElementById('userlogin').style.display = "inline-block";
    document.getElementById('dropdownMenu').style.display = "none";
    window.location.href = "../homepage/homepage.html";
}