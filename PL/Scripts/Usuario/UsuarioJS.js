
function Add(empleado) {

    $.ajax({
        type: 'POST',
        url: 'http://localhost:1142/api/empleado/add',
        dataType: 'json',
        data: empleado,
        success: function (result) {
            $('#ModalForm').modal('hide');
            $('#myModal').modal();

        },
        error: function (result) {
            alert('Error al agregar.' + result.responseJSON.ErrorMessage);
        }
    });
}
function GetById(IdUsuario) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:1142/api/empleado/GetById/' + IdUsuario,
        success: function (result) {
            $('#txtIdEmpleado').val(result.Object.IdUsuario);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellidoPaterno').val(result.Object.ApellidoPaterno);
            $('#txtApellidoMaterno').val(result.Object.ApellidoMaterno);
            $('#txtApellidoPaterno').val(result.Object.ApellidoPaterno);
            $('#txtApellidoMaterno').val(result.Object.ApellidoMaterno);




            $('#ddlRoles').val(result.Object.Estado.IdEstado);

            $('#ModalForm').modal('show');
            $('#lblTitulo').modal('Modificar Empleado');

        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }

    });

}
$.ajax({
    type: 'PUT',
    url: 'http://localhost:1142/api/empleado/update/',
    dataType: 'json',
    data: empleado,
    success: function (result) {

        $('#ModalForm').modal('hide');
        $('#myModal').modal();

        EstadoGetAll();
        GetAll();
        Console(respond);
    },
    error: function (result) {
        alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
    }
});
function ShowModal() {

    $('#ModalForm').modal('show');

    

    InitializeControls();
    $('#lblTitulo').modal('Agregar Nuevo Empleado');

}
function InitializeControls() {

    $('#txtIdEmpleado').val('');
    $('#txtNumeroNomina').val('');
    $('#txtNombre').val('');
    $('#txtApellidoPaterno').val('');
    $('#txtApellidoMaterno').val('');
    $('#ddlEstados').val(0);
    $('#ModalForm').modal('show');
}
