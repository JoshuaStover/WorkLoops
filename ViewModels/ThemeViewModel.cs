using System.Windows.Media;

namespace WorkLoops.ViewModels
{
    /// <summary>
    /// The ThemeViewModel manages visual themes.
    /// This class helps to de-clutter the other UI code.
    /// </summary>
    public class ThemeViewModel : Observable
    {
        private Brush _bgColor;
        private Brush _fontColor;
        private Brush _lightText = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        private Brush _darkText = new SolidColorBrush(Color.FromRgb(200, 200, 200));
        private Brush _lightBlueText = new SolidColorBrush(Color.FromRgb(14, 14, 10));
        private Brush _darkBlueText = new SolidColorBrush(Color.FromRgb(220, 220, 200));
        private Brush _lightGreenText = new SolidColorBrush(Color.FromRgb(14, 10, 14));
        private Brush _darkGreenText = new SolidColorBrush(Color.FromRgb(220, 210, 220));
        private Brush _lightBackground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        private Brush _darkBackground = new SolidColorBrush(Color.FromRgb(15, 13, 15));
        private Brush _lightBlueBackground = new SolidColorBrush(Color.FromRgb(230, 230, 255));
        private Brush _darkBlueBackground = new SolidColorBrush(Color.FromRgb(20, 20, 40));
        private Brush _lightGreenBackground = new SolidColorBrush(Color.FromRgb(230, 255, 230));
        private Brush _darkGreenBackground = new SolidColorBrush(Color.FromRgb(20, 40, 20));

        public Brush BGColor
        {
            get
            {
                if (_bgColor == null)
                {
                    return _lightBackground;
                }

                return _bgColor;
            }

            set
            {
                _bgColor = value;
                OnPropertyChanged("BGColor");
            }
        }

        public Brush FontColor
        {
            get
            {
                if (_fontColor == null)
                {
                    return _lightText;
                }

                return _fontColor;
            }

            set
            {
                _fontColor = value;
                OnPropertyChanged("FontColor");
            }
        }

        public void SetLight()
        {
            BGColor = _lightBackground;
            FontColor = _lightText;
        }

        public void SetDark()
        {
            BGColor = _darkBackground;
            FontColor = _darkText;
        }

        public void SetLightBlue()
        {
            BGColor = _lightBlueBackground;
            FontColor = _lightBlueText;
        }

        public void SetDarkBlue()
        {
            BGColor = _darkBlueBackground;
            FontColor = _darkBlueText;
        }

        public void SetLightGreen()
        {
            BGColor = _lightGreenBackground;
            FontColor = _lightGreenText;
        }

        public void SetDarkGreen()
        {
            BGColor = _darkGreenBackground;
            FontColor = _darkGreenText;
        }
    }
}
