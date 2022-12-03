package com.INSAT.RestProject;

import jakarta.ws.rs.Consumes;
import jakarta.ws.rs.GET;
import jakarta.ws.rs.PUT;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.PathParam;
import jakarta.ws.rs.Produces;
import jakarta.ws.rs.QueryParam;
import jakarta.ws.rs.core.MediaType;

@Path("comparator")
public class Comparator {

    String message;

    @GET
    @Path("longeur/{chaine}")
    @Produces(MediaType.TEXT_PLAIN)
    public int getLongueur(@PathParam("chaine") String inString) {
        return inString.length();
    }

    @GET
    @Path("longeurDouble")
    @Produces(MediaType.TEXT_PLAIN)
    public int getLongueurDouble(@QueryParam("chaine") String inString) {
        return inString.length() * 2;
    }

    @PUT
    @Path("{idStudent}")
    @Consumes(MediaType.TEXT_PLAIN)
    public void updateStudent(@PathParam("idStudent") int id) {
        System.out.println("Student with id " + id + " updated");
    }
}
