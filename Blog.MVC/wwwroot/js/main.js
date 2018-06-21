var setUpMenu = function(event) {
    var navOverlay = document.getElementsByClassName("overlay")[0];
    
    var marginTop = window.innerHeight / 2;
    var marginLeft = window.innerWidth / 2;
    var height = window.innerHeight;
    var width = window.innerWidth;

    var radius = Math.sqrt(Math.pow(width, 2) + Math.pow(height, 2));
    console.log("Radius: " + radius);
    var diameter = radius * 2;
    navOverlay.style.height = diameter + "px";
    navOverlay.style.width = diameter + "px";
    navOverlay.style.marginTop = -radius + "px";
    navOverlay.style.marginLeft = -(radius - width) + "px";
}

document.addEventListener("DOMContentLoaded", setUpMenu);
window.addEventListener("resize", setUpMenu);