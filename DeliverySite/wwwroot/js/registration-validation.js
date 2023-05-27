// Wait for the document to be fully loaded
document.addEventListener('DOMContentLoaded', function() {
    // Get the registration form
    var form = document.querySelector('form');

    // Add event listener to the form submit event
    form.addEventListener('input', function(event) {
        // Prevent the form from being submitted by the browser
        event.preventDefault();

        // Perform form validation
        if (validateForm(form)) {
            // If the form is valid, submit it
            form.submit();
        }
    });
});

// Function to validate the form
function validateForm(form) {
    var isValid = true;

    // Reset error messages
    var errorMessages = form.getElementsByClassName('text-danger');
    for (var i = 0; i < errorMessages.length; i++) {
        errorMessages[i].textContent = '';
    }

    // Validate each form field
    var firstNameInput = form.querySelector('[name="FirstName"]');
    if (!validateField(firstNameInput)) {
        isValid = false;
    }

    var lastNameInput = form.querySelector('[name="LastName"]');
    if (!validateField(lastNameInput)) {
        isValid = false;
    }

    var userNameInput = form.querySelector('[name="UserName"]');
    if (!validateField(userNameInput)) {
        isValid = false;
    }

    var emailInput = form.querySelector('[name="Email"]');
    if (!validateField(emailInput) || !validateEmail(emailInput.value)) {
        isValid = false;
    }

    var phoneNumberInput = form.querySelector('[name="PhoneNumber"]');
    if (!validateField(phoneNumberInput) || !validatePhoneNumber(phoneNumberInput.value)) {
        isValid = false;
    }

    var nationalIdInput = form.querySelector('[name="NationalId"]');
    if (!validateField(nationalIdInput)) {
        isValid = false;
    }

    var citySelect = form.querySelector('[name="City"]');
    if (!validateSelect(citySelect)) {
        isValid = false;
    }

    var paymentSelect = form.querySelector('[name="Payment"]');
    if (!validateSelect(paymentSelect)) {
        isValid = false;
    }

    var passwordInput = form.querySelector('[name="Password"]');
    if (!validateField(passwordInput)) {
        isValid = false;
    }

    var verifyPasswordInput = form.querySelector('[name="VerifyPassword1"]');
    if (!validateField(verifyPasswordInput) || !validatePasswordMatch(passwordInput.value, verifyPasswordInput.value)) {
        isValid = false;
    }

    var termsAndConditionsInput = form.querySelector('[name="TermsAndConditions"]');
    if (!validateCheckbox(termsAndConditionsInput)) {
        isValid = false;
    }

    return isValid;
}

// Function to validate a form field (required)
function validateField(field) {
    var errorMessage = field.parentNode.querySelector('.text-danger');

    if (field.value.trim() === '') {
        errorMessage.textContent = 'This field is required.';
        return false;
    }

    return true;
}

// Function to validate an email address
function validateEmail(email) {
    var emailPattern = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    return emailPattern.test(email);
}

// Function to validate a phone number
function validatePhoneNumber(phoneNumber) {
    var phonePattern = /^\d{10}$/;
    return phonePattern.test(phoneNumber);
}

// Function to validate a select field (required)
function validateSelect(selectField) {
    var errorMessage = selectField.parentNode.querySelector('.text-danger');

    if (selectField.value === '') {
        errorMessage.textContent = 'Please select an option.';
        return false;
    }

    return true;
}

// Function to validate password match
function validatePasswordMatch(password, verifyPassword) {
    var errorMessage = verifyPassword.parentNode.querySelector('.text-danger');

    if (password !== verifyPassword) {
        errorMessage.textContent = 'Passwords do not match.';
        return false;
    }

    return true;
}

// Function to validate a checkbox (required)
function validateCheckbox(checkbox) {
    var errorMessage = checkbox.parentNode.parentNode.querySelector('.text-danger');

    if (!checkbox.checked) {
        errorMessage.textContent = 'Please agree to the terms and conditions.';
        return false;
    }

    return true;
}
