
	    ymaps.ready(function () {
	        map = new ymaps.Map('map', {
	            center: [46.455258, 30.729430],
	            zoom: 12
	        });
/*
	        // Создание метки с квадратной активной областью.
	        var squareLayout = ymaps.templateLayoutFactory.createClass('<div class="placemark_layout_container"><div class="square_layout">$</div></div>');

	        squarePlacemark = new ymaps.Placemark(
	            [55.725118, 37.682145], {
	                hintContent: 'Метка с прямоугольным HTML макетом'
	            }, {
	                iconLayout: squareLayout,
	                // Описываем фигуру активной области "Прямоугольник".
	                iconShape: {
	                    type: 'Rectangle',
	                    // Прямоугольник описывается в виде двух точек - верхней левой и нижней правой.
	                    coordinates: [
	                        [-25, -25], [25, 25]
	                    ]
	                }
	            }
	        );
	        //map.geoObjects.add(squarePlacemark);

	        // Создание метки с круглой активной областью.
	        var circleLayout = ymaps.templateLayoutFactory.createClass('<div class="placemark_layout_container"><div class="circle_layout">#</div></div>');

	        var circlePlacemark = new ymaps.Placemark(
	            [46.483280, 30.700762], {
	                hintContent: 'Метка с круглым HTML макетом'
	            }, {
	                iconLayout: circleLayout,
	                // Описываем фигуру активной области "Круг".
	                iconShape: {
	                    type: 'Circle',
	                    // Круг описывается в виде центра и радиуса
	                    coordinates: [0, 0],
	                    radius: 25
	                }
	            }
	        );
	        map.geoObjects.add(circlePlacemark);*/
	        
	        response = [{"paper":"m", "bottle":"h", "plastic":"s",'coord':[46.455258, 30.729430]}];
	        
	        for (var i=0; i < response.length; i++) {
	        	var tdshki = '';
	        	for(name in response[i]) {
	        		
	        		if (name == 'coord')
	        			continue;
	        		
	        		var color = '';
	        		var text = '';
	        		
	        		switch(response[i][name]) {
	        		case 'h':
	        			color = 'red';
	        			text = 'высокое';
	        			break;
	        		case 'm':
	        			color = 'yellow';
	        			text = 'cреднее';
	        			break;
	        		case 's':
	        			color = 'green';
	        			text = 'низкое';
	        			break;
	        		}
	        		
	        		tdshki += '<tr><td><img src="img/' + name + '.png"></td><td class="'+ color +'">' + response[i][name] + '</td></tr>';
	        	}
	        	
	        	var polygonLayout = ymaps.templateLayoutFactory.createClass('<div class="garbage_info"><table class="garbage_info">'
		    	          + tdshki +
		    	          '</table></div>');
	        	
		        var polygonPlacemark = new ymaps.Placemark(
		            [response[i].coord[0], response[i].coord[1]], {
		                hintContent: 'HTML метка сложной формы'
		            }, {
		                iconLayout: polygonLayout,
		                // Описываем фигуру активной области "Полигон".
		                iconShape: {   
		                    type: 'Polygon',
		                    // Полигон описывается в виде трехмерного массива. Массив верхнего уровня содержит контуры полигона. 
		                    // Первый элемента массива - это внешний контур, а остальные - внутренние.
		                    coordinates: [
		                        [-27, -27], [27, 27]
		                    ]
		                }
		            }
		        );
		        
		        map.geoObjects.add(polygonPlacemark);
	        }
	    });