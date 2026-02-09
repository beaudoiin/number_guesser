namespace Week4
{

    internal class Program
    {

        public static string? CpuName;
        public static Dictionary<string, string[]> cpu_outputs = new(){
                {"Title", new string[]{"Mr.", "Ms.", "Mrs.", "Miss", "Dr.", "Prof.", "Sir", "Dame", "Lord", "Lady", "Rev.", "Fr.", "Sr.", "Br.", "Capt.", "Cmdr.", "Maj.", "Col.", "Gen.", "Adm.", "Chief", "Officer", "Inspector", "Detective", "Coach", "Boss", "Master", "Mistress", "Hon.", "Justice", "Chancellor", "Dean", "Principal", "Director", "President"}},
                {"Name", new string[]{ "Zibble", "Bob", "Sir. Xylo", "Dr. Snork", "Pibble", "Rex", "Wormsley", "Fizz", "Clomp", "Agnes", "Bort", "Zanadoo", "Plink", "Mort", "Greeble", "Tonk", "Elspeth", "Wub", "Crank", "Nigel", "Florp", "Dazzle", "Kevin", "Yorp", "Blanche", "Skree", "Ponk", "Edna", "Zog", "Myrtle", "Blip", "Harold", "Quibble", "Snazz", "Otis", "Bloop", "Frangle", "Sue", "Krag", "Niblet", "Waldo", "Zippy", "Gertrude", "Plorf", "Chet", "Bumbles", "Yvette", "Glonk", "Percy", "Spindle", "Bobette", "Zazz", "Hector", "Flim", "Norbert", "Pogo", "Ethel", "Crimbus", "Dex", "Loopy", "Agatha", "Snibble", "Rufus", "Wonk", "Beatrice", "Zimble", "Carl", "Froop", "Gladys", "Quirk", "Alfred", "Skloop", "Doris", "Bing", "Yarnell", "Phlump", "Mabel", "Twerp", "Ernie", "Zonk", "Winifred", "Plumbus", "Stan", "Gonk", "Helga", "Piff", "Walter", "Zoodle", "Irene", "Blort", "Lenny" } },
                {"Guess_text", new string[]{ "Ah I got it! The number", "Arlight lets just pick the familiar number,", "Well your not making this esier, but i'll have to say", "Wow, well it must be", "It couldn't possibly be", "Closing my circuits, and i'm going to guess", "Re-evaluating probability matrix… .. It's probably", "This is taking longer than expected… I guess", "I’m running simulations… the answer has plotted to", "Circuits warming up… almost there… the temperature in Celcius (my guess)", "Confidence dropping… tentative guess,", "The first number that pops into my transisters is", "Eh… hold on… hold on… this ain’t addin’ up… if I didnt already guess, let me try" }},
                {"Taunt", new string[]{ "Wow… do you pick that number a lot, or was this a special occasion?", "Amazing. It’s like you’re the computer and I’m the super-human genius here.", "This game was way too easy… did you even try to think?", "Ah yes, somewhere between 1 and 100. Bold. Daring. Truly revolutionary.", "Thank goodness you didn’t choose an irrational number. I wasn’t emotionally prepared for π.", "Oh wow. That number again. I should’ve brought a blindfold.", "I love this part where I pretend I didn’t already know.", "You had the whole number line… and that’s what you went with?", "Incredible strategy. I’ll be recovering from this victory for minutes.", "Hold on—let me act surprised. …Okay, done.", "I mean, sure, anyone could’ve guessed that. Including me. Immediately.", "Wow. I should charge admission for performances like this.", "That was less ‘mind game’ and more ‘mild suggestion.’", "Next time, maybe challenge me. Or at least confuse me a little." } },
                {"Suspicious", new string[]{ "hmm…", "uhh…", "really?", "oh?", "wait…", "seriously?", "uh… okay…", "…huh.", "mmmaybe…", "hold on…", "erm…", "well then…", "you sure?", "uhh… right…", "wow… really?", "okay… wow.", "hmm. Interesting…", "that so?", "uhh… nope.", "right… sure." } }};
        public static Random random = new();
        public static byte msg_bad_input = (byte)msg_type.bad_input;
        //Use as a refrence to remember what the byte numbers are for the msg_system function. Avoids comparing stirngs.
        enum msg_type
        {
            select_secrete_number,
            select_yes_not,
            bad_input,
            cpu_speaker_label
        }
        static string? MainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=============== Guessing Game ===============\n");
            Console.ForegroundColor = ConsoleColor.White;
            string[] menu_labels = {
                " - Single Player",
                     " - Two Player",
                    " - Survival Mode (User vs.Clock)",
                    " - Mastermind Mode (Computer vs. User)",
                    " - Exit program"};
            for (int i = 0; i < menu_labels.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"\t{i + 1}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(menu_labels[i]);

            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n ============================================\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\tEnter 1,2,3,4, or 5 below");
            return Console.ReadLine();

        }
        static void SinglePlayerGuessingGame()
        {
            int randNum = new Random().Next(1, 101);
            int lower = 1; int upper = 100; int userInput; int counter = 0;
            while (true)
            {
                Console.WriteLine($"Enter b/w {lower} to {upper}");
                if (!int.TryParse(Console.ReadLine(), out userInput))
                { msg_system(msg_bad_input); continue; }
                counter++;
                if (userInput > randNum) { Console.WriteLine("Guess something smaller"); upper = userInput; }
                else if (userInput < randNum) { Console.WriteLine("Guess something bigger"); lower = userInput; }
                else { Console.WriteLine($"Game is over it took {counter} time to guess it!\n"); return; }

            }
        }

        static void TwoPlayerGuessingGame()
        {
            Console.WriteLine("Enter first player name :");
            string p1Name = Console.ReadLine()!;
            Console.WriteLine("Enter second player name :");
            string p2Name = Console.ReadLine()!;
            int randNum = new Random().Next(1, 101);
            int rand = new Random().Next(1, 3); // 1 or 2
            string? turn = rand == 1 ? p1Name : p2Name;
            int upper = 100; int lower = 1; int userInput;
            while (true)
            {
                Console.WriteLine($"{turn} Guess a number b/w {lower}  and {upper}");
                if (!int.TryParse(Console.ReadLine(), out userInput)) { msg_system(msg_bad_input); continue; }
                if (randNum > userInput) { Console.WriteLine("Guess something bigger"); lower = userInput; }
                else if (randNum < userInput) { Console.WriteLine("Guess something smaller"); upper = userInput; }
                else { Console.WriteLine($"The game is over the WINNER is {turn}\n"); break; }
                turn = turn == p1Name ? p2Name : p1Name;
            }
        }

        static void WriteEnergy(int attempts, string b)
        {
            Console.Write("Energy Level: ");
            for (int i = 1; i < attempts + 1; i++) Console.Write(b);
            Console.WriteLine();
        }
        static void SurvivalGuessingGame()
        {
            string energy_string = Console.OutputEncoding.CodePage == 65001 ? "🍪" : "X";
            Console.WriteLine("Find the hidden number before your \"Energy\"(attempts) runs out.");
            byte attempts = 7;
            int randNum = new Random().Next(1, 101);
            int lower = 1; int upper = 100; int userInput;
            while (true)
            {
                if (attempts > 0)
                {
                    WriteEnergy(attempts, energy_string);
                    Console.WriteLine($"Enter b/w {lower} to {upper}");
                    if (!int.TryParse(Console.ReadLine(), out userInput))
                    { msg_system(msg_bad_input); continue; }
                    attempts--;
                    if (userInput > randNum) { Console.WriteLine("Guess something smaller"); upper = userInput; }
                    else if (userInput < randNum) { Console.WriteLine("Guess something bigger"); lower = userInput; }
                    else { Console.WriteLine($"Game is over it took you {7 - attempts} times to guess it!"); confirm_return(); break; }
                }
                else { Console.WriteLine($"Game is over it took you {7 - attempts} times and you still couldn't get it!"); confirm_return(); break; }
            }
        }

        static void MasterMindGuessingGame()
        {
            bool win = false;
            bool confirm_guess = false;
            int answer = 0; int low = 1; int high = 100; int cpu_guess = 0;

            int sleep_ms = random.Next(0, 13);

            byte msg_select_secrete_number = (byte)msg_type.select_secrete_number;
            byte msg_yes_not = (byte)msg_type.select_yes_not;
            byte cpu_speaker_label = (byte)msg_type.cpu_speaker_label;



            CpuName = $"{Choose("Title")} {Choose("Name")}";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\tWelcome to Master Mind Guessing Game!");
            msg_system(msg_select_secrete_number);

            while (!int.TryParse(Console.ReadLine(), out answer) || answer < 1 || answer > 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                msg_system(msg_bad_input);
                msg_system(msg_select_secrete_number);
            }
            Thread.Sleep(sleep_ms * 80);

            while (!win)
            {
                if (!confirm_guess)
                {
                    //Console.WriteLine("\nDEBUG Low: " + low + ", High: " + high);
                    cpu_guess = (low + high) / 2;
                    msg_system(cpu_speaker_label);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($" {Choose("Guess_text", sleep_ms)} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(cpu_guess);
                }
                confirm_guess = false;
                Console.ForegroundColor = ConsoleColor.Gray; //Resets text color to white for above cpu speach and speech before looping. (nested inside the feedback)
                Console.Write("Type H (Higher), L (Lower), C (Correct) to provide feedback: ");
                Console.ForegroundColor = ConsoleColor.White;
                switch (Console.ReadLine()!.ToUpper())
                {
                    case "H":
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (cpu_guess < high)
                            low = cpu_guess + 1;
                        else
                        {

                            if (low > high - 3 && cpu_guess != 100)
                            {
                                high = 100;
                                msg_system(cpu_speaker_label);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($" {Choose("Suspicious")} I feel like you said lower before?");
                                Console.ForegroundColor = ConsoleColor.White;
                                confirm_guess = true;
                            }
                            else
                            {//default
                                msg_system(cpu_speaker_label);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($" {Choose("Suspicious")} You said it can't be any higher then {high} .. ?");
                                Console.ForegroundColor = ConsoleColor.White;


                            }
                        }
                        break;


                    case "L":
                        Console.ForegroundColor = ConsoleColor.Red;
                        if (cpu_guess > low)
                            high = cpu_guess - 1;
                        else
                        {
                            if (high < low + 3 && cpu_guess != 1)
                            {
                                low = 1;
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                msg_system(cpu_speaker_label);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($" {Choose("Suspicious")} I feel like you said higher before?");
                                Console.ForegroundColor = ConsoleColor.White;
                                confirm_guess = true;
                            }
                            else
                            { //default
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                msg_system(cpu_speaker_label);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($" {Choose("Suspicious")} You said it can't be any lower then {low} .. ?");
                                Console.ForegroundColor = ConsoleColor.White;


                            }
                        }

                        break;

                    case "C":
                        //Allows cpu to suspect a lie
                        if (cpu_guess != answer)
                        {
                            if (new Random().Next(0, 6) == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                msg_system(cpu_speaker_label);
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write($" Hmm.."); Thread.Sleep(300);
                                Console.Write($"."); Thread.Sleep(200);
                                Console.Write($".. "); Thread.Sleep(200);
                                Console.Write($"Im just not, "); Thread.Sleep(400);
                                Console.Write($"uh, "); Thread.Sleep(200);
                                Console.Write($"sure that was your origonal number...."); Thread.Sleep(600);
                                Console.WriteLine($" was it?"); Thread.Sleep(200);
                                Console.ForegroundColor = ConsoleColor.Gray;
                                msg_system(msg_yes_not);

                                while (true)
                                {
                                    string confirm = Console.ReadLine()!.ToUpper();
                                    if (confirm == "Y")
                                    {
                                        //Lets CPU win when suspecious and player confirms
                                        win = true;
                                        break;
                                    }
                                    if (confirm == "N")
                                    {
                                        //Lets CPU reguess.
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        msg_system(cpu_speaker_label);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine("I knew it... wow.. ugh..");
                                        Thread.Sleep(500);
                                        break;
                                    }
                                    else
                                    {
                                        //Expects to reconfirm.
                                        msg_system(msg_yes_not);
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                win = true;
                            }
                        }
                        else
                        {
                            win = true;
                        }

                        break;
                    default:
                        msg_system(msg_bad_input);//feedback isnt H, L or C
                        break;
                }

            }
            msg_system(cpu_speaker_label, true);
            Console.WriteLine($" {Choose("Taunt")}");
            msg_system(cpu_speaker_label);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Im sending you back to the main menu");
            confirm_return();

        }
        static void confirm_return()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to return to the main menu.");
            while (Console.KeyAvailable) Console.ReadKey(true);
            Console.ReadKey();
            Console.WriteLine();
        }

        static string Choose(string Key, int upper = 0)
        {
            //Chooses the length of the Array @ dictionary key, otherwise th supplied upper limit
            return cpu_outputs[Key][random.Next(0, (upper == 0) ? cpu_outputs[Key].Length : upper)];
        }

        public static void msg_system(byte choice, bool reset_white = false)
        {
            switch (choice)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"Select A secret number from 1 to 100 for your AI (Awful intelegence) opponent ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(CpuName);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" to guess: ");
                    return;
                case 1:

                    Console.Write("Enter ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("(Y for yes)");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" or ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("(N for no)");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" : ");
                    return;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("BAD INPUT! Please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{CpuName}:");
                    break;
            }
            if (reset_white)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // main engine would be
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                string? choice = MainMenu();
                Console.Clear();
                switch (choice)
                {
                    case "1": SinglePlayerGuessingGame(); break;
                    case "2": TwoPlayerGuessingGame(); break;
                    case "3": SurvivalGuessingGame(); break;
                    case "4": MasterMindGuessingGame(); break;
                    case "5": Environment.Exit(0); break;
                    default: Console.WriteLine("BAD INPUT!"); break;
                }
            }
        }
    }
}
