
const showRegisterTags = () => {
    const reg = document.getElementById("register")
    reg.style.visibility="initial"
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
    catch (er) {
        console.log(er)
    }
    }

const checkPwdStrength = async () => {
    try {
        const passInput = document.getElementById("regPassword")
        const password = passInput.value
        const progress = document.getElementById("progress")
        const result= await fetchPwdStrength(password)
        if (result < 2) {
            alert("easy password... choose a differrent one")
            progress.value = result/4
        }
        else {
            var progressBar = document.getElementById("progress")
            progressBar.value = (result / 4)
        }
    }
    catch (er) {
        alert("error in checking yor password, please try again")
    } 
}
async function register() {
    try {
        const UserName = document.getElementById("regName").value
        const Password = document.getElementById("regPassword").value
        const FirstName = document.getElementById("regFName").value
        const LastName = document.getElementById("regLName").value
        const result = await fetchPwdStrength(Password)
        var progressBar = document.getElementById("progress")
        if (result < 2) {
            alert("easy password... choose a differrent one")
            progressBar.value = result/4
            return
        }
        const user = { UserName, Password, FirstName, LastName }
        const res = await fetch("api/Users", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(user)
        })
        if (!res.ok) {
            console.log(res)//how should I return the message from the validations in class user?
            alert(res)
            return
        }
        sessionStorage.setItem("User", res.user)
        alert(`Welcome! ${FirstName} `)
    }
    catch (er) {
        alert(er)
    } 
}
async function login () {
    try {
        const user = {
            "userName": document.getElementById("logName").value,
            "password" : document.getElementById("logPassword").value
        }

        const res = await fetch(`api/Users/login`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            }, body: JSON.stringify(user)
        })
        if (res.status == 204) {
            alert("user not found")
            showRegisterTags()
            return;
        }
        if (!res.ok) { 
            alert("userName or password are not valid, please try again")
            return        }
        
        const data = await res.json();
        const createdUser = await JSON.stringify(data);
        sessionStorage.setItem("User", createdUser)
        window.location.href = "UserDetails.html?firstName=" + data.firstName
    }

    catch (er) {
        alert("error..., please try again")
    }
}


