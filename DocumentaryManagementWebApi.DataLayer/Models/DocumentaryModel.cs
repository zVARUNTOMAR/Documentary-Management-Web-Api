using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentaryManagementWebApi.DataLayer.Models
{
    public class DocumentaryModel
    {
        [Key]
        public int DocumentaryId { get; set; }

        [Required]
        //[Index("TitleIndex", IsUnique = true)]
        [MaxLength(50, ErrorMessage = "Invalid Name")]
        public string DocumentaryName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Invalid Genre")]
        public string DocumentaryGenre { get; set; }

        public ActorModel Actor { get; set; }

        [ForeignKey("ActorId")]
        public int ActorId { get; set; }
    }
}