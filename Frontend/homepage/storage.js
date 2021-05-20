window.onload = function (){
    //loadSessionStorage();

    let termAccpet = localStorage.getItem('terms_accepteren');
    if(termAccpet == null){
        bindClickHandlers();
        showCookiePopup();
    }

}
let loggedInUser,consentPopup;

function bindClickHandlers() {
     consentPopup = document.getElementById('cookie-popup');
    const acceptBtn = document.getElementById('accept');

    acceptBtn.onclick = function(){
        //saveToStorage(storageType);
        localStorage.setItem('terms_accepteren','ok');

        consentPopup.classList.add('verborgen');
    };

}
function showCookiePopup() {
    setTimeout(() => {
        consentPopup.classList.remove('verborgen');
    }, 2000);
}