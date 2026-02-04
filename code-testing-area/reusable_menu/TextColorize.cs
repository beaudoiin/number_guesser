using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
namespace Menu
{

    static class Console2
    {
        public static bool ansiOk = false;

        public static byte r_bg_default = 00;
        public static byte g_bg_default = 00;
        public static byte b_bg_default = 00;
        public static byte r_fg_default = 00;
        public static byte g_fg_default = 00;
        public static byte b_fg_default = 00;

        public static int fg_hex;
        public static int bg_hex;
        public static ConsoleColor default_fg_console_color;
        public static ConsoleColor default_bg_console_color;
        /// <summary>
        /// Requires a string of text, if your using write or writeline, fg color as hex and console color backup, and the same for bg.
        /// </summary>
        /// <param name="parts"></param>
        public static void Console_advanced(
            params (string text, 
            bool write, 
            int? Colorfg, 
            ConsoleColor? Colorfg_console,
            int? Colorbg, 
            ConsoleColor? Colorbg_console)[] 
            parts)
        {


            foreach (var param in parts)
            {
                //Check if consolefg is used/passed if not use console color, if not passed use default. 
                if (param.Colorfg is null)
                {

                    if (param.Colorfg_console is not null)
                        Console.ForegroundColor = (ConsoleColor)param.Colorfg_console;
                    else
                        if (!ansiOk)
                        Console.ForegroundColor = default_fg_console_color;

                }
                else
                {
                    fg_hex = (int)param.Colorfg;
                }


                /*Check if consolebg is used/passed if not use console color, if not passed use default.*/
                if (param.Colorbg is null)

                {

                    if (param.Colorbg_console is not null)
                        Console.ForegroundColor = (ConsoleColor)param.Colorbg_console;
                    else
                        if (ansiOk)
                        fg_hex = default_bg_hex;
                    else
                        Console.ForegroundColor = default_bg_console_color;

                }
                else
                {
                    bg_hex = (int)param.Colorbg;
                }

                if (ansiOk)
                    {

                    //Get the r,g,b value by bitshifting the int and casting to a byte
                    byte r = (byte)((fg_hex >> 16) & 0xFF);
                    byte g = (byte)((fg_hex >> 8) & 0xFF);
                    byte b = (byte)((fg_hex) & 0xFF);



                    //Write the text using write function filling in details
                    Console.Write($"\u001b[38;2;{r};{g};{b}m{param.text}\x1b\u001b[38;2;{r_fg_default};{g_fg_default};{b_fg_default}m");
                    }
                    else
                    {
                        Console.Write(param.text);
                    Console.ForegroundColor = default_fg_console_color;
                    Console.BackgroundColor = default_bg_console_color;
                }
                if (!param.write)
                {
                    Console.WriteLine();
                }
            }

              


            }
        static void Default_colors(int fg_hex, int bg_hex, ConsoleColor fg_console,  ConsoleColor bg_console)
        {

            default_fg_console_color = fg_console;
            default_bg_console_color = bg_console;
       
            //Convert passed hex to defualt rgb
            byte r_fg_default = (byte)((fg_hex >> 16) & 0xFF);
            byte g_fg_default = (byte)((fg_hex >> 8) & 0xFF);
            byte b_fg_default = (byte)((fg_hex) & 0xFF);

            byte r_bg_default = (byte)((bg_hex >> 16) & 0xFF);
            byte g_bg_default = (byte)((bg_hex >> 8) & 0xFF);
            byte b_bg_default = (byte)((bg_hex) & 0xFF);
        }
        }
}
