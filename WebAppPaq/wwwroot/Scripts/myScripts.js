


function LoadTipoProducto(tipoProducto) {


    console.log(tipoProducto);
    console.log($(tipoProducto).val());

    if ($(tipoProducto).val() == undefined) {
        $("#monto").removeAttr('disabled');
        $("#peso").removeAttr('disabled');
    }

    if ($(tipoProducto).val() == "Dinero") {
        $("#peso").attr('disabled', 'disabled');
        $("#monto").removeAttr('disabled');

    } else {
        $("#monto").attr('disabled', 'disabled');
        $("#peso").removeAttr('disabled');
        

    }

    
   
    //$("input").removeAttr('disabled');
}

//function renderProduct(element, data) {
//    //render product
//    var $ele = $(element);
//    $ele.empty();
//    $ele.append($('<option/>').val('0').text('Select'));
//    $.each(data, function (i, val) {
//        $ele.append($('<option/>').val(val.ProductID).text(val.ProductName));
//    })
//}

$(document).ready(function () {
    //Add button click event
    $('#add').click(function () {
        //validation and add order items
        var isAllValid = true;

        if ($('#tipoProducto').val() == "Seleccionar") {
            isAllValid = false;
            $('#tipoProducto').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#tipoProducto').siblings('span.error').css('visibility', 'hidden');
        }

        if (!($('#peso').val().trim() != '' && (parseInt($('#peso').val()) || 0))) {
            isAllValid = false;
            $('#peso').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#monto').siblings('span.error').css('visibility', 'hidden');
        }

        if (!($('#monto').val().trim() != '' && (parseInt($('#monto').val()) || 0))) {
            isAllValid = false;
            $('#monto').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#monto').siblings('span.error').css('visibility', 'hidden');
        }

       

        if (isAllValid) {
            var $newRow = $('#mainrow').clone().removeAttr('id');
          //  $('.pc', $newRow).val($('#productCategory').val());
            //$('.product', $newRow).val($('#product').val());

            //Replace add button with remove button
            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

            //remove id attribute from new clone row
            $('#tipoProducto,#peso,#monto,#add', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            //append clone row
            $('#orderdetailsItems').append($newRow);

            //clear select data
            $('#tipoProducto').val('Seleccionar');
            $('#peso,#monto').val('0');
            $('#orderItemError').empty();
        }

    })

    //remove button click event
    $('#orderdetailsItems').on('click', '.remove', function () {
        $(this).parents('tr').remove();
    });

    $('#submit').click(function () {
        var isAllValid = true;

        //validate order items
        $('#orderItemError').text('');
        var list = [];
        var errorItemCount = 0;
        $('#orderdetailsItems tbody tr').each(function (index, ele) {
            if (
                $('select.tipoProducto', this).val() == "Seleccionar" ||
                (parseInt($('.monto', this).val()) || 0) == 0 ||
                $('.precio', this).val() == "" ||
                isNaN($('.precio', this).val())
            ) {
                errorItemCount++;
                $(this).addClass('error');
            } else {
                var orderItem = {
                    ProductID: $('select.tipoProducto', this).val(),
                    Quantity: parseInt($('.monto', this).val()),
                    Rate: parseFloat($('.precio', this).val())
                }
                list.push(orderItem);
            }
        })

        if (errorItemCount > 0) {
            $('#orderItemError').text(errorItemCount + " invalid entry in order item list.");
            isAllValid = false;
        }

        if (list.length == 0) {
            $('#orderItemError').text('At least 1 order item required.');
            isAllValid = false;
        }

        if ($('#orderNo').val().trim() == '') {
            $('#orderNo').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#orderNo').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#orderDate').val().trim() == '') {
            $('#orderDate').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#orderDate').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var data = {
                OrderNo: $('#orderNo').val().trim(),
                OrderDateString: $('#orderDate').val().trim(),
                Description: $('#description').val().trim(),
                OrderDetails: list
            }

            $(this).val('Please wait...');

            $.ajax({
                type: 'POST',
                url: '/facturas/create',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        alert('Successfully saved');
                        //here we will clear the form
                        list = [];
                        $('#orderNo,#orderDate,#description').val('');
                        $('#orderdetailsItems').empty();
                    }
                    else {
                        alert('Error');
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

