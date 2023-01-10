import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlayersResolver } from './guards/players.resolver';
import { EditPlayerComponent } from './pages/edit-player/edit-player.component';
import { HomeComponent } from './pages/home/home.component';
import { NewPlayerComponent } from './pages/new-player/new-player.component';

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "cadastro", component: NewPlayerComponent, resolve: { player: PlayersResolver } },
  { path: "editar/:id", component: EditPlayerComponent, resolve: { player: PlayersResolver } }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
