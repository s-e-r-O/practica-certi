import { Component, OnInit, Input } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  @Input() username : string;
  constructor(private cookieService : CookieService, private router : Router) { }

  ngOnInit() {
  }

  onSignOut($event){
    this.cookieService.delete('Username');
    this.router.navigate(['/login']);
  }

}
