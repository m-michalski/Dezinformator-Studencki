namespace Dezinformator
{
        public class Question
        {
            public required string Q_Key { get; set; }
            public required string[] Q_Text { get; set; }
            public string[][]? Answers { get; set; }
        }
}
