

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

## Resources

### Links
- [ERD](https://dbdiagram.io/d/ScriptureNote-682497705b2fc4582f94eab5)
- [API Documentation (Postman)](https://documenter.getpostman.com/view/36648839/2sB2qgddX8)
- [Wireframe](https://drive.google.com/file/d/1k1fZ8dRZyu3xdijEwmtQWR5XgzyNC6-k/view?usp=sharing)
- [Presentation Slides](https://docs.google.com/presentation/d/19hGiCwdwRwy3KQjgZlP4u0YeiR3gj8JLdu7pvCc30jo/edit?usp=sharing)

### Loom Video
- [Project Walkthrough (Loom Artifacts and Unit Testing)](https://www.loom.com/share/f503b73b646c4a1d9b1c97fed2d96f5a?sid=a3778ea2-f700-4fc1-be65-6ea40817fa33)
- [Project Walkthrough (Loom Postman Calls)](https://www.loom.com/share/46fd3610ef06475c9d16287b1fa865d1?sid=92e58c54-09e9-4727-a4ec-4e7804957551)

---

## License

This project is licensed under the MIT License.

---

**Contributions and feedback are welcome!**
