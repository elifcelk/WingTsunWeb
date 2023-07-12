$(document).ready(function () {
    $("#addContactForm").validate({
        rules: {
            title: {
                required: true
            },
            phoneNumber: {
                required: true
            }
        },
        messages: {
            title: {
                required: "Ad soyad giriniz."
            },
            phoneNumber: {
                required: "Telefon numarası giriniz."
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
            AddContact();
            return false;
        }
    });
});

function AddContact() {
    var formData = new FormData();
    formData.append("title", $("#title").val());
    formData.append("phoneNumber", $("#phoneNumber").val());

    fetch('/Contact/Create', {
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