

const showUpdateTags = () => {
    const updateTags = document.getElementById("update")
    updateTags.style.visibility = "initial" 
}

async function updateUserDetails() {
    try {
        const UserName = document.getElementById("updateName").value
        const Password = document.getElementById("updatePassword").value
        const FirstName = document.getElementById("updateFName").value
        const LastName = document.getElementById("updateLName").value
        const user = { UserName, Password, FirstName, LastName }
        let id;

        try {
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
        if (res.status == 204) {
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