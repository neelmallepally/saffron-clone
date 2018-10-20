import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';

import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule } from '@angular/common/http';

import { MaterialModule } from './material.module';
import { GraphQLModule } from './graphql.module';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AppRoutingModule } from './app-routing.module';
import { BrowseCookbookComponent } from './browse-cookbook/browse-cookbook.component';
import { SearchComponent } from './search/search.component';
import { AddRecipeComponent } from './add-recipe/add-recipe.component';
import { AddRecipeToCookbookComponent } from './add-recipe-to-cookbook/add-recipe-to-cookbook.component';
import { SettingsComponent } from './settings/settings.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    BrowseCookbookComponent,
    SearchComponent,
    AddRecipeComponent,
    AddRecipeToCookbookComponent,
    SettingsComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    LayoutModule,
    AppRoutingModule,
    MaterialModule,
    GraphQLModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
