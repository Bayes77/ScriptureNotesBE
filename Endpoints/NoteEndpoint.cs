using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Endpoints
{
    public static class NoteEndpoint
    {
        public static void MapNoteEndpoints(this IEndpointRouteBuilder routes)
        {
            var app = routes.MapGroup("/api").WithTags(nameof(Note));

            //--GetNotes--
            app.MapGet("/notes", async (INoteServices noteServices) =>
            {
                return await noteServices.GetNotes();
            })
            .WithName("GetAllNotes")
            .WithOpenApi()
            .Produces<List<Note>>(StatusCodes.Status200OK);

            //--GetNoteById--
            app.MapGet("/notes/{id}", async (int id, INoteServices noteServices) =>
            {
                var results = await noteServices.GetNoteById(id);
                return results is null ? Results.NotFound() : Results.Ok(results);
            })
            .WithName("GetNoteById")
            .WithOpenApi()
            .Produces<Note>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            //--AddNote--
            app.MapPost("/notes", async (Note note, INoteServices noteServices) =>
            {
                var addedNote = await noteServices.AddNote(note);
                return addedNote is null ? Results.NotFound() : Results.Created($"/notes/{addedNote.Id}", addedNote);
            })
            .WithName("AddNote")
            .WithOpenApi()
            .Produces<Note>(StatusCodes.Status201Created);

            //--UpdateNote--
            app.MapPut("/notes/{id}", async (int id, Note note, INoteServices noteServices) =>
            {
                var existingNote = await noteServices.UpdateNote(id, note);
                return existingNote is null ? Results.NotFound() : Results.Ok(existingNote);
            })
            .WithName("UpdateNote")
            .WithOpenApi()
            .Produces<Note>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            //--DeleteNote--
            app.MapDelete("/notes/{id}", async (int id, INoteServices noteServices) =>
            {
                var deltedNote = await noteServices.DeleteNote(id);
                return Results.NotFound();
            })
            .WithName("DeleteNote")
            .WithOpenApi()
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
