
let totalPrice = 0;

const showCartItems = async (items) => {
    for (let i = 0; i < items.length; i++) {
        showItem(items[i]);
    }
    document.getElementById('itemCount').innerText = items ? items.length : 0;
    document.getElementById('totalAmount').innerText = totalPrice
}

const showItem = async (item) => {
    totalPrice += item.price
    const tmp = document.getElementById('temp-row')
    const clone = tmp.content.cloneNode(true)
    clone.querySelector(".image").src = "./images/products" + item.image.trim()
    clone.querySelector(".itemName").innerText = item.name
    clone.querySelector(".price").innerText = item.price
    clone.querySelector("button").addEventListener('click', () => deleteProduct(item))
    document.querySelector('tbody').appendChild(clone);
}

const getMyCart = async () => {
    document.querySelector("tbody").replaceChildren([])
    totalPrice=0
    let cart = JSON.parse(sessionStorage.getItem("cart"));
    showCartItems(cart)
}

const deleteProduct = async (item) => {
    totalPrice -= item.price
    const cart = JSON.parse(sessionStorage.getItem('cart'))
    const filteredCart = cart.filter(prod => prod.id != item.id)
    sessionStorage.setItem('cart', JSON.stringify(filteredCart))
    getMyCart()
}

const placeOrder = async () => {
    const user = sessionStorage.getItem("User");
    if (!user)
        window.location.href = "home.html"
    else { 
        const order = await createOrder();
        const createdOrder = await postOrder(order);
        alert("added successfuly!")
}        
}
const postOrder = async (order) => {
    const res = await fetch("api/Orders", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(order)
    })
    if (!res.ok) {
        alert("failed")
        return
    }
    const createdOrder = await res.json();
    return createdOrder;
}

const createOrder = async () => {
    const user = JSON.parse(sessionStorage.getItem("User"))
    const cart = JSON.parse(sessionStorage.getItem("cart"))
    let orderItems = []
    for (let i = 0; i < cart.length; i++) {
        const ord = orderItems.findIndex(o=>o.productId==cart[i].id)
        if (ord!=null)
            orderItems[ord].quantity++;
        else 
            orderItems.push({"productId":cart[i].id,"quantity":1})   
    }
    const order = {
        "userId": user.id,
        "orderSum": totalPrice,
        "orderDate": new Date(),
        "orderItems":orderItems
    }
    return order;
}


