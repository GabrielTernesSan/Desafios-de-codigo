import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PlayersService } from 'src/app/services/players.service';
import { ActivatedRoute } from '@angular/router';
import { Players } from 'src/app/models/players';
import { editPlayer } from 'src/app/models/editPlayer';

@Component({
  selector: 'app-edit-player',
  templateUrl: './edit-player.component.html',
  styleUrls: ['./edit-player.component.css']
})
export class EditPlayerComponent implements OnInit {

  formEdit: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private service: PlayersService,
    private route: ActivatedRoute,
    private _snackBar: MatSnackBar,
    private location: Location) {
    const player: Players = this.route.snapshot.data['player'];
    console.log(player);
    this.formEdit = this.formBuilder.group({
      nome: [player.nome, { nonNullable: true }],
      email: [player.email, { nonNullable: true }],
      telefone: [player.telefone, { nonNullable: false }]
    });
  }

  ngOnInit(): void {

  }

  private onError() {
    this._snackBar.open("Erro ao editar o jogador!", '', { duration: 5000 });
  }

  private onSuccess() {
    this._snackBar.open("Jogador editado!", '', { duration: 5000 });
    this.location.back();
  }

  onEdit() {
    const player: Players = this.route.snapshot.data['player'];
    this.service.edit(this.formEdit.value, player.id).subscribe({
      complete: () => {
        this.onSuccess();
        console.log(player);
      },
      error: () => this.onError()
    });
  }
}
