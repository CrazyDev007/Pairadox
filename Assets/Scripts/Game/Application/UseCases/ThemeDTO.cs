namespace Game.Application.UseCases
{
    public class ThemeDto
    {
        public string Name { get; set; }
        public string BackgroundColor { get; set; }

        public ThemeDto(string name, string backgroundColor)
        {
            Name = name;
            BackgroundColor = backgroundColor;
        }
    }
}