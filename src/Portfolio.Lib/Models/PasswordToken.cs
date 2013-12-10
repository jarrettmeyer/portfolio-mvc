using System;

namespace Portfolio.Lib.Models
{
    public class PasswordToken
    {
        /// <summary>
        /// A unique token to be given out when the user forgets his or her password.
        /// </summary>
        public virtual string Token { get; set; }

        /// <summary>
        /// The user for the token. This is referenced through the [username] column
        /// in the database.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// When the password token is scheduled to expire.
        /// </summary>
        public virtual DateTime ExpiresAt { get; set; }

        /// <summary>
        /// When the password token was created.
        /// </summary>
        public virtual DateTime CreatedAt { get; set; }

        /// <summary>
        /// Factory method to create a new password token for the given user.
        /// </summary>
        public static PasswordToken GenerateForUser(User user)
        {
            DateTime dateTime = DateTime.UtcNow;

            return new PasswordToken
            {
                Token = Guid.NewGuid().ToString("N"),
                User = user,
                ExpiresAt = dateTime.AddHours(1),
                CreatedAt = dateTime
            };
        }
    }
}
