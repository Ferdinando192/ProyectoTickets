
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

