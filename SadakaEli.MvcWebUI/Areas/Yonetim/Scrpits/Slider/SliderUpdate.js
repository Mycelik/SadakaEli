$(document).ready(function () {
    $("#btnUpdate").click(function () {

        var formData = new FormData();
        formData.append('SliderImage', $('#slPhoto')[0].files[0]);

        $.ajax({
            url: "/Yonetim/Slider/UploadPhoto",
            method: 'post',
            dataType: 'json',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                if (response.Result) {
                    var vm =
                    {
                        Id: $("#txtSliderId").val(),
                        Title: $("#txtSliderTitle").val(),
                        ImagePath: response.FileName
                    };
                    $.ajax({
                        url: "/Yonetim/Slider/SliderUpdateJson",
                        method: 'post',
                        dataType: 'json',
                        data: vm,
                        success: function (resp) {
                            if (resp.Result) {
                                alert("Kayıt Başarılı");
                            }
                        }
                    });

                }
                else {
                    alert("Dosya yüklenirken bir hata oldu : " + response.Message);
                }
            }
        });

    });
});