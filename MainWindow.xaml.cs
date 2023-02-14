using Skill_visualization;
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

namespace KeyWordsVisualizer
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataAccess myDataAccess = new DataAccess();
            myDataAccess.createDbFile();
            this.InitializeComponent();
            Output.ItemsSource = DataAccess.GetCollabList();
        }

        private void AddCollab(object sender, RoutedEventArgs e)
        {
            Collab myCollab = new Collab
            {
                Name = collabNameInput.Text,
                Resume = collabResumeInput.Text,
            };

            string[] skillName = collabSkillInput.Text.Split(',');

            DataAccess.AddCollab(myCollab, skillName);

            Output.ItemsSource = DataAccess.GetCollabList();

            collabNameInput.Text = "";
            collabResumeInput.Text = "";
            collabSkillInput.Text = "";
        }
    }
    }
}
