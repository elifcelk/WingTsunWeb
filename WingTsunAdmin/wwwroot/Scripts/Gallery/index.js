$(document).ready(function () {
    $(".changeStatus").on("click", function () {
        var id = $(this).attr("data-id");
        ChangeStatus(id);
    });

    $(".deleteButton").on("click", function () {
        var id = $(this).attr("data-id");
        DeleteGallery(id);
    });
});


function ChangeStatus(id) {
    var formData = new FormData();
    formData.append("id", id);
    fetch('/Gallery/ChangeStatus', {
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

function DeleteGallery(id) {
    var formData = new FormData();
    formData.append("id", id);
    fetch('/Gallery/Delete', {
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