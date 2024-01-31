// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function appAlert(content, title = ' ', btntext = 'تایید') {
    $("<div></div>").kendoAlert({
        title: title,
        content: content,
        messages: {
            okText: btntext
        }
    }).data("kendoAlert").open();
}

function appConfirm(content, title, btnok,btncancel) {
    return $("<div></div>").kendoConfirm({
        title: title,
        content: content,
        messages: {
            okText: btnok,
            cancel: btncancel
        }
    }).data("kendoConfirm").open().result;
}

function showDialogDelete(id,msg,title) {
    appConfirm(msg, title, "تایید", "خیر").then(function () {
        $.ajax({
            url: id,
            method: "POST",
            success: function (result) {
                appAlert(result);
                location.reload();

            }
        });
    }, function () {


    })
}

function getImageEditor(fieldName, imageUrl) {

    let previewitem = `<div id="img${fieldName}">`;
    if (imageUrl) {
        previewitem += `<div class='image-logo'><img class="image-logo-img" src="${imageUrl}" /></div>`;
    }
    previewitem += `</div>`;

    let temphtml = `${previewitem}<div class="k-upload k-upload-sync k-upload-empty" role="application"><div class="k-dropzone k-upload-dropzone"><div class="k-upload-button-wrap"><div class="k-button k-button-md k-rounded-md k-button-solid k-button-solid-base k-upload-button" tabindex="0" role="button"><span class="k-button-text">انتخاب</span>
                    </div><input id="${fieldName}" name="${fieldName}" type="file"  onchange="onSelect(this)" data-role="upload" aria-label="انتخاب" tabindex="-1" aria-hidden="true" autocomplete="off"></div></div></div>
         <script>
         kendo.syncReady(function(){jQuery("#${fieldName}").kendoUpload({"success":onSelect,"dropZone":".dropZoneElement","multiple":false,"showFileList":true,"validation":{"allowedExtensions":[".jpg",".jpeg",".png",".svg",".bmp",".gif"],"minFileSize":1000}});});
         function onSelect(e) {
                let overimg = false;
                let file;
                for (var i = 0; i < e.files.length; i++) {
                    if (i == 0) {
                        file = e.files[i];

                        if (file) {
                            var reader = new FileReader();

                            reader.onloadend = function () {
                                    $("#img${fieldName}").html("<div class='image-logo'><img class='image-logo-img' src=" + this.result + " /></div>");
                            };

                            reader.readAsDataURL(file);

                        }
                    }
                    else {
                        overimg = true;

                    }
                }
                if (overimg) {
                    if (file) {
                      //  e.files = [...file];
                    }
                }
            }

         <\/script>`;
    return temphtml;

}

function getGridImageBox(src) {
    let ans = `<div class='image-min-logo'>`;
    if (src) {
        ans += `<img class='image-logo-img' src='${src}#' />`;
    }
    ans += `</div>`;
    return ans
}
function processTable(data, idField, foreignKey, rootLevel, val) {
    var hash = {};

    for (var i = 0; i < data.length; i++) {
        var item = data[i];
        var id = item[idField];
        item.selected = false;
        if (val) {
            if (val == id) {
                item.selected = true;
            }
        }
        item.expanded = true;
        var parentId = item[foreignKey];

        hash[id] = hash[id] || [];
        hash[parentId] = hash[parentId] || [];

        item.items = hash[id];
        hash[parentId].push(item);
    }

    return hash[rootLevel];
}

function isNumberkendo(evt, el, sidel) {

    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    if (sidel) {
        let sel = document.getElementById(sidel);
        var textbox = $(sel).data("kendoTextBox");
        textbox.value("0");
    }
    if (el) {
        let eel = document.getElementById(el);
        var textboxel = $(eel).data("kendoTextBox");
        let val = textboxel.value();
        if (val == "0") {
            textboxel.value("");
        }
    }
    return true;
}