package org.cinema.web;


import jakarta.transaction.Transactional;
import org.cinema.dao.FilmRepository;

import org.cinema.dao.TicketRepository;
import org.cinema.entities.Film;
import org.cinema.entities.Ticket;
import org.cinema.entities.TicketFrom;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.*;

import java.awt.*;
import java.io.File;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@RestController
@Transactional
@CrossOrigin("*")
public class CinemaRestController {

    @Autowired
    private FilmRepository filmRepository;

    @Autowired
    private TicketRepository ticketRepository;

    @GetMapping(path = "/imageFilm/{id}", produces = MediaType.IMAGE_JPEG_VALUE)
    public byte[] image(@PathVariable(name = "id") Long id) throws Exception {

        Film f = filmRepository.findById(id).get();
        String photoName = f.getPhoto();
        //System.getProperty("user.home")+"/cinema/images/
        File file = new File("/Users/aymanehinane/Desktop/Home/Spring Boot/Gestion_Cinema/src/main/resources/static/images/" + photoName);
        Path path = Paths.get(file.toURI());
        return Files.readAllBytes(path);
    }


    @PostMapping("/payerTickets")
    @Transactional
    public List<Ticket> payerTickets(@RequestBody TicketFrom ticketFrom) {
        List<Ticket> listTickets = new ArrayList<>();

        ticketFrom.getTickets().forEach(idTicket -> {
            System.out.println(idTicket);
            Optional<Ticket> optionalTicket = ticketRepository.findById(idTicket);
            if (optionalTicket.isPresent()) {
                Ticket ticket = optionalTicket.get();
                System.out.println(ticket.getId());
                ticket.setNomClient(ticketFrom.getNomClient());
                ticket.setReserve(true);
                ticket.setCodePayement(ticketFrom.getCodePayment());
                ticketRepository.save(ticket);
                listTickets.add(ticket);
            }
        });

        return listTickets;
    }

}