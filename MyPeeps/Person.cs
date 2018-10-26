using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPeeps
{
    class Person
    {
        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string EmailAddress { get; set; }
        protected bool _isAnAdult;
        public static List<Person> adults = new List<Person>();
        #endregion

        #region Constructor
        public Person(string firstName, string lastName, string emailAddress, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Age = age;
        }
        #endregion

        #region Methods
        public bool IsAnAdult(int Age)
        {
            if (Age >= 18)
            {
                return _isAnAdult = true;
            }
            else
            {
                return false;
            }
        }

        public void AddToList(string FirstName, string LastName, string EmailAddress, int Age)
        {
            IsAnAdult(Age);

            if (_isAnAdult)
            {
                adults.Add(this);
                Console.WriteLine($"{this.FirstName} {this.LastName} was successfully added to the list.");
            }
            else
            {
                Console.WriteLine("Person must be over 18 years old to be added to the list.");
            }
        }

        public static void ViewList(List<Person> adults)
        {
            foreach (var person in adults)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}'s email is {person.EmailAddress} and they are {person.Age} years old.");
            }
        }
        #endregion
    }
}
