function changeLogo(id) {
    $('#' + id).click();
   
}

function removeImage(url, idImg, idRemove) {
    console.log('Eliminando imagen');
    $('#' + idImg).attr('src', url);
    $('#' + idImg).attr('files', []);
    $('#' + idRemove).val(1);

    showMyImageRefresh(url);
}


function showMyImageRefresh(src) {
    console.log('refrescando imagen');
    var img = document.getElementById("FotoResources");
    img.file = null;
    img.src = src;
    var reader = new FileReader();
    reader.onload = (function (aImg) {
        return function (e) {
            aImg.src = e.target.result;
        };
    })(img);
}