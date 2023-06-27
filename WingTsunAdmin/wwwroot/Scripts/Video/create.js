$(document).ready(function () {
    $("#addVideoForm").validate({
        rules: {
            videoUrl: {
                required: true
            }
        },
        messages: {
            videoUrl: {
                required: "Link ekleyiniz."
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
            AddVideo();
            return false;
        }
    });
});
function AddVideo() {
    var formData = new FormData();
    formData.append("videoUrl", $("#videoUrl").val());

    fetch('/Video/Create', {
        method: 'POST',
        body: formData
    }).then(response => {
        if (!response.ok) {
            alert("Hata");
        }
        else {
            response.json().then(result => {
                if (!result.succeeded) {
                    alert("Hata oluştu");
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