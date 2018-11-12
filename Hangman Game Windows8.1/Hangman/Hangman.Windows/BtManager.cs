using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Hangman
{
    class BtManager
    {

        private List<Button> btList = new List<Button>();
       
        static public void TurnOn(Button btn)
        {
            btn.Opacity = 100;
            btn.IsEnabled = true;
        }
        static public void TurnOff(Button btn)
        {
            btn.Opacity = 0.5;
            btn.IsEnabled = false;
        }
        
        public void Add(Button bt)
        {
                btList.Add(bt);
        }

        public void RealeaseBtn()
        {
            for (int i = 0; i < btList.Count; i++)
            {
                TurnOn(btList[i]);
            }
        }

       





    }
}
