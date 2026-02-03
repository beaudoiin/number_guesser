## Updates
Play is now dont through Sound.Play(string Key) and some other paramaters. This allows me to simply call a sound, and not have to write a check for the object existing. (exceptions) for each time I play a sound in the main code flow.

       try{
           soundLibrary[Key].PlayInstance(vol, setLoop);
       }catch (ArgumentException)
       {
           valid = false;
           Console.ForegroundColor = ConsoleColor.Red;
           Console.Error.WriteLine("Wrong argument provided");
           Console.ResetColor();
       }
       catch (KeyNotFoundException) {
           valid = false;
           Console.ForegroundColor = ConsoleColor.Red;
           Console.Error.WriteLine("Sound not found in soundLibrary.");
           Console.ResetColor();
       }


# Implemented error message

 public static void WriteError(string message)
 {
     Console.ForegroundColor = ConsoleColor.Red;
     Console.Error.WriteLine(message);
     Console.ResetColor();
 }

 # Updated folder creation to be a bit more robust

 using

   try
  {
      DirectoryInfo save_folder = Directory.CreateTempSubdirectory("guessing");
      path = save_folder.FullName;
  }
