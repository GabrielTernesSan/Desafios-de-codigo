import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { NewPlayerComponent } from './pages/new-player/new-player.component';

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "cadastro", component: NewPlayerComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
