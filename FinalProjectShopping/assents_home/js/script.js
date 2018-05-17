

// <<<<<<<<<<<<<<<<<<<<<<< navbar<<<<<<<<<<<<<<<<<<<<<< \\

$(".nav-item").click(function(){

    if ($(this).children().attr("aria-expanded")=="true") {
        $(this).children().removeAttr("data-toggle")
    }
})


// <<<<<<<<<<<<<<<<<<<<<<< Index.html<<<<<<<<<<<<<<<<<<<<<< \\

$('#index_slider .owl-carousel').owlCarousel({
    loop:true,
    margin:10,
    nav:true,
    autoplay:true,
    autoHeight:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:1
        }
    }
})



$('#clothing_content .owl-carousel').owlCarousel({
    loop:true,
    margin:10,
    nav:true,
    autoplay:true,
    autoHeight:true,    
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:1
        }
    }
})






// <<<<<<<<<<<<<<<<<<<<<<<  Left Search <<<<<<<<<<<<<<<<<<<<<< \\

 




// <<<<<<<<<<<<<<<<<<<<<<<  Product <<<<<<<<<<<<<<<<<<<<<< \\

var old_img=$('._cl_product_img img').attr('src')

$("._cl_product_img_list div div div img").click(function(){ 
    $('._cl_product_img img').attr('src',$(this).attr('src'))
    old_img=$('._cl_product_img img').attr('src')
})




$("._cl_product_img_list div div div img").hover(function(){
    $('._cl_product_img img').attr('src',$(this).attr('src')); 
})

$("._cl_product_img_list div div div img").mouseleave(function(){
    $('._cl_product_img img').attr('src',old_img);    
})



// <<<<<<<<<<<<<<<<<<<<<<<  Product  Quantity <<<<<<<<<<<<<<<<<<<<<< \\
$(document).ready(function () {
   $('.quantity-left-minus').click(function(e){
        // e.preventDefault();
        var quantity = parseInt($(this).parent().next().val());
        if (quantity > 0) {
            quantity--;
           $(this).parent().next().val(quantity);
        }
       var price = $("._cl_price_text_decor").text();
       var arr = price.split(" ");
       var number = parseInt(arr[0]);
       var totalprice = number * quantity;
       $("._total_price").text(totalprice +" "+ "$");
    });

     $('.quantity-right-plus').click(function(e){
        e.preventDefault();
        var quantity = parseInt( $(this).parent().prev().val());

        if (quantity < currentCount) {
            quantity++;
            $(this).parent().prev().val(quantity);
        }
        var price = $("._cl_price_text_decor").text();
        var arr = price.split(" ");
        var number = parseInt(arr[0]);
        var totalprice = number * quantity;
        $("._total_price").text(totalprice +" "+ "$");
    });
    
});

// <<<<<<<<<<<<<<<<<<<<<<<  Bag  Quantity <<<<<<<<<<<<<<<<<<<<<< \\
$(document).ready(function () {
    $('.quantity-minus').click(function (e) {
        // e.preventDefault();
        var quantity = parseInt($(this).parent().next().val());
        if (quantity > 0) {
            $(this).parent().next().val(quantity - 1);
        }
    });

    $('.quantity-plus').click(function (e) {
        e.preventDefault();
        var quantity = parseInt($(this).parent().prev().val());
        var count = parseInt($(this).attr("data-attr"))
        if (quantity < count) {
            $(this).parent().prev().val(quantity + 1);
        }
        
    });

});




// <<<<<<<<<<<<<<<<<<<<<<<  Color Select <<<<<<<<<<<<<<<<<<<<<< \\

$("._product_color").click(function(){
    $("._product_color").css('border', '1px solid grey');
    $("._product_size").css('border', '1px solid #8798b5');
    $(this).css('border', '2px solid #2c3544');
})

// <<<<<<<<<<<<<<<<<<<<<<<  Size Select <<<<<<<<<<<<<<<<<<<<<< \\

$("._product_size").click(function(){
    $("._product_size").css('border', '1px solid #8798b5');
    $(this).css('border', '2px solid #2c3544');
})


// <<<<<<<<<<<<<<<<<<< Password>>>>>>>>>>>>>>>>>>>>>>>>>>> \\
$("#user_name").focus(function () {
    $(this).css('borderColor', '#ced4da');
    $(this).attr("placeholder", "Your name");
})
$("#user_email").focus(function () {    
    $(this).css('borderColor', '#ced4da');
    $(this).attr("placeholder", "Your email");    
})

$("#user_password").focus(function () {
    $(this).css('borderColor', '#ced4da');
    $(this).attr("placeholder", "Your password");
})
$("#user_confirm_password").focus(function () {
    $(this).css('borderColor', '#ced4da');
    $(this).attr("placeholder", "Confirm your password");
})

$("#user_name, #user_email, #user_password, #user_confirm_password").focusout(function () {
    if ($(this).val() == "") {
        $(this).css('borderColor', 'red');
        $(this).attr("placeholder", "Do not empty");
    }
    if ($('#user_password').val() == "") {
        $('#user_passLength').text("")
    } else if ($('#user_password').val().length < 6 || $('#user_password').val().length > 15) {
        $('#user_passLength').text('Passwords must contain: min 6   max 15! ');
        $('#user_passLength').css("color", "red")
    }
    else {
        $(this).css('borderColor', '#ced4da');
    }
})

$('#user_password, #user_confirm_password').on('keyup', function () {
    if ($('#user_password').val() == "" || $('#user_confirm_password').val() == "") {
        $('#message').text('')
    }
    else if ($('#user_password').val() == $('#user_confirm_password').val()) {
        $('#message').text('');
    }
    else {
        $('#message').text('Not Matching').css('color', 'red');
    }
});

$("#business_name").focus(function () {
    $(this).css('borderColor', '#ced4da');
    $(this).attr("placeholder", "Your business name");
})

$("#business_email").focus(function () {
    $(this).css('borderColor', '#ced4da');
    $(this).attr("placeholder", "Your business email");
})

$("#business_password").focus(function () {
    $(this).css('borderColor', '#ced4da');
    $(this).attr("placeholder", "Your password");
})

$("#business_confirm_pass").focus(function () {
    $(this).css('borderColor', '#ced4da');
    $(this).attr("placeholder", "Confirm your password");
})

$("#business_phone").focus(function () {
    $(this).css('borderColor', '#ced4da');
    $(this).attr("placeholder", "Your business phone");
})

$("#business_location").focus(function () {
    $(this).css('borderColor', '#ced4da');
    $(this).attr("placeholder", "Your business location");
})


$("#business_name, #business_email, #business_password, #business_confirm_pass, #business_phone, #business_location").focusout(function () {
    if ($(this).val() == "") {
        $(this).css('borderColor', 'red');
        $(this).attr("placeholder", "Do not empty");
    }
    if ($('#business_password').val() == "") {
        $('#_password_length').text("")
    }else if ($('#business_password').val().length < 6 || $('#business_password').val().length > 15) {
        $('#_password_length').text('Passwords must contain: min 6   max 15! ');
        $('#_password_length').css("color", "red")
    }
    else {
        $(this).css('borderColor', '#ced4da');
    }
})

$('#business_password, #business_confirm_pass').on('keyup', function () {
    if ($('#business_password').val() == "" || $('#business_confirm_pass').val() == "") {
        $('#mssg').text('')
        $('#_password_length').text("")
    }
    else if ($('#business_password').val() == $('#business_confirm_pass').val()) {
        $('#mssg').text('');
    }
    else {
        $('#mssg').text('Not Matching').css('color', 'red');
    }
});

