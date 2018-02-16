using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Tictac
{
    public partial class MainPage : ContentPage
    {
        private bool _turn = true; // true = X turn | false = O turn
        private int _turnCount;
        private readonly List<Button> _buttons = new List<Button>();
        public MainPage()
        {
            InitializeComponent();
            AddButtons();
        }



        private void AddButtons()
        {
            _buttons.Add(A1);
            _buttons.Add(A2);
            _buttons.Add(A3);
            _buttons.Add(B1);
            _buttons.Add(B2);
            _buttons.Add(B3);
            _buttons.Add(C1);
            _buttons.Add(C2);
            _buttons.Add(C3);
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var b = (Button)sender;

            b.Text = _turn ? "X" : "O";

            _turn = !_turn;
            b.IsEnabled = false;
            _turnCount++;
            CheckForWinner();
        }

        private void CheckForWinner()
        {
            var there_is_a_winner = false;

            // vertical check
            if (Check(A1, A2, A3))
            {
                there_is_a_winner = true;
            }
            else if (Check(B1, B2, B3))
            {
                there_is_a_winner = true;
            }
            else if (Check(C1, C2, C3))
            {
                there_is_a_winner = true;
            }

            // horizontal check
            if (Check(A1, B1, C1))
            {
                there_is_a_winner = true;
            }
            else if (Check(A2, B2, C2))
            {
                there_is_a_winner = true;
            }
            else if (Check(A3, B3, C3))
            {
                there_is_a_winner = true;
            }

            // horizontal check
            if (Check(A1, B1, C1))
            {
                there_is_a_winner = true;
            }
            else if (Check(A2, B2, C2))
            {
                there_is_a_winner = true;
            }
            else if (Check(A3, B3, C3))
            {
                there_is_a_winner = true;
            }

            // diagonal check
            if (Check(A1, B2, C3))
            {
                there_is_a_winner = true;
            }
            else if (Check(A3, B2, C1))
            {
                there_is_a_winner = true;
            }

            if (there_is_a_winner)
            {
                disableButtons();

                DisplayAlert("Game Over!", _turn ? "O is the winner" : "X is the winner", "OK");

                NewGame();

            }
            else if (_turnCount == 9)
            {
                DisplayAlert("Game Over!", "It's a draw!", "OK");
                NewGame();

            }
        }

        private void New(object sender, EventArgs e)
        {
            NewGame();

        }

        private bool Check(Button a, Button b, Button c)
        {
            return (a.Text == b.Text) && (b.Text == c.Text) && (!a.IsEnabled);
        }

        private void disableButtons()
        {
            foreach (var button in _buttons)
            {
                try
                {

                    button.IsEnabled = false;

                }
                catch { }

            }
        }

        private void NewGame()
        {
            _turn = true;
            _turnCount = 0;

            foreach (var button in _buttons)
            {
                try
                {

                    button.IsEnabled = true;
                    button.Text = "";

                }
                catch { }

            }

        }
    }
}
