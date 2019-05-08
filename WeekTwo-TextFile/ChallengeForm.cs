using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileChallenge
{
    public partial class ChallengeForm : Form
    {
        BindingList<UserModel> users = new BindingList<UserModel>();

        public ChallengeForm()
        {
            InitializeComponent();
            SetUpInitialListFromFile("AdvancedDataSet.csv");
            WireUpDropDown();
        }

        private void WireUpDropDown()
        {
            usersListBox.DataSource = users;
            usersListBox.DisplayMember = nameof(UserModel.DisplayText);
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            var firstName = firstNameText.Text;
            var lastName = lastNameText.Text;
            var age = Convert.ToInt32(agePicker.Value);
            var isAlive = isAliveCheckbox.Checked;

            var myUser = new UserModel
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                IsAlive = isAlive
            };

            users.Add(myUser);
        }

        private void saveListButton_Click(object sender, EventArgs e)
        {
            using (var writer = new StreamWriter("AdvancedDataSet.csv"))
            {
                writer.WriteLine("Age,LastName,IsAlive,FirstName");
                foreach (var user in users)
                {
                    var alive = (user.IsAlive) ? 1 : 0;
                    writer.WriteLine($"{user.Age},{user.LastName},{alive},{user.FirstName}");
                }
            }

        }

        private void SetUpInitialListFromFile(string fileToRead)
        {
            using (var reader = new StreamReader(fileToRead))
            {
                bool passedFirstLine = false;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var lineValues = line.Split(',');
                    if (passedFirstLine)
                    {
                        var isAliveFlag = (int.Parse(lineValues[2]) == 0) ? false : true;
                        var myUser = new UserModel()
                        {
                            Age = int.Parse(lineValues[0]),
                            LastName = lineValues[1],
                            IsAlive = isAliveFlag,
                            FirstName = lineValues[3],
                        };
                        users.Add(myUser);
                    }
                    else
                    {
                        passedFirstLine = true;
                    }
                }
            }
        }
    }
}
