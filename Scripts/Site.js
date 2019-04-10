$(document).ready(function () {
    //Trailer overlay modal
    $('#TrailerOverlay').on('shown.bs.modal', function () {
        $('#TrailerToggle').trigger('focus')
    });
    //Script handling genre filtering
    $(".GenreFilterButton").on("click", function () {
        var filter = $(this).data("filter");
        $.ajax({
            url: "/Browse/SortByGenre/?Genre=" + filter,
            type: "GET",
        }).done(function (partialViewResult) {
            $("#MovieGrid").html(partialViewResult);
        });
    });
    //Script handling search bar
    var typingTimer;
    var doneTypingInterval = 150;
    $("#searchbar").on('keyup', function () {
        clearTimeout(typingTimer);
        typingTimer = setTimeout(doneTyping, doneTypingInterval);
    });
    $("#searchbar").on('keydown', function () {
        clearTimeout(typingTimer);
    });
    //
    //Rating system, stars for now, can be replaced later. See the RatingHandler function

    //Owl Carousel
    $(".owl-carousel").owlCarousel({
        responsiveClass: true,
        responsive: {
            0: {
                items: 4
            },
            600: {
                items: 6
            },
            1080: {
                items: 7
            },
            1600: {
                items: 9
            }
        },
        margin: 10,
        slideBy: 4,
        center: true,
        loop: true,
        nav: true,
        navText: ['<i class="fa fa-angle-left" aria-hidden="true"></i>', '<i class="fa fa-angle-right" aria-hidden="true"></i>'],
    });
    //Added the stars function
    $(function () {
        $('span.stars').stars();
    });

    //$("#ShipToUser").checked(function () {
    //    alert("checked");
    //});

    //$("#ShipToUser").unchecked(function () {
    //    alert("unchecked");
    //});


    //Handles the checkbox in the checkout
    ToggleShippingAddress();
    $("#ShipToUser").click(ToggleShippingAddress);

    //Submits a review
    $("#SubmitReview").click(function () {
        var MovieID = $("#SubmitReview").data("movieid");
        var Score = 4;
        console.log(Score);
        var ReviewText = $("#ReviewText option:selected").val();
        $.ajax({
            url: "/Movie/CreateReview/?ReviewedMovieID=" + MovieID + "&ReviewScore=" + Score + "&ReviewContent=" + ReviewText,
            type: "get"
        });
        $.ajax({
            url: "/Movie/UpdateReviews/?MovieID=" + MovieID,
            type: "GET",
        }).done(function (partialViewResult) {
            $("#ReviewContainer").html(partialViewResult);
            ReloadMenuBar();
        });
    });
});


//Functions outside of DocumentReady. These will not run unless you call them manually
//Handles the checkbox in the checkout
function ToggleShippingAddress() {
    if ($("#ShipToUser:checked").length == 1) {

        $("#RecipientName").prop("readonly", "readonly").val($("#UserFirstName").val());
        $("#RecipientSurname").prop("readonly", "readonly").val($("#UserLastName").val());
        $("#ShippingAddress").prop("readonly", "readonly").val($("#UserBillingAddress").val());
        $("#ShippingZip").prop("readonly", "readonly").val($("#UserBillingZip").val());
        $("#ShippingCity").prop("readonly", "readonly").val($("#UserBillingCity").val());
    } else {
        $("#RecipientName").removeAttr("readonly").val("");
        $("#RecipientSurname").removeAttr("readonly").val("");
        $("#ShippingAddress").removeAttr("readonly").val("");
        $("#ShippingZip").removeAttr("readonly").val("");
        $("#ShippingCity").removeAttr("readonly").val("");
    }
};

//Ajax function handling adding new items to the cart
function AddToCart(id) {
    $.ajax({
        url: "/ShoppingCart/AddToCart/?movieID=" + id,
        type: "get"
    }).done(function () {
        $('#AddToCart').removeClass("btn-secondary").addClass("btn-success").html("<i class=\"fas fa-check\"></i> Added");
        setTimeout(function () {
            var price = $("#AddToCart").data("cost");
            $('#AddToCart').removeClass("btn-success").addClass("btn-secondary").html("<i class=\"fas fa-shopping-cart\"></i> Add to Cart <span class=\"badge badge-light\"><i class=\"fas fa-dollar-sign\"></i> " + price + "</span>");
        }, 1500);
        ReloadMenuBar();
    });
}


//Ajax function handling removing items from the cart
function RemoveFromCart(index) {
    $.ajax({
        url: "/ShoppingCart/RemoveFromCart/?index=" + index,
        type: "GET",
    }).done(function (partialViewResult) {
        $("#CartContainer").html(partialViewResult);
        ReloadMenuBar();
    });
};

//Increments items in the cart
function IncreaseItemQuantity(index) {
    $.ajax({
        url: "/ShoppingCart/IncreaseItemQuantity/?movieID=" + index,
        type: "get"
    }).done(function (partialViewResult) {
        $("#CartContainer").html(partialViewResult);
        ReloadMenuBar();
    });
};
//decrements items in the cart
function DecreaseItemQuantity(index) {
    $.ajax({
        url: "/ShoppingCart/DecreaseItemQuantity/?movieID=" + index,
        type: "get"
    }).done(function (partialViewResult) {
        $("#CartContainer").html(partialViewResult);
        ReloadMenuBar();
    });
};
//Toggles the filter pane on the movie browse page
function toggleNav() {
    if (document.getElementById("toggleSideNav").value == "O") {
        document.getElementById("mySidenav").style.width = "250px";
        document.getElementById("main").style.marginLeft = "250px";
        document.getElementById("toggleSideNav").value = "C";
    }
    else {
        document.getElementById("mySidenav").style.width = "0";
        document.getElementById("main").style.marginLeft = "0";
        document.getElementById("toggleSideNav").value = "O";
    }
}

//Handles selecting the appropriate rating based on integer passed

//Gets the number of cart items and displays it in the menu
function GetCartAmount() {
    $.ajax({
        url: "/GetCartAmount",
        type: "get"
    }).done(function (amount) {
        $("#MenuCartItemCount").html(amount);
    });
}
$.fn.stars = function () {
    return $(this).each(function () {
        //get the value
        var val = parseFloat($(this).html());
        var size = Math.max(0, (Math.min(5, val))) * 16;
        var $span = $('<span />').width(size);
        $(this).html($span);
    });
}

//Reloads the menubar to refresh the item count in the cart
function ReloadMenuBar() {
    $("#TopMenu").load(location.href + " #TopMenu>*", "");
};

//Function that runs when someone stops typing in the search bar
function doneTyping() {
    var filter = $("#searchbar").val();
    $.ajax({
        url: "/Browse/Search/?Q=" + filter,
        type: "GET",
    }).done(function (partialViewResult) {
        $("#MovieGrid").html(partialViewResult);
    });
};