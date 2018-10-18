import { Component, OnInit } from '@angular/core';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import { Observable } from 'rxjs';
import { shareReplay, map } from 'rxjs/operators';

@Component({
  selector: 'app-browse-cookbook',
  templateUrl: './browse-cookbook.component.html',
  styleUrls: ['./browse-cookbook.component.css']
})
export class BrowseCookbookComponent implements OnInit {
  cookbooks: Cookbook[] = [
    { id: 'sample-0', title: 'Sample Cookbook' },
    { id: 'Indian-1', title: 'Indian Cookbook' },
    { id: 'Chinese-2', title: 'Chineese Cookbook' }
  ];

  courses$: Observable<Course[]>;

  constructor(private apollo: Apollo) { }

  ngOnInit() {
    this.courses$ = this.apollo.watchQuery<Query>({
      query: gql`
        {
          allCourses {
            id
            title
            author
            description
            topic
            url
          }
        }
      `
    })
      .valueChanges
      .pipe(
        map(result => result.data.allCourses)
      );
  }
}

export interface Cookbook {
  id: string;
  title: string;
}

export type Course = {
  id: number;
  title: string;
  author: string;
  description: string;
  topic: string;
  url: string;
}
export type Query = {
  allCourses: Course[];
}
