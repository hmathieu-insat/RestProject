package com.INSAT.RestProject;

import jakarta.ws.rs.GET;
import jakarta.ws.rs.POST;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.PathParam;
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

    @GET
    @Path("/{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Student getStudent(@PathParam("id") int id) {
        Student student = new Student();
        student.setName("Mohamed");
        student.setSurname("Bouhlel");
        return student;
    }

    @POST
    @Produces(MediaType.APPLICATION_JSON)
    public Student createStudent(Student student) {
        System.out.println("Student created");
        System.out.println(student);
        return student;
    }
}
