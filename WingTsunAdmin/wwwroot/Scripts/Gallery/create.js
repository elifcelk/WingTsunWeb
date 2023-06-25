$(document).ready(function () {
   
});
$(".addPhoto").on("click", function () {
    AddPhoto();
});
function AddPhoto() {
    var formData = new FormData();
    formData.append("file", document.getElementById("file").files[0]);

    fetch('/Gallery/Create', {
        method: 'POST',
        body: formData
    }).then(response => {
        if (!response.ok) {
            alert("Hata");
        }
        else {
            response.json().then(result => {
                if (!result.succeeded) {
                    alert("Resim yüklemediniz");
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