import { Component, OnInit, Inject } from '@angular/core';
import { GameModel } from '../model/game.model';
import { LeadBoardService } from '../services/LeadboardService';
import { HttpClient } from '@angular/common/http';
import { ResponseBase } from '../model/ResponseBase';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {
  public baseUrl = "";
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public game: GameModel = new GameModel();

  public gameSource: Array<GameModel> = new Array<GameModel>();




  ngOnInit() {
    this.getGame();
  }


  saveGame() {
    this.http.post<ResponseBase>(this.baseUrl + 'LeadBoard/CreateGame', this.game).subscribe((result: any) => {
        alert(result.errorMessage)
    }, error => console.error(error), () => {
      this.getGame();
    });
  }

  getGame() {
    this.http.get<GameModel[]>(this.baseUrl + 'LeadBoard/GetAllGames').subscribe((result: any) => {
      this.gameSource = result.games;
  }, error => console.error(error));

  }

}
