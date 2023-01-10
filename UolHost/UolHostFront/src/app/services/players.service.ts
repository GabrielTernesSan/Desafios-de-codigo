import { Injectable } from '@angular/core';
import { Players } from '../models/players';
import { HttpClient } from '@angular/common/http';
import { first, tap } from 'rxjs/operators';
import { Grupos } from '../models/Grupos';
import { editPlayer } from '../models/editPlayer';

@Injectable({
  providedIn: 'root'
})
export class PlayersService {

  private readonly API = 'https://localhost:7067/v1/jogador'

  constructor(private httpClient: HttpClient) { }

  list() {
    return this.httpClient.get<Players[]>(this.API).pipe(tap(player => {
      player.forEach(element => {
        if (element.grupo == 1) {
          element.equipe = Grupos[1];
        } else {
          element.equipe = Grupos[2];
        }

        if (element.telefone == null || element.telefone == "") {
          element.telefone = " - "
        }
      });
    })
    );
  }

  save(record: Players) {
    console.log(record)
    return this.httpClient.post<Players>(this.API, record);
  }

  getById(id: string) {
    return this.httpClient.get<Players>(`${this.API}/${id}`);
  }

  edit(record: Players, id: string) {
    console.log(record);
    let playerEdit: editPlayer = { nome: record.nome, telefone: record.telefone, email: record.email }
    return this.httpClient.put<editPlayer>(`${this.API}/${id}`, playerEdit);
  }

  delete(id: string) {
    console.log(id)
    return this.httpClient.delete(`${this.API}/${id}`);
  }

}
