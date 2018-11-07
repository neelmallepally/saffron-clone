import { NgModule } from '@angular/core';
import { DragDropModule } from '@angular/cdk/drag-drop';
import {
  MatToolbarModule,
  MatButtonModule,
  MatSidenavModule,
  MatIconModule,
  MatSelectModule,
  MatCardModule,
  MatListModule,
  MatTooltipModule,
  MatInputModule
} from '@angular/material';

@NgModule({
  imports: [],
  declarations: [],
  exports: [
    DragDropModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatTooltipModule,
    MatSelectModule,
    MatCardModule,
    MatListModule
  ]
})
export class MaterialModule { }
