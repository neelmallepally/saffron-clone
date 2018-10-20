import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material.module';
import { LayoutModule } from '@angular/cdk/layout';
import { FlexLayoutModule } from '@angular/flex-layout';

import { CookbookRoutingModule } from './cookbook-routing.module';
import { ManageCookbookComponent } from './manage-cookbook/manage-cookbook.component';


@NgModule({
  declarations: [
    ManageCookbookComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    LayoutModule,
    FlexLayoutModule,
    CookbookRoutingModule
  ],
  exports: [
    
  ]
})
export class CookbookModule { }
