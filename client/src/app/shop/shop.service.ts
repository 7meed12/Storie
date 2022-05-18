import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { IBrand } from '../shared/models/brand';
import IPagination from '../shared/models/pagination';
import { IType } from '../shared/models/productType';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  constructor(private http : HttpClient) { }
  getProducts(brandId?:any,typeId?:any){
    if(brandId===0)brandId=""
    if(typeId===0)typeId=""
  
    let params = new HttpParams()
      .append('brandId',brandId!.toString())
      .append('typeId',typeId!.toString());
    return this.http.get<IPagination>(this.baseUrl + 'products',{observe:'response', params})
    .pipe(
      map(response => {
      return response.body;
         }));
        
  }
  getBrands(){
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }
  getTypes(){

    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }
}
