using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Text;
namespace Menu
{
    class Menu
    {
        //Optional Extensions
        //IMenu_Extension_1 extension;
        // IMenu_Extension_2 extension;

        //Menu Colors
        public int? menu_bg_color_hex; //pass format 0x000000; background
        public static byte r_bg_default = 0x00;
        public static byte g_bg_default = 0x00;
        public static byte b_bg_default = 0x00;
        public static byte r_fg_default = 0xff;
        public static byte g_fg_default = 0xff;
        public static byte b_fg_default = 0xff;

       
        public ConsoleColor? menu_bg_color_console_color; 
        public ConsoleColor? menu_fg_color_console_color;
        public int? border_bg_color_hex;//pass format 0x000000; background
        public int? border_fg_color_hex;//pass format 0x000000; foreground
        public ConsoleColor? border_bg_color_console_color;
        public ConsoleColor? border_fg_color_console_color;
        public required int[] grouping_menu_item_bg_color; //When grouping menu items into sections; //pass format 0x000000; hex background
        public required int[] grouping_menu_item_fg_color; //When grouping menu items into sections; //pass format 0x000000; hex foreground
        public ConsoleColor premenu_color_state_console; // background
        public int premenu_color_state_hex;// background
        public int? screen_caption_fg_hex; //pass format 0x000000; background
        public int? screen_caption_bg_hex; //pass format 0x000000; foreground
        public ConsoleColor? screen_caption_fg_console_color;
        public ConsoleColor? screen_caption_bg_console_color; 

        //Formatting - Text
        public required Func<int> draw_header; // Function passed should print header and return lines used
        public bool ansi_enabled;
        public Char bullet; //Little icon next to menu item
        public char[] border_chars = new char[4]; //Holds the 4 characters to construct borders and seperators
        public byte layout;
        public string screen_caption = "Menu: (Use Up/Down Arrow and Enter)"; // Example is instructions on how to use the menu
      
        ////////// Header Seperator
        public static bool header_seperator;
        public static char header_seperator_char;
        public int buffer_width_before_draw;
        public int buffer_height_before_draw;
        public static int header_seperator_char_fg_default = 0xffffff;
        public static int header_seperator_char_bg_default = 0x000000;
        public static ConsoleColor header_seperator_char_fg_console_default = ConsoleColor.White;
        public static ConsoleColor header_seperator_char_bg_console_default = ConsoleColor.Black;
        public static bool header_seperator_padding = true;


        //Animations
        public byte transition_bg_color; //Time in 0.1s to transition.
        public int bullet_color_animation; //Color to change bullet it when transitioning
        public byte bullet_color_animation_duration; //1= 0.1s, this sets the time to change color

        //Audio (Implemented by external passed engine refrence with object)
        public required object sound_bg_musc;
        public required object sound_sfx_select;
        public required object sound_sfx_scroll;

        // navigation
        public ConsoleKey key_enter = ConsoleKey.Enter;
        public ConsoleKey key_cycle_up = ConsoleKey.UpArrow;
        public ConsoleKey key_cycle_down = ConsoleKey.DownArrow;
        public byte selector_cycle_delay; //1 = 0.01 delay
        public bool scrolling_in_progess = false;
        private byte selector_position_current;
        private byte selector_position_defualt;
        byte selection_return = 0;


        //Menu Items
        public required List<MenuItem> itemList;


        //Methods

        public void Run()
        {
            selector_position_current = selector_position_defualt;
            DrawMenu();


        }
        public void DrawMenu()
        {

            ClearScreenBackground(ansi_enabled, menu_bg_color_hex, r_bg_default, g_bg_default, b_bg_default);
            buffer_width_before_draw = Console.BufferWidth; //Set the width before drawing to get an idea of how many chars to print.
            buffer_height_before_draw = Console.BufferHeight; //Set the width before drawing to get an idea of how many chars to print.
            buffer_height_before_draw -= draw_header(); //removed from available space the size of the header.

            // expects static void TextColorize(params (string? Color, string text, bool write)[] parts)
            string current_header_seperator = Convert.ToString(header_seperator_char);
            buffer_height_before_draw--; //update available space for menu layouts
            for (int i = 0; i < buffer_width_before_draw; i++)
            {
                current_header_seperator += current_header_seperator;
            }
            if (header_seperator_padding)
            {
                current_header_seperator = "\n" + current_header_seperator + "\n";
                buffer_height_before_draw -= 2;//update available space for menu layouts
            }
            //Prints the seperator with a fg and bg color using supplied string, defualts used if ansi not specified.
            Console2.Console_advanced(
                (
                current_header_seperator,
                true,
                (int?)header_seperator_char_fg_default,
                (ConsoleColor?)header_seperator_char_fg_console_default,
                (int?)header_seperator_char_bg_default,
                (ConsoleColor?)header_seperator_char_bg_console_default
                ));
            scrolling_in_progess = false; // may not be needed

            Console2.Console_advanced(
                (
                screen_caption,
                true,
                (int?)screen_caption_fg_hex,
                (ConsoleColor?)screen_caption_fg_console_color,
                (int?)screen_caption_bg_hex,
                (ConsoleColor?)screen_caption_bg_console_color
                ));

            switch (layout)
            {
                case 0:
                    //Main
                    //

                    /*Needs Work
                    for (byte i = 0; i < itemList.Count; i++)
                    {
                        if (i == selector_position_current - 1)
                        {
                            Console.BackgroundColor = select_color;
                            Console.WriteLine($"  {menu_bullet} {menu_label[i]}");
                        }
                        else
                            Console.WriteLine($"    {itemList[selector_position_current].label}");
                        if (i == selector_position_current - 1) Console.BackgroundColor = selector_position_current;
                    }
                    */



                    break;
                case 1:
                    //Column Vertical
                    break;
                case 2:
                    //Column Horizontal
                    break;
            }

        }



        /// <summary>
        /// Changes the background to a specified hex color property,
        /// if the hex is not defined the background will be changed with console_background as ConsoleColor type.
        /// Make sure pass to use ansi or not, and the defualt r g b must be passed
        /// Expects screen to write text after this clear.
        /// </summary>
        private void ClearScreenBackground(bool ansi_enabled, int? menu_bg_color_hex, byte r_bg_default,byte g_bg_default,byte b_bg_default)
        {
            //Does not restore data just clears blank
            // Expland to receive direct params so that it can be used for transition.

            //Set the background and clear the screen using either ansi or console.
            if (ansi_enabled)
            {
                if (menu_bg_color_hex is not null)
                {
                    //This should be done via the class members like it was done in TextColorise
                    byte r = (byte)((menu_bg_color_hex >> 16) & 0xFF); // >> 16 means to shift over by 16 bits, & 0xFF Read only the next 8 bits
                    byte g = (byte)((menu_bg_color_hex >> 8) & 0xFF);
                    byte b = (byte)(menu_bg_color_hex & 0xFF);
                }
                else
                {
                    //No hex supplied use defualts
                    byte r = r_fg_default;
                    byte g = g_fg_default;
                    byte b = b_fg_default;
                }

                Console.Write($"\x1b[48;2;{r};{g};{b}m");  // background color
                Console.Write("\x1b[2J");                    // clear entire screen using current bg
                Console.Write("\x1b[H");                     // move cursor to top-left
            }else{
                Console.BackgroundColor = menu_bg_color_console_color;
                Console.Clear();
            }
        }

        //Optiona >> implement interfaces possibly with class extensions in seperate files
        public void Remove()
        {
            // Adds a new menu Item allowing for it to be dynamic.
        }

        public void Add()
        {
            // Adds a new menu Item allowing for it to be dynamic.
        }
        public void Transition_background()
        {
            //Transitions from previous backgound color to new one. (Fade Effect)
        }
        private void TrackScreen()
        {
            //Optional
            //TrackScreen the screen where to overwrite strings to help prevent flicker
        }
    }
    class MenuItem
    {
        public string? label;
        public int? label_length;
        public string? label_abreviated;
        private string? Suffex_state;
        public string? description { get; private set; }
        public byte group_id;
        public object value; //Object used to catch various data types. Key is setting proper Item_Type to avoid errors.
        public byte item_type;
        static List<MenuItem> items = new();
        public enum Item_Type_Disc
        {
            Return,
            Toggle,
            Scrolle,
            Action,
            Menu,
            Heading,
            Exit
        }
        //When grouping menu items into sections; //pass format 0x000000; hex background
        static public List<int[]> grouping_menu_item_bgfg_color = new() { new int[] { 0x000000, 0xffffff } };
        public MenuItem(
            string label,
            string label_abreviated,
            object value,
            byte item_type,
            string description,
            byte group_id = 1)
        {
            //Initiate values for new object
            this.label = label;
            this.label_abreviated = label_abreviated;
            this.value = value;
            this.item_type = item_type;
            this.description = description;
            this.group_id = group_id;
            this.label_length = label.Length;

        }

    }


}

