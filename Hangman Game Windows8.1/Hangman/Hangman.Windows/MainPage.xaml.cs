using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Hangman
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {        
        string word = Dico.NewWord(false);
        public int falseNumber = 0;
        BtManager btnlist = new BtManager();

        public MainPage()
         {
            this.InitializeComponent();
            NewGameMessage();            
            Initialisation(word);       
                 
        }

        private void bt_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            btnlist.Add(clickedButton);

            char letter = clickedButton.Content.ToString()[0];
            textBlock.Text += letter;
            textBlock.Text += ", ";

            BtManager.TurnOff(clickedButton);

            if (Dico.IsGood(word, letter))
            {
                int index = 0;
                while (index !=-1)
                {
                    index = word.IndexOf(letter,index);
                    StringBuilder temp = new StringBuilder();
                    temp.Append(textWord.Text);
                    
                    if(index != -1)
                    {
                        temp.Remove(index, 1);
                        temp.Insert(index, letter);
                        textWord.Text = temp.ToString().ToUpper();
                        index++;
                    }
                }
                if (textWord.Text.IndexOf('?') == -1) EndGame(true);
            }
            else
            {
                falseNumber++;
                ImageSource hangIm = new BitmapImage(new Uri(string.Format("ms-appx:///Assets/{0}.jpg", falseNumber)));
                image.Source = hangIm;
                if (falseNumber == 10)
                    EndGame(false);                
            }
        }
        
        private void Initialisation(string word)
        {
            ImageSource hangIm = new BitmapImage(new Uri(string.Format("ms-appx:///Assets/{0}.jpg", 0)));
            image.Source = hangIm;
            textWord.Text = "?";
            for (int i = 0; i < word.Length-1; i++)
            {
                textWord.Text += "?";
            }
        }
        
        private void NewGame(bool level)
        {
            word = Dico.NewWord(level);
            falseNumber = 0;
            Initialisation(word);
            btnlist.RealeaseBtn();
            textBlock.Text = "Already Tested : ";
        }
        
        async public void EndGame(bool isWining)
        {
            MessageDialog dlg;
            if (isWining)
                dlg = new MessageDialog("Wonderfull! you won, Do you want to play again? ", "End Game");
            else
                 dlg = new MessageDialog(string.Format("Game Over, Do you want to play again? \n the word was: {0}", word.ToUpper()), "End Game");
            
            UICommand yesCommand = new UICommand("yes", ContinueToPlay);
            UICommand noCommand = new UICommand("no", GameOverAndClose);
            dlg.Commands.Add(yesCommand);
            dlg.Commands.Add(noCommand);
            await dlg.ShowAsync();
        }
        
        async public void NewGameMessage()
        {
            MessageDialog dlg = new MessageDialog("Choose your Level", "New Game");
            UICommand yesCommand = new UICommand("Easy", EasyGame);
            UICommand noCommand = new UICommand("Hard", HardGame);
            dlg.Commands.Add(yesCommand);
            dlg.Commands.Add(noCommand);
            await dlg.ShowAsync();
        }

        private void EasyGame(IUICommand command)
        {
            NewGame(true);
        }

        private void HardGame(IUICommand command)
        {
            NewGame(false);                                    
        }

        private void GameOverAndClose(IUICommand command)
        {
            Application.Current.Exit();
        }

        private void ContinueToPlay(IUICommand command)
        {
            NewGameMessage();
        }
        
    }
}
