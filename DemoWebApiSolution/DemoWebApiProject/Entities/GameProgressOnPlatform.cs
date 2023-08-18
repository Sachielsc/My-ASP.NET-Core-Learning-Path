using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoWebApiProject.Entities
{
    public class GameProgressOnPlatform
    {
        private readonly IEnumerable<string> _validPlatformValues = new HashSet<string> {
            "PC",
            "PS4",
            "PS5",
            "XBOX",
            "Nintendo Switch",
            "Other Platform"
        };

        private readonly IEnumerable<string> _mouseSpeeds = new HashSet<string> {
            "1",
            "2",
            "3",
            "4",
            "5"
        };

        private string platform = "Undecided Platform";
        private string recommendedMouseSpeed = "Undecided mouse speed";

        [Required]
        [MaxLength(50)]
        // The enumerable property
        public string Platform
        {
            get { return platform; }
            set
            {
                if (_validPlatformValues.Contains(value))
                {
                    platform = value;
                }
                else
                {
                    throw new ArgumentException(value + " is an Invalid value for Platform. ");
                }
            }
        }

        public string RecommendedMouseSpeed
        {
            get { return recommendedMouseSpeed; }
            set
            {
                if (_mouseSpeeds.Contains(value))
                {
                    recommendedMouseSpeed = value;
                }
                else
                {
                    throw new ArgumentException(value + " is an Invalid value for recommended mouse speed. ");
                }
            }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameProgressOnThisPlatformId { get; set; }

        public string? ProgressOnThisPlatform { get; set; }
        public string? BugsAndIssues { get; set; }

        [ForeignKey("GameId")]
        public GameProgress? GameProgress { get; set; }
        public int GameId { get; set; }
    }
}
