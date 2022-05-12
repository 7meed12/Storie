
import { Component, OnInit } from '@angular/core';


import { IProduct } from './shared/models/products';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Storie';
  products: IProduct[] = [];
  constructor( ){
  }
  ngOnInit(): void {
  
  }
}
