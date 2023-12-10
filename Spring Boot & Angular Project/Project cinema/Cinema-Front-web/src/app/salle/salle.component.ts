import { Component, Input, OnInit } from '@angular/core';
import { CinemaService } from '../services/cinema.service';

@Component({
  selector: 'app-salle',
  templateUrl: './salle.component.html',
  styleUrls: ['./salle.component.css']
})
export class SalleComponent implements OnInit {



  @Input() salle;
  projections;
  currentProjection;
  selectedTickets:any;

  constructor(public cinemaService:CinemaService)
  { }

  ngOnInit(): void {
     console.log(this.salle);
  }

  onGetTicketsPlaces(p){
    this.currentProjection = p;

    this.cinemaService.getTicketsPlaces(p)
     .subscribe(data => {
       this.currentProjection.tickets=data;
       this.selectedTickets=[]
     },err=>{
        console.log(err);
     })

  }

  onSelectTicket(t){

      if(!t.selected){
        t.selected = true;
        this.selectedTickets.push(t);
      }else{
        t.selected = false;
        this.selectedTickets.slice(this.selectedTickets.indexOf(t),1);
      }

      console.log(this.selectedTickets);
  }

  getTicketClass(t){
     let classe="btn ";
     if(t.reserve == true)
        classe+="btn-danger disabled";
     else if(t.selected)
        classe+="btn-warning";
     else
        classe+="btn-success"

    return classe;
  }


  onPayTickets(dataForm){


    let tickets = [];

    this.selectedTickets.forEach(t => {
      tickets.push(t.id);
    });

    dataForm.tickets = tickets;

    this.cinemaService.payerTickets(dataForm)
    .subscribe(data=>{
      alert("les ticket on etait bien reserver");
      this.onGetTicketsPlaces(this.currentProjection);
    },err=>{
      console.log(err)
    })


  }
}
