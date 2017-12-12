(function( $) {
    "use strict";
    $(document).ready(function() {
        // Demo panel
        
       $("footer").append("<div class=\"swicther\"> <div class=\"sett\"><i class=\"fa fa-cog fa-spin fa-3x fa-fw\"></i></div><div id=\"demo-wrapper\"> <h5 class=\"demo-head\">COLORS:</h5 class=\"demo-head\"> <ul> <li class=\"color1\" data-path=\"css/color1.css\"></li><li class=\"color2\" data-path=\"css/color2.css\"></li><li class=\"color3\" data-path=\"css/color3.css\"></li><li class=\"color4\" data-path=\"#\"></li></ul> </div></div>");
        $('.sett').click(function () {
                $("#demo-wrapper").toggle("slide");
            });
        $('head').append('<link id="colorme" rel="stylesheet" href="#" type="text/css" />');
        $('#demo-wrapper ul li').on('click', function(){
             var path = $(this).data('path');
             $('#colorme').attr('href', path);
        });


        /*========== Owl Carsusel Script ========== */
        $("#homepage-slider1").owlCarousel( {
            nav: true, // Show next and prev buttons
            slideSpeed: 300, dots: false, paginationSpeed: 400, singleItem: true, navText: [ "<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"], items: 1 // itemsDesktop : false,
            // itemsDesktopSmall : false,
            // itemsTablet: false,
            // itemsMobile : false
        }
        );
        /*========== Owl Carsusel Script | About US page ========== */
        $(".about-slider").owlCarousel( {
            nav: false, // Show next and prev buttons
            slideSpeed: 300, dots: false, paginationSpeed: 400, singleItem: true, navText: [ "<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"], items: 2 // itemsDesktop : false,
            // itemsDesktopSmall : false,
            // itemsTablet: false,
            // itemsMobile : false
        }
        );
        /*========== Owl Carsusel Script ========== */
        $("#homepage-slider2").owlCarousel( {
            nav: false, // Show next and prev buttons
            slideSpeed: 300, dots: true, paginationSpeed: 400, singleItem: true, navText: [ "<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"], items: 1 // itemsDesktop : false,
            // itemsDesktopSmall : false,
            // itemsTablet: false,
            // itemsMobile : false
        }
        );
        /*========== Owl Carsusel Script ========== */
        // Homepage Latest Course  slider
        $("#hv2-course-list").owlCarousel( {
            nav:true, // Show next and prev buttons
            slideSpeed: 300, dots: false, paginationSpeed: 400, margin: 30, navText: [ "<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"], items: 4, responsive: {
                0: {
                    items: 1
                }
                , 480: {
                    items: 2
                }
                , 768: {
                    items: 3
                }
                , 980: {
                    items: 3
                }
                , 1024: {
                    items: 4
                }
                ,
            }
        }
        );
        /*========== Owl Carsusel Script ========== */
        // Homepage Featured professor slider
        $(".professors").owlCarousel( {
            nav:true, // Show next and prev buttons
            slideSpeed: 300, dots: false, paginationSpeed: 400, margin: 30, navText: [ "<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"], items: 2, responsive: {
                0: {
                    items: 1
                }
                , 480: {
                    items: 2
                }
                , 768: {
                    items: 3
                }
                , 980: {
                    items: 3
                }
                , 1024: {
                    items: 2
                }
                ,
            }
        }
        );
        /*========== Owl Carsusel Script ========== */
        // Homepage Featured professor slider
        $("#student-testimonial").owlCarousel( {
            nav:false, // Show next and prev buttons
            slideSpeed: 300, dots: true, paginationSpeed: 400, margin: 30, items: 2, responsive: {
                0: {
                    items: 1
                }
                , 480: {
                    items: 1
                }
                , 768: {
                    items: 2
                }
                , 980: {
                    items: 2
                }
            }
        }
        );
        /*========== Responsve menu ========== */
        jQuery('.nav-mobile-menu').meanmenu( {
            meanMenuContainer: '.menu-icon-bar', meanScreenWidth: "992"
        }
        );
        if ($('.mean-nav > .navbar-nav li').hasClass('submenu')) {
            $(".mean-nav ul li.submenu").removeClass('submenu');
            $("ul.dropdown-menu").removeClass('dropdown-menu');
        }
        /*==========  Jquery Mailchiamp  ========== */
        $('#mc-form').ajaxChimp( {
            url: 'http://blahblah.us1.list-manage.com/subscribe/post?u=5afsdhfuhdsiufdba6f8802&id=4djhfdsh9'
        }
        );
        /*==========  Fun facts counter Number animation  ========== */
        jQuery('.signle-fid h4').counterUp( {
            delay: 15, time: 1000
        }
        );
        /*========== Event Calendar Widget  ========== */
        var eventData=[ {
            "date": "2016-11-12", "badge": false, "title": "New Collage Date", "url": "http://google.com"
        }
        , {
            "date": "2016-11-16", "badge": false, "title": "New School Date", "location": "narayanganj", "url": "http://twist.com"
        }
        ];
        $("#my-calendar").zabuto_calendar( {
            cell_border: true, today: true, show_days: true, weekstartson: 0, data: eventData, action: function () {
                return myDateFunction(this.id, false);
            }
            ,
        }
        );
        function myDateFunction(id) {
            var hasEvent=$("#" + id).data("hasEvent");
            if (hasEvent) {
                // var name = ;// `this` here refers to the current p you clicked on
                var eventTitle=$("#" + id).attr('title');
                var eventUrl=$("#" + id).attr('url');
                $(".title").text(eventTitle);
                $("a.box").attr("href", eventUrl);
            }
            return true;
        }
        /*========== Accordion Toggle icon ========== */
        $('#counter').countdown( {
            date: '11/12/2017 23:59:59', // Month/Date/Year Time
            offset: -8, day: 'Day', days: 'Days'
        }
        , function () {
            $('#counter').remove();
        }
        );
        /*========== Accordion Toggle icon ========== */
        $('.collapse').on('shown.bs.collapse', function() {
            $(this).parent().find("span").addClass("accodion-down");
        }
        ).on('hidden.bs.collapse', function() {
            $(this).parent().find("span").removeClass("accodion-down");
        }
        );
        /*========== Contact From ========== */
        $("#cf .alert").hide();
        $("#cf").validate( {
            submitHandler: function(form) {
                var submitButton=$(this.submitButton);
                submitButton.button("Sending..");
                $.ajax( {
                    type: "POST", url: "/assets/sendmail.php", data: {
                        "name": $("#cf-name").val(), "email": $("#cf-email").val(), "subject": $("#cf-subject").val(), "message": $("#cf-message").val()
                    }
                    , dataType: "json", complete: function () {
                        submitButton.button("reset");
                        $("#cf .form-control").val("");
                        setTimeout(function() {
                            // $( "button.submit" ).append( "<strong>Hello</strong>" );
                            $("button.submit,#cf .form-control").hide();
                            $(".alert").fadeIn();
                            // success Message for Contact form
                        }
                        , 1000);
                    }
                }
                );
            }
        }
        );
    }
    );
}

)(jQuery);