

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SulsApp.Models
{
    public class Problem
    {

        public Problem()
        {
            this.Id = Guid.NewGuid().ToString();
        }




        [Key]
        public string Id { get; set; }

        [MaxLength(20),Required]
        public string Name { get; set; }

        [Required]
        public int Points { get; set; }

        public virtual ICollection <Submission> Submissions { get; set; }= new HashSet<Submission>();

    }
}


//•	Has an Id – a string, Primary Key
//•	Has a Name – a string with min length 5 and max length 20 (required)
//•	Has Points– an integer between 50 and 300 (required)
