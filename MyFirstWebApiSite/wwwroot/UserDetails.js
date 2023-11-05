

const showUpdateTags = () => {
    const updateTags = document.getElementById("update")
    updateTags.style.visibility = "initial" 
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
        const UserName = document.getElementById("updateName").value
        const Password = document.getElementById("updatePassword").value
        const FirstName = document.getElementById("updateFName").value
        const LastName = document.getElementById("updateLName").value
        const user = { UserName, Password, FirstName, LastName }
        let id;
        const result = fetchPwdStrength(Password)
        if (result < 2) {
            alert("easy password... choose a differrent one")
            progress.value = result / 4
            return
        }
        try {
            //Save the entire user object in the sessionStorage and then you won't need to fetch userId
            const storagedUserName = sessionStorage.getItem("UserName")
            const storagedPassword = sessionStorage.getItem("Password")
            const res = await fetch(`api/Users/?email=${storagedUserName}&password=${storagedPassword}`, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json"
                }
            })
            if (res.status == 204) {
                alert("user not found")
                return;
            }
            if (!res.ok) {
                throw new Error("error in login, please try again")
                alert("error in getting your details, please try again")
            }

            const data = await res.json();
            id=data.userId
        }
        catch (er) {
            alert("error................., please try again")
        }

        const res = await fetch(`api/Users/${id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(user)
        })
        if (res.status == 204) {//204 is not suitable status for easy password- consider 400...
            alert("easy password...")
            return
        }
        if (!res.ok) {
            alert(res)//how should I return the message from the validations in class user?
            return
        }
        alert("Updated!")
    }
    catch (er) {
        alert("error...!!, please try again")
    }
}