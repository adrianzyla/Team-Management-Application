using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace TeamManagementAppGUI
{
    
    public partial class MainWindow : Window
    {
        private bool changesMade = false;
        Team team;
        public MainWindow()
        {
            InitializeComponent();
            if (team is object)
            {
                lstBoxMembers.ItemsSource = new ObservableCollection<TeamMember>(team.TeamMembers);
                tblName.Text = team.TeamName;
                tblLeader.Text = team.TeamLeader.ToString();
            }
            Closing += MainWindow_Closing;
        }

        public void CreateTeam(Team team)
        {
            this.team = team;
            lstBoxMembers.ItemsSource = new ObservableCollection<TeamMember>(team.TeamMembers);
            tblName.Text = team.TeamName;
            tblLeader.Text = team.TeamLeader.ToString();
            changesMade = true;
        }
        public void OpenTeam ()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                dlg.FileName = filename;
                team = (Team)Team.ReadXML(filename);
                if (team is object)
                {
                    lstBoxMembers.ItemsSource = new ObservableCollection<TeamMember>(team.TeamMembers);
                    tblName.Text = team.TeamName;
                    tblLeader.Text = team.TeamLeader.ToString();
                }
            }
            changesMade = true;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (tblLeader.Text != "")
            {
                PersonWindow window = new PersonWindow(team.TeamLeader);
                bool? result = window.ShowDialog();
                if (result == true)
                {
                    tblLeader.Text = team.TeamLeader.ToString();
                }
            }
            else
            {
                PersonWindow window = new PersonWindow();
                bool? result = window.ShowDialog();
                if (result == true)
                {
                    tblLeader.Text = team.TeamLeader.ToString();
                }
            }
            changesMade = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            TeamMember tm = new TeamMember();
            PersonWindow okno = new PersonWindow(tm);
            bool? result = okno.ShowDialog();
            if (result == true)
            {
                team.AddMember(tm);
                lstBoxMembers.ItemsSource = new
                ObservableCollection<TeamMember>(team.TeamMembers);
            }
            changesMade = true;
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lstBoxMembers.SelectedIndex > -1)
            {
                foreach (var item in lstBoxMembers.SelectedItems)
                {
                    team.RemoveMember(((TeamMember)item).Pesel);
                }
                lstBoxMembers.ItemsSource = new
                ObservableCollection<TeamMember>(team.TeamMembers);
            }
            changesMade = true;
        }
       
        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            team.Sort();
            lstBoxMembers.ItemsSource = team.TeamMembers;
            changesMade = true;
        }

        private void btnSortByPesel_Click(object sender, RoutedEventArgs e)
        {
            team.SortByPESEL();
            lstBoxMembers.ItemsSource = team.TeamMembers;
            changesMade = true;
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            lstBoxMembers.ItemsSource = team.TeamMembers.Where(p => p.TeamFunction == tblFunction.Text).ToList();
            changesMade = true;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            tblFunction.Text = "";
            lstBoxMembers.ItemsSource = team.TeamMembers;
            changesMade = true;
        }

        private void btnEditMember_Click(object sender, RoutedEventArgs e)
        {
            PersonWindow window = new PersonWindow(lstBoxMembers.SelectedItem as TeamMember);
            bool? result = window.ShowDialog();
            if (result == true)
            {
                lstBoxMembers.Items.Refresh();
            }
        }

        private void btnSetStatus_Click(object sender, RoutedEventArgs e)
        {
            TeamMember member = new TeamMember();
            member = lstBoxMembers.SelectedItem as TeamMember;
            if(member.Active == true) 
            {
                member.Active = false;
            }
            else
            {
                member.Active = true;
            }
            lstBoxMembers.Items.Refresh();
            changesMade = true;
        }

        private void btnClone_Click(object sender, RoutedEventArgs e)
        {
            TeamMember memberClone = new TeamMember();
            TeamMember member = new TeamMember();
            member = lstBoxMembers.SelectedItem as TeamMember;
            this.team.TeamMembers.Add((TeamMember)member.Clone());
            lstBoxMembers.ItemsSource = new ObservableCollection<TeamMember>(team.TeamMembers);
            changesMade = true;
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                team.TeamName = tblName.Text;
                Team.SaveXML(filename, team);
            }
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                team.TeamName = tblName.Text;
                team = (Team)Team.ReadXML(filename);
                if (team is object)
                {
                    lstBoxMembers.ItemsSource = new ObservableCollection<TeamMember>(team.TeamMembers);
                    tblName.Text = team.TeamName;
                    tblLeader.Text = team.TeamLeader.ToString();
                }
            }
        }
        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (changesMade)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save changes before leaving?", "Save changes?", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    Nullable<bool> resultDlg = dlg.ShowDialog();
                    if (resultDlg == true)
                    {
                        string filename = dlg.FileName;
                        team.TeamName = tblName.Text;
                        Team.SaveXML(filename, team);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
