## Ansi Fallback Program ##
This is a snipped of code I found to test for and adjust if ansi is not found on the console running the app.
Review the code, learn/understand it and make adjusments, then consider adding it to the application.

Code works as intended now my program needs to be adjusted becuase I return back colors codes as strings, thise write lines should send a string instead and return void.
Check a flag to see if ansi is on or not and then print accordingly, using console.Write and Console.Color.
