using static System.Console;
using static System.ConsoleColor;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class Menu
    {
        private string Prompt;
        private string[] Options;
        private int SelectedIndex = 0;

        public Menu(string _Prompt, string[]_Options)
        {
            Prompt = _Prompt;
            Options = _Options;
        }

        private void DisplayOptions()
        {
            Clear();
            WriteLine(Prompt);
            for(int i = 0; i < Options.Length; i++)
            {
                if(i == SelectedIndex)
                {
                    BackgroundColor = White;
                    ForegroundColor = Black;
                }
                else
                {
                    BackgroundColor = Black;
                    ForegroundColor = White;
                }
                WriteLine($"<< {Options[i]} >>");
            }
            ResetColor();
        }
        public int Start()
        {
            ConsoleKey KeyPressed;
            do {
                DisplayOptions();
                KeyPressed = ReadKey(true).Key;
                if(KeyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if(SelectedIndex < 0)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }else if(KeyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if(SelectedIndex > Options.Length - 1)
                    {
                        SelectedIndex = 0;
                    }
                }
            }while(KeyPressed != ConsoleKey.Enter);

            Clear();
            return SelectedIndex;
        }
    }
}
