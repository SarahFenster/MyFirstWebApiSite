
let count=0;

const loadStorePage = async () => {
    document.getElementById("PoductList").innerHTML = ''
    document.getElementById("categoryList").innerHTML = ''
    const products = await getAllProducts();
    const categories = await getAllCategories();
    showAllProducts(products)
    showAllCategories(categories)
    getMaxAndMinPrice(products)
}
const showAllProducts = async (products) => {
    for (let i = 0; i < products.length; i++)  {
        showProduct(products[i])
    }
}

const showProduct = async(product) => {
    let tmp = document.getElementById("temp-card");
    let cloneProduct = tmp.content.cloneNode(true)
    cloneProduct.querySelector("img").src = "./images/products/" + product.image
    cloneProduct.querySelector("h1").textContent = product.name
    cloneProduct.querySelector(".price").innerText = product.price
    cloneProduct.querySelector(".description").innerText = product.description
    cloneProduct.querySelector("button").addEventListener('click', () => { addToCart(product) }); 
    document.getElementById("PoductList").appendChild(cloneProduct)
}

const showAllCategories = async (categories) => {
    for (let i = 0; i < categories.length; i++) {
        showCategory(categories[i])
    }
}

const showCategory = async(category) => {
    let tmp = document.getElementById("temp-category")
    let cloneCategory = tmp.content.cloneNode(true)
    cloneCategory.querySelector(".OptionName").innerText = category.categoryName
    cloneCategory.querySelector("input").id = category.id
    document.getElementById("categoryList").appendChild(cloneCategory)
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
        const res = await fetch("https://localhost:44300/api/Categories")
        const categories = await res.json();
        return categories;
    }
    catch (ex) {
        console.log(ex)
    }
}

const getMaxAndMinPrice = (products) => {
    console.log(products)
    const min = products.Min(p => p.price)
    console.log(min)
    const max = products.Max(p => p.price)
    document.getElementById("minPrice").innerHTML=min

}

const filterProducts = async () => {
    const fromPrice =x
    const toPrice =x
     
}

const addToCart = async (item) => {
    
    count = count + 1;
    sessionStorage.setItem("item" + count, item);
    document.getElementById("ItemsCountText").innerText = count
    
}