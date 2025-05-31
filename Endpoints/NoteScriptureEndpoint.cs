using Microsoft.AspNetCore.SignalR;
using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Endpoints
{
    public static class NoteScriptureEndpoint
    {
        public static void MapNoteScriptureEndpoints(this IEndpointRouteBuilder routes)
        {
            var app = routes.MapGroup("/api").WithTags(nameof(NoteScripture));

            //--Get NoteScripture---
            app.MapGet("/notescripture", async (INoteScriptureServices noteScriptureServices) =>
            {
                return await noteScriptureServices.GetNoteScriptures();
            })
            .WithName("GetAllNoteScriptures")
            .WithOpenApi()
            .Produces<List<NoteScripture>>(StatusCodes.Status200OK);

            //Get NoteScripture by Id
            app.MapGet("/notescripture/{id}", async (int id, INoteScriptureServices noteScriptureServices) =>
            {
                var result = await noteScriptureServices.GetNoteScriptureById(id);
                return result is null ? Results.NotFound() : Results.Ok(result);
            })
            .WithName("GetNoteScriptureById")
            .WithOpenApi()
            .Produces<NoteScripture>(StatusCodes.Status200OK);

            //Add NoteScripture
            app.MapPost("/notescripture", async (NoteScripture noteScripture, INoteScriptureServices noteScriptureServices) =>
            {
                var addedNoteScripture = await noteScriptureServices.AddNoteScripture(noteScripture);
                return addedNoteScripture is null ? Results.BadRequest() : Results.Created($"/notescripture/{addedNoteScripture.Id}", addedNoteScripture);
            })
            .WithName("AddNoteScripture")
            .WithOpenApi()
            .Produces<NoteScripture>(StatusCodes.Status201Created);

            //Update NoteScripture
            app.MapPut("/notescripture/{id}", async (int id, NoteScripture noteScripture, INoteScriptureServices noteScriptureServices) =>
            {
                var existingNoteScripture = await noteScriptureServices.UpdateNoteScripture(id, noteScripture);
                return existingNoteScripture is null ? Results.NotFound() : Results.Ok(existingNoteScripture);
            })
            .WithName("UpdateNoteScripture")
            .WithOpenApi()
            .Produces<NoteScripture>(StatusCodes.Status200OK);

            //Delete NoteScripture
            app.MapDelete("/notescripture/{id}", async (int id, INoteScriptureServices noteScriptureServices) =>
            {
                var deletedNoteScripture = await noteScriptureServices.DeleteNoteScripture(id);
                return Results.NotFound();
            })
            .WithName("DeleteNoteScripture")
            .WithOpenApi()
            .Produces(StatusCodes.Status204NoContent);
        }
    }
}
