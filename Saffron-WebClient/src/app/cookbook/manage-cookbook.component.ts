import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-manage-cookbook',
  templateUrl: './manage-cookbook.component.html',
  styleUrls: ['./manage-cookbook.component.css']
})
export class ManageCookbookComponent implements OnInit {
  cookbooks = [
      {
        "id": '1',
        "title":'Sample Cookbook'
      },
      {
        "id": '2',
        "title":'Indian Cookbook'
      },
    ];
  constructor() { }

  ngOnInit() {
  }

}

