﻿var gid;
function AddNewItems() {
    $('#newproducts').modal('show');

}
function AddNewDemag() {
    $('#demag').modal('show');
}
function CreatDetails() {
    $('#createDetailsId').modal('show');
}
function ShowDelMessage(id) {
    gid = id;
    $('#confirm').modal('show');
}
function Confiremdel1() {

    $.ajax({
        url: "/Home/Delete",
        data: { record_no: gid },
        type: "POST",
        success: function (result) {
            console.table(result)
            alert(result.deleteMessage);
            location.reload();
        }
    });
}
function update(id) {
    var id1 = document.getElementById("Id");
    var name = document.getElementById("Name");
    var description = document.getElementById("Description");

    $.ajax({
        url: "/Home/GetData",
        data: { id: id },
        type: "POST",
        success: function (result) {
            id1.value = result.id;
            name.value = result.name;
            description.value = result.description;
            // Handle the successful response
            console.table(result);
        },
        error: function (xhr, status, error) {
            // Handle the error response
            console.error('Error:', error);
        }
    });
    $('#update').modal('show');
}
function update2(id) {
    var iid = document.getElementById("Id");
    var color = document.getElementById("Color");
    var qty = document.getElementById("Qty");
    var price = document.getElementById("Price");
    var img = document.getElementById("Images");
/*    var pid = document.getElementById("ProductId");*/

    $.ajax({
        url: "/Home/GetData2",
        data: { id: id },
        type: "POST",
        success: function (result) {
            console.table(result);
            iid.value = result.iid;
            color.value = result.color;
            qty.value = result.qty;
            price.value = result.price;
            img.value = result.img;
/*          pid.value = result.pid;*/

        },
    });
    $('#update2').modal('show');
}


function update3(id) {
    var iid = document.getElementById("Id");
    var qty = document.getElementById("Qty");
    var pid = document.getElementById("ProductId");

    $.ajax({
        url: "/Home/GetData3",
        data: { id: id },
        type: "POST",
        success: function (result) {
            iid.value = result.iid;
            qty.value = result.qty;
            pid.value = result.pid;
            console.table(result);
        },
    });
    $('#update3').modal('show');
}
