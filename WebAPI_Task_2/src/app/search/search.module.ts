import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GlobalSearchComponent } from './global-search/global-search.component';
import {MatInputModule} from "@angular/material/input";
import {ReactiveFormsModule} from "@angular/forms";
import {MatSelectModule} from "@angular/material/select";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {SelectionService} from "../services/selection.service";
import {HttpClientModule} from "@angular/common/http";
import {MatCardModule} from "@angular/material/card";
import { SafePipe } from './safe.pipe';

@NgModule({
  declarations: [
    GlobalSearchComponent,
    SafePipe
  ],
  exports: [GlobalSearchComponent, SafePipe],
  imports: [
    CommonModule,
    MatInputModule,
    ReactiveFormsModule,
    MatSelectModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatCardModule
  ],
  providers: [SelectionService],
  bootstrap: [GlobalSearchComponent]
})
export class SearchModule {

}
