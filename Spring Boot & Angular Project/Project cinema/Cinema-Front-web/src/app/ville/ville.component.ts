import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CinemaService } from '../services/cinema.service';

@Component({
  selector: 'app-ville',
  templateUrl: './ville.component.html',
  styleUrls: ['./ville.component.css']
})
export class VilleComponent {

  villes;
  @Input() ville;

  @Output() villeOutput  = new EventEmitter(); 

  constructor(private cinemaService: CinemaService)
  { }

  ngOnInit(): void {
    this.cinemaService.getVilles()
      .subscribe(data => {
        this.villes = data;
      }, err => {
        console.log(err);
      })
  }

  sendFilm(ville)
  {
      this.villeOutput.emit(ville);
  }

 


}
