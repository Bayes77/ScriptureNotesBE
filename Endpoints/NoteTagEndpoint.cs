using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;
using System.Runtime.CompilerServices;

namespace ScriptureNotesBE.Endpoints
{
    public static class NoteTagEndpoint
    {
        public static void MapNoteTagEndpoints(this IEndpointRouteBuilder routes)
        {
            var app = routes.MapGroup("/api").WithTags(nameof(NoteTag));

            //---GET noteTag --
            app.MapGet("/notetag", async (INoteTagServices noteTagServices) =>
            {
                return await noteTagServices.GetNoteTags();
            })
            .WithName("GetAllNoteTags")
            .WithOpenApi()
            .Produces<List<NoteTag>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            //---GET noteTag by id --
            app.MapGet("/notetag/{id}", async (int id, INoteTagServices noteTagServices) =>
            {
                var result = await noteTagServices.GetNoteTagById(id);
                return result is not null ? Results.Ok(result) : Results.NotFound();
            })
                .WithName("GetNoteTagById")
                .WithOpenApi()
                .Produces<NoteTag>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            //---POST noteTag --
            app.MapPost("/notetag", async (NoteTag noteTag, INoteTagServices noteTagServices) =>
            {
                var addeddNoteTag = await noteTagServices.AddNoteTag(noteTag);
                return addeddNoteTag is not null ? Results.Created($"/notetag/{addeddNoteTag.Id}", addeddNoteTag) : Results.BadRequest();
            })
                .WithName("CreateNoteTag")
                .WithOpenApi()
                .Produces<NoteTag>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);


            //---PUT noteTag --
            app.MapPut("/notetag/{id}", async (int id, NoteTag noteTag, INoteTagServices noteTagServices) =>
            {
                var exsistingNoteTag = await noteTagServices.DeleteNoteTag(id);
                return exsistingNoteTag is not null ? Results.Ok(await noteTagServices.UpdateNoteTag(id, noteTag)) : Results.NotFound();
            })
                .WithName("UpdateNoteTag")
                .WithOpenApi()
                .Produces<NoteTag>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status400BadRequest);

            //---DELETE noteTag --
            app.MapDelete("/notetag/{id}", async (int id, INoteTagServices noteTagServices) =>
            {
                var deletedNoteTag = await noteTagServices.DeleteNoteTag(id);
                if (deletedNoteTag is null)
                {
                    return Results.NotFound();
                }
                return deletedNoteTag is not null ? Results.Ok(deletedNoteTag) : Results.NotFound();
            })
                .WithName("DeleteNoteTag")
                .WithOpenApi()
                .Produces<NoteTag>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status400BadRequest);
        }
    }
}
