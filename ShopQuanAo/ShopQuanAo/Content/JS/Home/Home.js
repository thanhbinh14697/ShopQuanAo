var $ = document.querySelector.bind(document)
var iconmenu = $('.icon-menu')
var menu = $('.menu')
var btnclosemenu = $('.navbar i')
var days = $('.days')
var hour = $('.hour')
var minutes = $('.minutes')
var seconds = $('.seconds')


btnclosemenu.onclick = () => {
    menu.style.display = 'none'
}

iconmenu.onclick = () => {
    menu.style.display = 'block'
    console.log('fdfbdfb')
}
var d = null;
var h = parseInt(hour.innerText); // Giờ
var m = parseInt(minutes.innerText); // Phút
var s = parseInt(seconds.innerText);
var timeout; // Timeout

function countdown() {


    if (s == -1) {
        s = 59;
        m -= 1;
    }
    if (m == -1) {
        h -= 1;
        m = 59;
    }
    if (h == -1) {
        clearTimeout(timeout);
        return false;
    }

    hour.innerText = h.toString();
    minutes.innerText = m.toString();
    seconds.innerText = s.toString();
    timeout = setTimeout(function () {
        s--;
        countdown();
    }, 1000);
}
countdown();


