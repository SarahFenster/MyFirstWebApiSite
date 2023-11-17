
const showCartItems = async (items) => {
    for (let i = 0; i < items.length; i++) {
        showItem(items[i]);
    }
}

const showItem = async (item) => {
    let tmp = document.getElementById("temp-row");
    let cloneItem = tmp.content.cloneNode(true)
    cloneItem.querySelector(".image").src = "./images/products/" + item.image
    cloneItem.querySelector(".itemName").innerText = item.name
    document.getElementById("itemList").appendChild(cloneItem)
}

const getMyCart = async () => {
    let cart = sessionStorage.getItem("items");
    //cart = JSON.parse(cart);
    showCartItems(cart)
}

