## Required improvements ##
  ## General
* Name spaces into one for Audio Engine for reuse and one for the main program

  ## Display
* When a player wins or loses, the word Win/Lose with player name needs to be displayed
* Improve clarity when user makes a guess and updates the screen as previous guess. Some people might not think their guess went through, consider alternating colors when turn changes.
* Avatar ansi pictures should have a tab to keep it away from the edge of the screen.
* All text displayed whould have a single white space on a new line to pad from the top
* Consider always printing one blank line above the header when header is printed for padding.

  ## Logic
* Files need to be cleaned up on terminate if using base64 temp folder, as base 64 is persistant
* Review exceptions and null value possabilities

  ## Sound
* Imrpove sound bytes and character profiles to have better/funner options. (no more then maybe 6)

  ## Menu System
* Options should include turning on and off specific sound such as musc, vs gui sfx, vs regular sounds bytes.
* Options should allow user to use left and right arrow key instead of enter

  ## Sound Engine 
* Sound Engine needs a total rework
* Sound Engine needs to have clearly defined classes
* ISampleProvider should not be controling the Logical Flow of Pause, Stop, Loop
* Assets should be registered into a specific class as objects
* Fade needs to be updated as there is a provided fade in and out option

 ## Documentation
 * Add comments to specific logical junctions or where needed, and <summary> to all methods and classes.
 * Consider writing to a log file if issues come up so the user can view what went wrong
