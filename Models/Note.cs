﻿namespace ScriptureNotesBE.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Uid { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public User? User { get; set; }
        public List<NoteTag>? NoteTags { get; set; }
    }
}
