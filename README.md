# WorkLoops
WorkLoops is a productivity tool that aims to help with time management. Users can set the length of working periods, short breaks, and long breaks, and customize the frequency of their breaks.
- - -
## Current Features
### Basic Functions
With the application open, you can use sliders to change the length of working periods, the length of short breaks, the length of long breaks, and the number of short breaks that happen before a long break. As an example, if work length is set to 40 minutes, short breaks are 10 minutes, long breaks are 20 minutes, and shorts until long is set to 2, the resulting pattern is: 40 minutes of work, 10 minute break, 40 minutes of work, 10 minute break, 40 minutes of work, 20 minute break. This will repeat until the stop or reset button is pressed. The progress bar shows both the name of the current task and the progress of that task.

### Sound Effects
At the end of a working period or end of a break a sound effect is played to alert the user of the change in state. Sound effects were created using LMMS.

### Themes
The theme menu lets users choose a color scheme from a list. The theme can be changed at any time, including during active loops, but will default to the standard light theme.
- - - 
## Implementation
This application was created in Visual Studio with C# and WPF, using the MVVM pattern.
- - - 
## Roadmap
### Website Blocking
User-created list of websites can be blocked when application is in a working state.
### Android Version
Android version of current application.
### Theme Editor
User defined color schemes in addition to the predefined list.
- - -
## License
[MPL2](https://choosealicense.com/licenses/mpl-2.0/)
