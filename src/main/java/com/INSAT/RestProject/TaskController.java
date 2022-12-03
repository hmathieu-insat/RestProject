package com.INSAT.RestProject;

import java.util.ArrayList;

import jakarta.ws.rs.Consumes;
import jakarta.ws.rs.DELETE;
import jakarta.ws.rs.GET;
import jakarta.ws.rs.POST;
import jakarta.ws.rs.PUT;
import jakarta.ws.rs.Path;
import jakarta.ws.rs.Produces;
import jakarta.ws.rs.QueryParam;
import jakarta.ws.rs.core.MediaType;

@Path("tasks")
public class TaskController {

    public TaskController() {
        tasks = new ArrayList<>();
    }

    private ArrayList<Task> tasks;

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public ArrayList<Task> getTasks() {
        return tasks;
    }

    @GET
    @Path("{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public Task getTask(@QueryParam("id") int id) {
        return tasks.get(id);
    }

    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    public void addTask(Task task) {
        tasks.add(task);
    }

    @DELETE
    @Path("{id}")
    public void deleteTask(Task task) {
        tasks.remove(task);
    }

    @PUT
    @Path("{id}")
    @Consumes(MediaType.APPLICATION_JSON)
    public void updateTask(Task task) {
        for (int i = 0; i < tasks.size(); i++) {
            if (tasks.get(i).getTitle().equals(task.getTitle())) {
                tasks.set(i, task);
            }
        }
    }
}
