$(document).ready(function () {
    $("#viewAboutForm").validate({
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
            UpdateAbout();
            return false;
        }
    });
});

function UpdateAbout() {
    var formData = new FormData();
    formData.append("id", $("#id").val());
    formData.append("title", $("#title").val());
    formData.append("text", $("#text").val());


    fetch('/About/Update', {
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
                        window.location.assign("https://localhost:7038/about/list")

                    }
                }
            });
        }
    })
}