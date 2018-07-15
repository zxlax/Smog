import { Component, OnInit, DoCheck, OnChanges, SimpleChange, SimpleChanges, AfterContentChecked, AfterViewInit } from '@angular/core';
import {ISmog} from '../ISmog';
import {ChartService} from './chart.service';
import * as CanvasJS from './CanvasJS.min.js';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {
	

	

  errorMessage: string;
	Smog: ISmog[] =[];
	OldSmog: ISmog[] =[];

  constructor(private _chartService: ChartService) { }

  ngOnInit() {
		
    this._chartService.getSmog()
            .subscribe(data => {
							this.OldSmog =data;
								this.Smog = data;
								
                
                
            },
								error => this.errorMessage = <any>error);
								this.drawChart(this.Smog);
								
}

drawChart(ToChartData: ISmog[]): void 
{


  let dataPoints = [];
	let y = 0;		
	for ( var i = 0; i <= ToChartData.length; i++ ) {		  
		
		dataPoints.push({ y:1});
		y += 1;	
	}
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



