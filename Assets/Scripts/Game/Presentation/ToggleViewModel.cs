using Game.Presentation.Views;
using Models;

namespace Game.Presentation
{
    public class ToggleViewModel
    {
        private ToggleModel _toggleModel;
        private IToggleView _toggleView;

        public ToggleViewModel(ToggleModel toggleModel, IToggleView toggleView)
        {
            _toggleModel = toggleModel;
            _toggleView = toggleView;
            //
            toggleView.SetToggleAction(OnToggleChanged);
        }

        private void OnToggleChanged()
        {
            _toggleModel.Toggle();
        }
    }
}