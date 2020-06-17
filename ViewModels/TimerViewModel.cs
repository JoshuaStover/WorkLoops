using System;
using System.Threading.Tasks;
using System.Timers;

namespace WorkLoops.ViewModels
{
    /// <summary>
    /// The TimerViewModel allows the UI and LoopTimer to communicate.
    /// The TimerViewModel uses attributes to communicate user input
    /// to the LoopTimer, and reports the LoopTimer's progress to the UI.
    /// </summary>
    public class TimerViewModel : Observable
    {
        private byte _workLength;
        private byte _shortBreakLength;
        private byte _longBreakLength;
        private byte _shortBreaksUntilLongBreak;

        private int _progress;

        private LoopTimer lt;

        private string _currentTask;

        /// <summary>
        /// The clock in the TimerViewModel is used to routinely sync
        /// the UI with the Looptimer.
        /// </summary>
        Timer clock;

        public byte WorkLength
        {
            get
            {
                return _workLength;
            }
            set
            {
                _workLength = value;
                OnPropertyChanged("WorkLength");
            }
        }

        public byte ShortBreakLength
        {
            get
            {
                return _shortBreakLength;
            }
            set
            {
                _shortBreakLength = value;
                OnPropertyChanged("ShortBreakLength");
            }
        }

        public byte LongBreakLength
        {
            get
            {
                return _longBreakLength;
            }
            set
            {
                _longBreakLength = value;
                OnPropertyChanged("LongBreakLength");
            }
        }

        public byte ShortBreaksUntilLongBreak
        {
            get
            {
                return _shortBreaksUntilLongBreak;
            }
            set
            {
                _shortBreaksUntilLongBreak = value;
                OnPropertyChanged("ShortBreaksUntilLongBreak");
            }
        }

        public string CurrentTask
        {
            get
            {
                if (string.IsNullOrEmpty(_currentTask))
                {
                    return "None";
                }

                return _currentTask;
            }
            set
            {
                _currentTask = value;
                OnPropertyChanged("CurrentTask");
            }
        }

        public int Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                _progress = value;
                OnPropertyChanged("Progress");
            }
        }

        /// <summary>
        /// Starts the TimerViewModel clock and the LoopTimer clock.
        /// Instantiates the LoopTimer with the TimerViewModel's attributes.
        /// </summary>
        public async Task Start()
        {
            clock = new Timer(100);
            clock.Elapsed += Sync;
            clock.AutoReset = true;
            clock.Start();
            await Task.Run(() =>
            {
                lt = new LoopTimer(this);
                lt.Start();
            });
            
        }

        /// <summary>
        /// Stops and disposes of the clock in the TimerViewModel and LoopTimer.
        /// Verifies that clock has been instantiated before attempting to dispose.
        /// </summary>
        public async Task Stop()
        {
            if (!Object.Equals(clock, null))
            {
                CurrentTask = "";
                Progress = 0;
                clock.Stop();
                clock.Dispose();
                await Task.Run(() =>
                {
                    lt.Stop();
                });
            }
        }

        /// <summary>
        /// Syncs information from the LoopTimer to the TimerViewModel.
        /// These changes are automatically communicated to the UI.
        /// </summary>
        private async void Sync(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                CurrentTask = lt.GetTask();
                Progress = lt.GetProgress();
            });
        }
    }
}
