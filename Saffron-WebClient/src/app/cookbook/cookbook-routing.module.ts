import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CookbookComponent } from './cookbook.component';
import { ManageCookbookComponent } from './manage-cookbook.component';

const routes: Routes = [
  { path: '', 
    component: ManageCookbookComponent,
    children:[
      { path: 'new', component: CookbookComponent },
      { path: ':id', component: CookbookComponent }
    ]
  },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CookbookRoutingModule { }
