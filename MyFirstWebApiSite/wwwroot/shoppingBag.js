
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
    let tmp = document.getElementById('temp-row')
    let clone = tmp.content.cloneNode(true)
    clone.querySelector("img").src = "./images/products/" + item.image
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
    let cart = JSON.parse(sessionStorage.getItem('cart'))
    let ind = cart.findIndex(prod => prod.id == item.id)
    cart.splice(ind, 1);
    sessionStorage.setItem('cart', JSON.stringify(cart))
    getMyCart()
}

const placeOrder = async () => {
    let user = sessionStorage.getItem("User");
    if (!user)
        window.location.href = "home.html"
    else { 
        let order = await createOrder(user);
        let createdOrder = await postOrder(order);
        if (createdOrder) 
            alert("order number " + createdOrder.id + " added successfuly!")
}        
}
const postOrder = async (order) => {
    let res = await fetch("api/Orders", {
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
    let createdOrder = await res.json();
    return createdOrder;
}

const createOrder = async (stringUser) => {
    let user = JSON.parse(stringUser)
    let cart = JSON.parse(sessionStorage.getItem("cart"))
    let orderItems = []
    for (let i = 0; i < cart.length; i++) {
        let ord = orderItems.findIndex(o=>o.productId==cart[i].id)
        if (ord>-1)
            orderItems[ord].quantity++;
        else 
            orderItems.push({"productId":cart[i].id,"quantity":1})   
    }
    let order = {
        "userId": user.id,
        "orderSum": totalPrice,
        "orderDate": new Date(),
        "orderItems": orderItems

    }
    return order;
}


