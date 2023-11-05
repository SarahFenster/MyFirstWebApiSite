//I recommend to change the project name to webApiShopSite or shopSite etc.
//Change file name to home.js (also userDetails.js)- camelCase
const ShowRegisterTags = () => {
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
    catch {
         //Alerting errors to the user is not recommended, log them to the console.
        alert("error ..., please try again")
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
//JavaScript function names and variables names should start with camel case
async function Register() {
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
        //Save the entire user object in sessionStorage - using json.stringify...
        sessionStorage.setItem("FirstName", FirstName)
        sessionStorage.setItem("LastName", LastName)
        alert(`Welcome! ${FirstName} `)
    }
    catch (er) {
        alert(er)
    } 
}
//login
async function Login () {
    try {
        //userName,password
        const UserName = document.getElementById("logName").value
        const Password = document.getElementById("logPassword").value

        const res = await fetch(`api/Users/?email=${UserName}&password=${Password}`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        })
        if (res.status == 204) {
            alert("user not found")
            ShowRegisterTags()
            return;
        }
        if (!res.ok) { 
           //Instead of throwing an error , only display an alert to the user
           //UserName or password are not valid, login failed...
            throw new Error("error in login, please try again")
            alert("error in login, please try again")}
        
        const data = await res.json();
        console.log(data)
        sessionStorage.setItem("Password", data.password)
        sessionStorage.setItem("UserName", data.userName)
        window.location.href = "UserDetails.html?firstName=" + data.firstName
    }

    catch (er) {
        alert("error..., please try again")
    }
}


