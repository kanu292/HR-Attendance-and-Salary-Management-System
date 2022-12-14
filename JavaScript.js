function opennavmenu() {
    //val v = session["val"];
    //if (v == 1) {
        document.getElementById("myslidemenu").style.width = "250px";
    //}
}

function closenavmenu() {
    document.getElementById("myslidemenu").style.width = "0px";
}

function openpopup() {
    window.open('PanelHoliday', this, 'resizable=no,width=200,height=400');
}