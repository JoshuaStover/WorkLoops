using System.Threading.Tasks;
using System.Windows;
using WorkLoops.ViewModels;

namespace WorkLoops
{
    public partial class MainWindow : Window
    {
        MainViewModel _main = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _main;
        }

        private void WorkLengthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _main.TimerVM.WorkLength = (byte)WorkLengthSlider.Value;
        }

        private void ShortPerLongSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _main.TimerVM.ShortBreaksUntilLongBreak = (byte)ShortPerLongSlider.Value;
        }

        private void ShortBreakLengthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _main.TimerVM.ShortBreakLength = (byte)ShortBreakLengthSlider.Value;
        }

        private void LongBreakLengthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _main.TimerVM.LongBreakLength = (byte)LongBreakLengthSlider.Value;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(async() => 
            {
                await _main.TimerVM.Start();
            });
            DisableOptions();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(async() =>
            {
                await _main.TimerVM.Stop();
            });
            EnableOptions();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(async() =>
            {
                await _main.TimerVM.Stop();
                _main.TimerVM.WorkLength = 20;
                _main.TimerVM.ShortBreakLength = 5;
                _main.TimerVM.ShortBreaksUntilLongBreak = 2;
                _main.TimerVM.LongBreakLength = 10;
                _main.TimerVM.Progress = 0;
            });
            EnableOptions();
        }

        /// <summary>
        /// Creates a MessageBox containing a concise version of the documentation.
        /// </summary>
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Work Length: Length of working periods in minutes.\n\n" +
                "Short Break Length: Length of a short break in minutes.\n\n" +
                "Shorts Until Long: Number of short breaks before a long break.\n\n" +
                "Long Break Length: Length of a long break in minutes.\n\n" +
                "Start: Start the timer at the beginning of a new working period.\n\n" +
                "Stop: Stop the timer and reset progress.\n\n" +
                "Reset: Stop timer if started, then reset all sliders to default position.\n\n" +
                "Help: Open this dialog window.\n\n" +
                "Theme Menu: Choose a color scheme for the application.\n\n",
                "Help",
                MessageBoxButton.OK,
                MessageBoxImage.Question);
        }

        private void DarkGreenTheme_Click(object sender, RoutedEventArgs e)
        {
            _main.ThemeVM.SetDarkGreen();
            UncheckThemes();
            DarkGreenTheme.IsChecked = true;
        }

        private void LightGreenTheme_Click(object sender, RoutedEventArgs e)
        {
            _main.ThemeVM.SetLightGreen();
            UncheckThemes();
            LightGreenTheme.IsChecked = true;
        }

        private void DarkBlueTheme_Click(object sender, RoutedEventArgs e)
        {
            _main.ThemeVM.SetDarkBlue();
            UncheckThemes();
            DarkBlueTheme.IsChecked = true;
        }

        private void LightBlueTheme_Click(object sender, RoutedEventArgs e)
        {
            _main.ThemeVM.SetLightBlue();
            UncheckThemes();
            LightBlueTheme.IsChecked = true;
        }

        private void DarkTheme_Click(object sender, RoutedEventArgs e)
        {
            _main.ThemeVM.SetDark();
            UncheckThemes();
            DarkTheme.IsChecked = true;
        }

        private void LightTheme_Click(object sender, RoutedEventArgs e)
        {
            _main.ThemeVM.SetLight();
            UncheckThemes();
            LightTheme.IsChecked = true;
        }

        /// <summary>
        /// Removes any current check marks in the theme menu.
        /// </summary>
        private void UncheckThemes()
        {
            LightTheme.IsChecked = false;
            DarkTheme.IsChecked = false;
            LightBlueTheme.IsChecked = false;
            DarkBlueTheme.IsChecked = false;
            LightGreenTheme.IsChecked = false;
            DarkGreenTheme.IsChecked = false;
        }

        /// <summary>
        /// Disables UI options related to the operation of the LoopTimer.
        /// Prevents users from changing settings while the timer is running.
        /// </summary>
        private void DisableOptions()
        {
            StartButton.IsEnabled = false;
            WorkLengthSlider.IsEnabled = false;
            ShortBreakLengthSlider.IsEnabled = false;
            ShortPerLongSlider.IsEnabled = false;
            LongBreakLengthSlider.IsEnabled = false;
        }

        /// <summary>
        /// Enables UI options related to the operation of the LoopTimer.
        /// </summary>
        private void EnableOptions()
        {
            StartButton.IsEnabled = true;
            WorkLengthSlider.IsEnabled = true;
            ShortBreakLengthSlider.IsEnabled = true;
            ShortPerLongSlider.IsEnabled = true;
            LongBreakLengthSlider.IsEnabled = true;
        }
    }
}
