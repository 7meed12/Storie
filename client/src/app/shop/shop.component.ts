import { compileNgModuleDeclarationExpression } from '@angular/compiler/src/render3/r3_module_compiler';
import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/products';
import { IType } from '../shared/models/productType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products:IProduct[] = [];
  brands:IBrand[]=[];
  types:IType[]=[];
  brandSelected=0;
  typeSelected=0;
  

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }
  getProducts(){
    this.shopService.getProducts(this.brandSelected,this.typeSelected).subscribe(response => {
      this.products = response!.data;
 
    });
  }
  getBrands(){
    this.shopService.getBrands().subscribe(data => {
      this.brands = [{id:0,name:'All'},...data];
    });
  }
  getTypes(){
    this.shopService.getTypes().subscribe(data => {
      this.types=[{id:0,name:'All'},...data];
    });
  }
  onBrandSelected(brandId:number){
    this.brandSelected = brandId;
    this.getProducts();
    
  }
  onTypeSelected(typeId:number){
    this.typeSelected = typeId;
    this.getProducts();
   
  }


}
