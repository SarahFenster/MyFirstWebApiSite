

const showUpdateTags = () => {
    let updateTags = document.getElementById("update")
    updateTags.style.visibility = "initial" 
    let user = JSON.parse(sessionStorage.getItem("User"))
    document.getElementById("updateName").value=user.userName
    let password=document.getElementById("updatePassword").value = user.password
    document.getElementById("updateFName").value = user.firstName
    document.getElementById("updateLName").value = user.lastName
}

const fetchPwdStrength = async (password) => {
    try {
        const res = await fetch("api/Users/checkYourPass", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(password)
        })
        if (!res.ok)
            throw new Error("error in checking pwd strength")
        const result = await res.json();
        return result
    }
    catch {
        alert("error ..., please try again")
    }
}

async function updateUserDetails() {
    try {
        let userName = document.getElementById("updateName").value
        let password = document.getElementById("updatePassword").value
        let firstName = document.getElementById("updateFName").value
        let lastName = document.getElementById("updateLName").value
        let user = { userName, password, firstName, lastName }
        let result = fetchPwdStrength(password)
        if (result < 2) {
            alert("easy password... choose a differrent one")
            return
        }
        const storagedUser = JSON.parse(sessionStorage.getItem("User"))
        const res = await fetch(`api/Users/${storagedUser.id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(user)
        })
        if (res.status == 400) {
            alert("easy password...")
            return
        }
        if (!res.ok) {
            alert(res)
            return
        }
        if (res.status == 204) {
            alert("user not found")
            return
        }
        alert("Updated!")
    }
    catch (er) {
        alert("error...!!, please try again")
    }
}