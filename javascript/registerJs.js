var menuHolder = document.getElementById('menuHolder')
var siteBrand = document.getElementById('siteBrand')
function menuToggle() {
  if (menuHolder.className === "drawMenu") menuHolder.className = ""
  else menuHolder.className = "drawMenu"
}


// animation of logo 

function myFunction() {
  var img = document.getElementById("my-image");
  img.classList.add("slide-animation");
}


// Example starter JavaScript for disabling form submissions if there are invalid fields
(function () {
  'use strict'

  // Fetch all the forms we want to apply custom Bootstrap validation styles to
  var forms = document.querySelectorAll('.needs-validation')

  // Loop over them and prevent submission
  Array.prototype.slice.call(forms)
    .forEach(function (form) {
      form.addEventListener('click', function (event) {
        if (!form.checkValidity()) {
          event.preventDefault()
          event.stopPropagation()
        }

        form.classList.add('was-validated')
      }, false)
    })
})()
// window.onload = function () {
//   document.getElementById("password1").onchange = validatePassword;
//   document.getElementById("password2").onchange = validatePassword;
// }
// function validatePassword() {
//   var pass2 = document.getElementById("password2").value;
//   var pass1 = document.getElementById("password1").value;
//   if (pass1 =="")
//     document.getElementById("password2").setCustomValidity("Passwords Don't Match");
//     else if(pass1 != pass2){
//       document.getElementById("password1").setCustomValidity("cannot be empty");
//     }
//   else
//     document.getElementById("password2").setCustomValidity('');
//   //empty string means no validation error
// }
document.addEventListener("DOMContentLoaded", function () {
  var password1 = document.getElementById("password1");
  var password2 = document.getElementById("password2");
  var passwordErrorMessage = document.querySelector(".invalid-feedback");

  function checkPasswordNotEmpty() {
    if (password1.value === "") {
      passwordErrorMessage.textContent = "Please enter a password.";
    } else {
      passwordErrorMessage.textContent = ""; // Clear any previous error message
    }
  }

  function checkPasswordMatch() {
    if (password1.value !== password2.value) {
      passwordErrorMessage.textContent = "Passwords do not match.";
    } else {
      passwordErrorMessage.textContent = ""; // Clear any previous error message
    }
  }

  password1.addEventListener("input", checkPasswordNotEmpty);
  password2.addEventListener("input", checkPasswordMatch);
});

