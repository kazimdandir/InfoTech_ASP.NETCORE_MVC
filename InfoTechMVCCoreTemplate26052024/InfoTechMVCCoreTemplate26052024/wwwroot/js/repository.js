function submitForm(event) {
    event.preventDefault(); // Varsayılan form gönderimini engeller
    Swal.fire({
        position: "top-end",
        icon: "success",
        title: "Öğrenci başarıyla silinmiştir. Lütfen bekleyiniz...",
        showConfirmButton: false,
        timer: 1500
    }).then(() => {
        //TumListe sayfasına yönlenir
        window.location.href = '/Egitim/TumListe';
    });
}

function applyForm(event) {
    event.preventDefault(); // Varsayılan form gönderimini engeller

    var formData = $('#applyForm').serialize();

    $.ajax({
        url: '/Egitim/Apply',
        type: 'POST',
        data: formData,
        success: function (response) {
            if (response.success) {
                Swal.fire({
                    position: "top-end",
                    icon: "success",
                    title: response.message,
                    showConfirmButton: false,
                    timer: 3000
                }).then(() => {
                    window.location.href = '/Egitim/TumListe';
                });
            } else {
                var errorMessage = response.message;
                if (response.errors && response.errors.length > 0) {
                    errorMessage += "\n\n" + response.errors.join("\n");
                }
                Swal.fire({
                    icon: 'error',
                    title: 'Hata',
                    text: errorMessage
                });
            }
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Hata',
                text: 'Bir hata oluştu. Lütfen tekrar deneyin.'
            });
        }
    });
}


function confirmEdit(event) {
    event.preventDefault();

    Swal.fire({
        title: "Değişiklikleri kaydetmek istediğinize emin misiniz?",
        showDenyButton: true,
        confirmButtonText: "Kaydet",
        denyButtonText: `Vazgeç`
    }).then((result) => {
        if (result.isConfirmed) {
            var formData = new FormData(document.getElementById('editForm'));

            $.ajax({
                url: '/Egitim/EditUser',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    if (response.success) {
                        Swal.fire({
                            text: response.message,
                            icon: "success",
                        }).then(() => {
                            window.location.href = '/Egitim/TumListe';
                        });
                    } else {
                        Swal.fire({
                            title: "Hata!",
                            text: response.message,
                            icon: "error"
                        });
                    }
                },
                error: function () {
                    Swal.fire({
                        text: "Bir hata oluştu.",
                        icon: "error"
                    });
                }
            });
        } else if (result.isDenied) {
            Swal.fire({
                text: "Herhangi bir değişiklik yapılmamıştır!",
                confirmButtonText: "Tamam",
                icon: "info"
            });
        }
    });
}


function deleteUser(userId) {
    Swal.fire({
        title: "Kaydı silmek istediğinize emin misiniz?",
        showDenyButton: true,
        confirmButtonText: "Sil",
        denyButtonText: `Vazgeç`
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Egitim/DeleteUser',
                type: 'POST',
                data: { id: userId },
                success: function (response) {
                    if (response.success) {
                        Swal.fire({
                            text: response.message,
                            icon: "success",
                        }).then(() => {
                            location.reload(); // Sayfayı yenilemek
                        });
                    } else {
                        Swal.fire({
                            title: "Hata!",
                            text: response.message,
                            icon: "error"
                        });
                    }
                },
                error: function () {
                    Swal.fire({
                        text: response.message,
                        icon: "error"
                    });
                }
            });
        } else if (result.isDenied) {
            Swal.fire({
                text: "Herhangi bir değişiklik yapılmamıştır!",
                confirmButtonText: "Tamam",
                icon: "info"
            });
        }
    });
}




