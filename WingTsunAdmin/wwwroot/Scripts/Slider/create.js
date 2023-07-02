$(document).ready(function () {
    $("#addSliderForm").validate({
        rules: {
            title: {
                required: true
            },
            description: {
                required: true
            },
        },
        messages: {
            title: {
                required: "Başlık giriniz."
            },
            description: {
                required: "Açıklama giriniz."
            },
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
            AddSlider();
            return false;
        }
    });
});

function AddSlider() {
    var formData = new FormData();
    formData.append("file", document.getElementById("file").files[0]);
    formData.append("title", $("#title").val());
    formData.append("description", $("#description").val());

    fetch('/Slider/Create', {
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