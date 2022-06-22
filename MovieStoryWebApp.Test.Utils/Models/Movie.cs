namespace MovieStoryWebApp.Test.Utils.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Movie")]
    public partial class Movie
    {
        public int ID { get; set; }

        [Required]
        [StringLength(60)]
        public string Title { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        public decimal Price { get; set; }

        [Required]
        [StringLength(5)]
        public string Rating { get; set; }
    }
}
