package com.INSAT.RestProject;

import jakarta.ws.rs.GET;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.Produces;
import jakarta.ws.rs.core.MediaType;

@Path("students")
public class StudentResource {
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public Student getStudent() {
        Student student = new Student();
        student.setName("Mohamed");
        student.setSurname("Bouhlel");
        return student;
    }
}
