import { Component } from '@angular/core';
import { GlobalsService } from './globals.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  constructor(private globals: GlobalsService) {}



}
