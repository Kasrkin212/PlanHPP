using System;
using System.Collections.Generic;
using System.Text;

namespace PlanHPP.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
    }
}
