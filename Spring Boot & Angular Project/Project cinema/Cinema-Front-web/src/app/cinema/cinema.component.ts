import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CinemaService } from '../services/cinema.service';


interface Ville {
  name: string
}

@Component({
  selector: 'app-cinema',
  templateUrl: './cinema.component.html',
  styleUrls: ['./cinema.component.css']
})



export class CinemaComponent  {

  ville;
  constructor(private cinemaService: CinemaService) {

  }
  getVille(e){
      this.ville = e;
  }
}
