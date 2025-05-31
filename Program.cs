using Microsoft.EntityFrameworkCore;
using ScriptureNotesBE.Interfaces;
using ScriptureNotesBE.Data;
using ScriptureNotesBE.Services;
using ScriptureNotesBE.Repositories;
using ScriptureNotesBE.Endpoints;       
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


// Add configuration to read from user secrets when in development
builder.Services.AddNpgsql<ScriptureNoteBEDbContext>(builder.Configuration["ScriptureNoteBEDbConnectionString"]);

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Add services to the container.
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ITagServices, TagServices>();
builder.Services.AddScoped<ITagRepository, TagRepository>();

builder.Services.AddScoped<IGroupMemberServices, GroupMemberServices>();
builder.Services.AddScoped<IGroupMemberRepository, GroupMemberRepository>();

builder.Services.AddScoped<INoteServices, NoteServices>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();

builder.Services.AddScoped<IStudyGroupServices, StudyGroupServices>();
builder.Services.AddScoped<IStudyGroupRepository, StudyGroupRepository>();

builder.Services.AddScoped<IScriptureServices, ScriptureServices>();
builder.Services.AddScoped<IScriptureRepository, ScriptureRepository>();

builder.Services.AddScoped<INoteTagServices, NoteTagServices>();
builder.Services.AddScoped<INoteTagRepository, NoteTagRepository>();

builder.Services.AddScoped<INoteScriptureServices, NoteScriptureServices>();
builder.Services.AddScoped<INoteScriptureRepository, NoteScriptureRepository>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.MapUserEndpoints();
app.MapTagEndpoints();
app.MapStudyGroupEndpoints();
app.MapNoteEndpoints();
app.MapScriptureEndpoints();
app.MapNoteTagEndpoints();
app.MapNoteScriptureEndpoints();
app.MapGroupMemberEndpoints();



app.Run();


