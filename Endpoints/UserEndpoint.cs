using Microsoft.AspNetCore.SignalR;
using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;
using System.Diagnostics;

namespace ScriptureNotesBE.Endpoints
{
    public static class UserEndpoint
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/users").WithTags(nameof(User));

            //--Get Users ---
            routes.MapGet("/users", async (IUserServices userServices) =>
            {
                return await userServices.GetUsers();
            })
            .WithName("GetAllUsers")
            .WithOpenApi()
            .Produces<List<User>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            //--Get User by Id ---
            routes.MapGet("/users/{id}", async (string id, IUserServices userServices) =>
            {
                var result = await userServices.GetUserById(id);
                return result != null ? Results.Ok(result) : Results.NotFound();
            })
            .WithName("GetUserById")
            .WithOpenApi()
            .Produces<User>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            //--Add User ---
            routes.MapPost("/users", async (User user, IUserServices userServices) =>
            {
                var addedUser = await userServices.AddUser(user);
                return addedUser != null ? Results.Created($"/users/{addedUser.Id}", addedUser) : Results.BadRequest("User already exists");
            })
            .WithName("AddUser")
            .WithOpenApi()
            .Produces<User>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            //--Update User ---
            routes.MapPut("/users/{id}", async (int id, User user, IUserServices userServices) =>
            {
                var existingUser = await userServices.UpdateUser(id, user);
                return existingUser != null ? Results.Ok(existingUser) : Results.NotFound();
            })
            .WithName("UpdateUser")
            .WithOpenApi()
            .Produces<User>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            //--Delete User ---
            routes.MapDelete("/users/{id}", async (int id, IUserServices userServices) =>
            {
                var deletedUser = await userServices.DeleteUser(id);
                return  Results.NoContent();
            })
            .WithName("DeleteUser")
            .WithOpenApi()
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
