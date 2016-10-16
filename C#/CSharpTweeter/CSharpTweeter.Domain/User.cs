using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTweeter.Domain
{
    public class User
    {
        public User()
        {
            Followers = new List<User>();
        }
        public string Name { get; set; }
        public List<User> Followers { get; set; }



        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            return Name.Equals(((User)obj).Name);
        }
    }
}
