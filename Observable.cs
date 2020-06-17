using System.ComponentModel;

namespace WorkLoops
{
    /// <summary>
    /// Base class for viewmodel derivation.
    /// </summary>
    public class Observable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
