using KeyWordsVisualizer;
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
    public sealed partial class MainWindow : Window
    {
        public string[] service { get; set; }
        public MainWindow()
        {
            this.InitializeComponent();
            service = new string[] { "Estia_Tech", "Estia_Recherche", "CompositAdour", "Addimadour", "Estia_Entreprendre", "Scolarité", "Formation" };
            DataContext = this;
            DataAccess.InitializeDatabase();
            //Output.ItemsSource = DataAccess.GetCollabList();
        }
        private void AddCollab(object sender, RoutedEventArgs e)
        {
            Collab myCollab = new Collab
            {
                Name = collabNameInput.Text,
                FirstName = collabFirstNameInput.Text,
                Service = collabServiceInput.Text,
                Resume = collabResumeInput.Text,
            };

            string[] skillName = collabSkillInput.Text.Split(',');

            DataAccess.AddCollab(myCollab, skillName);

            Output.ItemsSource = DataAccess.GetCollabList();

            collabNameInput.Text = "";
            collabFirstNameInput.Text = "";
            collabServiceInput.Text = "";
            collabResumeInput.Text = "";
            collabSkillInput.Text = "";
        }

        private void AddProject(object sender, RoutedEventArgs e)
        {
            string[] collabName = ProjectCollabName.Text.Split(',');
            Project myProject = new Project
            {
                Name = projectNameInput.Text,
                Description = projectDescInput.Text,
            };

            DataAccess.AddProject(myProject, collabName);

            Output.ItemsSource = DataAccess.GetCollabList();

            projectNameInput.Text = "";
            ProjectCollabName.Text = "";
            projectDescInput.Text = "";

        }

        private void AddSkill(object sender, RoutedEventArgs e)
        {
            string[] collabName = skillCollabInput.Text.Split(',');
            string[] projectName = skillProjectInput.Text.Split(',');
            Skill mySkill = new Skill
            {
                Name = skillNameInput.Text,
                Description = skillDescInput.Text
            };

            DataAccess.AddSkill(mySkill, collabName, projectName);

            Output.ItemsSource = DataAccess.GetCollabList();

            skillNameInput.Text = "";
            skillDescInput.Text = "";
            skillCollabInput.Text = "";
            skillProjectInput.Text = "";

        }

        private void SuppCollab(object sender, RoutedEventArgs e)
        {
            DataAccess.SuppCollab(suppCollabInput.Text);

            Output.ItemsSource = DataAccess.GetCollabList();

            suppCollabInput.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Name.Navigate(typeof(WordCloudPage));
        }

        private void FiltreService(object sender, RoutedEventArgs e)
        {
            
            Output.ItemsSource = DataAccess.GetCollabListByService(filtreServiceInput.Text);

            filtreServiceInput.Text = "";
        }

        private void FiltreServiceAll(object sender, RoutedEventArgs e)
        {

            Output.ItemsSource = DataAccess.GetCollabList();
        }

        private void RechercheCollab(object sender, RoutedEventArgs e)
        {

            Output.ItemsSource = DataAccess.GetCollabListByName(rechercheNameInput.Text);

            rechercheNameInput.Text = "";
        }
        private void RechercheSkill(object sender, RoutedEventArgs e)
        {

            Output.ItemsSource = DataAccess.GetCollabListBySkill(rechercheSkillInput.Text);

            rechercheSkillInput.Text = "";
        }
    }

}

