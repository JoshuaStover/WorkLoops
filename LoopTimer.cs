using System;
using System.Media;
using System.Timers;
using WorkLoops.ViewModels;

namespace WorkLoops
{
    class LoopTimer
    {
        private byte _workLength;
        private byte _shortBreakLength;
        private byte _longBreakLength;
        private byte _shortBreaksUntilLongBreak;
        private byte _shortBreaksTaken;

        private int _timeElapsedSeconds;
        private int _currentTaskLengthSeconds;
        private string _currentTaskString;
        private int _taskProgress;

        enum TaskName
        {
            Work,
            ShortBreak,
            LongBreak
        }
        private TaskName _currentTask;

        Timer clock;

        SoundPlayer Sound;

        /// <summary>
        /// Creates a LoopTimer from the properties of a TimerViewModel.
        /// </summary>
        /// <param name="tvm">
        /// TimerViewModel containing parameters set in the UI.
        /// </param>
        public LoopTimer(TimerViewModel tvm)
        {
            _workLength = tvm.WorkLength;
            _shortBreakLength = tvm.ShortBreakLength;
            _longBreakLength = tvm.LongBreakLength;
            _shortBreaksUntilLongBreak = tvm.ShortBreaksUntilLongBreak;

            _shortBreaksTaken = 0;

            _taskProgress = 0;

            _currentTaskString = tvm.CurrentTask;
        }

        public string GetTask()
        {
            return _currentTaskString;
        }

        public int GetProgress()
        {
            return _taskProgress;
        }

        public void SetCurrentTaskLength(byte CT)
        {
            _currentTaskLengthSeconds = CT * 60;
        }

        public void SetProgress()
        {
            _taskProgress = (_timeElapsedSeconds * 1000) / _currentTaskLengthSeconds;
        }

        /// <summary>
        /// Starts a new Timer if one deos not already exist,
        /// and starts the first "Work" task.
        /// </summary>
        public void Start()
        {
            if (clock != null) { clock.Dispose(); }
            clock = new System.Timers.Timer(1000);
            clock.Elapsed += Tick;
            clock.AutoReset = true;
            clock.Start();
            _currentTask = TaskName.Work;
            SetCurrentTaskLength(_workLength);
            _currentTaskString = "Work";
            _timeElapsedSeconds = 0;
            _shortBreaksTaken = 0;
        }

        /// <summary>
        /// Stops the current Timer and disposes of it,
        /// if the Timer has been initialized.
        /// </summary>
        public void Stop()
        {
            if (!Object.Equals(clock, null))
            {
                clock.Stop();
                clock.Dispose();
            }
            
        }

        private void Tick(Object source, ElapsedEventArgs e)
        {
            _timeElapsedSeconds++;
            CheckTaskComplete();
            SetProgress();
        }

        /// <summary>
        /// CheckTaskComplete manages the current task of the LoopTimer.
        /// When a task is completed,
        /// this function causes the appropriate sound to play.
        /// </summary>
        private void CheckTaskComplete()
        {
            if (_timeElapsedSeconds >= _currentTaskLengthSeconds)
            {
                switch (_currentTask)
                {
                    case TaskName.Work:
                        if (_shortBreaksTaken < _shortBreaksUntilLongBreak)
                        {
                            _currentTask = TaskName.ShortBreak;
                            SetCurrentTaskLength(_shortBreakLength);
                            _currentTaskString = "Short Break";
                            Sound = new SoundPlayer(Properties.Resources.workLoopComplete);
                        }
                        else
                        {
                            _currentTask = TaskName.LongBreak;
                            SetCurrentTaskLength(_longBreakLength);
                            _currentTaskString = "Long Break";
                            Sound = new SoundPlayer(Properties.Resources.workLoopComplete);
                        }
                        break;
                    case TaskName.ShortBreak:
                        _shortBreaksTaken++;
                        _currentTask = TaskName.Work;
                        SetCurrentTaskLength(_workLength);
                        _currentTaskString = "Work";
                        Sound = new SoundPlayer(Properties.Resources.breakOver);
                        break;
                    case TaskName.LongBreak:
                        _shortBreaksTaken = 0;
                        _currentTask = TaskName.Work;
                        SetCurrentTaskLength(_workLength);
                        _currentTaskString = "Work";
                        Sound = new SoundPlayer(Properties.Resources.breakOver);
                        break;
                }
                _timeElapsedSeconds = 0;
                Sound.Play();
            }
        }
    }
}