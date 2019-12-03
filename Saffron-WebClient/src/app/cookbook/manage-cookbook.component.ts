import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Cookbook } from './cookbook';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-manage-cookbook',
  templateUrl: './manage-cookbook.component.html',
  styleUrls: ['./manage-cookbook.component.css']
})
export class ManageCookbookComponent implements OnInit {
  cookbooks: Cookbook[];
  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data  => {
      this.cookbooks = data.cookbooks;
    });   
  }

}

