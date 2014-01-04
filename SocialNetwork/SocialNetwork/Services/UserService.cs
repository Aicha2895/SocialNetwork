using System;
using System.Linq;
using SocialNetwork.Entities;
using SocialNetworkDataAccess;

namespace SocialNetwork.Services
{
	public class UserService
	{
		private DataBaseEntities _context;

		public UserService()
		{
			_context = new DataBaseEntities();
		}

		public bool IsEmailUnique(string email)
		{
			return _context.Users.Any(u => u.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase)) == false;
		}

		public int Register(string email, string password, string name, string surname)
		{
			int userId = 0;

			if (_context.Users.Count() > 0)
			{
				userId = _context.Users.Max(u => u.Id);
			}

			User dbUser = new User()
				{
					Id = ++userId,
					Email = email,
					Name = name,
					Surname = surname,
					Password = password
				};

			_context.Users.AddObject(dbUser);
			_context.SaveChanges();

			return dbUser.Id;
		}

		public UserEntity Authentificate(string email, string password)
		{
			var user = new UserEntity() {Id = 0};

			User dbUser =
				_context.Users.FirstOrDefault(
					u => u.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase) && u.Password.Equals(password));

			if (dbUser != null)
			{
				user.Id = dbUser.Id;
				user.Name = dbUser.Name;
				user.Surname = dbUser.Surname;
				user.DateOfBirth = dbUser.DateOfBirth;
				user.Activities = dbUser.Activities;
				user.Description = dbUser.Description;
				user.PhoneNumbers = dbUser.PhoneNumbers;
			}

			return user;
		}

		public void UpdateUser(UserEntity user)
		{
			User dbUser =
				_context.Users.FirstOrDefault(
					u => u.Id == user.Id);

			if (dbUser != null)
			{
				dbUser.Name = user.Name;
				dbUser.Surname = user.Surname;
				dbUser.Activities = user.Activities;
				dbUser.Description = user.Description;
				dbUser.PhoneNumbers = user.PhoneNumbers;

				if (user.DateOfBirth != null)
				{
					dbUser.DateOfBirth = user.DateOfBirth;
				}
			}

			_context.SaveChanges();
		}

		public UserEntity GetUserById(int userId)
		{
			var user = new UserEntity() { Id = 0 };

			User dbUser =
				_context.Users.FirstOrDefault(u => u.Id == userId);

			if (dbUser != null)
			{
				user.Id = dbUser.Id;
				user.Name = dbUser.Name;
				user.Surname = dbUser.Surname;
				user.DateOfBirth = dbUser.DateOfBirth;
				user.Activities = dbUser.Activities;
				user.Description = dbUser.Description;
				user.PhoneNumbers = dbUser.PhoneNumbers;
			}

			return user;
		}
	}
}