using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BullsAndCows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Mustery mustery = new Mustery();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void buttonGo_Click(object sender, RoutedEventArgs e)
        {
            
            textBoxMustery.Text = String.Empty;
            textBlockLog.Text = String.Empty;
            textBoxAnswer.Text = String.Empty;
            textBoxBulls.Text = "0";
            textBoxCows.Text = "0";
            textBoxMoves.Text = "0";
            mustery.Moves = 0;
            Random rand = new Random();
            int digit1 = rand.Next(1, 9);
            int digit2;
            int digit3;
            int digit4;
            do
            {
                digit2 = rand.Next(0, 9);
            } while (digit2 == digit1);
            do
            {
                digit3 = rand.Next(0, 9);
            } while (digit3 == digit1 || digit3 == digit2);
            do
            {
                digit4 = rand.Next(0, 9);
            } while (digit4 == digit1 || digit4 == digit2 || digit4 == digit3);
            mustery.Number = digit1.ToString() + digit2 + digit3 + digit4;
            //textBoxMustery.Text = mustery.Number.ToString();
            textBoxMustery.Text = "****";
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            int Answer = 0;

            try
            {
                Answer = Convert.ToInt32(textBoxAnswer.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Enter a four-digit number ");
            }
            if (Answer < 1000 || Answer > 9999) MessageBox.Show("Enter a four-digit number ");
            else
            {
                Counting(Answer);
                mustery.Moves++;
                textBoxMoves.Text = mustery.Moves.ToString();
            }
            

        }

        private void Counting(int Answer)
        {
            int bulls = 0;
            int cows = 0;
            string Ans = Answer.ToString();
            string Mus = mustery.Number;
            if (Mus == Ans)
            {
                MessageBox.Show("You winner!!!");
                textBoxMustery.Text = mustery.Number.ToString();
            }
            else
            {
                for (int i = 0; i < Mus.Length; i++)
                {
                    for (int j = 0; j < Ans.Length; j++)
                    {
                        if (Mus[i] == Ans[j])
                        {
                            if (i == j) bulls++;
                            else cows++;
                        }
                    }
                }
                textBoxBulls.Text = bulls.ToString();
                textBoxCows.Text = cows.ToString();
                textBlockLog.Text = textBlockLog.Text + String.Format("\n{0}, Bulls: {1}, Cows: {2}", Answer, bulls, cows);
            }
            

        }
    }
}
