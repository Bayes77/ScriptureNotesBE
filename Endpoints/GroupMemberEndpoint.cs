using Microsoft.AspNetCore.SignalR;
using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;


namespace ScriptureNotesBE.Endpoints
{
    public static class GroupMemberEndpoint
    {
        public static void MapGroupMemberEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api").WithTags(nameof(GroupMember));

            //---GetGroupMembers---
            group.MapGet("/groupMembers", async (IGroupMemberServices groupMemberServices) =>
            {
                return await groupMemberServices.GetGroupMembers();
            })
            .WithName("GetAllGroupMembers")
            .WithOpenApi()
            .Produces<List<GroupMember>>(StatusCodes.Status200OK);

            //---GetGroupMemberById---
            group.MapGet("/groupmembers/{id}", async (int id, IGroupMemberServices groupMemberServices) =>
            {
                var result = await groupMemberServices.GetGroupMemberById(id);
                return result is not null ? Results.Ok(result) : Results.NotFound();
            })
            .WithName("GetGroupMemberById")
            .WithOpenApi()
            .Produces<GroupMember>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            //---AddGroupMember---
            group.MapPost("/groupmembers", async (GroupMember groupMember, IGroupMemberServices groupMemberServices) =>
            {
                var addedGroupMember = await groupMemberServices.AddGroupMember(groupMember);
                return addedGroupMember is not null ? Results.Created($"/groupmembers/{addedGroupMember.Id}", addedGroupMember) : Results.BadRequest();
            })
            .WithName("AddGroupMember")
            .WithOpenApi()
            .Produces<GroupMember>(StatusCodes.Status201Created);

            //---UpdateGroupMember---
            group.MapPut("/groupmembers/{id}", async (int id, GroupMember groupMember, IGroupMemberServices groupMemberServices) =>
            {
                var existingGroupMember = await groupMemberServices.UpdateGroupMember(id, groupMember);
                return await groupMemberServices.UpdateGroupMember(id, groupMember);
            })
            .WithName("UpdateGroupMember")
            .WithOpenApi()
            .Produces<GroupMember>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            //---DeleteGroupMember---
            group.MapDelete("/groupmembers/{id}", async (int id, IGroupMemberServices groupMemberServices) =>
            {
                var deletedGroupMember = await groupMemberServices.DeleteGroupMember(id);
                return Results.NotFound();
            })
            .WithName("DeleteGroupMember")
            .WithOpenApi()
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
