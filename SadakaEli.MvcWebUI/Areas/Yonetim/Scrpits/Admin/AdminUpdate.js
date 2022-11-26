$(document).ready(function () {
    $("#btnAdminUpdate").click(function () {
        var vm =
        {
            Id:$("#txtAdminId").val(),
            FullName:$("#txtFullName").val(),
            Password:$("#txtPassword").val(),
            Email:$("#txtEmail").val(),


        };  

        $.ajax({
            url: "/Yonetim/Admin/AdminUpdateJson",
            method: "post",
            datatype: "json",
            data: { vm: vm },
            success: function (response) {
                if (response.Operation) {
                    Swal.fire({
                        type: 'success',
                        title: 'Admin Güncellendi',
                        text: 'Admin Başarıyla Güncellendi',
                    })
                }
                else
                    alert(response.Message);
            }
        });

    });

    $(document).on("click", "#yetkiAta", async function () {
        var select = '<select id="yetkiId">' +
            '<option value="2">NewsAdmin</option>' + '</select>';


         
        const { value: formValues } = await Swal.fire({
                title: "Yetki Düzenleme",
                html: select
            })

        var adminId = $(this).attr("data-id");
        var yetkiId = $("#yetkiId").val();
        var yetkiAd = $("#yetkiId option:selected").text();
        var button = $(this);

        $.ajax({
            url: "/Yonetim/Admin/AdminRoleUpdateJson",
            method: "post",
            datatype: "json",
            data: { 'yetkiId': yetkiId, 'adminId': adminId },
            success: function (response) {

                if (response.Operation) {
                    button.text(yetkiAd);
                    Swal.fire({
                        type: 'success',
                        title: 'Yetki Güncellendi',
                        text: 'Yetki Başarıyla Güncellendi',
                    })
                }
                else
                    alert(response.Message);
            }
        });

    });

});