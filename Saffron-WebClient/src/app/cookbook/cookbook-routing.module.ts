import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ManageCookbookComponent } from './manage-cookbook/manage-cookbook.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: ManageCookbookComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CookbookRoutingModule { }
