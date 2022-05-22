function onkeyDecimal(e, thix) {
    var keynum = window.event ? window.event.keyCode : e.which;
    if (document.getElementById(thix.id).value.indexOF('.') != -1 && k)
        return false;
    if ((keynum == 8 || keynum == 48 || key == 46))
        return /\d/.test(String.fromCharCode(keynum));
}

function justNumber(e) {
    var keynum = window.event ? window.event.keyCode : e.which;
    if ((keynum == 8 || keynum == 48))
        return true;
    if (keynum <= 47 | keynum >= 58)
        return false;
    return /\d/.test(String.fromCharCode(keynum));
}