$(document).ready(function () {
    $("#btnNewsUpdate").click(function () {
        var vm = {
            Id: $("#txtNewsId").val(),
            Headline: $("#txtHeadline").val(),
            Explanation: $("#txtExplanation").val()
        };
        $.ajax({
            url: "/Yonetim/News/UpdateNewsJson",
            method: "post",
            dataType: "json",
            data: { vm: vm },
            success: function (response) {
                if (response.Operation) {
                    Swal.fire({
                        type: 'success',
                        title: 'Haber Güncellendi',
                        text: 'Haber Başarıyla Güncellendi',
                    })
                }
                else {
                    alet(response.Message);
                }

            }
        });
    });

});