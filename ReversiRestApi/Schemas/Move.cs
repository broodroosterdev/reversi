using System.ComponentModel.DataAnnotations;

namespace ReversiRestApi.schemas
{
    public class Move
    {
        [Required]
        public string GameToken;
        [Required]
        public string PlayerToken;
        [Required]
        public bool Pass;
        public int? Row;
        public int? Col;
    }
}