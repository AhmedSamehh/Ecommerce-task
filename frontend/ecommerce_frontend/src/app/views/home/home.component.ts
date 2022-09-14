import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  categoryId:any;
  title:String = "";
  subcategories:any;
  products:any;
  
  constructor(private http: HttpClient, private route:ActivatedRoute) {}

 
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.categoryId = params['id'];
      this.title = params['title'];
      this.getSubCategories();
    });
    
  }

  getSubCategories() {
    this.http.get('https://localhost:7212/subcategories/'+this.categoryId).subscribe(response => {
      this.subcategories = response;
      if(this.subcategories.length == 0)
        this.getProductsByCategoryId();
      else
        this.getProductsBySubCategoryId(this.subcategories[0].id);
    }, err => {
      console.log(err);
    })
  }

  getProductsBySubCategoryId(id:any) {
    this.http.get('https://localhost:7212/products/'+id).subscribe(response => {
      this.products = response;
      
    }, err => {
      console.log(err);
    })
  }

  getProductsByCategoryId() {
    this.http.get('https://localhost:7212/products/category/'+this.categoryId).subscribe(response => {
      this.products = response;
      
    }, err => {
      console.log(err);
    })
  }
}
