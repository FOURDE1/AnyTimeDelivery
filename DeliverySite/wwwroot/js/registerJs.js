function menuToggle() {
    if (menuHolder.className === "drawMenu") menuHolder.className = ""
    else menuHolder.className = "drawMenu"
}


// animation of logo 

function myFunction() {
    const img = document.getElementById("my-image");
    img.classList.add("slide-animation");
}


const passwordInput = document.getElementById('Password');
const emailInput = document.getElementById('Email');
const confirmPasswordInput = document.getElementById('VerifyPassword1');
const feedbackDiv = document.getElementById('feedbackDiv');
var matched = 0;
// Event listener for email input
emailInput.addEventListener('input', function () {
    var email = emailInput.value;
    var emailIsValid = /^[\w-]+(\.[\w-]+)*@gmail\.com$/.test(email);

    feedbackDiv.style.backgroundColor = 'grey';
    feedbackDiv.style.borderRadius = '5%';
    feedbackDiv.style.textAlign = 'center';

    // Update email input border color and feedback message
    if (emailIsValid) {
        matched++;
        emailInput.style.borderColor = 'green';
        feedbackDiv.innerHTML = "<p>A valid email should be in the form:<br><span style='color:#79FF00;'> &#x2022; &#x2713; xyz@cmps278.lab.edu</span></p>";
    } else {
        emailInput.style.borderColor = 'red';
        feedbackDiv.innerHTML = '<img src=\'images/warning.jpg\' width=\'16px\' height=\'16px\' alt=\'not working\'><p>A valid email should be in the form:<br><span style="color:#DC0000;"> &#x2022; &#x2718; xyz@cmps278.lab.edu<span></p>';
    }
});

// Event listener for password input
passwordInput.addEventListener('input', function () {
    var password = passwordInput.value;
    feedbackDiv.style.backgroundColor = 'grey';
    feedbackDiv.style.borderRadius = '5%';
    feedbackDiv.style.textAlign = 'center';

    feedbackDiv.innerHTML = '';

    // Password conditions
    var passwordConditions = [
        {regex: /^(?=.*[a-z])/, message: 'Contains at least one lowercase letter.'},
        {regex: /^(?=.*[A-Z])/, message: 'Contains at least one uppercase letter.'},
        {regex: /^(?=.*\d)/, message: 'Contains at least one number.'},
        {regex: /^.{8,}$/, message: 'Contains at least 8 characters.'}
    ];


    var satisfiedConditions = 0;
    var feedbackMessage = "<img src='images/warning.jpg'>A valid password must satisfy the following conditions:";

    passwordConditions.forEach(function (condition) {
        if (condition.regex.test(password)) {
            satisfiedConditions++;
            feedbackMessage += '<p style="color:#79FF00;">&#x2713; ' + condition.message + '</p>';
        } else {
            feedbackMessage += '<p style="color:#DC0000;">&#x2718; ' + condition.message + '</p>';
        }
    });

    feedbackDiv.innerHTML = satisfiedConditions > 0 ? feedbackMessage : "";


    // Update password input border color based on matching conditions
    if (satisfiedConditions === passwordConditions.length) {
        matched++;
        passwordInput.style.borderColor = '#79FF00';
    } else {
        passwordInput.style.borderColor = '#DC0000';
    }

    feedbackDiv.style.backgroundColor = 'grey';
    feedbackDiv.style.borderRadius = '5%';
    feedbackDiv.style.textAlign = 'center';
});

// Event listener for confirm password input
confirmPasswordInput.addEventListener('input', function () {
    var password = passwordInput.value;
    var confirmPassword = confirmPasswordInput.value;
    feedbackDiv.innerHTML = '';

    // Update confirm password input border color and feedback message
    if (password === confirmPassword) {
        matched++;
        confirmPasswordInput.style.borderColor = 'green';
        feedbackDiv.innerHTML = '<p style="color:#79FF00;">&#x2713; Both passwords match.</p>';
    } else {
        confirmPasswordInput.style.borderColor = 'red';
        feedbackDiv.innerHTML = '<p style="color:#DC0000;">&#x2718; Passwords don\'t match.</p>';
    }

    feedbackDiv.style.backgroundColor = 'grey';
    feedbackDiv.style.borderRadius = '5%';
    feedbackDiv.style.textAlign = 'center';
})

if (matched === 3) {
    feedbackDiv.innerHTML = '<h1>Account Created Succefully</h1>';
}

$(document).ready(function () {
    $("#clientButton").click(function () {
        // Show client registration form section
        $("#clientFormSection").show();

        // Hide delivery worker registration form section
        $("#deliveryFormSection").hide();
    });

    $("#deliveryButton").click(function () {
        // Show delivery worker registration form section
        $("#deliveryFormSection").show();

        // Hide client registration form section
        $("#clientFormSection").hide();
    });
});