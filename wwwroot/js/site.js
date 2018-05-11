// Write your JavaScript code.
var slideIndex = 1;
showSlides(slideIndex);

// Next/previous controls
function plusSlides(n) {
  showSlides(slideIndex += n);
}

// Thumbnail image controls
function currentSlide(n) {
  showSlides(slideIndex = n);
}

function showSlides(n) {
  var i;
  var slides = document.getElementsByClassName("mySlides");
  var dots = document.getElementsByClassName("dot");
  if (n > slides.length) { slideIndex = 1;}
  if (n < 1) { slideIndex = slides.length;}
  for (i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
      dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex-1].style.display = "block";
  dots[slideIndex-1].className += " active";
} 

function Lang1()
{
  document.getElementById("1").innerHTML = "Spennu";
  document.getElementById("2").innerHTML = "Rómantík";
  document.getElementById("3").innerHTML = "Grín";
  document.getElementById("4").innerHTML = "Ungir fullorðnir";
  document.getElementById("5").innerHTML = "Heimspeki";
  document.getElementById("6").innerHTML = "Ekki skáldað";
  document.getElementById("tsb").innerHTML = "Metsölu Bækur";
  document.getElementById("cart").innerHTML = "Karfa";
  document.getElementById("su").innerHTML = "Skrá sig inn";
  document.getElementById("language").innerHTML = "Tungumál";
  document.getElementById("eng").innerHTML = "Enska";
  document.getElementById("isk").innerHTML = "Íslenska";
  document.getElementById("username").innerHTML = "Notanda nafn";
  document.getElementById("pass").innerHTML = "Aðgangsorð";
}
function Lang2()
{
  document.getElementById("1").innerHTML = "Action";
  document.getElementById("2").innerHTML = "Romance";
  document.getElementById("3").innerHTML = "Comedy";
  document.getElementById("4").innerHTML = "Young Adults";
  document.getElementById("5").innerHTML = "Philosophy";
  document.getElementById("6").innerHTML = "Non-Fiction";
  document.getElementById("tsb").innerHTML = "Top Selling Books";
  document.getElementById("cart").innerHTML = "Cart";
  document.getElementById("su").innerHTML = "Sign up";
  document.getElementById("language").innerHTML = "Language";
  document.getElementById("eng").innerHTML = "English";
  document.getElementById("isk").innerHTML = "Icelandic";
  document.getElementById("cart").innerHTML = "Cart";
  document.getElementById("su").innerHTML = "Sign up";
  document.getElementById("language").innerHTML = "Language";
  document.getElementById("username").innerHTML = "Username";
  document.getElementById("pass").innerHTML = "Password";
}


function login() {
    var username = document.getElementById("#username").value;
    var password = document.getElementById("#password").value;

    $.ajax({
        type: 'POST',
        url: 'login',
        data: {
            email:    username,
            password: password
        },
        success: function (user) {
            if (user) {
                $('#login-modal').modal('toggle');
                $('#userName').text(user.Name);
                $('#modalError').hide();
            } else {
                $('#modalError').show();
            }
        }
    });
}