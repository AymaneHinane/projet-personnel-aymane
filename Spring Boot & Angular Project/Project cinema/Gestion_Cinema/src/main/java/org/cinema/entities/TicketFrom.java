package org.cinema.entities;

import lombok.Data;

import java.util.ArrayList;
import java.util.List;

@Data
public class TicketFrom {
    private String nomClient;
    private int codePayment;
    private List<Long> tickets = new ArrayList<>();
}
