function GetAll() {
    $.ajax({
        type: 'GET',
        url: '@Url.Action("GetAll", "personalAutorizacion")', 
        success: function (result) {
            $('#tblPersonalAutorizacion tbody').empty();
            $.each(result.Objects, function (i, personalAutorizacion) {
                var filas =
                    '<tr>'
                    + '<td class="text-center"> '
                    + '<a class="glyphicon glyphicon-edit" href="#" onclick="GetById(' + personalAutorizacion.IdPersonalAutorizacion + ')">'

                    + '</a> '
                    + '</td>'
                    + "<td  id='id' class='text-center'>" + personalAutorizacion.IdPersonalAutorizacion + "</td>"
                    
                    + "<td class='text-center'>" + personalAutorizacion.Nombre + " " + personalAutorizacion.ApellidoPaterno + " " + personalAutorizacion.ApellidoMaterno + "</td>"
            
                    + '<td class="text-center"> <button class="btn btn-danger" onclick="Eliminar(' + personalAutorizacion.IdPersonalAutorizacion + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";


                $("#tblPersonalAutorizacion tbody").append(filas);

            });
        },
        error: function (result) {
            alert('Error al consultar el personal.' + result.responseJSON.ErrorMessage);

        }
    });
}
function InitializeControls() {

    $('#txtIdPersonalAutorizacion').val('');
    $('#txtNombre').val('');
    $('#txtApellidoPaterno').val('');
    $('#txtApellidoMaterno').val('');
    $('#ModalForm').modal('show');

}

function ShowModal() {

    $('#ModalForm').modal('show');

    //EstadoGetAll();

    InitializeControls();
    $('#lblTitulo').modal('Agregar Nuevo Personal');

}