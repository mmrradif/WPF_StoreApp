using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApp.Models
{
    public class Employee
    {
        private string department;
        private string designation;
        private int id ;
        private string title;
        private string lastName;
        private string email;
        private string contact;
        private string json;

        public string Department { get => department; set => department = value; }
        public string Designation { get => designation; set => designation = value; }
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string FirstName { get; set; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Contact { get => contact; set => contact = value; }
        public string Json { get => json; set => json = value; }
    }
}
