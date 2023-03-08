using System;
using System.Collections.Generic;
using System.Globalization;
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
using TeamManagementApp;

namespace TeamManagementAppGUI
{
    /// <summary>
    /// Interaction logic for CreateTeamWindow.xaml
    /// </summary>
    public partial class CreateTeamWindow : Window
    {
        public CreateTeamWindow()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            string teamName = tblTeamName.Text;
            string pesel = tblLeaderPesel.Text;
            string name = tblLeaderName.Text;
            string surname = tblLeaderSurname.Text;
            string birthDate = tblLeaderBirthDate.Text;
            EnumSex sex;
            if (comboBox.Text == "Female")
            {
                sex = EnumSex.F;
            }
            else
            {
                sex = EnumSex.M;
            }
            string experience = tblLeaderExperience.Text;
            Team team = new Team(teamName, new TeamLeader(pesel, name, surname, birthDate, sex, Convert.ToInt32(experience)));
            mw.CreateTeam(team);
            mw.Show();
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
