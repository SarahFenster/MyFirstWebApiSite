

const showUpdateTags = () => {
    const updateTags = document.getElementById("update")
    updateTags.style.visibility = "initial" 
    const user = JSON.parse(sessionStorage.getItem("User"))
     document.getElementById("updateName").value=user.userName
    const password=document.getElementById("updatePassword").value = user.password
    document.getElementById("updateFName").value = user.firstName
    document.getElementById("updateLName").value = user.lastName
    let result = fetchPwdStrength(password)
    document.getElementById("progress").value = result / 4;
   
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
            const progress = document.getElementById("progress")
            progress.value = result / 4
            return
        }
        const storagedUser = JSON.parse(sessionStorage.getItem("User"))
        const res = await fetch(`api/Users/${storagedUser.id}`, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(storagedUser)
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