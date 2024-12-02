//#region global
//boot aOs
// AOS.init({
//     duration: 2000,
// });

//darkMode
const $html = document.querySelector('html');
const $element = document.querySelector('#btnMode');

$element.addEventListener('click',function(){
$html.classList.toggle('darkMode')
});


//#endregion

//menuHamburger

// Seleciona os elementos necessários
const hamburger = document.querySelector('.hamburger');
const navBar = document.querySelector('.navBar');

// Adiciona um evento de clique no ícone do hambúrguer
hamburger.addEventListener('click', () => {
    navBar.classList.toggle('active');

navBar.addEventListener('click', ()=>{

  navBar.classList.remove('active');

});


});


//#region particles

var count_particles, stats, update;
stats = new Stats;
stats.setMode(0);
stats.domElement.style.position = 'absolute';
stats.domElement.style.left = '0px';
stats.domElement.style.top = '0px';
document.body.appendChild(stats.domElement);
count_particles = document.querySelector('.js-count-particles');
update = function() {
  stats.begin();
  stats.end();
  if (window.pJSDom[0].pJS.particles && window.pJSDom[0].pJS.particles.array) {
    count_particles.innerText = window.pJSDom[0].pJS.particles.array.length;
  }
  requestAnimationFrame(update);
};
requestAnimationFrame(update);

//#endregion

//#region nav




//#endregion


//#region portfolio
$(document).ready(
  function () {
    $('.grid').isotope({
      itemSelector: '.item',
    });
    $('.filterGroup').on('click', 'li', function () {
      var filterValue = $(this).attr('data-filter');
      $('.grid').isotope({ filter: filterValue });
      $('.filterGroup li').removeClass('active');
      $(this).addClass('active');

    });

  });


//#endregion
