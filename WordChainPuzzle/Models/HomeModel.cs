namespace WordChainPuzzle.Models
{
    public class HomeModel
    {
        public HomeModel()
        {
            
        }

        [System.ComponentModel.DataAnnotations.Required]
        public string FirstWord { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string SecondWord { get; set; }
    }
}
