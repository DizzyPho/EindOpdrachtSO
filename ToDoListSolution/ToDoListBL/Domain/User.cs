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

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PictureURL { get; set; }

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
