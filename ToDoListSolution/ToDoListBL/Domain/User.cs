using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ToDoListBL.Domain
{
    public class User
    {
        public User(string id, string firstName, string lastName, DateTime birthDate, string pictureURL)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            PictureURL = pictureURL;
        }
        public User(string firstName, string lastName, DateTime birthDate, string pictureURL) 
            : this(Guid.NewGuid().ToString(), firstName, lastName, birthDate, pictureURL) { }

        public string Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime BirthDate { get; init; }
        public string PictureURL { get; init; }

        // method from https://stackoverflow.com/questions/4127363/date-difference-in-years-using-c-sharp
        public int GetAge()
        {
            DateTime now = DateTime.Now;
            return (BirthDate.Year - now.Year - 1) +
                    (((BirthDate.Month > now.Month) ||
                    ((BirthDate.Month == now.Month) && (BirthDate.Day >= now.Day))) ? 1 : 0);
        }
    }
}
