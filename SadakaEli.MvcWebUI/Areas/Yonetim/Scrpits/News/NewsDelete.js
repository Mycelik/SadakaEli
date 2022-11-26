$(document).ready(function () {
    $(".btnNewsSil").click(function () {
        var newsId = $(this).attr("newsId");
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
                    url: "/Yonetim/News/DeleteNewsJson/",
                    method: "post",
                    data: { id: newsId },
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