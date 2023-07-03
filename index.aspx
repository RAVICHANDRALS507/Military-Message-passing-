<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MilitaryMessage.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">
<head>
<title>Military Message Passing</title>
<!-- for-mobile-apps -->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Green Farm Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, Sony Ericsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false);
		function hideURLbar(){ window.scrollTo(0,1); } </script>
<!-- //for-mobile-apps -->
<!-- Custom Theme files -->
<link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
<link href="css/font-awesome.css" rel="stylesheet"> 
<link href="css/style.css" rel="stylesheet" type="text/css" media="all" />
<link rel="stylesheet" href="css/lightbox.css">
<link rel="stylesheet" type="text/css" href="css/menu_topexpand.css" />
<!-- //Custom Theme files -->
<!--fonts-->
<link href="//fonts.googleapis.com/css?family=Courgette&amp;subset=latin-ext" rel="stylesheet">
<link href="//fonts.googleapis.com/css?family=Montserrat:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i&amp;subset=latin-ext,vietnamese" rel="stylesheet">
<!--//fonts-->
</head>
<body>
<!--Slider-->
<div class="slider">
	<div class="header-bottom">
		<div class="top-nav menu-wrap">
		<nav class="menu">
			<div class="icon-list">
				<a href="#home" class="scroll"><i class="glyphicon glyphicon-home"></i><span>Home</span></a>
				
				<a href="Login.aspx" class=""><i class="glyphicon glyphicon-user"></i><span>Login</span></a>
				
			</div>
		</nav>
	</div>
	<button class="menu-button" id="open-button"></button> 

		<div class="clearfix"> </div>
		<h1><a href="index.aspx" class="w3l-logo"><i class="fa fa-pagelines" aria-hidden="true"></i>Military Message Passing <span></span></a></h1>
		<div class="w3layouts_header_right">
			
		</div>
		<div class="clearfix"> </div>
	</div>
	<div class="callbacks_container">
		<%--<ul class="rslides" id="slider3">
			<li>
				<div class="slider-info">
					<h3>Welcome to Our Farm</h3>
					<p>Have a Look at our Beautiful Farm</p>
					<div class="readmore-w3"><a class="readmore" href="#" data-toggle="modal" data-target="#myModal2">Gather More</a></div>
				</div>
			</li>
			<li>
				<div class="slider-info">
					<h3>Welcome to Our Farm</h3>
					<p>Offering farming solutions worldwide</p>
					<div class="readmore-w3"><a class="readmore" href="#" data-toggle="modal" data-target="#myModal2">Gather More</a></div>
				</div>
			</li>
			<li>
				<div class="slider-info">
					<h3>Welcome to Our Farm</h3>
					<p>we grow organic food for you</p>
					<div class="readmore-w3"><a class="readmore" href="#" data-toggle="modal" data-target="#myModal2">Gather More</a></div>
				</div>
			</li>
		</ul>--%>
	</div>
	<div class="clearfix"></div>
</div>
<!--//Slider-->
<!-- welcome -->

<!--//footer-->

<!-- js-files -->
<!-- js -->
<script type="text/javascript" src="js/jquery-2.1.4.min.js"></script>
<!-- //js -->
<!-- gallery -->
<script src="js/lightbox-plus-jquery.min.js"></script> 
<!-- //gallery -->
<!-- awards -->
<script src="js/jquery.gauge.js"></script>
<script>
    $(document).ready(function () {
        $("#gauge1").gauge(30, { color: "#FEC606", unit: " %", type: "halfcircle" });
        $("#gauge2").gauge(70, { color: "#FD5B03", unit: " %", type: "halfcircle" });
        $("#gauge3").gauge(75, { color: "#2C82C9", unit: " %", type: "halfcircle" });
    });
</script> 
<!-- //awards -->		
<!-- banner-slider -->
<script src="js/responsiveslides.min.js"></script>
<script>
    // You can also use "$(window).load(function() {"
    $(function () {
        // Slideshow 3
        $("#slider3").responsiveSlides({
            auto: true,
            pager: true,
            nav: true,
            speed: 500,
            namespace: "callbacks",
            before: function () {
                $('.events').append("<li>before event fired.</li>");
            },
            after: function () {
                $('.events').append("<li>after event fired.</li>");
            }
        });

    });
</script>
<!-- //banner-slider -->
<!-- testimonials -->
<!-- required-js-files-->
<link href="css/owl.carousel.css" rel="stylesheet">
<script src="js/owl.carousel.js"></script>
<script>
$(document).ready(function() {
  $("#owl-demo").owlCarousel({
	items : 1,
	lazyLoad : true,
	autoPlay : false,
	navigation : true,
	navigationText : true,
	pagination : true,
  });
});
</script>
<!-- //required-js-files-->
<!-- //testimonials -->
<!-- start-smooth-scrolling-->
<script type="text/javascript" src="js/move-top.js"></script>
<script type="text/javascript" src="js/easing.js"></script>	
<script type="text/javascript">
    jQuery(document).ready(function ($) {
        $(".scroll").click(function (event) {
            event.preventDefault();

            $('html,body').animate({ scrollTop: $(this.hash).offset().top }, 1000);
        });
    });
</script>
<!-- //end-smooth-scrolling -->	
<!-- smooth-scrolling-of-move-up -->
<script type="text/javascript">
    $(document).ready(function () {
        /*
        var defaults = {
        containerID: 'toTop', // fading element id
        containerHoverID: 'toTopHover', // fading element hover id
        scrollSpeed: 1200,
        easingType: 'linear' 
        };
        */

        $().UItoTop({ easingType: 'easeOutQuart' });

    });
</script>
<!-- //smooth-scrolling-of-move-up -->
<!-- Bootstrap core JavaScript
================================================== -->
<!-- Placed at the end of the document so the pages load faster -->
<script src="js/bootstrap.js"></script>
<!-- //menu-js -->
<script src="js/classie.js"></script>
<script src="js/main.js"></script>
<!-- //menu-js -->
<!-- //js-files -->

</body>
</html>
