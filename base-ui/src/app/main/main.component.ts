import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { UserService } from '../services/user.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit {
  private username : string;
  constructor(private router: Router, private userService: UserService, private location : Location) { 
    this.username = this.userService.currentUser();
    if (this.userService.isLoggedIn()){
      this.userService.getById(this.username).subscribe(
        response => {
          if (this.location.isCurrentPathEqualTo('')){
            this.router.navigate(['/store']);
          }
        },
        error => {
          this.router.navigate(['/login']);
        }
      )
    } else {
      this.router.navigate(['/login']);
    }
  }

  ngOnInit() {
  }

}
