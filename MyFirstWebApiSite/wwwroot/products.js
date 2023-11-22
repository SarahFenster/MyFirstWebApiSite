
let count = 0;
let cart=[]

const loadStorePage = async () => {
    const cart = JSON.parse(sessionStorage.getItem('cart'))
    if (cart)
        count = cart.length;
    filterProducts();
    const categories = await getAllCategories();
    showAllCategories(categories)
    
}
const showAllProducts = async (products) => {
    for (let i = 0; i < products.length; i++)  {
        showProduct(products[i])
    }
    document.getElementById("counter").innerText= products && products.length>0? products.length:0
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
    cloneCategory.querySelector("label").for = category.categoryName
    cloneCategory.querySelector("input").innerText = category.categoryName
    document.getElementById("categoryList").appendChild(cloneCategory)
}


const getAllProducts = async (url) => {
    try {
        const res = await fetch(url)
        const products = await res.json();
        return products;
    }
    catch (ex) {
        console.log(ex)
    }
}

const getAllCategories = async () => {
    try {
        const res = await fetch('api/Categories')
        const categories = await res.json();
        return categories;
    }
    catch (ex) {
        console.log(ex)
    }
}

const getMaxAndMinPrice = (products) => {
    const min = Math.min(...products.map(p => p.price))
    const max = Math.max(...products.map(p => p.price))
    document.getElementById("minPrice").value = min
    document.getElementById("maxPrice").value = max
}

const filterProducts = async () => {
    document.getElementById("PoductList").innerHTML = ''
    let url = 'api/Products'
    let categories = []
    let allCategoryOption = document.querySelectorAll(".opt");
    for (let i = 0; i < allCategoryOption.length; i++) {
        if (allCategoryOption[i].checked)
            categories.push(allCategoryOption[i].id)
    }
    let desc = document.getElementById("nameSearch").value
    let minPrice = document.getElementById("minPrice").value
    let maxPrice = document.getElementById("maxPrice").value

    if (desc || categories || minPrice || maxPrice)
        url += '?'
    if (desc)
        url += '&desc=' + desc
    if (minPrice)
        url += '&minPrice=' + minPrice
    if (maxPrice)
        url += '&maxPrice=' + maxPrice
    if (categories) {
        for (let i = 0; i < categories.length; i++) {
            url += '&categoryIds=' + categories[i]
        }
    }  
    const products = await getAllProducts(url);
    if (products) {
        showAllProducts(products);
        getMaxAndMinPrice(products);
    }
    else {
        alert("no products match your conditions")
    }
}

const addToCart = async (item) => {
    count++;
    document.getElementById("ItemsCountText").innerText = count
    cart.push(item);
    sessionStorage.setItem("cart", JSON.stringify(cart));
}