
window.onload = function ()
{
    let menu = document.querySelectorAll('.sidenav__link');

    for (let i = 0; i < menu.length;i++)
    {
        menu[i].classList.add('sidenav__link--on');
    }
}


let burgerBtn = document.querySelector('.burger');
let mainPanel = document.querySelector('.main');
let sidenavPanel = document.querySelector('.sidenav');

burgerBtn.addEventListener('click', function (e) {

    if (burgerBtn.classList.contains('burger--active')) {
        sidenavPanel.classList.remove('sidenav--active');
        burgerBtn.classList.remove('burger--active');
        mainPanel.classList.remove('main--active');
    }
    else {
        burgerBtn.classList.add('burger--active');
        mainPanel.classList.add('main--active');
        sidenavPanel.classList.add('sidenav--active');
    }
});

