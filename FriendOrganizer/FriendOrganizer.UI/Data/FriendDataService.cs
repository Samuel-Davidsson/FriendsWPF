using FriendOrganizer.Model;
using System.Collections.Generic;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        public IEnumerable<Friend> GetAll()
        {
            //ToDo: Load data from database.
            yield return new Friend { FirstName = "Kenopp", LastName = "Alic" };
            yield return new Friend { FirstName = "Jacob", LastName = "Gan" };
            yield return new Friend { FirstName = "Jacob", LastName = "Demo" };
            yield return new Friend { FirstName = "Samwise", LastName = "Gamgi" };
        }
    }
}
