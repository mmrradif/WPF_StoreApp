using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Services.Dialogs;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace StoreApp
{
    /// <summary>
    /// Interaction logic for json.xaml
    /// </summary>
    public partial class json : Window
    {
        private readonly string path = $"marketingDepartment.json";
        private readonly string path1 = $"operationsDepartment.json";
        private readonly string path2 = $"operationsDepartment.json";
        private readonly string path3 = $"operationsDepartment.json";
        private readonly string path4 = $"operationsDepartment.json";
        private readonly string path5 = $"operationsDepartment.json";


        public json()
        {
            InitializeComponent();

            List<string> Departments = new List<string>()
            {
                "Marketing Department",
                "Operations Department",
                "Finance Department",
                "Sales Department",
                "Human Resource Department",
                "Purchase Department"
            };
            this.cmbJson.ItemsSource = Departments;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
        }


        private void cmbJson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbJson.SelectedIndex==0)
            {
                try
                {
                    string jsonFromFile;
                    using (var reader = new StreamReader(path))
                    {
                        jsonFromFile = reader.ReadToEnd();
                    }
                    text.Text = jsonFromFile;
                    var employeeFromJson = JsonConvert.DeserializeObject<Employee>(jsonFromFile);
                }
                catch (Exception)
                {
                    Console.WriteLine("The File Could Not Be Read");
                }
            }
            if (cmbJson.SelectedIndex == 1)
            {
                try
                {
                    string jsonFromFile;
                    using (var reader = new StreamReader(path1))
                    {
                        jsonFromFile = reader.ReadToEnd();
                    }
                    text.Text = jsonFromFile;
                    var employeeFromJson = JsonConvert.DeserializeObject<Employee>(jsonFromFile);
                }
                catch (Exception)
                {
                    Console.WriteLine("The File Could Not Be Read");
                }
            }
        }
    }
}
