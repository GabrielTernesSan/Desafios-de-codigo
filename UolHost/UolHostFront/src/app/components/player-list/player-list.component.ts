import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { catchError } from 'rxjs';
import { Observable, of } from 'rxjs';
import { Players } from 'src/app/models/players';
import { PlayersService } from 'src/app/services/players.service';

@Component({
  selector: 'app-player-list',
  templateUrl: './player-list.component.html',
  styleUrls: ['./player-list.component.css']
})
export class PlayerListComponent implements OnInit {

  listPlayer: Observable<Players[]> | [] = [];

  displayedColumns = ['nome', 'telefone', 'email', 'nick', 'equipe', 'actions']

  constructor(
    private playersService: PlayersService,
    private _snackBar: MatSnackBar,
    private router: Router
  ) {
    this.refresh();
  }

  refresh() {
    this.listPlayer = this.playersService.list().pipe(
      catchError(error => {
        this.onError("Erro ao tentar carregar jogadores")
        return of([])
      })
    );
  }

  private onError(errorMsg: string) {
    this._snackBar.open(errorMsg, '', { duration: 5000 });
  }

  toEdit(player: Players) {
    this.router.navigate([`/editar/${player.id}`]);
  }

  onDelete(player: Players) {
    this.playersService.delete(player.id).subscribe(
      () => {
        this.refresh();
        this._snackBar.open("Jogador excluido com sucesso", 'X', {
          duration: 5000,
          verticalPosition: 'top',
          horizontalPosition: 'center'
        });
      },
      () => this.onError("Erro ao tentar remover curso")
    );
  }

  // onEdit(player: Players) {
  //   this.edit.emit(player)
  // }

  ngOnInit(): void { }
}
