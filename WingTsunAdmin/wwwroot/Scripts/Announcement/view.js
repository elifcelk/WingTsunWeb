$(document).ready(function () {
    $("#viewAnnouncementForm").validate({
        rules: {
            name: {
                required: true
            },
            content: {
                required: true
            }
        },
        messages: {
            name: {
                required: "Duyuru başlığı giriniz."
            },
            content: {
                required: "Duyuru içeriği giriniz."
            }
        },
        errorElement: 'div',
        errorPlacement: function (error, element) {
            var placement = $(element).data('error');
            if (placement) {
                $(placement).append(error)
            }
            else {
                error.insertAfter(element);
            }
        },
        submitHandler: function (form) {
            UpdateAnnouncement();
            return false;
        }
    });
});

function UpdateAnnouncement() {
    var dropdown = document.getElementById("type");
    var selectedValue = dropdown.value;

    var formData = new FormData();
    formData.append("id", $("#id").val());
    formData.append("name", $("#name").val());
    formData.append("content", $("#content").val());
    formData.append("type", selectedValue);

    formData.append("file", document.getElementById("file").files[0]);


    fetch('/Announcement/Update', {
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
                        window.location.href = 'list'
                    }
                    else {
                        alert("İşlem başarılı");
                        window.location.assign("https://localhost:7038/announcement/list")

                    }
                }
            });
        }
    })
}