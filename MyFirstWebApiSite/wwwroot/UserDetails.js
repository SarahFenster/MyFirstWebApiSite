

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
        const user = sessionStorage.getItem("User")
        const res = await fetch(`api/Users/${user.id}`, {
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
        alert("Updated!")
    }
    catch (er) {
        alert("error...!!, please try again")
    }
}