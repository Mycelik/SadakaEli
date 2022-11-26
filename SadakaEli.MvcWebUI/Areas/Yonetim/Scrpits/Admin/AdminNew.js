$(document).ready(function () {

    $.validator.addMethod("passwordCheck", function (value) {
        return /^[A-Za-z0-9\d=!\-@._*]*$/.test(value) // consists of only these
            && /[a-z]/.test(value) // has a lowercase letter
            && /\d/.test(value) // has a digit
    });


    $("#btnSave").click(function () {

        $("#frmNewAdmin").validate({
            rules: {
                txtFullName: {
                    required: true,
                    minlength: 3
                },
                txtEmail: {
                    required: true,
                    email: true
                },
                txtPassword: {
                    required: true,
                    minlength: 5,
                    passwordCheck: true
                },
                txtRePassword: {
                    required: true,
                    minlength: 5,
                    passwordCheck: true,
                    equalTo: "#txtPassword"
                }
            },
            messages: {
                txtFullName: {
                    required: "Ad Soyad Boş Bırakılamaz.",
                    minlength: "Ad Soyad en az 2 karakterden oluşmalıdır."
                },
                txtEmail: {
                    required: "Email Boş Bırakılamaz.",
                    email: "Gerçerli bir email adresi yazmalısınız."
                },
                txtPassword: {
                    required: "Şifre Boış bırakılamaz.",
                    minlength: "Şifre en az 5 karakterli olmalıdır.",
                    passwordCheck: "Şifrede en az 1 küçük harf en az 1 rakam olmalıdır."
                },
                txtRePassword: {
                    required: "Şifre Boş bırakılamaz.",
                    minlength: "Şifre en az 5 karakterli olmalıdır.",
                    passwordCheck: "Şifrede en az 1 küçük harf en az 1 rakam olmalıdır.",
                    equalTo: "Şifre ile tekrarı aynı olşmalıdır."
                }
            }
        });

        var isFormValid = $("#frmNewAdmin").valid();
        if (isFormValid) {
            var formData = new FormData();
            formData.append('adminImage', $('#fuPhoto')[0].files[0]);

            $.ajax({
                url: "/Yonetim/Admin/UploadPhoto",
                method: 'post',
                dataType: 'json',
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    if (response.Result) {
                        var vm =
                        {
                            FullName: $("#txtFullName").val(),
                            Email: $("#txtEmail").val(),
                            Password: $("#txtPassword").val(),
                            RePassword: $("#txtRePassword").val(),
                            RoleId: $("#ddlRoles").val(),
                            FileName: response.FileName
                        };



                        $.ajax({
                            url: "/Yonetim/Admin/AdminNew",
                            method: 'post',
                            dataType: 'json',
                            data: vm,
                            success: function (response) {
                                if (response.Result) {
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