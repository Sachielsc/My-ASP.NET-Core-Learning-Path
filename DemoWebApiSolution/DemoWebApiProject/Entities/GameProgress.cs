using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoWebApiProject.Entities
{
    public class GameProgress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        public string? ChineseName { get; set; }
        public string? EnglishName { get; set; }
        public string? Description { get; set; }
        
        [Required]
        public int Year { get; set; }
        public ICollection<GameProgressOnPlatform> GameProgressOnPlatforms { get; set; } = new List<GameProgressOnPlatform>();

    }
}
