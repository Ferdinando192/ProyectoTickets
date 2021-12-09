
/*Sweet alert Eliminar Incidente*/
$('#alertaBorrar').click(function () {
  
    Swal.fire({

        position: 'top-end',
        icon: 'error',
        title: 'Se ha borrado el ticket',
        showConfirmButton: false,
        timer: 3500
    })
})

$('#alertaBorrarDepartamento').click(function () {

    Swal.fire({

        position: 'center',
        icon: 'error',
        title: 'Se ha borrado el Departamento',
        showConfirmButton: false,
        timer: 3500
    })
})

$('#alertaCrearDepartamento').click(function () {

    Swal.fire({

        position: 'center',
        icon: 'success',
        title: 'Se ha creado el Departamento',
        showConfirmButton: false,
        timer: 3500
    })
})

