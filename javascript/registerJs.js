var menuHolder = document.getElementById('menuHolder')
var siteBrand = document.getElementById('siteBrand')
function menuToggle(){
  if(menuHolder.className === "drawMenu") menuHolder.className = ""
  else menuHolder.className = "drawMenu"
}
if(window.innerWidth < 426) siteBrand.innerHTML = "MAS"
window.onresize = function(){
  if(window.innerWidth < 420) siteBrand.innerHTML = "MAS"
  else siteBrand.innerHTML = "MY AWESOME WEBSITE"
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
  window.onload = function () {
    document.getElementById("password1").onchange = validatePassword;
    document.getElementById("password2").onchange = validatePassword;
  }
  function validatePassword() {
    var pass2 = document.getElementById("password2").value;
    var pass1 = document.getElementById("password1").value;
    if (pass1 =="")
      document.getElementById("password2").setCustomValidity("Passwords Don't Match");
      else if(pass1 != pass2){
        document.getElementById("password1").setCustomValidity("cannot be empty");
      }
    else
      document.getElementById("password2").setCustomValidity('');
    //empty string means no validation error
  }