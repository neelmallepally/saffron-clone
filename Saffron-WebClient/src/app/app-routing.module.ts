import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BrowseCookbookComponent } from './browse-cookbook/browse-cookbook.component';
import { SearchComponent } from './search/search.component';
import { AddRecipeComponent } from './add-recipe/add-recipe.component';
import { AddRecipeToCookbookComponent } from './add-recipe-to-cookbook/add-recipe-to-cookbook.component';
import { SettingsComponent } from './settings/settings.component';
import { NavComponent } from './nav/nav.component';

const routes: Routes = [
  { path: '', 
    component: NavComponent,
    children: [
      { path: 'browse', component: BrowseCookbookComponent },
      { path: 'search', component: SearchComponent },
      { path: 'add-recipe', component: AddRecipeComponent },
      { path: 'add-recipe-to-cookbook', component: AddRecipeToCookbookComponent },
      { path: 'settings', component: SettingsComponent },
      {
        path: 'manage-cookbook',
        loadChildren: './cookbook/cookbook.module#CookbookModule'
      }
    ]
  },
  
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
