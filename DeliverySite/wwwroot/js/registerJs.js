const menuHolder = document.getElementById('menuHolder')
function menuToggle(){
    if(menuHolder.className === "drawMenu") menuHolder.className = ""
    else menuHolder.className = "drawMenu"
}



// animation of logo 

function myFunction() {
    const img = document.getElementById("my-image");
    img.classList.add("slide-animation");
}


// Example starter JavaScript for disabling form submissions if there are invalid fields

$(document).ready(function() {
    // Form validation
    $('form.needs-validation').submit(function(event) {
        // Prevent form submission if it's invalid
        if (!this.checkValidity()) {
            event.preventDefault();
            event.stopPropagation();
        }

        // Add 'was-validated' class to show validation feedback
        $(this).addClass('was-validated');
    });

    // Password validation
    $('input[name="Password"]').on('keyup', function() {
        const password = $(this).val();

        // Password should contain at least 8 characters
        const minLength = 8;
        const hasMinLength = password.length >= minLength;

        // Password should contain at least one uppercase letter
        const hasUppercase = /[A-Z]/.test(password);

        // Password should contain at least one lowercase letter
        const hasLowercase = /[a-z]/.test(password);

        // Password should contain at least one digit
        const hasDigit = /\d/.test(password);

        // Password should contain at least one special character
        const hasSpecialChar = /[!@#$%^&*()\-_=+{}[\]|\\;:'",.<>/?]/.test(password);

        // Show/hide password strength feedback based on validation rules
        if (hasMinLength && hasUppercase && hasLowercase && hasDigit && hasSpecialChar) {
            $('.password-strength').text('Strong');
            $('.password-strength').removeClass('text-danger').addClass('text-success');
        } else {
            $('.password-strength').text('Weak');
            $('.password-strength').removeClass('text-success').addClass('text-danger');
        }
    });

    // Confirm password match validation
    $('input[name="VerifyPassword1"]').on('keyup', function() {
        const password = $('input[name="Password"]').val();
        const confirmPassword = $(this).val();

        // Show/hide password match feedback based on whether the passwords match
        if (password === confirmPassword) {
            $('input[name="VerifyPassword1"]').removeClass('is-invalid');
        } else {
            $('input[name="VerifyPassword1"]').addClass('is-invalid');
        }
    });
});






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
