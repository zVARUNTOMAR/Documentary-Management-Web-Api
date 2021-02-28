using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DocumentaryManagementWebApi.Entity
{
    public class Documentary 
    {
        [Key]
        public int DocumentaryId { get; set; }

        [MaxLength(50, ErrorMessage = "Invalid Name")]
        public string DocumentaryName { get; set; }

        [MaxLength(50, ErrorMessage = "Invalid Genre")]
        public string DocumentaryGenre { get; set; }

        public Actor actor { get; set; }

        [ForeignKey("ActorId")]
        public int ActorId { get; set; }
    }
}
