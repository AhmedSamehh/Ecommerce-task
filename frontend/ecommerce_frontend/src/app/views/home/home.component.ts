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
  currentSubCategoryId:any;
  currentPage:number = 1;
  totalPages:number = 1;
  itemsPerPage:number = 1;
  
  constructor(private http: HttpClient, private route:ActivatedRoute) {}

 
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.categoryId = params['id'];
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

  getProductsBySubCategoryId(id:any, sortBy?:string) {

    var url = 'https://localhost:7212/products/'+id+"?Page=" + this.currentPage+ "&ItemsPerPage="+this.itemsPerPage;

    if(sortBy != undefined)
      url += '&sortBy=' +sortBy;

    this.http.get(url, {observe: 'response'}).subscribe(response => {
      var xPagination = JSON.parse(response.headers.get('X-Pagination') as string)

      this.totalPages = xPagination.TotalPages;
      this.products = response.body;
      this.title = this.products[0].category.title;
      this.currentSubCategoryId = id;

    }, err => {
      console.log(err);
    })
  }

  getProductsByCategoryId() {
    var url = 'https://localhost:7212/products/category/'+this.categoryId+"?Page=" + this.currentPage+ "&ItemsPerPage="+this.itemsPerPage;
    this.http.get(url, {observe: 'response'}).subscribe(response => {
      

      var xPagination = JSON.parse(response.headers.get('X-Pagination') as string)

      this.totalPages = xPagination.TotalPages;
      this.products = response.body;
      this.title = this.products[0].category.title;

    }, err => {
      console.log(err);
    })
  }

  sortProducts(sortBy:string) {
    this.getProductsBySubCategoryId(this.currentSubCategoryId, sortBy);
  }

  buyNow(name:any, price:any) {
    alert("Are you sure you want to buy "+ name+ " for $"+ price + "?");
  }

  changePage(pageNumber:any) {
    if(pageNumber>=1&&pageNumber<=this.totalPages)
    {
      this.currentPage = pageNumber;
      if(this.subcategories.length>0)
        this.getProductsBySubCategoryId(this.currentSubCategoryId)
      else 
      this.getProductsByCategoryId()
    }
    
  }
}
