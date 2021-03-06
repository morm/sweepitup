<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>SweepItUp</title>

    <!-- Bootstrap -->
    <!-- Latest compiled and minified CSS -->
	<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css">

	<!-- Optional theme -->
	<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap-theme.min.css">

    <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
	
	<!-- Latest compiled and minified JavaScript -->
	<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
	<script src="http://api-maps.yandex.ru/2.1/?lang=ru_RU" type="text/javascript"></script>
	<script src="index.js" type="text/javascript"></script>
	<style>
        html, body, #map {
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
        }
        
        .placemark_layout_container { 
            position: relative;
            font-family: Georgia;
            font-size: 40px;
            text-align: center;
            font-weight: bold;
        }
        
        /* РљРІР°РґСЂР°С‚РЅС‹Р№ РјР°РєРµС‚ РјРµС‚РєРё */
        .square_layout {
            position: absolute;
            left: -23px;
            top: -23px;
            width: 46px;
            height: 46px;
            line-height: 46px;
            border: 2px solid #218703;
            background-color: #F8FDF7;
            color: #218703;
        }
        
        /* РљСЂСѓРіР»С‹Р№ РјР°РєРµС‚ РјРµС‚РєРё */
        .circle_layout {
            background-color: white;
            position: absolute;
            left: -23px;
            top: -23px;
            width: 46px;
            height: 46px;
            border: 2px solid #225D9C;
            color: #225D9C;
            line-height: 46px;
            /* Р­С‚Рѕ CSS СЃРІРѕР№СЃС‚РІРѕ РЅРµ Р±СѓРґРµС‚ СЂР°Р±РѕС‚Р°С‚СЊ РІ Internet Explorer 8 */
            border-radius: 50px;
        }
        
        /* РњР°РєРµС‚ РјРµС‚РєРё СЃ "С…РІРѕСЃС‚РёРєРѕРј" */
        .polygon_layout {
            position: relative;
            background: #ffffff;
            border: 4px solid #943A43;
            width: 50px; 
            height: 50px;
            position: absolute;
            left: -28px;
            top: -76px;
            color: #943A43;
        }
        
        .polygon_layout:after, .polygon_layout:before {
            top: 100%;
            left: 50%;
            border: solid transparent;
            content: " ";
            height: 0;
            width: 0;
            position: absolute;
        }
        
        .polygon_layout:after {
            border-top-color: #943A43;
            border-width: 10px;
            margin-left: -10px;
        }
        
        .polygon_layout:before {
            border-top-color: #943A43;
            border-width: 16px;
            margin-left: -16px;
        }
        
        .polygon_layout:before {
            border-top-color: #943A43;
            border-width: 16px;
            margin-left: -16px;
        }
        
        .garbage_info {
        	background: #ffffff;
        }
        
        table.garbage_info td:first-child {
        	width: 27px;
        	height: 27px;
        }
        
        table.garbage_info td:nth-child(2) {
        	width: 27px;
        	height: 27px;
        }
        
        .red {
        	background: red;
        }
        
        .green {
        	background: green;
        }
        
        .yellow {
        	background: yellow;
        }
    </style>
  </head>
  <body>
    <div class="container-fluid">
		<div class="row-fluid">
		<div class="col-md-12">
			<div id="map" style="width: 600px; height: 400px; margin: 0 auto;"></div>
		</div>
		</div>
	</div>
  </body>
</html>