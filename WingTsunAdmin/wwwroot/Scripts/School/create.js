$(document).ready(function () {
    $("#addSchoolForm").validate({
        rules: {
            name: {
                required: true
            },
            cityName: {
                required: true
            },
            districtName: {
                required: true
            },
            address: {
                required: true
            },
            phone: {
                required: true
            },
            instructorName: {
                required: true
            },
            instructorStatus: {
                required: true
            },
            instructorResume: {
                required: true
            },
            timetable: {
                required: true
            },
            mapLink: {
                required: true
            },
        },
        messages: {
            name: {
                required: "Okul adı giriniz."
            },
            cityName: {
                required: "İl giriniz."
            },
            districtName: {
                required: "İlçe giriniz."
            },
            address: {
                required: "Adres giriniz."
            },
            phone: {
                required: "Telefon numarası giriniz."
            },
            instructorName: {
                required: "Eğitmen adı giriniz."
            },
            instructorStatus: {
                required: "Eğitmen derecesi giriniz."
            },
            instructorResume: {
                required: "Eğitmen geçmişi giriniz."
            },
            timetable: {
                required: "Eğitim saati giriniz."
            },
            mapLink: {
                required: "Adres linki giriniz."
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
            AddSchool();
            return false;
        }
    });
});

function AddSchool() {
    var formData = new FormData();
    formData.append("name", $("#name").val());
    formData.append("cityName", $("#cityName").val());
    formData.append("districtName", $("#districtName").val());
    formData.append("address", $("#address").val());
    formData.append("phone", $("#phone").val());
    formData.append("instructorName", $("#instructorName").val());
    formData.append("instructorStatus", $("#instructorStatus").val());
    formData.append("instructorResume", $("#instructorResume").val());
    formData.append("timetable", $("#timetable").val());
    formData.append("mapLink", $("#mapLink").val());

    formData.append("file", document.getElementById("file").files[0]);
    

    fetch('/School/Create', {
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