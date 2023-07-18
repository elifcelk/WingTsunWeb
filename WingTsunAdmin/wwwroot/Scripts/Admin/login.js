$(document).ready(function () {
    $("#loginForm").validate({
        rules: {
            userName: {
                required: true
            },
            password: {
                required: true
            }
        },
        messages: {
            userName: {
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
            AddAdminUser();
            return false;
        }
    });
});
function AddAdminUser() {
    var formData = new FormData();
    formData.append("userName", $("#userName").val());
    formData.append("password", $("#password").val());
    console.log($("#userName").val(), $("#password").val())

    fetch('/Admin/SignIn', {
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
                        window.location.href = '/Home/Index'
                    }
                }
            });
        }
    })
}