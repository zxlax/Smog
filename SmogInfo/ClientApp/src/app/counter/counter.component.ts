import { Component, Inject } from '@angular/core';
import { ISmog } from '../shared/ISmog';
import { HttpClient } from '@angular/common/http';
import { GlobalsService } from '../globals.service';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {

  public IsChartShown:boolean = false;
  public ShowChart():void {this.IsChartShown = !this.IsChartShown;}

  
 

  
  
  }

