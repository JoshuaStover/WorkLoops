namespace WorkLoops.ViewModels
{
    /// <summary>
    /// The MainViewModel class simplifies viewmodel access by the UI code.
    /// Though there are only two viewmodels in this case,
    /// if more are added they can be instantiated here.
    /// </summary>
    class MainViewModel
    {
        public ThemeViewModel ThemeVM { get; private set; }
        public TimerViewModel TimerVM { get; private set; }

        public MainViewModel()
        {
            ThemeVM = new ThemeViewModel();
            TimerVM = new TimerViewModel();
        }
    }
}
