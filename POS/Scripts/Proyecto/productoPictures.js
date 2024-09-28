$(document).ready(function() {
    $(".guardarBtn").click(function () {
        var clickedBtn = $(this);
        var btnId = clickedBtn.attr('id').replace("guardarBtn", "");

        var formFiles = $(getinputName(btnId)).get(0).files;

        var formData = new FormData();

        for (var i = 0; i < formFiles.length; i++) {  
            formData.append(formFiles[i].name, formFiles[i]);  
        }

        formData.append("ID", btnId);
        $.ajax({  
			url: '/Productos/ChangeImage',  
            type: "POST",  
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: formData,  
            success: function (result) {  
                alert(result);  
            },  
            error: function (err) {  
                alert(err.statusText);  
            }  
        });

    });

    $(".guardarNewBtn").click(function () {
        var clickedBtn = $(this);
        var btnId = clickedBtn.attr('id').replace("guardarNewBtn", "");

        var formFiles = $(getnewInputName(btnId)).get(0).files;

        var formData = new FormData();

        for (var i = 0; i < formFiles.length; i++) {  
            formData.append(formFiles[i].name, formFiles[i]);  
        }

        formData.append("ID", btnId);
        $.ajax({  
            url: '/Productos/SaveImage',  
            type: "POST",  
            contentType: false, // Not to set any content header  
            processData: false, // Not to process data  
            data: formData,  
            success: function (result) {  
                alert(result);  
            },  
            error: function (err) {  
                alert(err.statusText);  
            }  
        });

    });
});

function getinputName(id) {
    return "#" + "inputFile" + id;
}
function getnewInputName(id) {
    return "#" + "inputNewFile" + id;
}