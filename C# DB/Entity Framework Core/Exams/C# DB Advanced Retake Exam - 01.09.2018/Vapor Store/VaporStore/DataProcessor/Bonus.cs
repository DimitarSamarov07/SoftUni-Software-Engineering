namespace VaporStore.DataProcessor
{
	using System;
    using System.Linq;
    using Data;

	public static class Bonus
    {
        private const string InvalidUserMessage = "User {0} not found";
        private const string SuccessChangeOfEmailMessage = "Changed {0}'s email successfully";
        private const string TakenEmailMessage = "Email {0} is already taken";


		public static string UpdateEmail(VaporStoreDbContext context, string username, string newEmail)
        {
            var targetUser = context.Users.FirstOrDefault(x => x.Username == username);
            string result;

            if (targetUser != null)
            {
                var isTaken = context.Users.FirstOrDefault(x => x.Email == newEmail) != null;
                if (!isTaken)
                {
                    targetUser.Email = newEmail;
                    result = String.Format(SuccessChangeOfEmailMessage,username);
                    context.SaveChanges();
                }

                else
                {
                    result = String.Format(TakenEmailMessage,newEmail);
                }
            }

            else
            {
                result = String.Format(InvalidUserMessage,username);
            }

            return result;
        }
	}
}
