import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { Players } from '../models/players';
import { PlayersService } from '../services/players.service';

@Injectable({
  providedIn: 'root'
})
export class PlayersResolver implements Resolve<Players> {

  constructor(private service: PlayersService) {
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Players> {
    if (route.params && route.params['id']) {
      return this.service.getById(route.params['id']);
    }
    return of({ id: '', nome: '', telefone: '', email: '', codinome: '', grupo: 0, equipe: '' });
  }
}
