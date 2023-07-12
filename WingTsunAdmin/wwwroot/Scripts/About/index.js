$(document).ready(function () {
    $(".deleteButton").on("click", function () {
        var id = $(this).attr("data-id");
        DeleteAbout(id);
    });
});

function DeleteAbout(id) {
    var formData = new FormData();
    formData.append("id", id);
    fetch('/About/Delete', {
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