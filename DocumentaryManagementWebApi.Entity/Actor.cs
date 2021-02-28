using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DocumentaryManagementWebApi.Entity
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }

        [MaxLength(50, ErrorMessage = "Invalid Name")]
        public string ActorName { get; set; }

        [Range(15, 80)]
        public int ActorAge { get; set; }

        [MaxLength(6, ErrorMessage = "InvalidGender")]
        public string ActorGender { get; set; }

        public DateTime ActorDateOfBirth { get; set; }
    }
}
