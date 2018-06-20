import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestComponent } from './test/test.component';
import { MainComponent } from './main/main.component';

const routes: Routes = [
  { path: 'test', component: TestComponent },
  { path: '', component: MainComponent, 
    children:[
      { path: 'test2', component: TestComponent }
    ] 
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
