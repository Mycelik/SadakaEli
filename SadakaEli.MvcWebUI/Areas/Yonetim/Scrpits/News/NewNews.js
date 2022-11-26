$(document).ready(function () {
    $("#txtExplanation").summernote();
    $("#btnSave").click(function () {

        $("#frmNewNews").validate({
            rules: {
                txtHeadline: {
                    required: true,
                    minlength: 5
                },
                txtExplanation: {
                    required: true,
                    minlength: 50
                },
               
            },
            messages: {
                txtHeadline: {
                    required: "Haber başlığı boş bırakılamaz.",
                    minlength: "Haber başlığı en az 5 karakterden oluşmalıdır."
                },
                txtExplanation: {
                    required: "Haber içeriği boş bırakılamaz.",
                    minlength: "Haber içeriği en az 50 karakterden oluşmalıdır."
                },
            }
        });

        var isFormValid = $("#frmNewNews").valid();
        if (isFormValid) {
            var formData = new FormData();
            formData.append('newsImage', $('#fuPhoto')[0].files[0]);

            $.ajax({
                url: "/Yonetim/News/UploadPhoto",
                method: 'post',
                dataType: 'json',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    if (response.Result) {
                        var vm =
                        {
                            Headline: $("#txtHeadline").val(),
                            Explanation: $("#txtExplanation").summernote('code'),
                            FileName: response.FileName
                        };

                        $.ajax({
                            url: "/Yonetim/News/NewNewsJson",
                            method: 'post',
                            dataType: 'json',
                            data: vm,
                            success: function (resp) {
                                if (resp.Result) {
                                    alert("Kayıt Başarılı");
                                }
                                else {
                                    $("#divErrorMessages").html(resp.ErrorMessages)
                                    $("#divErrorMessages").css({
                                        "border": "1px solid black",
                                        "color": "red",
                                        "background-color": "yellow",
                                        "height": "200px"
                                    });
                                }
                            }
                        });

                    }
                    else {
                        alert("Dosya yüklenirken bir hata oldu : " + response.Message);
                    }
                }
            });
        }

    });

});