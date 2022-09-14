import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-drawer',
  templateUrl: './drawer.component.html',
  styleUrls: ['./drawer.component.scss']
})
export class DrawerComponent implements OnInit {
  categories:any;
  
  constructor(private http: HttpClient) {}


  ngOnInit(): void {
    this.getCategories();
  }

  getCategories() {
    this.http.get('https://localhost:7212/categories').subscribe(response => {
      this.categories = response;
    }, err => {
      console.log(err);
    })
  }
}
