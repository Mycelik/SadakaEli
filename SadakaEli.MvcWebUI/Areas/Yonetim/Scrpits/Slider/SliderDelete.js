$(document).ready(function () {
    $(".btnSliderSil").click(function () {
        var userId = $(this).attr("sliderId");
        var tr = $(this).parent().parent();

        Swal.fire({
            title: 'Silmek İstediğinizden Emin Misiniz?',
            text: "Seçtiğiniz Sliderı Silme İşlemi Gerçekleşiyor.",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet',
            cancelButtonText: 'Hayır'
        }).then((result) => {
            if (result.value) {

                $.ajax({
                    url: "/Yonetim/Slider/Delete/",
                    method: "post",
                    data: { id: userId },
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
                    'Slider Silme İşlemi Yapılmadı!',
                    'Silme İşleminizi Gerçekleşmedi.',
                    'error')

            }
        });

    });

})