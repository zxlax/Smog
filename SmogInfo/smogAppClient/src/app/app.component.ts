import { Component, OnInit } from '@angular/core';
import {ChartComponent} from './chart/chart.component'
import { ChartService } from './chart/chart.service';
import { ISmog } from './ISmog';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit  {

  Smog :ISmog[];
 
  title = 'app works!';

  constructor(private _chartService:ChartService){};
  ngOnInit(): void 
  {
    this._chartService.getSmog()
            .subscribe(data => {
            this.Smog = data;})
  }
}
  
  


