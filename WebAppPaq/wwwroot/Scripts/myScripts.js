

function LoadTipoProducto(tipoProducto) {

    $('#peso').val(0);
    $('#monto').val(0);

    if ($(tipoProducto).val() == undefined || $(tipoProducto).val() == "Seleccionar") {
        $("#peso").attr('disabled', 'disabled');
        $("#monto").attr('disabled', 'disabled');
    } else {


        if ($(tipoProducto).val() == "Dinero") {
            $("#peso").attr('disabled', 'disabled');
            $("#monto").removeAttr('disabled');

        } else {
            $("#monto").attr('disabled', 'disabled');
            $("#peso").removeAttr('disabled');
        }
    }
}

$(document).ready(function () {

    $('#total').val(0.00);

    //Add button click event
    $('#add').click(function () {
        //validation and add order items
       // var isAllValid = true;

        //if ($('#tipoProducto').val() == "Seleccionar") {
        //    isAllValid = false;
        //    $('#tipoProducto').siblings('span.error').css('visibility', 'visible');
        //}
        //else {
        //    $('#tipoProducto').siblings('span.error').css('visibility', 'hidden');
        //}

        //if (!($('#peso').val().trim() != '' && (parseInt($('#peso').val()) || 0))) {
        //    isAllValid = false;
        //    $('#peso').siblings('span.error').css('visibility', 'visible');
        //}
        //else {
        //    $('#monto').siblings('span.error').css('visibility', 'hidden');
        //}

        //if (!($('#monto').val().trim() != '' && (parseInt($('#monto').val()) || 0))) {
        //    isAllValid = false;
        //    $('#monto').siblings('span.error').css('visibility', 'visible');
        //}
        //else {
        //    $('#monto').siblings('span.error').css('visibility', 'hidden');
        //}

        // console.log(isAllValid);

        //if (isAllValid) {

        // set precio
        var precioPorLibra = 125;
        var precioPorMonto = 0.10;
        var precio = 0;

        var tipoProducto = $('#tipoProducto').val();
        var monto = $('#monto').val();
        var peso = $('#peso').val();

        if (tipoProducto == "Dinero") {
            precio = (precioPorMonto * monto).toFixed(2);
        } else {
            precio = (precioPorLibra * peso).toFixed(2);
        }

        // set precio
        $('#precio').val(precio);

        ////set total
        //$('#total').val(precio);

        $("#monto").attr('disabled', 'disabled');
        $("#peso").attr('disabled', 'disabled');
        //$("#tipoProducto").attr('disabled', 'disabled');

        var $newRow = $('#mainrow').clone().removeAttr('id');
        $('.tp', $newRow).val($('#tipoProducto').val());
        $('.sucursal', $newRow).val($('#sucursalDetalle').val());

        //Replace add button with remove button
        $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

        //remove id attribute from new clone row
        $('#tipoProducto,#peso,#monto,#add', $newRow).removeAttr('id');
        $('span.error', $newRow).remove();
        //append clone row
        $('#orderdetailsItems').append($newRow);

        calcularTotal();

        //clear select data
        $('#tipoProducto').val('Seleccionar');
        $('#peso, #monto').val('0');
        $('#precio').val('0');
        $('#orderItemError').empty();
        LoadTipoProducto(undefined);
        //}

    })

    function calcularTotal() {
        var total = 0.00;

        $('#orderdetailsItems > tbody  > tr').each(function () {
            var precio = $(this).find("input#precio").val();

            total += parseInt(precio);
        });

        $('#total').val(total);
       
    }

    //remove button click event
    $('#orderdetailsItems').on('click', '.remove', function () {
        $(this).parents('tr').remove();
        calcularTotal();
    });

    $('#submit').click(function () {
        var isAllValid = true;

        //validate order items
        $('#orderItemError').text('');
        var list = [];
        var errorItemCount = 0;
        $('#orderdetailsItems tbody tr').each(function (index, ele) {
            //if (
            //    $('select.tipoProducto', this).val() == "Seleccionar" ||
            //    (parseInt($('.monto', this).val()) || 0) == 0 ||
            //    $('.precio', this).val() == "" ||
            //    isNaN($('.precio', this).val())
            //) {
            //    errorItemCount++;
            //    $(this).addClass('error');
            //} else {


       
                var orderItem = {
                    TipoProducto: $('.tp', this).val(),
                    PesoProducto: parseInt($('.peso', this).val()),
                    MontoEnvio: parseFloat($('.monto', this).val()),
                    Precio: parseFloat($('.precio', this).val()),
                    SucursalId: parseInt($('.sucursal', this).val())

                }
                list.push(orderItem);


           // }
        })

        //if (errorItemCount > 0) {
        //    $('#orderItemError').text(errorItemCount + " invalid entry in order item list.");
        //    isAllValid = false;
        //}

        //if (list.length == 0) {
        //    $('#orderItemError').text('At least 1 order item required.');
        //    isAllValid = false;
        //}

        //if ($('#orderNo').val().trim() == '') {
        //    $('#orderNo').siblings('span.error').css('visibility', 'visible');
        //    isAllValid = false;
        //}
        //else {
        //    $('#orderNo').siblings('span.error').css('visibility', 'hidden');
        //}

        //if ($('#orderDate').val().trim() == '') {
        //    $('#orderDate').siblings('span.error').css('visibility', 'visible');
        //    isAllValid = false;
        //}
        //else {
        //    $('#orderDate').siblings('span.error').css('visibility', 'hidden');
        //}

        if (isAllValid) {
            var data = {
                NombreClienteEnvia: $('#nombreClienteEnvia').val().trim(),
                ApellidoClienteEnvia: $('#apellidoClienteEnvia').val().trim(),
                TelefonoClienteEnvia: $('#telefonoClienteEnvia').val().trim(),
                CedulaClienteEnvia: $('#cedulaClienteEnvia').val().trim(),
                NombreClienteRecibe: $('#nombreClienteRecibe').val().trim(),
                ApellidoClienteRecibe: $('#apellidoClienteRecibe').val().trim(),
                TelefonoClienteRecibe: $('#telefonoClienteRecibe').val().trim(),
                CedulaClienteRecibe: $('#cedulaClienteRecibe').val().trim(),
                TelefonoClienteEnvia: $('#telefonoClienteEnvia').val().trim(),
                SucursalId: $('#SucursalId').val().trim(),
                Total: $('#total').val().trim(),
                DetalleFacturas: list
            };

            console.log(data);



            $(this).val('Please wait...');

            $.ajax({
                type: 'POST',
                url: '/facturas/save',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        alert('Su factura ha sido guarda satisfactoriamente.');
                        window.location.href = "/Facturas";
                        //here we will clear the form
                        list = [];
                       // $('#orderNo,#orderDate,#description').val('');
                      //  $('#orderdetailsItems').empty();
                    }
                    else {
                        alert('Error, no se pudo guardar su factura. Intente de nuevo.');
                    }
                    $('#submit').val('Save');
                },
                error: function (error) {
                    console.log(error);
                    $('#submit').val('Save');
                }
            });
        }

    });

});

