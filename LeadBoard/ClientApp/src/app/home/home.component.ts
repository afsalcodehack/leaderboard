import { Component, Inject, OnInit } from '@angular/core';
import { GameModel } from '../model/game.model';
import { UserModel } from '../model/UserModel';
import { HttpClient } from '@angular/common/http';
import { ScoreModel } from '../model/scoreModel';
import { ResponseBase } from '../model/ResponseBase';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public gameSource: Array<GameModel> = new Array<GameModel>();
  public userSource: Array<UserModel> = new Array<UserModel>();
  public score: ScoreModel = new ScoreModel();

  public dataSource: Array<ScoreModel> = new Array<ScoreModel>();

  public baseUrl = "";
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  displayedColumns: string[] = ['id', 'gameName', 'userName', 'score'];

  ngOnInit() {
    this.getUser();
    this.getGame();
    this.getScore();
  }

  handleUserChange(event) {
    this.score.userId = event.value
  }

  handleGameChange(event) {
    this.score.gameId = event.value
  }

  gameFilter(event) {
    this.getScoreByGame(event.value);
  }


  getGame() {
    this.http.get<GameModel[]>(this.baseUrl + 'LeadBoard/GetAllGames').subscribe((result: any) => {
      this.gameSource = result.games;
    }, error => console.error(error));

  }

  saveScore() {
    this.http.post<ResponseBase>(this.baseUrl + 'LeadBoard/CreateScore', this.score).subscribe((result: any) => {
      alert(result.errorMessage)
    }, error => console.error(error), () =>  { this.getScore() });
  }


  getScore() {
    this.http.get<GameModel[]>(this.baseUrl + 'LeadBoard/GetScore?limit=10').subscribe((result: any) => {
      this.dataSource = result.scoreList;
    }, error => console.error(error));

  }

  getScoreByGame(gameId: number) {
    this.http.get<GameModel[]>(this.baseUrl + 'LeadBoard/GetScoreByGame?gameId=' + gameId).subscribe((result: any) => {
      this.dataSource = result.scoreList;
    }, error => console.error(error));

  }

  getUser() {
    this.http.get<GameModel[]>(this.baseUrl + 'LeadBoard/GetAllUsers').subscribe((result: any) => {
      this.userSource = result.users;
    }, error => console.error(error));

  }
}
