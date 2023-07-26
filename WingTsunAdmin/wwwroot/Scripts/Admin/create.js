$(document).ready(function () {
    $("#addAdminForm").validate({
        rules: {
            username: {
                required: true
            },
            password: {
                required: true
            }
        },
        messages: {
            username: {
                required: "Kullanıcı adı giriniz."
            },
            password: {
                required: "Şifre giriniz."
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
            AddAdmin();
            return false;
        }
    });
});

function AddAdmin() {
    var formData = new FormData();
    formData.append("username", $("#username").val());
    formData.append("password", $("#password").val());

    fetch('/Admin/Create', {
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