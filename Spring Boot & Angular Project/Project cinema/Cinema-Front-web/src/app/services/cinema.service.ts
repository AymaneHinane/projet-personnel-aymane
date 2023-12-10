import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CinemaService {

  public host:string="http://localhost:8080";

  constructor(private http:HttpClient) { }

  public getVilles(){
    return this.http.get(this.host+"/villes");
  }

  public getCinemas(v){
     return this.http.get(v._links.cinemas.href)
  }

  public getSalles(c){
    return this.http.get(c.href)
  }

  public getProjection(s){

    let url = s._links.projection.href.replace("{?projection}","");
    console.log(url+"?projection=p1");
    return this.http.get(url+"?projection=p1");
  }

  getTicketsPlaces(p: any) {
    let url = p._links.tickets.href.replace("{?projection}","")
    console.log(url+"?projection=ticketProj");
    return this.http.get(url+"?projection=ticketProj");
  }


  payerTickets(dataFrom){
    return this.http.post(this.host+"/payerTickets",dataFrom);
  }
  
}
