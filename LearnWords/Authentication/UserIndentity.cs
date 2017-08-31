using System;
using System.Linq;
using System.Security.Principal;
using LearnWords.Contexts;
using LearnWords.Exceptions.Authentication;
using LearnWords.Models;

namespace LearnWords.Authentication
{
    public class UserIndentity : IIdentity
    {
        public User User { get; set; }

        public string AuthenticationType => typeof(User).ToString();

        public bool IsAuthenticated => User != null;

        public Guid Id => User.UserId;

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.FullName;
                }
                //иначе аноним
                return "anonym";
            }
        }

        public void Init(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                using (var dbContext = new DBContext())
                {
                    User matchingObjects =
                        dbContext.Users.FirstOrDefault(x => x.UserId == new Guid(id));

                    if (matchingObjects == null)
                    {
                        throw new UserNotFoundException($"Not found user with id: {id}");
                    }

                    User = matchingObjects;
                }
            }
        }
    }
}