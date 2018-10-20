import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-manage-cookbook',
  templateUrl: './manage-cookbook.component.html',
  styleUrls: ['./manage-cookbook.component.css']
})
export class ManageCookbookComponent implements OnInit {
  cookbooks = ['Sample Cookbook', 'Indian Cookbook'];
  constructor() { }

  ngOnInit() {
  }

}
