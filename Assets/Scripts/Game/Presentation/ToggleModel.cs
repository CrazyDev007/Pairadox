namespace Models
{
    public class ToggleModel
    {
        public bool IsOn { get; private set; }

        public void Toggle()
        {
            IsOn = !IsOn;
        }
    }
}