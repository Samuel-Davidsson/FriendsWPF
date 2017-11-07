﻿using System.Threading.Tasks;
using FriendOrganizer.DataAccess;
using System.Data.Entity;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.Data.Repositories
{
    public class ProgrammingLanguageRepository : GenericRepository<ProgrammingLanguage, FriendOrganizerDbContext>, IProgrammingLanguageRepository
    {
        public ProgrammingLanguageRepository(FriendOrganizerDbContext context) : base(context)
        {
        }

        public async Task<bool> IsReferencedByFriendAsync(int programmingLanguageId)
        {
            return await Context.Friends.AsNoTracking().AnyAsync(f => f.FavoriteLanguageId == programmingLanguageId);
        }
    }
}
