$(document).ready(function () {
    $(".btnAdminSil").click(function () {
        var adminId = $(this).attr("adminId");
        var tr = $(this).parent().parent();

        Swal.fire({
            title: 'Silmek İstediğinizden Emin Misiniz?',
            text: "Seçtiğiniz Admini Silme İşlemi Gerçekleşiyor.",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet',
            cancelButtonText: 'Hayır'
        }).then((result) => {
            if (result.value) {

                $.ajax({
                    url: "/Yonetim/Admin/AdminDeleteJson/",
                    method: "post",
                    data: { id: adminId },
                    dataType: "json",
                    success: function (response) {
                        if (response.Operation) {
                            Swal.fire(
                                'Silindi!',
                                response.Message,
                                'success'
                            )

                            $(tr).remove();
                        }
                    }
                });

            }
            else {
                Swal.fire(
                    'Silinme İşlemi Yapılmadı!',
                    'Silme İşleminizi Gerçekleşmedi.',
                    'error')

            }
        });

    });

})