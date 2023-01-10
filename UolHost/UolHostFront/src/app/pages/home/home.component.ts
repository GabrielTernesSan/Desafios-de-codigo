import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Players } from 'src/app/models/players';
import { PlayersService } from 'src/app/services/players.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  // constructor(private router: Router, private route: ActivatedRoute) {
  // }

  // onEdit(player: Players) {
  //   this.router.navigate(['edit', player._id], { relativeTo: this.route })
  // }
}
