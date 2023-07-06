namespace DemoWebApiProject.Models
{
    public class GameProgressOnPlatformDto
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

        public int? Id { get; set; }
        public string? ProgressOnThisPlatform { get; set; }
        public string? BugsAndIssues { get; set; }
    }
}
