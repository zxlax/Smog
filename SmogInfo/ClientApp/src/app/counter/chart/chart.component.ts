import { Component, OnInit } from '@angular/core';
import {ISmog} from '../../shared/ISmog';
import * as CanvasJS from './CanvasJS.min.js';
import { GlobalsService } from '../../globals.service';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {
	
	 smog: ISmog[] ;
	 chartVar

	

	 constructor(private globals:GlobalsService) {this.smog = globals.smog}

  ngOnInit() {
			this.drawChart();
		 }

drawChart(): void 
{

	let warningLevel =[];
  let dataPoints = [];
  let dateTime =[];
  
		
	for ( var i = 0; i < this.smog.length; i++ ) {		  
		
		dataPoints.push({ y: this.smog[i].pM10Concentration});
		warningLevel.push({y:50});
		dateTime.push({ y:this.smog[i].dateTime});

		
			
	}
	
	let chart = new CanvasJS.Chart("chartContainer", {
		zoomEnabled: true,
		animationEnabled: true,
		exportEnabled: true,
		title: {},
		axisX:{
			labelFormatter: function(e){
				return  "x: " + e.value;
			},
			//valueFormatString: "DD MMM",
			crosshair: {
				enabled: true,
				snapToDataPoint: true
			}
		},
		axisY: {
			title: "µg/m^3",
			crosshair: {
				enabled: true
			}
		},
			
		
		subtitles:[{
			
		}],
		data: [
		{
			type: "line",                
			dataPoints: dataPoints
		},
		{
			type: "line",                
			dataPoints: warningLevel
		}
	]
	});
		
	chart.render();
	
}

		


}



