namespace Game.Domain.Entities
{
    public class Theme
    {
        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }

        public Theme(string name, string backgroundColor, string textColor)
        {
            Name = name;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
        }
    }
}