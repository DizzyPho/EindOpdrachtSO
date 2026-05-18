using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ToDoListBL.Domain
{
    public class User
    {
        public User(string firstName, string lastName, DateTime birthDate, string pictureURL, string id = null)
        {

            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            PictureURL = pictureURL;
            if (id != null)
            {
                Id = id;
            }
            else
            {
                Id = Guid.NewGuid().ToString();
            }
        }

        public string Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime BirthDate { get; init; }
        public string PictureURL { get; init; }

        // method from https://stackoverflow.com/questions/4127363/date-difference-in-years-using-c-sharp
        public int GetAge()
        {
            DateTime now = DateTime.Now;
            return (now.Year - BirthDate.Year - 1) +
                    (((now.Month > BirthDate.Month) ||
                    ((now.Month == BirthDate.Month) && (now.Day >= BirthDate.Day))) ? 1 : 0);
        }
    }
}
