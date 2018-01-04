// ni-script.js -> some basic function for ui and everything 
$(document).ready(function(){

    var myDate = new Date();
    var hrs = myDate.getHours();
    console.log(hrs);
    if (5 <= hrs && hrs < 15)
        $('#section-1').css('backgroundImage', 'url(img/morning.jpg)');
    else if (hrs >= 15 && hrs <= 19)
        $('#section-1').css('backgroundImage', 'url(img/evening.jpg)');
    else if (hrs >= 20 || hrs < 5)
        $('#section-1').css('backgroundImage', 'url(img/night.png)');


    // #region "Scroll Reveal"

    window.sr = ScrollReveal({ reset: true });
    sr.reveal('.wlcmImg', {
        viewFactor: 0.5,
        duration: 1000
    });
    sr.reveal('.fullImg', {
        origin: 'right',
        duration: 1000
    });
    sr.reveal('.clr76FF03', {
        origin: 'right',
        duration: 1000
    });
    sr.reveal('.clrFF5722', {
        origin: 'right',
        duration: 1000,
        delay: 100
    });
    sr.reveal('.clr40C4FF', {
        origin: 'right',
        duration: 1000,
        delay: 400
    });
    sr.reveal('.clrEAF916', {
        viewFactor: 0.5,
        duration: 1000
    });
    sr.reveal('.whyIcon', {
        viewFactor: 0.5,
        duration: 1000
    });

    sr.reveal('.shareImg', {
        viewFactor: 0.5,
        duration: 1000
    })

    // #endregion

});

