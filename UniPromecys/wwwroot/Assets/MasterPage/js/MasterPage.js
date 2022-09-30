(function ($) {
    "use strict";
    $(document).ready(function () {

        if ($('.sidevar.active').prop('margin-left', '0')) {
            $('#sidebarCollapse_').hide();
        } else {
            $('#sidebarCollapse_').show();
        }

        $('.Reducido').hide();
        
        $("#sidebar").mCustomScrollbar({
            theme: "minimal"
        });

        $('#sidebarCollapse').on('click', function () {

            $('#sidebar, #content').toggleClass('active');
            $('.collapse.in').toggleClass('in');
            $('a[aria-expanded=true]').attr('aria-expanded', 'false');


            if (($('#sidebar').hasClass('active'))) {
                $('.sidebar-header').hide();
                $('.Reducido').show();
                $('#sidebarCollapse_').show();
            } else {
                $('.sidebar-header').show();
                $('.Reducido').hide();
                $('#sidebarCollapse_').hide();
            }
        });

        $('#sidebarCollapse_1').on('click', function () {

            $('#sidebar, #content').toggleClass('active');
            $('.collapse.in').toggleClass('in');
            $('a[aria-expanded=true]').attr('aria-expanded', 'false');


            if (($('#sidebar').hasClass('active'))) {
                $('.sidebar-header').hide();
                $('.Reducido').show();
                //$('#sidebarCollapse_').show();
            } else {
                $('.sidebar-header').show();
                $('.Reducido').hide();
                //$('#sidebarCollapse_').hide();
            }
        });

        $('#sidebarCollapse_').on('click', function () {

            $('#sidebar, #content').toggleClass('active');
            $('.collapse.in').toggleClass('in');
            $('a[aria-expanded=true]').attr('aria-expanded', 'false');


            if (($('#sidebar').hasClass('active'))) {
                $('.sidebar-header').hide();
                $('.Reducido').show();
                $('#sidebarCollapse_').show();
            } else {
                $('.sidebar-header').show();
                $('.Reducido').hide();
                $('#sidebarCollapse_').hide();
            }
        });



    });
})(jQuery);