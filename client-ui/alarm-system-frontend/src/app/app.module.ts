import { NgModule } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { UserComponent } from '../app/user/user.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { compileComponentFromMetadata } from '@angular/compiler';

@NgModule({
    declarations:
    [
    ],
    
    imports:[
    MatTableModule,
    CommonModule,
    MatCheckboxModule,
    FormsModule],
            
    bootstrap:[]
})
export class appModule{}