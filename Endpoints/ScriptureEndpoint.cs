using Microsoft.AspNetCore.SignalR;
using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;
using System.Runtime.CompilerServices;

namespace ScriptureNotesBE.Endpoints
{
    public static class ScriptureEndpoint
    {
        public static void MapScriptureEndpoints(this IEndpointRouteBuilder routes)
        {
            var app = routes.MapGroup("/api").WithTags(nameof(Scripture));

            //---Get Scripture ---
            app.MapGet("/scriptures", async (IScriptureServices scriptureServices) =>
            {
                return await scriptureServices.GetScriptures();
            })
                .WithName("GetAllScriptures")
                .WithOpenApi()
                .Produces<List<Scripture>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithTags(nameof(Scripture));

            //---Get Scripture by Id ---
            app.MapGet("/scriptures/{id}", async (int id, IScriptureServices scriptureServices) =>
            {
                var result = await scriptureServices.GetScriptureById(id);
                return result is null ? Results.NotFound() : Results.Ok(result);
            })
                .WithName("GetScriptureById")
                .WithOpenApi()
                .Produces<Scripture>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithTags(nameof(Scripture));

            //---Add Scripture ---
            app.MapPost("/scriptures", async (Scripture scripture, IScriptureServices scriptureServices) =>
            {
                var addedScripture = await scriptureServices.AddScripture(scripture);
                return addedScripture is null ? Results.NotFound() : Results.Ok(addedScripture);
            })
                .WithName("AddScripture")
                .WithOpenApi()
                .Produces<Scripture>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithTags(nameof(Scripture));

            //---Update Scripture ---
            app.MapPut("/scriptures/{id}", async (int id, Scripture scripture, IScriptureServices scriptureServices) =>
            {
                var existingScripture = await scriptureServices.GetScriptureById(id);
                if (existingScripture is null)
                {
                    return Results.NotFound();
                }

                var updatedScripture = await scriptureServices.UpdateScripture(id, scripture);
                return Results.Ok(updatedScripture);
            })
                .WithName("UpdateScripture")
                .WithOpenApi()
                .Produces<Scripture>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);


            //---Delete Scripture ---
            app.MapDelete("/scriptures/{id}", async (int id, IScriptureServices scriptureServices) =>
            {
                var deletedScripture = await scriptureServices.DeleteScripture(id);
                return Results.NoContent();
            })
                .WithName("DeleteScripture")
                .WithOpenApi()
                .Produces<Scripture>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);
               
        }
    }
}
