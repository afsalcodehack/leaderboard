import { Component, OnInit, Inject } from '@angular/core';
import { GameModel } from '../model/game.model';
import { LeadBoardService } from '../services/LeadboardService';
import { HttpClient } from '@angular/common/http';
import { ResponseBase } from '../model/ResponseBase';
import { UserModel } from '../model/UserModel';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  public baseUrl = "";
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public user: UserModel = new UserModel();

  public userSource: Array<UserModel> = new Array<UserModel>();




  ngOnInit() {
    this.getUser();
  }


  saveUser() {
    this.http.post<ResponseBase>(this.baseUrl + 'LeadBoard/CreateUser', this.user).subscribe((result: any) => {
      alert(result.errorMessage)
    }, error => console.error(error), () => {
        this.getUser();
    });
  }

  getUser() {
    this.http.get<GameModel[]>(this.baseUrl + 'LeadBoard/GetAllUsers').subscribe((result: any) => {
      this.userSource = result.users;
    }, error => console.error(error));

  }

}
