﻿window.onload = drawClassAssetResume(); 

function drawClassAssetResume() {

    rows = document.getElementById("datatablesSimple").rows.length - 2;

    const data = {
        labels: ['Utilizadas', 'Disponibles'],
        datasets: [
            {
                label: 'Licencias',
                backgroundColor: ['#146CA4', '#ADD8E6'],
                data: [rows,30]
            }
        ]
    };

    const config = {
        type: 'doughnut',
        data: data,
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'bottom',
                },
                title: {
                    display: false,
                }   
            }
        },
    }

    const myChart = new Chart(
        document.getElementById('licenseChart'),
        config
    )

}

function validarCorreo() {

    let correo = document.getElementById("txtCorreoElectronico").value;

    $.ajax({
        url: "/Usuarios/buscarCorreo",
        type: "POST",
        data: {
            "correo": correo
        },
        dataType: "json",
        success: function (data) {
            if (data != "") {
                document.getElementById("alrMensajeError").innerHTML = "El correo que desea ingresar ya existe"
                document.getElementById("alrMensajeError").style.display = "";
            } else {
                document.getElementById("btnCrearUsuario").disable = false
                document.getElementById("alrMensajeError").style.display = "none";
            }
        }
    })

}

function crearUsuario() {

    var correoElectronico = document.getElementById("txtCorreoElectronico").value;
    var nombre = document.getElementById("txtNombre").value;
    var role = document.getElementById("selRole").value

    $.ajax({
        url: "/Usuarios/crearUsuario",
        type: "POST",
        data: {
            "correoElectronico": correoElectronico,
            "nombre": nombre,
            "role":role
        },
        dataType: "json",
        success: function (data) {
            console.log("User Created");
            window.location.reload(); 
        }
    })
}


function modificarEstadoUsuario(idUsuario, estadoUsuario) {
    if (estadoUsuario == 0) {
        requestType = "/Usuarios/activarUsuario"
    } else {
        requestType = "/Usuarios/desactivarUsuario"
    }

    $.ajax({
        url: requestType,
        type: "POST",
        data: {
            "idUsuario": idUsuario
        },
        dataType: "json",
        success: function (data) {

            auxiliar = data; 

        }
    })
}