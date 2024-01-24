// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function appAlert(content, title,btntext) {
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