import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-browse-cookbook',
  templateUrl: './browse-cookbook.component.html',
  styleUrls: ['./browse-cookbook.component.css']
})
export class BrowseCookbookComponent implements OnInit {
  cookbooks: Cookbook[] = [
    {id: 'sample-0', title: 'Sample Cookbook'},
    {id: 'Indian-1', title: 'Indian Cookbook'},
    {id: 'Chinese-2', title: 'Chineese Cookbook'}
  ];
  constructor() { }

  ngOnInit() {
  }

}

export interface Cookbook {
  id: string;
  title: string;
}
