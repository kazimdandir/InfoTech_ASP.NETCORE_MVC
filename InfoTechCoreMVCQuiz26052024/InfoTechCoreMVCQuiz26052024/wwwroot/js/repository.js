function deleteProduct(userId) {
    $.ajax({
        url: '/Product/Delete',
        type: 'POST',
        data: { id: userId },
        success: function (response) {
            if (response.success) {
                location.reload(); // refresh page
            } else {
                alert(response.message);
            }
        },
        error: function () {
            alert('Error occurred while deleting the product.');
        }
    });
}

function updateProduct(event) {
    event.preventDefault();

    Swal.fire({
        title: "Are you sure you want to save the changes?",
        showDenyButton: true,
        confirmButtonText: "Save",
        denyButtonText: `Cancel`
    }).then((result) => {
        if (result.isConfirmed) {
            var formData = new FormData(document.getElementById('editForm'));

            $.ajax({
                url: '/Product/Update',
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
                            window.location.href = '/Product/ProductList';
                        });
                    } else {
                        Swal.fire({
                            title: "Error!",
                            text: response.message,
                            icon: "error"
                        });
                    }
                },
                error: function () {
                    Swal.fire({
                        text: "Something went wrong!",
                        icon: "error"
                    });
                }
            });
        } else if (result.isDenied) {
            Swal.fire({
                text: "No changes have been made!",
                confirmButtonText: "OK",
                icon: "info"
            });
        }
    });
}

