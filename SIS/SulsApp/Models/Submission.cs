using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SulsApp.Models
{
    public class Submission
    {
        public Submission()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public int AchievedResult { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public  virtual Problem Problem { get; set; }

        public  virtual User UserId { get; set; }

    }
}


//•	Has an Id – a string, Primary Key
//•	Has Code – a string with min length 30 and max length 800 (required)
//•	Has Achieved Result – an integer between 0 and 300 (required)
//•	Has a Created On – a DateTime object (required)
//•	Has Problem – a Problem object
//•	Has User – a User object
