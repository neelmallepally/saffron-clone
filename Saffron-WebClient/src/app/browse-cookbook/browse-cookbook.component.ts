import { Component, OnInit } from '@angular/core';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import { Observable } from 'rxjs';
import { shareReplay, map } from 'rxjs/operators';
import { Cookbook } from '../cookbook/cookbook';

@Component({
  selector: 'app-browse-cookbook',
  templateUrl: './browse-cookbook.component.html',
  styleUrls: ['./browse-cookbook.component.css']
})
export class BrowseCookbookComponent implements OnInit {
  cookbooks: Cookbook[] = [
    {
      id: 'sample-0',
      title: 'Sample Cookbook',
      sections: [{
        id: 'section 1',
        title: 'section 1',
        order: 1
      },
      {
        id: 'section 2',
        title: 'section 2',
        order: 2
      }]
    },
    {
      id: 'Indian-1',
      title: 'Indian Cookbook',
      sections: [{
        id: 'section 1',
        title: 'section 1',
        order: 1
      }]
    },
    {
      id: 'Chinese-2',
      title: 'Chineese Cookbook',
      sections: [{
        id: 'section 1',
        title: 'section 1',
        order: 1
      }]
    }
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
