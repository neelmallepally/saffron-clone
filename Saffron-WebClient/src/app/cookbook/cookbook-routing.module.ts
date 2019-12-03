import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CookbookComponent } from './cookbook.component';
import { ManageCookbookComponent } from './manage-cookbook.component';
import { CookbookResolverService } from './cookbook-resolve.service';

const routes: Routes = [
  { path: '', 
    component: ManageCookbookComponent,
    resolve: { cookbooks: CookbookResolverService },
    children:[
      { path: 'new', component: CookbookComponent },
      { path: ':id/edit', component: CookbookComponent }
    ]
  },
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CookbookRoutingModule { }
