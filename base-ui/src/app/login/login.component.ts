import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form : FormGroup;
  private invalid : boolean;
  constructor(private userService:UserService, private router: Router, private cookieService: CookieService) { 
    this.form = new FormGroup({
      username: new FormControl(undefined, Validators.required),
      password: new FormControl(undefined, Validators.required),
    });
    this.invalid = false;
  }

  onClick() {
    this.invalid = false;

    this.userService.getById(this.form.value['username']).subscribe(
      response => {
      if(response.password == this.form.value['password']){
        
        this.cookieService.set('Username',response.username);
        this.router.navigate(['/store']);

      }
      else {          
        this.invalid = true;
        this.form.controls['password'].reset();
      }
      
      }

    );
  }
  ngOnInit() {
  }

  onSignUpClick() {
    this.invalid = true;
    this.router.navigate(['/signup']);
  }

}
