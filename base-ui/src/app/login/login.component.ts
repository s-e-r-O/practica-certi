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
  constructor(private userService:UserService, private router: Router, private cookieService: CookieService) { 
    this.form = new FormGroup({
      username: new FormControl(undefined, Validators.required),
      password: new FormControl(undefined, Validators.required),
    });
  }

  onClick() {
    for(var control in this.form.controls){
      this.form.controls[control].markAsTouched();
    }

    if(this.form.valid) {
      this.userService.getById(this.form.value['username']).subscribe(
        response => {
        if(response.password == this.form.value['password']){
          
          this.cookieService.set('Username',response.username);
          this.router.navigate(['/store']);

        }
        else {
          
          this.form.controls['password'].reset();
        }
        
        }

      );
    } 
  }
  ngOnInit() {
  }

}
