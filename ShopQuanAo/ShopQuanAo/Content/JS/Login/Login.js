
function Login() {

    var a = {
        SDT: Number(jQuery("#sdt_login").val()),
        PASSWORD: Number(jQuery("#pass-login").val())
    }
    var as = jQuery("#urllogin").val();
    jQuery.ajax({
        url: jQuery("#urllogin").val(),
        method: "POST",
        data: JSON.stringify(a),
        contentType: "application/json",
    }).done(function (response) {

        loginlayout.style.display = "none";
    })
}
function Register() {

    var a = {
        SDT: Number(jQuery("#sdt_Register").val()),
        PASSWORD: Number(jQuery("#pass-Register").val())
        NAME: jQuery("#name-Register").val()
    }
    var as = jQuery("#urlregister").val();
    jQuery.ajax({
        url: jQuery("#urllogin").val(),
        method: "POST",
        data: JSON.stringify(a),
        contentType: "application/json",
    }).done(function (response) {
        alert("Bạn đã đăng kí thành công!");
        loginlayout.style.display = "none";
    })
}