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
	

	 constructor(private globals:GlobalsService) {this.smog = globals.smog}

  ngOnInit() {
			this.drawChart();
		 }

drawChart(): void 
{


  let dataPoints = [];
		
	for ( var i = 0; i < this.smog.length; i++ ) {		  
		
		dataPoints.push({ y: this.smog[i].pM10Concentration});
		//dataPoints.push({ x: this.smog[i].dateTime});

		
			
	}
	
	let chart = new CanvasJS.Chart("chartContainer", {
		zoomEnabled: true,
		animationEnabled: true,
		exportEnabled: true,
		title: {},
		axisX:{
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
		}]
	});
		
	chart.render();
	
}

		


}



