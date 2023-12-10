import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { CinemaService } from '../services/cinema.service';

@Component({
  selector: 'app-cinema-list',
  templateUrl: './cinema-list.component.html',
  styleUrls: ['./cinema-list.component.css']
})

export class CinemaListComponent implements OnInit,OnChanges{

  @Input() ville;
  cinemas;
  salles;

  constructor(private cinemaService: CinemaService) {

  }

  ngOnInit(): void {
    
  }

  ngOnChanges(changes: SimpleChanges): void {

    if(this.ville != undefined)
       this.onGetCinema(this.ville)
  }

  public onGetCinema(ville) {
    this.cinemaService.getCinemas(ville)
      .subscribe(data => {
        this.cinemas = data;
      }, err => {
        console.log(err);
      })
  }

  
  public onGetSall(c:any)
  {
          this.cinemaService.getSalles(c._links.salles)
          .subscribe(data => {
            this.salles = data;
            this.salles._embedded.salles.forEach(salle => {
                this.cinemaService.getProjection(salle)
                    .subscribe(data=>{
                      salle.projections = data
                    }, err => {
                      console.log(err);
                    })
            });
          }, err => {
            console.log(err);
          })
  }

  onButtonGroupClick($event){
    let clickedElement = $event.target || $event.srcElement;

    if( clickedElement.nodeName === "BUTTON" ) {

      let isCertainButtonAlreadyActive = clickedElement.parentElement.querySelector(".btn-primary");
      // if a Button already has Class: .active
      if( isCertainButtonAlreadyActive ) {
        isCertainButtonAlreadyActive.classList.remove("btn-primary");
      }

      clickedElement.className += " btn-primary";
    }

  }
 
}
