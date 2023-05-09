
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

  // cards functions 
  
  function moveToSelected(element) {

    if (element == "next") {
      var selected = $(".selected").next();
    } else if (element == "prev") {
      var selected = $(".selected").prev();
    } else {
      var selected = element;
    }
  
    var next = $(selected).next();
    var prev = $(selected).prev();
    var prevSecond = $(prev).prev();
    var nextSecond = $(next).next();
  
    $(selected).removeClass().addClass("selected");
  
    $(prev).removeClass().addClass("prev");
    $(next).removeClass().addClass("next");
  
    $(nextSecond).removeClass().addClass("nextRightSecond");
    $(prevSecond).removeClass().addClass("prevLeftSecond");
  
    $(nextSecond).nextAll().removeClass().addClass('hideRight');
    $(prevSecond).prevAll().removeClass().addClass('hideLeft');
  
  }
  
  // Eventos teclado
  $(document).keydown(function(e) {
      switch(e.which) {
          case 37: // left
          moveToSelected('prev');
          break;
  
          case 39: // right
          moveToSelected('next');
          break;
  
          default: return;
      }
      e.preventDefault();
  });
  
  $('#carousel div').click(function() {
    moveToSelected($(this));
  });
  
  $('#prev').click(function() {
    moveToSelected('prev');
  });
  
  $('#next').click(function() {
    moveToSelected('next');
  });



  // login part 




 