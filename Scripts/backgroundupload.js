﻿$(switchBackground);
var fileReader = new FileReader(), filter = /^(?:image\/bmp|image\/cis\-cod|image\/gif|image\/ief|image\/jpeg|image\/jpeg|image\/jpeg|image\/pipeg|image\/png|image\/svg\+xml|image\/tiff|image\/x\-cmu\-raster|image\/x\-cmx|image\/x\-icon|image\/x\-portable\-anymap|image\/x\-portable\-bitmap|image\/x\-portable\-graymap|image\/x\-portable\-pixmap|image\/x\-rgb|image\/x\-xbitmap|image\/x\-xpixmap|image\/x\-xwindowdump)$/i;
fileReader.onload = function (oFREvent) {
    localStorage.setItem('b', oFREvent.target.result);
    switchBackground();
};
function switchBackground() {
    $('body').css('background-image', "url(" + localStorage.getItem('b') + ')');
}
function loadImageFile(testEl) {
    if (!testEl.files.length) { return; }
    var oFile = testEl.files[0];
    if (!filter.test(oFile.type)) { alert("You must select a valid image file"); return n; }
    fileReader.readAsDataURL(oFile);
}