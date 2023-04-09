function visualizarActivo(idActivo) {

    $.ajax({
        url: "/Activo/detalleActivo",
        type: "POST",
        data: {
            "idActivo": idActivo,
        },
        dataType: "json",
        success: function (data) {
            alert("chagne")
        }
    })

}