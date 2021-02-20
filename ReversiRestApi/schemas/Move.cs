namespace ReversiRestApi.schemas
{
    public class Move
    {
        public string GameToken;
        public string PlayerToken;
        public bool Pass;
        public int? Row;
        public int? Col;
    }
}