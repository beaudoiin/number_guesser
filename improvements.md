## Required improvements ##

## Language and messages
* Provide language support by loading external documents, or embeded arrays with strings of each test that would be printed out (apart from variables ofcourse)
* Laungauges have different syntax, so temportary variables need to mark the place. VAR1, VAR2 inside the string. Use literal text @"your name is {tmp_name}", use naming convetion that may not conflict with various scopes. prefex is a good idea.
* Consider markup language such as Yaml, or JSON.

## General
* Name spaces into one for Audio Engine for reuse and one for the main program
* Give version number to exe file and version number on the splash screen and in the Program Class comment to help link what is being run

## Display
* When a player wins or loses, the word Win/Lose with player name needs to be displayed
* Improve clarity when user makes a guess and updates the screen as previous guess. Some people might not think their guess went through, consider alternating colors when turn changes.
* Avatar ansi pictures should have a tab to keep it away from the edge of the screen.
* All text displayed whould have a single white space on a new line to pad from the top
* Consider always printing one blank line above the header when header is printed for padding.

## Game Play
* Keep track of wins and looses in multiplayer so users can see how got the best.
* Increase to a higher level such as numbers up to 1000
* Improve hint modes to provide more intersting moments
* consider removing liar mode based on user feedback
* single Player give the user points, and allow them to unlock a special souind byte based on their points (may be a dumb idea)
  
## Logic
* Files need to be cleaned up on terminate if using base64 temp folder, as base 64 is persistant
* Review exceptions and null value possabilities
* review permissions of methods and values to prevent reading where it shouldnt be read. this will prevent bad progaramming practices when implimenting methods. Especially important for SoundEngine.

## Sound
* Imrpove sound bytes and character profiles to have better/funner options. (no more then maybe 6)

## Menu System
* Options should include turning on and off specific sound such as musc, vs gui sfx, vs regular sounds bytes.
* Options should allow user to use left and right arrow key instead of enter
* Option to remove lying bot givng fake hints
* Consider allowing the menu to be a longer list with a limit of 5, top 2 and and bottom 2 will be semi transparent, ie blend the background color and font color for new color.
  Consider formatting, this is just a guideline
  This should allow of the menu to cycle around like a roller index, thus if we have a menu with 20 things it will be esier to see them all.
* Consider a max options allowed in a row, then introduce new formatted row that checks the string length of the first menu, and places specific characrs over by adding the extra tabs or whitespace.
  This allows for it to look like a grid or side by side list. Selector now should have the feature to go up, and, left and right, enter allows editing, enter allows accept. (Maybe just using down arrows and cycling throgh is enough)
  

## Sound Engine 
* Sound Engine needs a total rework
* Sound Engine needs to have clearly defined classes
* ISampleProvider should not be controling the Logical Flow of Pause, Stop, Loop
* Assets should be registered into a specific class as objects
* Fade needs to be updated as there is a provided fade in and out option

## Documentation
* Add comments to specific logical junctions or where needed, and <summary> to all methods and classes.
* Consider writing to a log file if issues come up so the user can view what went wrong

## Persistance
* Consider storing user data in file, such as win history and such. SqlLite may be used but super bloated for the need. simple text file is good. Practic eencoding the string so that its  harder to edit. Practice.
