/***************************************************
==================== JS INDEX ======================
****************************************************
01. Preloader
02. Go top Top
03. Offcanvas Menu Control
04. Header Search
05. Header | Home One
06. Header | Home Two
07. Counter Activation
08. Testimonial Slider | Home 1
09. Testimonial Slider | Home 2
10. Team Slider
11. MixitUp activation
12. WOW JS Activation
13. Mobile Menu Activation
14. ProgressBar activation
15. Banner Slider

****************************************************/

(function ($) {
  "use strict";



  // Screen Size
  let device_width = window.innerWidth;


  // Preloader
  $(document).ready(function () {
    $('.cxu-preloader').hide();
  });


  // Search
  $('.search-icon').on('click', function () {
    $(this).hide();
    $('.search-close').show();
    $('.search--box form').addClass('showed');
  });

  $('.search-close').on('click', function () {
    $(this).hide();
    $('.search-icon').show();
    $('.search--box form').removeClass('showed');
  });


  // Logo Slider
  var logo_slider = new Swiper(".logo__slider", {
    spaceBetween: 50,
    centeredSlides: true,
    speed: 3000,
    autoplay: {
      delay: .5
    },
    loop: true,
    slidesPerView: 'auto',
    allowTouchMove: false,
    disableOnInteraction: true
  });


  // Logo Slider 2
  var text_slider = new Swiper(".text__slider", {
    spaceBetween: 20,
    centeredSlides: true,
    speed: 6000,
    autoplay: {
      delay: .5
    },
    loop: true,
    slidesPerView: 'auto',
    allowTouchMove: false,
    disableOnInteraction: true
  });


  // Testimonial slider
  var tesitmonial_slider = new Swiper(".testimonial__slider", {
    loop: true,
    speed: 1500,
    spaceBetween: 30,
    slidesPerView: 1,
    speed: 1500,
    navigation: {
      nextEl: ".btn-next",
      prevEl: ".btn-prev",
    },
  });


  // Portfolio slider
  var portfolio_slider = new Swiper(".portfolio__slider", {
    loop: true,
    speed: 1500,
    spaceBetween: 50,
    slidesPerView: 1,
    centeredSlides: true,
    navigation: {
      nextEl: ".btn-next",
      prevEl: ".btn-prev",
    },
    breakpoints: {
      1200: {
        slidesPerView: 3,
      },
      768: {
        slidesPerView: 2,
        spaceBetween: 40,
      },
    }
  });

  // Portfolio slider
  var portfolio_slider2 = new Swiper(".portfolio__slider-2", {
    loop: true,
    speed: 1500,
    spaceBetween: 50,
    slidesPerView: 1,
    navigation: {
      nextEl: ".btn-next",
      prevEl: ".btn-prev",
    },
    breakpoints: {
      1200: {
        slidesPerView: 3,
      },
      768: {
        slidesPerView: 2,
        spaceBetween: 30,
      },
    },
  });


  // Team Slider
  var team_slider = new Swiper(".team__slider", {
    loop: true,
    speed: 1500,
    spaceBetween: 30,
    slidesPerView: 1,
    speed: 1500,
    navigation: {
      nextEl: ".btn-next",
      prevEl: ".btn-prev",
    },
    breakpoints: {
      768: {
        slidesPerView: 3,
      },
      1024: {
        slidesPerView: 4,
      },
    },
  });


  // Hero Slider
  const progressCircle = document.querySelector(".autoplay-progress svg");
  const progressContent = document.querySelector(".autoplay-progress span");
  var hero_slider = new Swiper(".hero__slider", {
    autoplay: true,
    loop: true,
    speed: 2200,
    pagination: {
      el: ".swiper-pagination",
      type: "fraction",
    },
    navigation: {
      nextEl: ".swiper-button-next",
      prevEl: ".swiper-button-prev",
    },
    on: {
      autoplayTimeLeft(s, time, progress) {
        progressCircle.style.setProperty("--progress", 1 - progress);
        progressContent.textContent = `${Math.ceil(time / 1000)}s`;
      }
    }
  });


  // Full Screen Home
  var breakpoint = window.matchMedia('( max-width: 767px )');
  var home_fullscreen = document.querySelector('.home_fullscreen');

  if (home_fullscreen) {
    var enableSwiper = function () {
      var full_screen = new Swiper(".home_fullscreen", {
        loop: false,
        'speed': 1500,
        slidesPerView: 1,
        spaceBetween: 0,
        mousewheel: true,
        pagination: {
          el: ".swiper-pagination",
          clickable: true,
        }
      });
    };

    var breakpointChecker = function (full_screen) {
      if (breakpoint.matches === true) {
        if (full_screen !== undefined) full_screen.destroy(true, true);
        return;
      } else if (breakpoint.matches === false) {
        return enableSwiper();
      }
    };

    breakpoint.addListener(breakpointChecker);
    breakpointChecker();
  }


  // GSAP
  gsap.registerPlugin(ScrollTrigger, ScrollSmoother, SplitText);
  ScrollSmoother.create({
    smooth: 1.3,
    effects: device_width < 1025 ? false : true,
    smoothTouch: 0.1,
    normalizeScroll: false,
    ignoreMobileResize: true,
  });


  // Service move
  var service_item = gsap.utils.toArray('.cxu__service.style-1 .service-item');
  let service_img = gsap.utils.toArray(".cxu__service.style-1 .hover-img");

  function ServiceImageMove(event, item) {
    const contentBox = item.getBoundingClientRect();
    const dx = (event.clientX - contentBox.x) / 5;
    const dy = (event.clientY - contentBox.y) / 8;
    service_img.forEach((img) => {
      gsap.to(img, {
        x: dx,
        y: dy,
      });
    });
  }

  service_item.forEach((item, i) => {
    item.addEventListener("mousemove", (event) => {
      setInterval(ServiceImageMove(event, item), 1000);
    });
  });


  // Blog move
  var blog_item = gsap.utils.toArray('.cxu--posts.style-1 .cxu-post');
  let blog_img = gsap.utils.toArray(".cxu--posts.style-1 .thumb-img");

  function BlogImageMove(event, item) {
    const contentBox = item.getBoundingClientRect();
    const dx = (event.clientX - contentBox.x) / 5;
    const dy = (event.clientY - contentBox.y) / 8;
    blog_img.forEach((img) => {
      gsap.to(img, {
        x: dx,
        y: dy,
      });
    });
  }

  blog_item.forEach((item, i) => {
    item.addEventListener("mousemove", (event) => {
      setInterval(BlogImageMove(event, item), 1000);
    });
  });


  // Blog move
  var award_item = gsap.utils.toArray('.award__item');
  let award_img = gsap.utils.toArray(".award__item .award-img");

  function AwardImageMove(event, item) {
    const contentBox = item.getBoundingClientRect();
    const dx = (event.clientX - contentBox.x) / 5;
    const dy = (event.clientY - contentBox.y) / 8;
    award_img.forEach((img) => {
      gsap.to(img, {
        x: dx,
        y: dy,
      });
    });
  }

  award_item.forEach((item, i) => {
    item.addEventListener("mousemove", (event) => {
      setInterval(AwardImageMove(event, item), 1000);
    });
  });


  // Counter Activate
  const counter_def = window.counterUp.default
  const counter_cb = entries => {

    entries.forEach(entry => {
      const el = entry.target
      if (entry.isIntersecting && !el.classList.contains('is-visible')) {
        counter_def(el, {
          duration: 1500,
          delay: 16,
        })
        el.classList.add('is-visible')
      }
    })
  }

  const IO = new IntersectionObserver(counter_cb, {
    threshold: 1
  })

  const els = document.querySelectorAll('.counter-active');
  els.forEach((el) => {
    IO.observe(el)
  });


  // magnificPopup Activate
  $('.video-popup').magnificPopup({
    type: 'iframe'
  });


  // Meanmenu Activate
  jQuery('.main-menu').meanmenu({
    meanScreenWidth: "1200",
    meanMenuContainer: ".mobile__menu",
  });

  $('.close__menu').on('click', function () {
    $('.mobile__menu').css('inset-inline-end', '-360px');
  });

  $('.open__menu').on('click', function () {
    $('.mobile__menu').css('inset-inline-end', '0');
  });


  // Offcanvas hamburger
  $('#offcanvas__hamburger').on('click', function () {
    $('.offcanvas__menu').addClass('active');
  });

  $('.offcanvas__close').on('click', function () {
    $('.offcanvas__menu').removeClass('active');
  });


  // Offcanvas Menu 2
  var headerOverlay = new TimelineMax({ paused: true });
  if ($(".offcanvas__area-2")[0]) {
    OffcanvasMenu();
  }

  OffcanvasSubMenu();

  function OffcanvasSubMenu() {
    var menuItemWithChild = $(".offcanvas__menu-2 .has-submenu>a");

    menuItemWithChild.on('click', function (e) {
      e.preventDefault();
      var thisItem = $(this),
        thisItemParent = thisItem.parent(),
        thisItemParentSiblingsWithDrop = thisItemParent.siblings('.offcanvas__menu-2 .has-children');
      if (thisItemParent.hasClass('has-submenu')) {
        var submenu = thisItemParent.find('> ul.sub-menu');
        if (submenu.is(':visible')) {
          submenu.slideUp();
          thisItemParent.removeClass('open_sub');
        }
        else {
          thisItemParent.addClass('open_sub');
          if (thisItemParentSiblingsWithDrop.length === 0) {
            submenu.slideDown();
          } else {
            thisItemParent.siblings().removeClass('open-sub').find('.sub-menu').slideUp(function () {
              submenu.slideDown();
            });
          }
        }
      }
      return false;
    })
  }

  function OffcanvasMenu() {

    gsap.set(".offcanvas__area-2", { yPercent: -100 })
    gsap.set(".offcanvas__menu-2", { yPercent: 100 })
    gsap.set(".offcanvas__menu-2 ul .menu-item", { rotate: 5, y: 250, skewY: 10 })
    headerOverlay
      .to(".offcanvas__area-2", 1, { yPercent: 0 })
      .to(".offcanvas__menu-2", 1, { yPercent: 0 }, "-=1")
      .to(".offcanvas__menu-2 ul .menu-item", { opacity: 1, rotate: 0, y: 0, skewY: 0, stagger: 0.2 }, "-=0.5")

      .to(".offcanvas__social-2", 0.5, { y: 0, opacity: 1 }, "-=0.5")
    headerOverlay.reverse();

    $("#offcanvas_hamburger_2").on("click", function () {
      $('body').css('overflow', 'hidden');
      headerOverlay.reversed(!headerOverlay.reversed());
    });
  }

  $('.offcanvas__close-2').on('click', function () {
    $('body').css('overflow', 'visible');
    headerOverlay.reversed(!headerOverlay.reversed());
  });


  // Go Top
  var go_top = document.querySelector(".cxu--go-top");

  if (go_top) {
    window.onscroll = function () {
      if (document.body.scrollTop > 100 || document.documentElement.scrollTop > 100) {
        go_top.classList.add('showed');
      } else {
        go_top.classList.remove('showed');
      }
    };

    go_top.addEventListener('click', function () {
      document.body.scrollTop = 0;
      document.documentElement.scrollTop = 0;
    });
  }


  // Characters Animatoin
  let charsAnimation = gsap.utils.toArray(".cxu-chars");
  charsAnimation.forEach(splitChars => {
    const tl = gsap.timeline({
      scrollTrigger: {
        trigger: splitChars,
        start: 'top 90%',
        end: 'bottom 60%',
        scrub: false,
        toggleActions: 'play none none none'
      }
    });

    const textSplitChars = new SplitText(splitChars, { type: "chars" });
    gsap.set(splitChars, { perspective: 400 });
    textSplitChars.split({ type: "chars" })
    tl.from(textSplitChars.chars, {
      duration: 2,
      opacity: 0,
      scale: 0,
      y: 80,
      rotationX: 100,
      transformOrigin: "0% 50% -50",
      ease: "back",
      stagger: 0.1
    });
  });


  // Words Animatoin
  let wordsAnimation = gsap.utils.toArray(".cxu-words");
  wordsAnimation.forEach(splitWords => {
    const tl = gsap.timeline({
      scrollTrigger: {
        trigger: splitWords,
        start: 'top 90%',
        end: 'bottom 60%',
        scrub: false,
        toggleActions: 'play none none none'
      }
    });

    const textSplitWords = new SplitText(splitWords, { type: "words" });
    gsap.set(splitWords, { perspective: 400 });
    textSplitWords.split({ type: "words" })
    tl.from(textSplitWords.words, {
      duration: 1,
      delay: 0.3,
      opacity: 0,
      rotationX: 10,
      x: 50,
      force3D: true,
      transformOrigin: "top center -50",
      stagger: 0.1,
    });
  });

  // Line Animatoin
  let lineAnimation = gsap.utils.toArray(".cxu-lines");
  lineAnimation.forEach(splitLine => {
    const tl = gsap.timeline({
      scrollTrigger: {
        trigger: splitLine,
        start: 'top 90%',
        end: 'bottom 60%',
        scrub: false,
        markers: false,
        toggleActions: 'play none none none'
      }
    });

    const textSplitLine = new SplitText(splitLine, { type: "lines" });
    gsap.set(splitLine, { perspective: 400 });
    textSplitLine.split({ type: "lines" })
    tl.from(textSplitLine.lines, {
      duration: 1,
      delay: 0.3,
      opacity: 0,
      rotationX: -60,
      y: -50,
      force3D: true,
      transformOrigin: "top center -50",
      stagger: 0.1,
      ease: "back",
    });
  });



  // Fade Animation Bottom
  let fade_animation = gsap.utils.toArray(".cxu-fade");
  fade_animation.forEach((fade) => {
    const ease_value = fade.getAttribute('data-ease');

    gsap.from(fade, {
      scrollTrigger: {
        trigger: fade,
        start: 'top 90%',
      },
      delay: 0.5,
      opacity: 0,
      y: 50,
      ease: ease_value,
      duration: 1.5,
    });
  });


  //
  // Hero Animation
  // 

  // Fade Animation
  let hero_fade = gsap.utils.toArray(".hero-fade");
  hero_fade.forEach((fade) => {
    const ease_value = fade.getAttribute('data-ease');
    const delay_value = fade.getAttribute('data-delay');

    gsap.from(fade, {
      y: 50,
      delay: delay_value,
      opacity: 0,
      duration: 1,
      ease: ease_value,
    });
  });

  // Fade Animation
  let hero_fade_2 = gsap.utils.toArray(".hero-fade-2");
  hero_fade_2.forEach((fade) => {
    const ease_value = fade.getAttribute('data-ease');
    const delay_value = fade.getAttribute('data-delay');

    gsap.from(fade, {
      x: -60,
      delay: delay_value,
      opacity: 0,
      duration: 1.5,
      ease: ease_value,
    });
  });


  // Zoom Animation
  let hero_zoom = gsap.utils.toArray(".hero-zoom");
  hero_zoom.forEach((zoom) => {
    const ease_value = zoom.getAttribute('data-ease');
    const delay_value = zoom.getAttribute('data-delay');

    gsap.from(zoom, {
      scale: 1.3,
      delay: delay_value,
      opacity: 0,
      duration: 1.5,
      ease: ease_value,
    });
  });


  // Mode JS
  $('.mode-type button').on('click', function (e) {
    $(this).addClass('active').siblings().removeClass('active');

    var mode_val = $('.mode-type button.active').attr('data-mode');
    if (mode_val == 'rtl') {
      $('body').addClass('dir-rtl');
    } else {
      $('body').removeClass('dir-rtl');
    }
  });



})(jQuery);