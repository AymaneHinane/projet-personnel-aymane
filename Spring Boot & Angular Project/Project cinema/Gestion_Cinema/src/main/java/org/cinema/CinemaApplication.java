package org.cinema;


import org.cinema.dao.TicketRepository;
import org.cinema.entities.Film;
import org.cinema.entities.Salle;
import org.cinema.entities.Ticket;
import org.cinema.service.ICinemaInitService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.data.rest.core.config.RepositoryRestConfiguration;

@SpringBootApplication
public class CinemaApplication implements CommandLineRunner {
  //mysql -P 3306 --protocol=tcp -u root -p
    @Autowired
    private ICinemaInitService cinemaInitService;

    @Autowired
    private TicketRepository ticketRepository;

    @Autowired
    private RepositoryRestConfiguration restConfiguration;

     public static  void main(String[] args){
         SpringApplication.run(CinemaApplication.class,args);
     }

    @Override
    public void run(String... args) throws Exception {
         restConfiguration.exposeIdsFor(Film.class, Salle.class,Ticket.class);
        cinemaInitService.initVilles();
        cinemaInitService.initCinemas();
        cinemaInitService.initSalles();
        cinemaInitService.initPlaces();
        cinemaInitService.initSeances ();
        cinemaInitService.initCategories();
        cinemaInitService.initFilms ();
        cinemaInitService.initProjections();
        cinemaInitService.initTickets();


        //Ticket ticket = ticketRepository.findById(1).get();


    }
}
