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

function confirmEdit(event) {
    event.preventDefault(); 
    Swal.fire({
        title: "Değişiklikleri kaydetmek istediğinize emin misiniz?",
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: "Kaydet",
        denyButtonText: `Vazgeç`
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            // Sadece Kaydet butonuna tıklandığında işlemleri gerçekleştir
            Swal.fire({
                title: "Yapmış olduğunuz düzenleme kaydedilmiştir!",
                icon: "success",
            }).then(() => {
                window.location.href = '/Egitim/TumListe';
            });
        } else if (result.isDenied) {
            Swal.fire("Herhangi bir değişiklik yapılmamıştır!", "", "info");
        }
    });
}


//Silme işlemi için sayfa yönlendirme yerine sweet alert kullanılacak

function confirmDelete(event) {
    event.preventDefault();
    Swal.fire({
        title: "Kaydı silmek istediğinize emin misiniz?",
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: "Sil",
        denyButtonText: `Vazgeç`
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire({
                title: "Kayıt silinmiştir!",
                icon: "success",
            }).then(() => {
                window.location.href = '/Egitim/TumListe';
            });
        } else if (result.isDenied) {
            Swal.fire("Herhangi bir değişiklik yapılmamıştır!", "", "info");
        }
    });
}