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
using System.Xml.Linq;

namespace TeamManagementAppGUI
{
    /// <summary>
    /// Interaction logic for PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        Person person;
        public PersonWindow()
        {
            InitializeComponent();
            tblFunction.IsEnabled = false;
            tblExperience.IsEnabled = false;

        }
        public PersonWindow(Person pers) : this()
        {
            person = pers;
            if (pers is TeamLeader persLeader)
            {
                tblExperience.IsEnabled = true;
                tblPesel.Text = persLeader.Pesel;
                tblName.Text = persLeader.Name;
                tblSurname.Text = persLeader.Surname;
                tblBirthDate.Text = persLeader.DateOfBirth.ToString("dd-MM-yyyy");
                tblExperience.Text = persLeader.Experience.ToString();
                comboBox.Text = (persLeader.Sex == EnumSex.F) ? "Kobieta" : "Mężczyzna";
            }
            else if (pers is TeamMember persMember)
            {
                tblFunction.IsEnabled = true;
                tblPesel.Text = persMember.Pesel;
                tblName.Text = persMember.Name;
                tblSurname.Text = persMember.Surname;
                tblBirthDate.Text = $"{persMember.DateOfBirth:dd-MM-yyyy}";
                if (persMember.TeamFunction != null)
                {
                    tblFunction.Text = persMember.TeamFunction.ToString();
                }
                comboBox.Text = (persMember.Sex == EnumSex.F) ? "Kobieta" : "Mężczyzna";
            }
            else
            {
                tblFunction.IsEnabled = true;
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (tblPesel.Text != "" || tblName.Text != "" || tblSurname.Text != "")
            {
                person.Pesel = tblPesel.Text;
                person.Name = tblName.Text;
                person.Surname = tblSurname.Text;
                person.DateOfBirth = DateTime.Parse(tblBirthDate.Text);
                if (comboBox.Text == "Female")
                {
                    person.Sex = EnumSex.F;
                }
                else
                {
                    person.Sex = EnumSex.M;
                }
                if (person is TeamLeader leader)
                {
                    if (int.TryParse(tblExperience.Text, out int experience))
                    {
                        leader.Experience = experience;
                    }
                    else
                    {
                        MessageBox.Show("Nieprawidłowy format doświadczenia.");
                    }
                }
                if(person is TeamMember member)
                {
                    member.TeamFunction = tblFunction.Text;
                }
                DialogResult = true;
            } 
            else
            {
                DialogResult = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
