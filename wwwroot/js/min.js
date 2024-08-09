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
    console.log("ShowDelMessage called with id:", id);
    gid = id;
    $('#confirm').modal('show');
}

function Confiremdel1() {
    console.log("Confiremdel1 called");
    $.ajax({
        url: "/Home/Delete",
        data: { record_no: gid },
        type: "POST",
        success: function (result) {
            console.log("Delete success:", result.deleteMessage);
            alert(result.deleteMessage);
            location.reload(function () {
                console.log("Page reloaded");
            });
        },
        error: function (xhr, status, error) {
            console.error("Error deleting product:", error);
            alert("An error occurred while deleting the product: " + error);
        }
    });
}
function ShowDelMessage2(id) {
    console.log("ShowDelMessage2 called with id:", id);
    gid = id;
    $('#confirm2').modal('show');
}

function Confiremdel2() {
    console.log("Confiremdel2 called");
    $.ajax({
        url: "/Home/Delete2",
        data: { record_no: gid },
        type: "POST",
        success: function (result) {
            console.log("Delete success:", result.deleteMessage);
            alert(result.deleteMessage);
            location.reload(function () {
                console.log("Page reloaded");
            });
        },
        error: function (xhr, status, error) {
            console.error("Error deleting product:", error);
            alert("An error occurred while deleting the product: " + error);
        }
    });
}
function ShowDelMessage3(id) {
    console.log("ShowDelMessage3 called with id:", id);
    gid = id;
    $('#confirm3').modal('show');
}

function Confiremdel3() {
    console.log("Confiremdel2 called");
    $.ajax({
        url: "/Home/Delete3",
        data: { record_no: gid },
        type: "POST",
        success: function (result) {
            console.log("Delete success:", result.deleteMessage);
            alert(result.deleteMessage);
            location.reload(function () {
                console.log("Page reloaded");
            });
        },
        error: function (xhr, status, error) {
            console.error("Error deleting product:", error);
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