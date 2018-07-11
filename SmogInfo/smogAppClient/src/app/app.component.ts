import { Component } from '@angular/core';
import { Http, Response} from '@angular/http';
import 'rxjs/add/operator/map';
import { map } from 'rxjs/operators';
import 'rxjs/Rx';
import {Smog} from './smog'



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app works!';
  private apiUrl = 'http://localhost:5000/api/cities/1/smogstation/1/level';
  data: Smog[];

  constructor(private http:Http){
    console.log('Hello');
    this.getPM();
    this.getData();
  }
  getData() {
    return this.http.get(this.apiUrl)
    .map((res: Response) => res.json())}

  getPM() {this.getData().subscribe(data =>{console.log(data); this.data =data;})}


}
