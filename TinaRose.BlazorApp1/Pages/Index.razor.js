function loadBackgroundImage(url) {
    var img = new Image();
    img.src = url;
    img.onload = function () {
        var backgroundImage = document.getElementById("background-image");
        backgroundImage.style.backgroundImage = `url(${img.src})`;
        var loader = document.querySelector(".loader");
        loader.style.display = "none";
    };
}
