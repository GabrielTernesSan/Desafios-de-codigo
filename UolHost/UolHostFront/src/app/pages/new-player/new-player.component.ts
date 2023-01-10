import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { PlayersService } from 'src/app/services/players.service';

@Component({
  selector: 'app-new-player',
  templateUrl: './new-player.component.html',
  styleUrls: ['./new-player.component.css']
})
export class NewPlayerComponent implements OnInit {

  form: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private service: PlayersService,
    private _snackBar: MatSnackBar,
    private location: Location) {
    this.form = this.formBuilder.group({
      nome: ['', { nonNullable: true }],
      email: ['', { nonNullable: true }],
      telefone: [null],
      grupo: ['']
    });
  }

  onSubmit() {
    this.form.controls["grupo"].setValue(parseInt(this.form.value.grupo))
    console.log(this.form.value)

    this.service.save(this.form.value).subscribe({
      complete: () => {
        this.onSuccess();
        console.log(this.form.value);
      },
      error: () => this.onError()
    });
  }

  private onError() {
    this._snackBar.open("Erro ao salvar o jogador!", '', { duration: 5000 });
  }

  private onSuccess() {
    this._snackBar.open("Jogador cadastrado!", '', { duration: 5000 });
    this.location.back();
  }

  ngOnInit(): void { }
}
