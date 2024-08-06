var gid;
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
            alert(result.deleteMessage);
            location.reload();
        },
        error: function (xhr, status, error) {
            alert("An error occurred while deleting the product: " + error);
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
    var pid = document.getElementById("Id_Product");

    $.ajax({
        url: "/Home/GetData2",
        data: { id: id },
        type: "POST",
        success: function (result) {
            console.table(result);
            iid.value = result.id;
            color.value = result.color;
            qty.value = result.qty;
            price.value = result.price;
            img.value = result.images;
            pid.value = result.productId;
        },
    });
    $('#update2').modal('show');
}



function update3(id) {
    var iid = document.getElementById("Id");
    var qty = document.getElementById("qty");
    var pid = document.getElementById("Id_Product");

    $.ajax({
        url: "/Home/GetData3",
        data: { id: id },
        type: "POST",
        success: function (result) {
            console.table(result);
            iid.value = result.id;
            qty.value = result.qty;
            pid.value = result.productId;
        },
    });
    $('#update3').modal('show');
}