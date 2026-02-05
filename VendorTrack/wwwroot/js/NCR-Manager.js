$(function () {

    if (sessionStorage.getItem('NcrId') != null) {
        var ncrId = sessionStorage.getItem('NcrId');
        fetch('/VendorNcrs/GetVendorNcrById',
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(ncrId)
            })
            .then(async res => {
                const text = await res.text();
                const data = text ? JSON.parse(text) : null;
                if (res.ok) {
                    $('#hid_NcrId_1').val(data[0].vendorNcrId);
                    $('#lbl_ncrnumber').text(data[0].ncrNumber);
                    $('#txt_partnumber').val(data[0].partNumber);
                    $('#drp_fault').val(data[0].fault);

                    var parts = data[0].receivedDate.split('-'); // yyyy-MM-dd
                    var receivedDate = `${parts[2]}-${parts[1]}-${parts[0]}`; // dd-mm-yyyy
                    $('#txt_recdate').val(receivedDate);

                    $('#txt_recqty').val(data[0].receivedQuantity);
                    $('#txt_ncqty').val(data[0].nonConformingQuantity);
                    $('#txt_vendor').val(data[0].vendorName);
                    $('#txt_contactname').val(data[0].contactName);
                    $('#txt_contactemail').val(data[0].contactEmail);

                    $('#btn_update').show();
                    $('#btn_save').hide();
                }
            })
    }

    $('#txt_recdate').datepicker({
        dateFormat: 'dd-mm-yy',
        maxDate: 0
    });

    $('#txt_contactemail').on('blur', function () {
        var email = $('#txt_contactemail').val().trim();
        if (email != '' && !CheckForValidEmail(email)) return;
    })

    $('#btn_save').on('click', function () {
        if (!Validate()) return;
        SaveNCR();
    })

    $('#btn_update').on('click', function () {
        if (!Validate()) return;
        UpdateNCR();
    })

    $('.update').on('click', function () {
        var ncrId = $(this)
            .closest('tr')
            .find('#hid_NcrId')
            .val();

        sessionStorage.setItem('NcrId', ncrId);
        location.href = "/VendorNcrs/Index";      
    })

    $('.delete').on('click', function () {
        var ncrId_ = $(this)
            .closest('tr')
            .find('#hid_NcrId')
            .val();
        DeleteNCR(ncrId_);
    })

    $('#btn_clear').on('click', function () {
        sessionStorage.clear();
        location.reload();
    })

    $('#txt_recqty, #txt_ncqty').on('blur', function () {
        var recqty = $('#txt_recqty').val();
        var ncqty = $('#txt_ncqty').val();
        if (recqty < ncqty) {
            alert('NC quantity cannot be greater than Received quantity');
            $('#txt_ncqty').val('');
        }
    })
});
function SaveNCR() {
    var parts = $('#txt_recdate').val().split('-'); // dd-mm-yyyy

    var receivedDate = `${parts[2]}-${parts[1]}-${parts[0]}`; // yyyy-MM-dd

    var vendorNCR = {
        PartNumber: $('#txt_partnumber').val().trim(),
        Fault: $('#drp_fault :selected').val(),
        ReceivedDate: receivedDate,
        ReceivedQuantity: $('#txt_recqty').val().trim(),
        NonConformingQuantity: $('#txt_ncqty').val().trim(),
        VendorName: $('#txt_vendor').val().trim(),
        ContactName: $('#txt_contactname').val().trim(),
        ContactEmail: $('#txt_contactemail').val().trim(),
    }

    fetch('/VendorNcrs/SaveNewVendorNCR',
        {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(vendorNCR)
        })
        .then(async res => {
            const text = await res.text();
            const data = text ? JSON.parse(text) : null;
            if (res.ok) {
                alert(data.message);
                location.href = "/VendorNcrs/ViewVendorNCRs";
            }
        })
}
function UpdateNCR() {
    var parts = $('#txt_recdate').val().split('-'); // dd-mm-yyyy

    var receivedDate = `${parts[2]}-${parts[1]}-${parts[0]}`; // yyyy-MM-dd

    var vendorNCR = {
        VendorNcrId: $('#hid_NcrId_1').val().trim(),
        NcrNumber: $('#lbl_ncrnumber').text(),
        PartNumber: $('#txt_partnumber').val().trim(),
        Fault: $('#drp_fault :selected').val(),
        ReceivedDate: receivedDate,
        ReceivedQuantity: $('#txt_recqty').val().trim(),
        NonConformingQuantity: $('#txt_ncqty').val().trim(),
        VendorName: $('#txt_vendor').val().trim(),
        ContactName: $('#txt_contactname').val().trim(),
        ContactEmail: $('#txt_contactemail').val().trim(),
    }

    fetch('/VendorNcrs/UpdateVendorNCR',
        {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(vendorNCR)
        })
        .then(async res => {
            const text = await res.text();
            const data = text ? JSON.parse(text) : null;
            if (res.ok) {
                sessionStorage.clear();
                alert(data.message);
                location.href = "/VendorNcrs/ViewVendorNCRs";
            }
        })
}
function DeleteNCR(ncrId_) {
    fetch('/VendorNcrs/DeleteNcr',
        {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(ncrId_)
        })
        .then(async res => {
            const text = await res.text();
            const data = text ? JSON.parse(text) : null;
            if (res.ok) {
                alert(data.message);
                location.reload();
            }
        })
}
function CheckForValidEmail(email) {

    var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    if (!emailRegex.test(email)) {
        alert('Please enter a valid email.');
        $('#txt_contactemail').val('');
        $('#txt_contactemail').trigger('focus');
        return false;
    }
    return true
}
function Validate() {

    if ($('#txt_partnumber').val().trim() == '') {
        alert('Please enter Part number');
        return false;
    }
    if ($('#drp_fault :selected').val() == '0') {
        alert('Please choose fault');
        return false;
    }
    if ($('#txt_recdate').val() == null) {
        alert('Please choose Received Date');
        return false;
    }
    if ($('#txt_recqty').val().trim() == '') {
        alert('Please enter Received Quantity');
        return false;
    }
    if ($('#txt_ncqty').val().trim() == '') {
        alert('Please enter Non-Conforming Quantity');
        return false;
    }
    if ($('#txt_vendor').val().trim() == '') {
        alert('Please enter Vendor Name');
        return false;
    }
    if ($('#txt_contactname').val().trim() == '') {
        alert('Please enter Contact Name');
        return false;
    }
    if ($('#txt_contactemail').val().trim() == '') {
        alert('Please enter Contact Email');
        return false;
    }

    return true;
}
