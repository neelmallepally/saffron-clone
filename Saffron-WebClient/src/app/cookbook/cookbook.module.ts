import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material.module';
import { LayoutModule } from '@angular/cdk/layout';
import { FlexLayoutModule } from '@angular/flex-layout';

import { CookbookRoutingModule } from './cookbook-routing.module';
import { CookbookComponent } from './cookbook.component';
import { ManageCookbookComponent } from './manage-cookbook.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CookbookResolverService } from './cookbook-resolve.service';


@NgModule({
  declarations: [
    CookbookComponent,
    ManageCookbookComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
    LayoutModule,
    FlexLayoutModule,
    CookbookRoutingModule,
  ],
  providers : [
    CookbookResolverService
  ],
  exports: [
    
  ]
})
export class CookbookModule { }
