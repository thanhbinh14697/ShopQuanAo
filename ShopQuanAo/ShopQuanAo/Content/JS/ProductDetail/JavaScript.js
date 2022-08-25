
var $ = document.querySelector.bind(document)
var $$ = document.querySelectorAll.bind(document)

var iconmenu = $('.icon-menu')
var menu = $('.menu')
var btnclosemenu = $('.navbar i')
var imgprd = $('.product-imgs img')
var imgs = $$('.sliders img')
var btnpr = $('.btn-prev')
var btnnext = $('.btn-next')
var sliders = $('.sliders')
var dec = $('.dec')
var inc = $('.inc')
var amount = $('.cart-plus-minus-box')
var varsearch = $('.searchpr')
var btnsubmit = $$('#search-prod')
var imgnone = $('.img_none_detail')
var addCart = $('.btn-add-cart')
var url = $('#urllogin')
var loginlayout = $('.footer-subscribe')
var a = 1
var x = 0
var i = 0

imgs.forEach(img => {
    img.onclick = () => {
        imgprd.src = img.currentSrc
    }
});

btnclosemenu.onclick = () => {
    menu.style.display = 'none'
}

iconmenu.onclick = () => {
    menu.style.display = 'block'

}

btnnext.onclick = () => {
    x -= 91
    i++
    if (x > -637) {
        sliders.style.transform = `translateX(${x}px)`
        imgprd.src = imgs[i].currentSrc
    }
    else { x = 91; i = -1 }
}
btnpr.onclick = () => {
    x += 90
    i--
    if (x < 0) {
        sliders.style.transform = `translateX(${x}px)`
        imgprd.src = imgs[i].currentSrc
    }
    else { x = -637; i = 10 }
}

    inc.onclick = () => {
        a++
        amount.value = a
    }


dec.onclick = () => {
    a--
    if (a > 0) {
        amount.value = a
    }
    else { a = 1 }

}


function Search() {
    
    
    jQuery.ajax({
        url: jQuery("#urlSearch").val() + "?keySearch=" + varsearch.value,
        method: "GET",
        data: "",
        contentType: "application/json",
        dataType:""

    }).done(function (response) {
        console.log(response)
        jQuery("#lst-product").empty().append(response);
        jQuery("#list-search").empty().append(response);
        imgnone.style.display = "block";
    })

}

function AddCart() {
   
    let id = jQuery("#idProduct").val();
    let amountProduct = jQuery('.cart-plus-minus-box').val();
    var a = {
        IDPRODUCT: Number(id),
        SOLUONG: Number(amountProduct)
    }
    jQuery.ajax({
        url: jQuery("#urlAdd").val(),
        method: "POST",
        data: JSON.stringify(a),
        contentType: "application/json", 
        dataType: ""

    }).done(function (response) {
        
    })
}

