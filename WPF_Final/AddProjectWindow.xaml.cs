using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WPF_Final
{
    /// <summary>
    /// Interaction logic for AddProjectWindow.xaml
    /// </summary>
    public partial class AddProjectWindow : Window
    {
        public string Text
        {
            get
            {
                return textBox1.Text;
            }
            set { textBox1.Text = value; }

        }

        public string Text2
        {
            get
            {
                return textBox2.Text;
            }
            set
            {
                 textBox2.Text=value;
            }
        }
        public AddProjectWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
