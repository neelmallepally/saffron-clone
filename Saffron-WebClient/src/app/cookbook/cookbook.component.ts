import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { Cookbook } from './cookbook';


@Component({
  selector: 'app-cookbook',
  templateUrl: './cookbook.component.html',
  styleUrls: ['./cookbook.component.css']
})
export class CookbookComponent implements OnInit {
  cookbookForm: FormGroup;
  new = true;

  cookbook: Cookbook = {
    id: '123fdasf23',
    title: 'Indian Cookbook',
    sections: [
      {
        id: 'sadfsdf234',
        title: 'Breakfast',
        order: 1
      },
      {
        id: 'sadfsdf234',
        title: 'Lunch',
        order: 2
      },
      {
        id: 'sadfsdf234',
        title: 'Dinner',
        order: 3
      },
    ]
  };

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.cookbookForm = this.fb.group({
      title: [''],
    });
  }

  onSubmit() {
    console.log(this.cookbookForm.value);
  }

  // drop(event: CdkDragDrop<string[]>){

  // }

  addSection(title: string) {
    this.cookbook.sections.push({ id: '', title: title, order: 4});
  }

}
