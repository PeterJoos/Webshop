// Declaratie variabelen en constanten
let cartItemContainer;
const products = [];
const images = [];
const productCategorie = [];
const imagePath = "productFotos/";
const cardioProducts = [];
const powerProducts = [];
const crossTrainingProducts = [];
const nutritionProducts = [];

window.onload = function(){
    cartItemContainer= document.getElementById('cartItems');
    // haal produccten op; zodra als die opgehaals zijn (dus in the .then() want asynchroon) uw renderfunctie uitvoeren
    GetProductData();
    onLoadCartNumbers();
    displayCart();
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

// Data uit de database in arrays steken
function logResult(result) {
    for (let i = 0; i <result[0].DataTable.length ; i++) {
        products.push(result[0].DataTable[i]);
        products[i].inCart = 0;
    }
    for (let i = 0; i < result[1].DataTable.length; i++) {
        images.push(result[1].DataTable[i]);
    }
    for (let i = 0; i < result[2].DataTable.length; i++) {
        productCategorie.push(result[2].DataTable[i])
    }
}

// Data ophalen uit de database
function GetProductData(){
    fetch('https://localhost:44388/Product')
        .then(validateResponse)
        .then(readResponseAsJSON)
        .then(logResult)
        .then(renderCartItems)
        .then(bindEventListeners);
}

// Producten inladen op de product pagina
function renderCartItems(){
    for (let i = 0; i < products.length; i++) {
        let imageIdFilter = images.find(image=>image.ProductID === i+1);
        let image = imageIdFilter.Afbeeldingsnaam;
        let newCartItem = document.createElement('div');
        newCartItem.className = "col-lg-4 col-md-6 mb-4";
        newCartItem.innerHTML = `
                    <div class="card h-100">
                        <a href="#!"><img src="${imagePath+image}" class="card-img-top" id="Artikel1" alt="..."></a>
                        <div class="card-body">
                            <h4 class="card-title"><a href="#!">${products[i].Productnaam}</a></h4>
                            <h5 class="card-price">${products[i].Eenheidsprijs}</h5>
                            <!--<p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!</p>-->
                            <button class="btn btn-primary shop-item-button" type="button">ADD TO CART</button>
                        </div>
                    </div>`;
        cartItemContainer.appendChild(newCartItem);
    }
}

// Declaratie & functies om te controleren of de gebruiker op 1 van de categorie filters heeft geklikt
let cardioIsClicked = false;
let powerIsClicked = false;
let crossIsClicked = false;
let nutritionIsClicked = false;

function clickHandlerCardio(){
    cardioIsClicked = true;
    powerIsClicked = false;
    crossIsClicked = false;
    nutritionIsClicked = false;
}

function clickHandlerPower(){
    powerIsClicked = true;
    cardioIsClicked = false;
    crossIsClicked = false;
    nutritionIsClicked = false;
}

function clickHandlerCross(){
    crossIsClicked = true;
    powerIsClicked = false;
    cardioIsClicked = false;
    nutritionIsClicked = false;
}

function clickHandlerNutrition(){
    nutritionIsClicked = true;
    crossIsClicked = false;
    powerIsClicked = false;
    cardioIsClicked = false;
}

// Filter functies + functies om te controleren of de gebruiker op 1 van de categorie filters heeft geklikt als click-event meegeven aan de categorieën
document.getElementById('cardio').addEventListener('click', CardioFilter);
document.getElementById('cardio').addEventListener('click', clickHandlerCardio);
document.getElementById('power-training').addEventListener('click', PowerTrainingFilter);
document.getElementById('power-training').addEventListener('click', clickHandlerPower);
document.getElementById('cross-training').addEventListener('click', CrossTrainingFilter);
document.getElementById('cross-training').addEventListener('click', clickHandlerCross);
document.getElementById('supplements-and-food').addEventListener('click', SupplementsAndFoodFilter);
document.getElementById('supplements-and-food').addEventListener('click', clickHandlerNutrition);

// Filter functie om alleen de cardio producten op de pagina te tonen
function CardioFilter(){
    cartItemContainer.innerHTML = "";
    let productCategorieFilter = productCategorie.find(categorie =>categorie.Categorie === 'Cardio');
    let categorie = productCategorieFilter.ProductcategorieID;
    for (let i = 0; i < products.length; i++) {
        if (products[i].ProductcategorieID === categorie){
            let imageIdFilter = images.find(image=>image.ProductID === i+1);
            let image = imageIdFilter.Afbeeldingsnaam;
            let newCartItem = document.createElement('div');
            newCartItem.className = "col-lg-4 col-md-6 mb-4";
            newCartItem.innerHTML = `
                    <div class="card h-100">
                        <a href="#!"><img src="${imagePath+image}" class="card-img-top" id="Artikel1" alt="..."></a>
                        <div class="card-body">
                            <h4 class="card-title"><a href="#!">${products[i].Productnaam}</a></h4>
                            <h5 class="card-price">${products[i].Eenheidsprijs}</h5>
                            <!--<p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!</p>-->
                            <button class="btn btn-primary shop-item-button" type="button">ADD TO CART</button>
                        </div>
                    </div>`;
            cartItemContainer.appendChild(newCartItem);
            cardioProducts.push(products[i]);
        }
    }
    bindEventListeners();
    displayCart();
}

// Filter functie om alleen de power training producten op de pagina te tonen
function PowerTrainingFilter(){
    cartItemContainer.innerHTML = "";
    let productCategorieFilter = productCategorie.find(categorie =>categorie.Categorie === 'Power');
    let categorie = productCategorieFilter.ProductcategorieID;
    for (let i = 0; i < products.length; i++) {
        if (products[i].ProductcategorieID === categorie){
            let imageIdFilter = images.find(image=>image.ProductID === i+1);
            let image = imageIdFilter.Afbeeldingsnaam;
            let newCartItem = document.createElement('div');
            newCartItem.className = "col-lg-4 col-md-6 mb-4";
            newCartItem.innerHTML = `
                    <div class="card h-100">
                        <a href="#!"><img src="${imagePath+image}" class="card-img-top" id="Artikel1" alt="..."></a>
                        <div class="card-body">
                            <h4 class="card-title"><a href="#!">${products[i].Productnaam}</a></h4>
                            <h5 class="card-price">${products[i].Eenheidsprijs}</h5>
                            <!--<p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!</p>-->
                            <button class="btn btn-primary shop-item-button" type="button">ADD TO CART</button>
                        </div>
                    </div>`;
            cartItemContainer.appendChild(newCartItem);
            powerProducts.push(products[i]);
        }
    }
    bindEventListeners();
    displayCart();
}

// Filter functie om alleen de cross training producten op de pagina te tonen
function CrossTrainingFilter(){
    cartItemContainer.innerHTML = "";
    let productCategorieFilter = productCategorie.find(categorie =>categorie.Categorie === 'Cross training');
    let categorie = productCategorieFilter.ProductcategorieID;
    for (let i = 0; i < products.length; i++) {
        if (products[i].ProductcategorieID === categorie){
            let imageIdFilter = images.find(image=>image.ProductID === i+1);
            let image = imageIdFilter.Afbeeldingsnaam;
            let newCartItem = document.createElement('div');
            newCartItem.className = "col-lg-4 col-md-6 mb-4";
            newCartItem.innerHTML = `
                    <div class="card h-100">
                        <a href="#!"><img src="${imagePath+image}" class="card-img-top" id="Artikel1" alt="..."></a>
                        <div class="card-body">
                            <h4 class="card-title"><a href="#!">${products[i].Productnaam}</a></h4>
                            <h5 class="card-price">${products[i].Eenheidsprijs}</h5>
                            <!--<p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!</p>-->
                            <button class="btn btn-primary shop-item-button" type="button">ADD TO CART</button>
                        </div>
                    </div>`;
            cartItemContainer.appendChild(newCartItem);
            crossTrainingProducts.push(products[i]);
        }
    }
    bindEventListeners();
    displayCart();
}

// // Filter functie om alleen de supplements and food producten op de pagina te tonen
function SupplementsAndFoodFilter(){
    cartItemContainer.innerHTML = "";
    let productCategorieFilter = productCategorie.find(categorie =>categorie.Categorie === 'Nutrition');
    let categorie = productCategorieFilter.ProductcategorieID;
    for (let i = 0; i < products.length; i++) {
        if (products[i].ProductcategorieID === categorie){
            let imageIdFilter = images.find(image=>image.ProductID === i+1);
            let image = imageIdFilter.Afbeeldingsnaam;
            let newCartItem = document.createElement('div');
            newCartItem.className = "col-lg-4 col-md-6 mb-4";
            newCartItem.innerHTML = `
                    <div class="card h-100">
                        <a href="#!"><img src="${imagePath+image}" class="card-img-top" id="Artikel1" alt="..."></a>
                        <div class="card-body">
                            <h4 class="card-title"><a href="#!">${products[i].Productnaam}</a></h4>
                            <h5 class="card-price">${products[i].Eenheidsprijs}</h5>
                            <!--<p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Amet numquam aspernatur!</p>-->
                            <button class="btn btn-primary shop-item-button" type="button">ADD TO CART</button>
                        </div>
                    </div>`;
            cartItemContainer.appendChild(newCartItem);
            nutritionProducts.push(products[i])
        }
    }
    bindEventListeners();
    displayCart();
}

// Functies die er voor zorgen dat producten in een local storage gestoken worden wanneer de gebruiker op de 'add to cart' buttons klikt
function bindEventListeners() {
    let carts = document.querySelectorAll('.shop-item-button');
    for (let i = 0; i < carts.length; i++) {
        carts[i].addEventListener('click',() => {
            if (powerIsClicked === true){
                cartNumbers(powerProducts[i]);
                totalCost(powerProducts[i])
            }
            else if (cardioIsClicked === true){
                cartNumbers(cardioProducts[i]);
                totalCost(cardioProducts[i])
            }
            else if (crossIsClicked === true){
                cartNumbers(crossTrainingProducts[i]);
                totalCost(crossTrainingProducts[i])
            }
            else if (nutritionIsClicked === true){
                cartNumbers(nutritionProducts[i]);
                totalCost(nutritionProducts[i])
            }
            else {
                cartNumbers(products[i]);
                totalCost(products[i])
            }
        })}
}

function onLoadCartNumbers(){
    let productNumbers = localStorage.getItem('cartNumbers');
    if(productNumbers){
        document.querySelector('.icon-cart span').textContent = productNumbers;
    }
}

function cartNumbers(product) {
    let productNumbers = localStorage.getItem('cartNumbers');
    productNumbers = parseInt(productNumbers);
    if(productNumbers){
        localStorage.setItem('cartNumbers', productNumbers + 1);
        document.querySelector('.icon-cart span').textContent = productNumbers + 1;
    }
    else {
        localStorage.setItem('cartNumbers', 1);
        document.querySelector('.icon-cart span').textContent = 1;
    }
    setItems(product);
}

function setItems(product){
   let cartItems = localStorage.getItem('productsInCart');
   cartItems = JSON.parse(cartItems)

   if(cartItems != null){
       if(cartItems[product.Productnaam] === undefined){
           cartItems = {
               ...cartItems,
               [product.Productnaam] : product
           }
       }
       cartItems[product.Productnaam].inCart += 1;
   }
   else{
       product.inCart = 1;
       cartItems = {
           [product.Productnaam] : product
       }
   }
    localStorage.setItem("productsInCart", JSON.stringify(cartItems));
}

function totalCost(product){
    //console.log("The product price is", product.prijs);
    let cartCost = localStorage.getItem('totalCost');
    console.log("My cartCost is", cartCost);
    console.log(typeof cartCost);


   if(cartCost != null){
       cartCost = parseInt(cartCost);
       localStorage.setItem("totalCost", cartCost + product.Eenheidsprijs);
   } else{
       localStorage.setItem("totalCost", product.Eenheidsprijs);
   }

}

// Functie om de producten uit de local storage op te halen en te tonen op de shopping cart pagina
function displayCart(){
    let cartItems = localStorage.getItem("productsInCart");
    cartItems = JSON.parse(cartItems);
    let productContainer = document.querySelector(".products");
    let cartCost = localStorage.getItem('totalCost');
    if(cartItems && productContainer ){
        productContainer.innerHTML = '';
        Object.values(cartItems).map(item => {
            productContainer.innerHTML += `
            <div class="product">
                <ion-icon name="close-circle-outline"></ion-icon>
                <img scr="products/productsAlgemeen/dist/productFotos/${imagePath+images.Afbeeldingsnaam}.jpg">
                <span>${item.Productnaam}</span>
                </div>
                <div class="price">$${item.Eenheidsprijs},00</div>
                <div class="quantity">
                    <ion-icon class="decrease" name="arrow-dropleft-circle"></ion-icon>
                    <span>${item.inCart}</span>
                    <ion-icon class="increase" name="arrow-dropright-circle"></ion-icon>
                </div>
                <div class="total">
                $${item.inCart * item.Eenheidsprijs},00
                </div>
            `;
        });

        productContainer.innerHTML += `
        <div class="basketTotalContainer">
        <h4 class="basketTotalTitle">Basket Total</h4>
        <h4 class="basketTotal">€${cartCost},00</h4>
        `;

    }
}
