function showFormBand() {
    if (document.getElementById("formA")) {
        document.getElementById("FormA").style.display = "block";
        document.getElementById("FormB").style.display = "none";
    }
}

function showFormVenue() {
    if (document.getElementById("formB")) {
        document.getElementById("FormB").style.display = "block";
        document.getElementById("FormA").style.display = "none";
    }
}