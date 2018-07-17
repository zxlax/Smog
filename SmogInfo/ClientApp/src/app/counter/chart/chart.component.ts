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
	let y = 1;		
	for ( var i = 0; i < this.smog.length; i++ ) {		  
		
		dataPoints.push({ y: this.smog[i].pM10Concentration});
		
		y += 1;	
	}
	console.log(dataPoints);
	let chart = new CanvasJS.Chart("chartContainer", {
		zoomEnabled: true,
		animationEnabled: true,
		exportEnabled: true,
		title: {
			
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



