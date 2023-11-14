
let count=0;

const showAllProducts = async () => {
    const products = await getAllProducts();
    for (let i = 1; i < products.length; i++)  {
        showProduct(products[i])
    }
}

const showProduct = async(product) => {
    let tmp = document.getElementById("temp-card");
    let cloneProduct = tmp.content.cloneNode(true)
    cloneProduct.querySelector("img").src = "./images/products/" + product.image+".wmf";
    cloneProduct.querySelector("h1").textContent = product.name
    cloneProduct.querySelector(".price").innerText = product.price
    cloneProduct.querySelector(".description").innerText = product.description
    cloneProduct.querySelector("button").addEventListener((click), () => { addToCart(product) }); 
    document.getElementById("PoductList").appendChild(cloneProduct)
}

const showAllCategories = async () => {
    const categories = await getAllCategories();
    for (let i = 1; i < categories.length; i++) {
        showCategory(categories[i])
    }
}

const showCategory = async(category) => {
    let tmp = document.getElementById("temp-category")
    let cloneCategory = tmp.content.cloneNode(true)
    cloneCategory.querySelector(".OptionName").innerText=category.name
}
//<input type="checkbox" class="opt" id="" value="">
//    <label for="">
//        <span class="OptionName"></span>
//        <span class="Count"></span>

//    </label>


const getAllProducts = async () => {
    try {
        const res = await fetch("https://localhost:44300/api/Products")
        const products = await res.json();
        return products;
    }
    catch (ex) {
        console.log(ex)
    }
}

const getAllCategories = async () => {
    try {
        const res = fetch("https://localhost:44300/api/Categories")
        const categories = await res.json();
        return categories;
    }
    catch (ex) {
        console.log(ex)
    }
}

const filterProducts = async () => {
    const fromPrice =x
    const toPrice =x
     
}

const addToCart = async () => {
    count = count + 1;
    sessionStorage.setItem("item" + count, item.Id);
    
}