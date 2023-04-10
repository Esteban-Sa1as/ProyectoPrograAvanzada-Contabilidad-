function editarValidacion(idActivo, idValidacion) {

    Swal.fire({
        title: 'Indique el valor de la validación',
        input: 'text',
        inputAttributes: {
            autocapitalize: 'off'
        },
        showCancelButton: true,
        confirmButtonText: 'Modificar',
        confirmButtonColor: '#4C9A2A',
        showLoaderOnConfirm: true,
        preConfirm: (valor) => {

            //Editar el activo
            $.ajax({
                url: "/Activo/editarValidacion",
                type: "POST",
                data: {
                    "idActivo": idActivo,
                    "idValidacion": idValidacion,
                    "valor": valor
                },
                dataType: "json",
                success: function (data) {
                    window.location.reload(); 
                }
            })


        },
        allowOutsideClick: () => !Swal.isLoading()
    })

}

function agregarValidacion(idActivo, idValidacion) {

    Swal.fire({
        title: 'Indique el valor de la validación',
        input: 'text',
        inputAttributes: {
            autocapitalize: 'off'
        },
        showCancelButton: true,
        confirmButtonText: 'Agregar',
        confirmButtonColor: '#4C9A2A',
        showLoaderOnConfirm: true,
        preConfirm: (valor) => {

            //Editar el activo
            $.ajax({
                url: "/Activo/agregarValidacion",
                type: "POST",
                data: {
                    "idActivo": idActivo,
                    "idValidacion": idValidacion,
                    "valor": valor
                },
                dataType: "json",
                success: function (data) {
                    window.location.reload(); 
                }
            })


        },
        allowOutsideClick: () => !Swal.isLoading()
    })

}