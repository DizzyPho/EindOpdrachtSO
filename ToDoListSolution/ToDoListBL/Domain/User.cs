using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListBL.Domain
{
    public class User
    {
        public User(int id, string firstName, string lastName, DateTime birthDate, string pictureURL)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            PictureURL = pictureURL;
        }
        public int Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime BirthDate { get; init; }
        public string PictureURL { get; init; }
    }
}
