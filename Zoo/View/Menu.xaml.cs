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
using System.Windows.Shapes;

namespace Zoo.View
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
       
        
        
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Animals animals = new Animals();
            MainMenu.Content = animals;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Events events = new Events();
            MainMenu.Content = events;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Tickets tickets= new Tickets();
            MainMenu.Content = tickets;

        }

       
    }
}
