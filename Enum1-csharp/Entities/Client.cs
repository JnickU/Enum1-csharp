using System;

namespace Enum1_csharp.Entities {
    class Client {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        Client() {

        }

        public Client(string name, string email, DateTime birthDate) {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }
    }
}
