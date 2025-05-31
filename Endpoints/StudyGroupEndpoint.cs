using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Models;

namespace ScriptureNotesBE.Endpoints
{
    public static class StudyGroupEndpoint
    {
        public static void MapStudyGroupEndpoints(this  IEndpointRouteBuilder routes)
        {
            var app = routes.MapGroup("/api").WithTags(nameof(StudyGroup));

            //---GET all study groups
            app.MapGet("/studygroups", async (IStudyGroupServices studyGroupServices) =>
            {
                return await studyGroupServices.GetStudyGroups();
            })
            .WithName("GetAllStudyGroups")
            .WithOpenApi()
            .Produces<List<StudyGroup>>(StatusCodes.Status200OK);

            //---GET study group by id
            app.MapGet("/studygroups/{id}", async (int id, IStudyGroupServices studyGroupServices) =>
            {
                var result = await studyGroupServices.GetStudyGroupById(id);
                return result is not null ? Results.Ok(result) : Results.NotFound();
            })
            .WithName("GetStudyGroupById")
            .WithOpenApi()
            .Produces<StudyGroup>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            //---POST study groups
            app.MapPost("/studygroups", async (IStudyGroupServices studyGroupServices, StudyGroup studyGroup) =>
            {
                var addedStudyGroup = await studyGroupServices.AddStudyGroup(studyGroup);
                return addedStudyGroup is not null ? Results.Created($"/api/studygroups/{addedStudyGroup.Id}", addedStudyGroup) : Results.BadRequest("Failed to add study group.");
            })
            .WithName("AddStudyGroup")
            .WithOpenApi()
            .Produces<StudyGroup>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

            //---PUT study groups
            app.MapPut("/studygroups/{id}", async (int id, IStudyGroupServices studyGroupServices, StudyGroup studyGroup) =>
            {
                var existingStudyGroup = await studyGroupServices.GetStudyGroupById(id);
                return existingStudyGroup is not null ? Results.Ok(await studyGroupServices.UpdateStudyGroup(id, studyGroup)) : Results.NotFound();
            })
            .WithName("UpdateStudyGroup")
            .WithOpenApi()
            .Produces<StudyGroup>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

            //---DELETE study groups
            app.MapDelete("/studygroups/{id}", async (int id, IStudyGroupServices studyGroupServices) =>
            {
                var deletedStudyGroup = await studyGroupServices.DeleteStudyGroup(id);
                return  Results.NoContent();
            })
            .WithName("DeleteStudyGroup")
            .WithOpenApi()
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
