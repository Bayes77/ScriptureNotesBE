using ScriptureNotesBE.Models;
using Microsoft.EntityFrameworkCore;

namespace ScriptureNotesBE.Data
{
    public class ScriptureNoteBEDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<NoteTag> NoteTags { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<StudyGroup> StudyGroups { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Scripture> Scriptures { get; set; }
        public DbSet<NoteScripture> NoteScriptures { get; set; }

        public ScriptureNoteBEDbContext(DbContextOptions<ScriptureNoteBEDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Notes)
                .WithOne(n => n.User)
                .HasForeignKey(n => n.UserId); // Fixed property name to match convention  

            modelBuilder.Entity<User>()
                .HasMany(u => u.GroupMembers)
                .WithOne(gm => gm.User)
                .HasForeignKey(gm => gm.UserId);

            modelBuilder.Entity<Note>()
                .HasMany(n => n.NoteTags)
                .WithOne(nt => nt.Note)
                .HasForeignKey(nt => nt.NoteId);

            modelBuilder.Entity<StudyGroup>()
                .HasMany(sg => sg.GroupMembers)
                .WithOne(gm => gm.StudyGroup)
                .HasForeignKey(gm => gm.GroupId);

            modelBuilder.Entity<NoteScripture>()
                .HasKey(ns => new { ns.NoteId, ns.ScriptureId });

            modelBuilder.Entity<NoteTag>().HasData(NoteTagData.NoteTags);
            modelBuilder.Entity<User>().HasData(UserData.Users);
            modelBuilder.Entity<Note>().HasData(NoteData.Notes);
            modelBuilder.Entity<StudyGroup>().HasData(StudyGroupData.StudyGroups);
            modelBuilder.Entity<GroupMember>().HasData(GroupMemberData.GroupMembers);
            modelBuilder.Entity<Tag>().HasData(TagData.Tags);
            modelBuilder.Entity<Scripture>().HasData(ScriptureData.Scriptures);
            modelBuilder.Entity<NoteScripture>().HasData(NoteScriptureData.NoteScriptures);
        }
    }
}
