let textSlide = document.querySelectorAll('.hero__text');

let value = 0;

let swiper = new Swiper(".mySwiper", {
    direction: 'horizontal',
    loop: true,
    pagination: {
        el: '.swiper-pagination',
        clickable: true,
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
    allowTouchMove: false,
});

swiper.on('slideChange', function ({ realIndex: r }) {



    if ((r - value) == 1) {
        textSlide[r].classList.add('visibility-text-slide');
        textSlide[r - 1].classList.remove('visibility-text-slide');
    }
    else if ((r - value) == -1) {
        textSlide[r].classList.add('visibility-text-slide');
        textSlide[r + 1].classList.remove('visibility-text-slide');
    }
    else if (r == 0) {
        textSlide[r].classList.add('visibility-text-slide');
        textSlide[(textSlide.length - 1)].classList.remove('visibility-text-slide');
    }
    else {
        textSlide[r].classList.add('visibility-text-slide');
        textSlide[0].classList.remove('visibility-text-slide');
    }

    value = r;

});

