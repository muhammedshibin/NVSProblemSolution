import { AddLandmarkComponent } from './landmarks/add-landmark/add-landmark.component';
import { LandmarksListComponent } from './landmarks/landmarks-list/landmarks-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path:'',component:LandmarksListComponent},
  {path:'add',component:AddLandmarkComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
