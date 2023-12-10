import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  isOpen:boolean = false;

  constructor(private router: Router){}


  ngOnInit(): void {
    this.router.events.subscribe(event => {
    if (event instanceof NavigationEnd) {
      const currentUrl = this.router.url;
      if (currentUrl !== '/' && currentUrl !== '/home' &&!currentUrl.includes("/assignment-info"))
        this.open()
    }
  });
  }



  open(){
    this.isOpen = !this.isOpen;
  }

}
