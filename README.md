# ScriptureNotesBE

# ScriptureNotesBE

ScriptureNotesBE is a .NET 8 Web API backend for managing scripture notes, study groups, tags, and related entities. It is designed to support applications that allow users to create, organize, and share notes on scriptures, collaborate in groups, and tag content for easy retrieval.

## Features

- User registration and management
- Note creation, editing, and deletion
- Tagging of notes
- Study group management and group membership
- Scripture management and association with notes
- RESTful API endpoints for all major entities
- Entity Framework Core with PostgreSQL support
- Data seeding for development/testing

## Technologies

- .NET 8
- ASP.NET Core Minimal APIs
- Entity Framework Core
- PostgreSQL (via Npgsql)
- Swagger/OpenAPI for API documentation

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- (Optional) [Visual Studio 2022](https://visualstudio.microsoft.com/)

### Setup

1. **Clone the repository:**
   
2. **Configure the database connection:**
   - Set the `ScriptureNoteBEDbConnectionString` in `appsettings.json` or user secrets.
   - Example:
     
3. **Apply migrations and seed the database:**
   
4. **Run the application:**
   
5. **Access the API documentation:**
   - Navigate to `https://localhost:<port>/swagger` in your browser.

## API Overview

The API exposes endpoints for the following resources:

- **Users**: `/api/users`
- **Notes**: `/api/notes`
- **Tags**: `/api/tags`
- **Study Groups**: `/api/studygroups`
- **Group Members**: `/api/groupmembers`
- **Scriptures**: `/api/scriptures`
- **NoteTags**: `/api/notetags`
- **NoteScriptures**: `/api/notescriptures`

Each resource supports standard CRUD operations. See the Swagger UI for detailed request/response formats.

## Project Structure

- `Models/` - Entity classes (User, Note, Tag, etc.)
- `Data/` - Database context and seed data
- `Endpoints/` - Minimal API endpoint definitions
- `Services/` - Business logic services
- `Repositories/` - Data access layer
- `Interfaces/` - Service and repository interfaces

## Development

- To add new endpoints, update the corresponding endpoint class in `Endpoints/`.
- To seed new data, modify the relevant file in `Data/`.
- For business logic, use the `Services/` layer.

## License

This project is licensed under the MIT License.

---

**Contributions and feedback are welcome!**
