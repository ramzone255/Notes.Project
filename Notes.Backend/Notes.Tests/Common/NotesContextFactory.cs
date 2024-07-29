using Microsoft.EntityFrameworkCore;
using Notes.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notes.Domain;

namespace Notes.Tests.Common
{
    public class NotesContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid NoteIdForDelete = Guid.NewGuid();
        public static Guid NoteIdForUpdate = Guid.NewGuid();

        public static NotesDbContext Create()
        {
            var options = new DbContextOptionsBuilder<NotesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new NotesDbContext(options);
            context.Database.EnsureCreated();
            context.Notes.AddRange(
                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "Details1",
                    Editdate = null,
                    Id = Guid.Parse("2E937A2D-FDB3-4FCA-BDB0-AA332B496C91"),
                    Title = "Title1",
                    UserId = UserAId
                },

                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "Details2",
                    Editdate = null,
                    Id = Guid.Parse("3A3A24C8-EF84-4A6D-8663-B311D888E6BF"),
                    Title = "Title2",
                    UserId = UserBId
                },

                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "Details3",
                    Editdate = null,
                    Id = NoteIdForDelete,
                    Title = "Title3",
                    UserId = UserAId
                },

                new Note
                {
                    CreationDate = DateTime.Today,
                    Details = "Details4",
                    Editdate = null,
                    Id = NoteIdForUpdate,
                    Title = "Title4",
                    UserId = UserBId
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(NotesDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
