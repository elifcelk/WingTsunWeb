$(document).ready(function () {
    $("#addSocialMediaForm").validate({
        rules: {
            title: {
                required: true
            },
            path: {
                required: true
            }
        },
        messages: {
            title: {
                required: "Başlık giriniz."
            },
            path: {
                required: "Link giriniz."
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
            AddSocialMedia();
            return false;
        }
    });
});

function AddSocialMedia() {
    var formData = new FormData();
    formData.append("title", $("#title").val());
    formData.append("path", $("#path").val());

    fetch('/SocialMedia/Create', {
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
                        window.location.href = 'list'
                    }
                }
            });
        }
    })
}