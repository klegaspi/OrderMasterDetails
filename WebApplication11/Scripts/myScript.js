function loadProducts() {
    $.getJSON('/api/Products', function (result) {
        var $products = $('#products');
        $products.empty();
        $products.append($('<option value="" selected="selected">Select</option>'));
        $.each(result, function (index, item) {
            $products.append($('<option />').val(item.ProductID).text(item.Name));
        });
    });
}

function loadCustomers() {
    $.getJSON('/api/Customers', function (result) {
        var $customers = $('#customers');
        $customers.empty();
        $customers.append($('<option value="" selected="selected">Select</option>'));
        $.each(result, function (index, item) {
            $customers.append($('<option />').val(item.CustomerID).text(item.Name));
        });
    });
}


$(document).ready(function () {
    var orderItems = [];

    //Remove Item
    $('#orderItems table tbody').on('click', '#btnDelete', function (event) {
        var row = $(this).parent().parent(); //tr                
        row.remove();
    });

    //Add button click function
    $('#add').on("click", function () {
        var isValidItem = true;

        var $product = $('#products option:selected');
        var $quantity = $('#quantity');
        var $rate = $('#rate');

        if ($product.val().trim() == '') {
            isValidItem = false;
            $('#products').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#products').siblings('span.error').css('visibility', 'hidden');
        }

        if ($quantity.val().trim() == '') {
            isValidItem = false;
            $quantity.siblings('span.error').text("Quantity is required");
            $quantity.siblings('span.error').css('visibility', 'visible');
        }
        else {
            if (isNaN($quantity.val().trim())) {
                isValidItem = false;
                $quantity.siblings('span.error').text("Invalid Quantity").css('visibility', 'visible');
            }
            else {
                $quantity.siblings('span.error').css('visibility', 'hidden');
            }            
        }
        
        if ($rate.val().trim() == '') {
            isValidItem = false;            
            $rate.siblings('span.error').text("Price is required").css('visibility', 'visible');
        }
        else {
            if (isNaN($('#rate').val().trim())) {
                isValidItem = false;
                $rate.siblings('span.error').text("Invalid Price").css('visibility', 'visible');
            }
            else {
                $rate.siblings('span.error').css('visibility', 'hidden');
            }            
        }

        var isDuplicate = false;
        $('td:eq(0)', '#orderDetailsTbl tbody tr').each(function (index, item) {
            if ($(item).text() == $product.val()) {
                isDuplicate = true;
                return false;
            }
        });

        //$('#orderDetailsTbl tbody tr').find('td:eq(0)').each(function (index, item) {
        //    alert($(item).text());
        //    if ($(item).text() == $product.val()) {
        //        isDuplicate = true;
        //        return false;
        //    }
        //});

        //$.each(orderItems, function (index, item) {
        //    if (item.ProductID == $product.val()) {
        //        isDuplicate = true;
        //        return false;
        //    }
        //});
        
        if (isDuplicate) {
            isValidItem = false;
            alert('Duplicate item. Please select a different item.');
        }

        //Add item to list if valid
        if (isValidItem) {            
            AddItemToTable($product.val(), $product.text(), parseInt($quantity.val().trim()), parseFloat($rate.val().trim()));

            $('#products option:first').attr('selected', 'selected');
            $('#products').focus();
            $quantity.val('');
            $rate.val('');
        }
    });

    //Save button click function
    $('#submit').on('click', function () {
        orderItems = [];
        $('#orderDetailsTbl tbody tr').each(function () {

            var item = {
                ProductID: parseInt($(this).find('td:eq(0)').text()),
                Quantity: parseInt($(this).find('td:eq(2)').text()),
                Rate: parseFloat($(this).find('td:eq(3)').text()),
                TotalAmount: parseFloat($(this).find('td:eq(4)').text())
            };

            orderItems.push(item);
        });

        //validate order
        var isAllValid = true;

        if (orderItems.length == 0) {
            $('#orderItems').html('<span style="color:red;">Please add order items</span>')
            isAllValid = false;
        }

        var $orderNo = $('#orderNo');
        var $orderDate = $('#orderDate');
        var $customer = $('#customers option:selected');

        if ($orderNo.val().trim() == '') {
            $orderNo.siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $orderNo.siblings('span.error').css('visibility', 'hidden');
        }

        if ($customer.val().trim() == '') {
            $('#customers').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#customers').siblings('span.error').css('visibility', 'hidden');
        }

        if ($orderDate.val().trim() == '') {
            $orderDate.siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $orderDate.siblings('span.error').css('visibility', 'hidden');
        }

        //save if valid
        if (isAllValid) {            
            var data = {
                OrderNo: $orderNo.val().trim(),
                OrderDate: $orderDate.val().trim(),
                Description: $('#description').val().trim(),
                CustomerID: $customer.val().trim(),
                OrderDetails: orderItems
            }

            $(this).val('Please wait...');

            $.post("/api/Orders",
            data,
            function (data, status) {
                alert('Order has been successfully saved.')
                orderItems = [];
                $orderNo.val('');
                $orderDate.val('');
                $('#description').val('');
                $('#customers option:first').attr('selected', 'selected');
                $('#orderItems tbody').empty();
                $('#submit').val('Save Order');
            })
            //.done(function () {
            //    alert('success');
            //})
            .fail(function() {
                alert('failed');
                $('#submit').val('Save Order');
            });
        }
    });
    
    function AddItemToTable(productId, itemName, quantity, rate) {
        var $table = $('#orderDetailsTbl tbody');
        var $row = $('<tr/>');
        $row.append($('<td style="display:none"></td>').html(productId));
        $row.append($('<td/>').html(itemName));
        $row.append($('<td/>').html(quantity));
        $row.append($('<td/>').html(rate));
        $row.append($('<td/>').html(quantity * rate));
        $row.append($('<td><input type="button" value="Remove" id="btnDelete" class="btn btn-danger" /></td>'));
        $table.append($row);        
    }
});

loadCustomers();

loadProducts();