using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// Weak event pattern is not avialable in .net core
/// </summary>
namespace Observer
{
    public class Button
    {
        public event EventHandler<EventArgs> Clicked;

        public void Fire()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Window
    {
        public Window(Button button)
        {
            button.Clicked += Button_Clicked; 
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button Clicked");
        }

        ~Window()
        {
            Console.WriteLine("Window is finalized");
        }
    }
}
