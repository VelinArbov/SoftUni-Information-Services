
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SIS.MVCFramework;

namespace SulsApp.Models
{
    public class User: IdentityUser<string>
    {
        public User() 
        {
            this.Id = Guid.NewGuid().ToString();
        }
 

        public virtual ICollection<Submission> Submissions { get; set; } = new HashSet<Submission>();


    }
}
//•	Has a Username – a string with min length 5 and max length 20 (required)
//•	Has an Email - a string, which holds only valid email(required)
//•	Has a Password – a string with min length 6 and max length 20  - hashed in the database(required)
