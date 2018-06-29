import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { MAX_LENGTH_VALIDATOR } from '@angular/forms/src/directives/validators';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

	form : FormGroup;
	errorAlert: boolean = false;
	message : string;
	users : Observable<any>;
	userAlert : boolean = false;
	successMessage : string;

  constructor(private userService: UserService, private router: Router) { 
  	this.form = new FormGroup({
  		username: new FormControl(undefined, Validators.required),
  		password: new FormControl(undefined, Validators.required),
  		confirmPassword: new FormControl(undefined, Validators.required),
  		name: new FormControl(undefined, Validators.required),
  		lastname: new FormControl(undefined, Validators.required)
	  });
	  this.userAlert = false;
	  this.errorAlert = false;
  }

  ngOnInit() {
  }

  onClick() {
  	if (this.form.valid) {
  		if (this.form.value['password'] != this.form.value['confirmPassword']) {
  			this.errorAlert = true;
			  this.message = "Confirm Password does not coincide with Password";
			  this.form.controls['password'].reset();
			  this.form.controls['confirmPassword'].reset();
  		} else {
			  this.users = null;
			  this.errorAlert = false;
			  this.userService.create(new User(this.form.value)).subscribe(response => {
			  this.userAlert = true;
			  this.successMessage = "User created successfully!";
			  this.form.controls['username'].reset();
			  this.form.controls['name'].reset();
			  this.form.controls['lastname'].reset();
			  this.form.controls['password'].reset();
			  this.form.controls['confirmPassword'].reset();
			  this.timeout();
			  }, error => {
				  this.errorAlert = true;
				  this.message = "This username already exists. Please Choose other username";
				  this.form.controls['password'].reset();
			  	  this.form.controls['confirmPassword'].reset();
			  });
  		}
	  }	  
  }

  timeout() {
	setTimeout( () => { 
		console.log('Test');
		this.router.navigate(['/login']);
	}, 3000);
  }

}
