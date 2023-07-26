﻿$(document).ready(function () {
    $(".deleteButton").on("click", function () {
        var id = $(this).attr("data-id");
        DeleteAdmin(id);
    });
});

function DeleteAdmin(id) {
    var formData = new FormData();
    formData.append("id", id);
    fetch('/Admin/Delete', {
        method: 'POST',
        body: formData
    }).then(response => {
        if (!response.ok) {
            alert("Hata");
        }
        else {
            response.json().then(result => {
                if (!result.succeeded) {
                    alert(result.message);
                    location.reload();
                }
                else {
                    if (result.message != null) {
                        alert(result.message);
                        location.reload();
                    }
                    else {
                        alert("İşlem başarılı");
                        location.reload();
                    }
                }
            });
        }
    })
}