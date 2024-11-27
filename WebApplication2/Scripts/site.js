function signup() {
    debugger;
    //const signUpForm = document.getElementById("SignUPForm");

    //console.log(signUpForm.value);
    const firstname = document.getElementById("FirstName").value;
    const lastname = document.getElementById("LastName").value;
    const jobtitle = document.getElementById("JobTitle").value;


    const email = document.getElementById("Email").value;
    const pass = document.getElementById("Password").value;
    const mobilephone = document.getElementById("MobilePhone").value;
    const businessphone = document.getElementById("BusinessPhone").value;

    const street = document.getElementById("Street").value;
    const city = document.getElementById("City").value;
    const zip = document.getElementById("Zip").value;

   

    if (firstname == "" || lastname == "" || jobtitle == "" || email == "" || pass == "" || mobilephone == "" || businessphone == "" || street == "" || city == "" || zip == "") {
        alert("Please fill in all the fields.");
        return false;
    }

    else
        return true;
    
}

function login() {
    //const loginForm = document.getElementById("LoginFormButton");
    //console.log(loginForm);
    
   
            
    const email = document.getElementById("Email2").value;
    const password = document.getElementById("Password2").value;

    if (email == "" || password == "") {
        alert("Please enter both email and password.");
        return false;
    }
    else {
        return true;
    }

    


       
    
}


function Case() {
    const Title = document.getElementById("Title").value;
    const products = document.getElementById("products").value;
    const Description = document.getElementById("Description").value;
   

    if (Title == "" || products == "" || Description == "") {
        alert("Please enter all fields.");
        return false;
    }

    else {
        alert(products)
        return true;
    }
}

