using Microsoft.AspNetCore.SignalR;
using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Endpoints
{
    public static class TagEndpoint
    {
        public static void MapTagEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api").WithTags(nameof(Tag));

            //--GetTags --
            routes.MapGet("/tags", async (ITagServices tagServices) =>
            {
                return await tagServices.GetTags();
            })
            .WithName("GetAllTags")
            .WithOpenApi()
            .Produces<List<Tag>>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            //--GetTagById --
            routes.MapGet("/tags/{id}", async (int id, ITagServices tagServices) =>
            {
                return await tagServices.GetTagById(id);
                
            })
            .WithName("GetTagById")
            .WithOpenApi()
            .Produces<Tag>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            //--AddTag --
            routes.MapPost("/tags", async (Tag tag, ITagServices tagServices) =>
            {
                var addedTag = await tagServices.AddTag(tag);
                return addedTag != null ? Results.Created($"/tags/{addedTag.Id}", addedTag) : Results.BadRequest("Tag could not be added.");
            })
            .WithName("AddTag")
            .WithOpenApi()
            .Produces<Tag>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            //--UpdateTag --
            routes.MapPut("/tags/{id}", async (int id, Tag tag, ITagServices tagServices) =>
            {
                var existingTag = await tagServices.UpdateTag(id, tag);
                return Results.Ok(existingTag);
            })
            .WithName("UpdateTag")
            .WithOpenApi()
            .Produces<Tag>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            //--DeleteTag --
            routes.MapDelete("/tags/{id}", async (int id, ITagServices tagServices) =>
            {
                var deletedTag = await tagServices.DeleteTag(id);
                return Results.NoContent();
            })
            .WithName("DeleteTag")
            .WithOpenApi()
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
