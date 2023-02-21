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
using System.ComponentModel.DataAnnotations;

namespace StoreApp
{
    public partial class MainWindow : Window
    {
        // FOR READ JSON FILE ---------------------------------->>>
        private readonly string path = $"marketingDepartment.json";
        //------------------------------------------------------>>>

        Employee em = new Employee();

        public MainWindow()
        {
            InitializeComponent();

            List<string> titles = new List<string>()
            {
                "Mr",
                "Md",
                "Miss",
                "Mrs"
            };
            this.cmbTitle.ItemsSource = titles;
            this.cmbTitle1.ItemsSource = titles;

            List<string> Departments = new List<string>()
            {
                "Marketing Department",
                "Operations Department",
                "Finance Department",
                "Sales Department",
                "Human Resource Department",
                "Purchase Department"
            };
            this.cmbDepartment.ItemsSource = Departments;
            this.cmbDepartment1.ItemsSource = Departments;

            cmbDeleteDataDepartmentWise.ItemsSource = Departments;
            cmbshowDepartment.ItemsSource = Departments;

            json js = new json();
            js.cmbJson.ItemsSource = Departments;

            List<string> MarketingDepartmentsDesignations = new List<string>()
            {
                "Chief marketing officer (CMO)",
                "Creative director",
                "Marketing manager and product marketing manager",
                "Digital marketing manager",
                "Communications manager",
                "Content marketing specialist"
            };
            this.cmbDesignation.ItemsSource = MarketingDepartmentsDesignations;
            this.cmbDesignation1.ItemsSource = MarketingDepartmentsDesignations;

            List<string> OperationsDepartmentDesignations = new List<string>()
            {
                "Operations coordinator",
                "Operations analyst",
                "Operations supervisor",
                "Operations manager",
                "Project manager",
                "Program manager",
                "Operations engineer",
                "Director of operations"
            };
            this.cmbDesignation.ItemsSource = OperationsDepartmentDesignations;
            this.cmbDesignation1.ItemsSource = OperationsDepartmentDesignations;

            List<string> FinanceDepartmentDesignations = new List<string>()
            {
                "Auditor",
                "Financial analyst",
                "Finance manager",
                "Finance clerk",
                "Finance officer",
                "Chief financial officer",
                "Finance assistant",
                "Finance director"
            };
            this.cmbDesignation.ItemsSource = FinanceDepartmentDesignations;
            this.cmbDesignation1.ItemsSource = FinanceDepartmentDesignations;

            List<string> SalesDepartmentDesignations = new List<string>()
            {
                "National Sales Director",
                "Regional Sales Manager",
                "Sales Manager",
                "Inside Sales Representative",
                "Outside Sales Representative",
                "Sales Assistant",
                "Sales Engineer",
                "Wholesale and Manufacturing Sales"
            };
            this.cmbDesignation.ItemsSource = SalesDepartmentDesignations;
            this.cmbDesignation1.ItemsSource = SalesDepartmentDesignations;

            List<string> HumanResourceDepartmentDesignations = new List<string>()
            {
                "HR assistant",
                "HR representative",
                "HR administrator",
                "HR analyst",
                "HR specialist",
                "HR generalist",
                "Personnel manager",
                "HR manager"
            };
            this.cmbDesignation.ItemsSource = HumanResourceDepartmentDesignations;
            this.cmbDesignation1.ItemsSource = HumanResourceDepartmentDesignations;

            List<string> PurchaseDepartmentDesignations = new List<string>()
            {
                "Buyer",
                "Commodity Manager",
                "Procurement Director",
                "Procurement Officer",
                "Strategic Sourcing Director",
                "Purchasing Agent",
                "Materials Manager",
                "Purchasing Director"
            };
            this.cmbDesignation.ItemsSource = PurchaseDepartmentDesignations;
            this.cmbDesignation1.ItemsSource = PurchaseDepartmentDesignations;

            List<string> Menu = new List<string>()
            {
                "Insert",
                "Update",
                "Delete"
            };
            cmbMenu.ItemsSource = Menu;
            cmbMenu.SelectedItem = "Insert";
        }

        // ------------------------------------------------------------------------- FOR INSERT START -->>>
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text == "" | cmbTitle.SelectedItem == null | txtFirstName.Text == "" | txtLastName.Text == "" | txtEmail.Text == "" | txtContactNo.Text == "")
            {                
                if (txtId.Text == "")
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Missing Id", "Message", MessageBoxButton.OK);
                    if (show == MessageBoxResult.OK)
                    {
                        txtId.Focus();
                    }
                }
                else if (cmbTitle.SelectedItem == null)
                {                   
                    MessageBoxResult show;
                    show = MessageBox.Show("Missing Title", "Message", MessageBoxButton.OK);
                    if (show == MessageBoxResult.OK)
                    {
                        cmbTitle.Text = "Mr";
                    }
                }
                else if (txtFirstName.Text == "")
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Missing First Name", "Message", MessageBoxButton.OK);
                    if (show == MessageBoxResult.OK)
                    {
                        txtFirstName.Focus();
                    }
                }
                else if (txtLastName.Text == "")
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Missing Last Name", "Message", MessageBoxButton.OK);
                    if (show == MessageBoxResult.OK)
                    {
                        txtLastName.Focus();
                    }
                }
                else if (txtEmail.Text == "")
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Missing Email", "Message", MessageBoxButton.OK);
                    if (show == MessageBoxResult.OK)
                    {
                        txtEmail.Focus();
                    }
                }
                else
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Missing Contact Number", "Message", MessageBoxButton.OK);
                    if (show == MessageBoxResult.OK)
                    {
                        txtContactNo.Focus();
                    }
                }
            }
            else
            {
                try
                {
                    em.Department = cmbDepartment.SelectedItem.ToString();
                    em.Designation = cmbDesignation.SelectedItem.ToString();
                    em.Id = Convert.ToInt32(txtId.Text);
                    em.Title = cmbTitle.SelectedItem.ToString();
                    em.FirstName = txtFirstName.Text.ToString();
                    em.LastName = txtLastName.Text.ToString();
                    em.Email = txtEmail.Text.ToString();
                    em.Contact = txtContactNo.Text.ToString();

                    var newEmployeeMember = "{'Department':'" + em.Department + "','Designation':'" + em.Designation + "','Id':'" + em.Id + "','Title':'" + em.Title + "','FirstName':'" + em.FirstName + "','LastName':'" + em.LastName + "','Email':'" + em.Email + "','Contact':'" + em.Contact + "'}";      

                    if (em.Department== "Marketing Department")
                    {
                        var json = File.ReadAllText(@"marketingDepartment.json");
                        var jsonObj = JObject.Parse(json);
                        var employeeArray = jsonObj.GetValue("Employee") as JArray;

                        var newEmployee = JObject.Parse(newEmployeeMember);
                        employeeArray.Add(newEmployee);

                        jsonObj["Employee"] = employeeArray;
                        var newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
     
                        File.WriteAllText(@"marketingDepartment.json", newJsonResult); // MARKETING DEPARTMENT

                        marketingDepartmentShowData();
                        AllClear();
                        txtId.Focus();
                    }

                    else if (em.Department == "Operations Department")
                    {
                        var json = File.ReadAllText(@"operationsDepartment.json");
                        var jsonObj = JObject.Parse(json);
                        var employeeArray = jsonObj.GetValue("Employee") as JArray;

                        var newEmployee = JObject.Parse(newEmployeeMember);
                        employeeArray.Add(newEmployee);

                        jsonObj["Employee"] = employeeArray;
                        var newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);

                        File.WriteAllText(@"operationsDepartment.json", newJsonResult); // OPERATIONS DEPARTMENT

                        operationsDepartmentShowData();
                        AllClear();
                        txtId.Focus();
                    }


                    else if (em.Department == "Finance Department")
                    {
                        var json = File.ReadAllText(@"financeDepartment.json");
                        var jsonObj = JObject.Parse(json);
                        var employeeArray = jsonObj.GetValue("Employee") as JArray;

                        var newEmployee = JObject.Parse(newEmployeeMember);
                        employeeArray.Add(newEmployee);

                        jsonObj["Employee"] = employeeArray;
                        var newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);

                        File.WriteAllText(@"financeDepartment.json", newJsonResult); // FINANCE DEPARTMENT

                        financeDepartmentShowData();
                        AllClear();
                        txtId.Focus();
                    }


                    else if (em.Department == "Sales Department")
                    {
                        var json = File.ReadAllText(@"salesDepartment.json");
                        var jsonObj = JObject.Parse(json);
                        var employeeArray = jsonObj.GetValue("Employee") as JArray;

                        var newEmployee = JObject.Parse(newEmployeeMember);
                        employeeArray.Add(newEmployee);

                        jsonObj["Employee"] = employeeArray;
                        var newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);

                        File.WriteAllText(@"salesDepartment.json", newJsonResult); // SALES DEPARTMENT

                        salesDepartmentShowData();
                        AllClear();
                        txtId.Focus();
                    }

                    else if (em.Department == "Human Resource Department")
                    {
                        var json = File.ReadAllText(@"humanResourceDepartment.json");
                        var jsonObj = JObject.Parse(json);
                        var employeeArray = jsonObj.GetValue("Employee") as JArray;

                        var newEmployee = JObject.Parse(newEmployeeMember);
                        employeeArray.Add(newEmployee);

                        jsonObj["Employee"] = employeeArray;
                        var newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);

                        File.WriteAllText(@"humanResourceDepartment.json", newJsonResult); // HUMAN RESOURCE DEPARTMENT

                        humanResourceDepartmentShowData();
                        AllClear();
                        txtId.Focus();
                    }

                    else if (em.Department == "Purchase Department")
                    {
                        var json = File.ReadAllText(@"purchaseDepartment.json");
                        var jsonObj = JObject.Parse(json);
                        var employeeArray = jsonObj.GetValue("Employee") as JArray;

                        var newEmployee = JObject.Parse(newEmployeeMember);
                        employeeArray.Add(newEmployee);

                        jsonObj["Employee"] = employeeArray;
                        var newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);

                        File.WriteAllText(@"purchaseDepartment.json", newJsonResult); // HUMAN RESOURCE DEPARTMENT

                        purchaseDepartmentShowData();
                        AllClear();
                        txtId.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtId.Focus();
                }
            }
        }
        // ------------------------------------------------------------------------- FOR INSERT START -->>>



        // --------------------------------------------------------------------------------- UPDATE CLICK START -->>>
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            btnUpdate.IsEnabled = true;

            Button b = sender as Button;
            Employee empbtn = b.CommandParameter as Employee;
            int empId = empbtn.Id;

            cmbDepartment.SelectedItem = empbtn.Department;
            cmbDesignation.Text = empbtn.Designation;
            txtId.Text = empId.ToString();
            txtFirstName.Text = empbtn.FirstName.ToString();
            txtLastName.Text = empbtn.LastName.ToString();
            txtEmail.Text = empbtn.Email.ToString();
            txtContactNo.Text = empbtn.Contact.ToString();
            cmbTitle.SelectedItem = empbtn.Title.ToString();
            txtId.IsEnabled = false;           
        }
        // --------------------------------------------------------------------------------- UPDATE CLICK END -->>>



        // --------------------------------------------------------------------------------- UPDATE CLICK1 START -->>>
        private void Update_Click1(object sender, RoutedEventArgs e)
        {           
            Button b = sender as Button;
            Employee empbtn = b.CommandParameter as Employee;
            int empId = empbtn.Id;

            cmbDepartment1.SelectedItem = empbtn.Department;
            cmbDesignation1.Text = empbtn.Designation;
            txtId1.Text = empId.ToString();
            txtFirstName1.Text = empbtn.FirstName.ToString();
            txtLastName1.Text = empbtn.LastName.ToString();
            txtEmail1.Text = empbtn.Email.ToString();
            txtContactNo1.Text = empbtn.Contact.ToString();
            cmbTitle1.SelectedItem = empbtn.Title.ToString();
            txtId1.IsEnabled = false;
          
            cmbMenu.IsEnabled = false;
            btnUpdate2.IsEnabled = true;
        }
        // --------------------------------------------------------------------------------- UPDATE CLICK1 END -->>>


        // ------------------------------------------------------------------------------------------------- REFRESH START -->>>
        public void Refresh()
        {
            lstEmployee.ItemsSource = "";
        }
        public void Refresh1()
        {
            lstEmployee1.ItemsSource = "";
        }
        public void Refresh2()
        {
            lstEmployee2.ItemsSource = "";           
        }
        // ------------------------------------------------------------------------------------------------- REFRESH END -->>>



        // ------------------------------------------------------------------------------------------------- DELETE START -->>>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (em.Department == "Marketing Department")
            {
                var jsonD = File.ReadAllText(@"marketingDepartment.json");
                var jsonObj = JObject.Parse(jsonD);
                JArray empDeleteArray = (JArray)jsonObj["Employee"];

                Button b = sender as Button;
                Employee empbtn = b.CommandParameter as Employee;
                int empId = empbtn.Id;

                if (empId >= 0)
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Are You Sure???", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (show == MessageBoxResult.OK)
                    {
                        var employeeToDeleted = empDeleteArray.FirstOrDefault(obj => obj["Id"].Value<int>() == empId);
                        empDeleteArray.Remove(employeeToDeleted);

                        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                        File.WriteAllText(@"marketingDepartment.json", output);
                        AllClear();
                        Refresh();
                        marketingDepartmentShowData();
                    }
                    if (show == MessageBoxResult.Cancel)
                    {
                        AllClear();
                    }
                }
            }

            else if (em.Department == "Operations Department")
            {
                var jsonD = File.ReadAllText(@"operationsDepartment.json");
                var jsonObj = JObject.Parse(jsonD);
                JArray empDeleteArray = (JArray)jsonObj["Employee"];

                Button b = sender as Button;
                Employee empbtn = b.CommandParameter as Employee;
                int empId = empbtn.Id;

                if (empId >= 0)
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Are You Sure???", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (show == MessageBoxResult.OK)
                    {
                        var employeeToDeleted = empDeleteArray.FirstOrDefault(obj => obj["Id"].Value<int>() == empId);
                        empDeleteArray.Remove(employeeToDeleted);

                        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                        File.WriteAllText(@"operationsDepartment.json", output);
                        AllClear();
                        Refresh();
                        operationsDepartmentShowData();
                    }
                    if (show == MessageBoxResult.Cancel)
                    {
                        AllClear();
                    }
                }
            }

            else if (em.Department == "Finance Department")
            {
                var jsonD = File.ReadAllText(@"financeDepartment.json");
                var jsonObj = JObject.Parse(jsonD);
                JArray empDeleteArray = (JArray)jsonObj["Employee"];

                Button b = sender as Button;
                Employee empbtn = b.CommandParameter as Employee;
                int empId = empbtn.Id;

                if (empId >= 0)
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Are You Sure???", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (show == MessageBoxResult.OK)
                    {
                        var employeeToDeleted = empDeleteArray.FirstOrDefault(obj => obj["Id"].Value<int>() == empId);
                        empDeleteArray.Remove(employeeToDeleted);

                        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                        File.WriteAllText(@"financeDepartment.json", output);
                        AllClear();
                        Refresh();
                        financeDepartmentShowData();
                    }
                    if (show == MessageBoxResult.Cancel)
                    {
                        AllClear();
                    }
                }
            }

            else if (em.Department == "Human Resource Department")
            {
                var jsonD = File.ReadAllText(@"humanResourceDepartment.json");
                var jsonObj = JObject.Parse(jsonD);
                JArray empDeleteArray = (JArray)jsonObj["Employee"];

                Button b = sender as Button;
                Employee empbtn = b.CommandParameter as Employee;
                int empId = empbtn.Id;

                if (empId >= 0)
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Are You Sure???", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (show == MessageBoxResult.OK)
                    {
                        var employeeToDeleted = empDeleteArray.FirstOrDefault(obj => obj["Id"].Value<int>() == empId);
                        empDeleteArray.Remove(employeeToDeleted);

                        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                        File.WriteAllText(@"humanResourceDepartment.json", output);
                        AllClear();
                        Refresh();
                        humanResourceDepartmentShowData();
                    }
                    if (show == MessageBoxResult.Cancel)
                    {
                        AllClear();
                    }
                }
            }

            else if (em.Department == "Sales Department")
            {
                var jsonD = File.ReadAllText(@"salesDepartment.json");
                var jsonObj = JObject.Parse(jsonD);
                JArray empDeleteArray = (JArray)jsonObj["Employee"];

                Button b = sender as Button;
                Employee empbtn = b.CommandParameter as Employee;
                int empId = empbtn.Id;

                if (empId >= 0)
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Are You Sure???", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (show == MessageBoxResult.OK)
                    {
                        var employeeToDeleted = empDeleteArray.FirstOrDefault(obj => obj["Id"].Value<int>() == empId);
                        empDeleteArray.Remove(employeeToDeleted);

                        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                        File.WriteAllText(@"salesDepartment.json", output);
                        AllClear();
                        Refresh();
                        salesDepartmentShowData();
                    }
                    if (show == MessageBoxResult.Cancel)
                    {
                        AllClear();
                    }
                }
            }

            else if (em.Department == "Purchase Department")
            {
                var jsonD = File.ReadAllText(@"purchaseDepartment.json");
                var jsonObj = JObject.Parse(jsonD);
                JArray empDeleteArray = (JArray)jsonObj["Employee"];

                Button b = sender as Button;
                Employee empbtn = b.CommandParameter as Employee;
                int empId = empbtn.Id;

                if (empId >= 0)
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Are You Sure???", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (show == MessageBoxResult.OK)
                    {
                        var employeeToDeleted = empDeleteArray.FirstOrDefault(obj => obj["Id"].Value<int>() == empId);
                        empDeleteArray.Remove(employeeToDeleted);

                        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                        File.WriteAllText(@"purchaseDepartment.json", output);
                        AllClear();
                        Refresh();
                        purchaseDepartmentShowData();
                    }
                    if (show == MessageBoxResult.Cancel)
                    {
                        AllClear();
                    }
                }
            }
        }
        // ------------------------------------------------------------------------------------------------- DELETE END -->>>

        

        // DATA SHOW ----- MARKETING DEPARTMENT ------------------------------------------------------------------------ START ----->>>
        public void marketingDepartmentShowData()
        {
            var json = File.ReadAllText(@"marketingDepartment.json");
            var jsonObj = JObject.Parse(json);
            if (jsonObj != null)
            {
                JArray epmArray = (JArray)jsonObj["Employee"];
                List<Employee> emp1 = new List<Employee>();

                foreach (var item in epmArray)
                {
                    emp1.Add(new Employee()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        Title = item["Title"].ToString(),
                        FirstName = item["FirstName"].ToString(),
                        LastName = item["LastName"].ToString(),
                        Email = item["Email"].ToString(),
                        Contact = item["Contact"].ToString(),
                        Department = item["Department"].ToString(),
                        Designation = item["Designation"].ToString(),
                        Json = item.ToString()
                    });

                    if (json != null)
                    {
                        if (cmbMenu.SelectedItem.ToString() == "Insert")
                        {
                            lstEmployee.ItemsSource = emp1;
                        }
                        else if (cmbMenu.SelectedItem.ToString() == "Update")
                        {
                            if (cmbshowDepartment.SelectedItem.ToString() == "Marketing Department")
                            {
                                lstEmployee1.ItemsSource = emp1;
                            }
                        }
                        else if (cmbMenu.SelectedItem.ToString() == "Delete")
                        {
                            if (cmbDeleteDataDepartmentWise.SelectedItem.ToString() == "Marketing Department")
                            {                               
                                lstEmployee2.ItemsSource = emp1;
                            }
                        }
                    }
                }
                lstEmployee.Items.Refresh();
                lstEmployee1.Items.Refresh();
                lstEmployee2.Items.Refresh();
            }
        }
        public void marketingDepartmentShowData2()
        {
            var json = File.ReadAllText(@"marketingDepartment.json");
            var jsonObj = JObject.Parse(json);
            if (jsonObj != null)
            {
                JArray epmArray = (JArray)jsonObj["Employee"];
                List<Employee> emp1 = new List<Employee>();

                foreach (var item in epmArray)
                {
                    emp1.Add(new Employee()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        Title = item["Title"].ToString(),
                        FirstName = item["FirstName"].ToString(),
                        LastName = item["LastName"].ToString(),
                        Email = item["Email"].ToString(),
                        Contact = item["Contact"].ToString(),
                        Department = item["Department"].ToString(),
                        Designation = item["Designation"].ToString(),
                        Json = item.ToString()
                    });

                    if (json != null)
                    {
                        lstEmployee2.ItemsSource = emp1;
                    }
                }
                lstEmployee2.Items.Refresh();
            }
        }

        // DATA SHOW ----- MARKETING DEPARTMENT ------------------------------------------------------------------------ END ----->>>


        // DATA SHOW ----- OPERATIONS DEPARTMENT ------------------------------------------------------------------------ START ----->>>
        public void operationsDepartmentShowData()
        {
            var json = File.ReadAllText(@"operationsDepartment.json");
            var jsonObj = JObject.Parse(json);
            if (jsonObj != null)
            {
                JArray epmArray = (JArray)jsonObj["Employee"];
                List<Employee> emp1 = new List<Employee>();

                foreach (var item in epmArray)
                {
                    emp1.Add(new Employee()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        Title = item["Title"].ToString(),
                        FirstName = item["FirstName"].ToString(),
                        LastName = item["LastName"].ToString(),
                        Email = item["Email"].ToString(),
                        Contact = item["Contact"].ToString(),
                        Department = item["Department"].ToString(),
                        Designation = item["Designation"].ToString(),
                        Json = item.ToString()
                    });

                    if (json != null)
                    {
                        if (cmbMenu.SelectedItem.ToString()=="Insert")
                        {
                            lstEmployee.ItemsSource = emp1;
                        }
                        else if (cmbMenu.SelectedItem.ToString() == "Update")
                        {
                            if (cmbshowDepartment.SelectedItem.ToString() == "Operations Department")
                            {
                                lstEmployee1.ItemsSource = emp1;
                            }
                        }
                        else if (cmbMenu.SelectedItem.ToString() == "Delete")
                        {
                            if (cmbDeleteDataDepartmentWise.SelectedItem.ToString()=="Operations Department")
                            {
                                lstEmployee2.ItemsSource = emp1;
                            }
                        }                 
                    }
                }
                lstEmployee.Items.Refresh();
                lstEmployee1.Items.Refresh();
                lstEmployee2.Items.Refresh();
            }
        }

        public void operationsDepartmentShowData2()
        {
            var json = File.ReadAllText(@"operationsDepartment.json");
            var jsonObj = JObject.Parse(json);
            if (jsonObj != null)
            {
                JArray epmArray = (JArray)jsonObj["Employee"];
                List<Employee> emp1 = new List<Employee>();

                foreach (var item in epmArray)
                {
                    emp1.Add(new Employee()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        Title = item["Title"].ToString(),
                        FirstName = item["FirstName"].ToString(),
                        LastName = item["LastName"].ToString(),
                        Email = item["Email"].ToString(),
                        Contact = item["Contact"].ToString(),
                        Department = item["Department"].ToString(),
                        Designation = item["Designation"].ToString(),
                        Json = item.ToString()
                    });

                    if (json != null)
                    {
                        lstEmployee2.ItemsSource = emp1;
                    }
                }               
                lstEmployee2.Items.Refresh();
            }
        }

        // DATA SHOW ----- OPERATIONS DEPARTMENT ------------------------------------------------------------------------ END ----->>>


        // DATA SHOW ----- FINANCE DEPARTMENT ------------------------------------------------------------------------ START ----->>>
        public void financeDepartmentShowData()
        {
            var json = File.ReadAllText(@"financeDepartment.json");
            var jsonObj = JObject.Parse(json);
            if (jsonObj != null)
            {
                JArray epmArray = (JArray)jsonObj["Employee"];
                List<Employee> emp1 = new List<Employee>();

                foreach (var item in epmArray)
                {
                    emp1.Add(new Employee()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        Title = item["Title"].ToString(),
                        FirstName = item["FirstName"].ToString(),
                        LastName = item["LastName"].ToString(),
                        Email = item["Email"].ToString(),
                        Contact = item["Contact"].ToString(),
                        Department = item["Department"].ToString(),
                        Designation = item["Designation"].ToString(),
                        Json = item.ToString()
                    });

                    if (json != null)
                    {
                        if (cmbMenu.SelectedItem.ToString() == "Insert")
                        {
                            lstEmployee.ItemsSource = emp1;
                        }
                        else if (cmbMenu.SelectedItem.ToString() == "Update")
                        {
                            if (cmbshowDepartment.SelectedItem.ToString() == "Finance Department")
                            {
                                lstEmployee1.ItemsSource = emp1;
                            }
                        }
                        else if (cmbMenu.SelectedItem.ToString() == "Delete")
                        {
                            if (cmbDeleteDataDepartmentWise.SelectedItem.ToString() == "Finance Department")
                            {
                                lstEmployee2.ItemsSource = emp1;
                            }
                        }
                    }
                }
                lstEmployee.Items.Refresh();
                lstEmployee1.Items.Refresh();
                lstEmployee2.Items.Refresh();
            }
        }

        public void financeDepartmentShowData2()
        {
            var json = File.ReadAllText(@"financeDepartment.json");
            var jsonObj = JObject.Parse(json);
            if (jsonObj != null)
            {
                JArray epmArray = (JArray)jsonObj["Employee"];
                List<Employee> emp1 = new List<Employee>();

                foreach (var item in epmArray)
                {
                    emp1.Add(new Employee()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        Title = item["Title"].ToString(),
                        FirstName = item["FirstName"].ToString(),
                        LastName = item["LastName"].ToString(),
                        Email = item["Email"].ToString(),
                        Contact = item["Contact"].ToString(),
                        Department = item["Department"].ToString(),
                        Designation = item["Designation"].ToString(),
                        Json = item.ToString()
                    });

                    if (json != null)
                    {
                        lstEmployee2.ItemsSource = emp1;
                    }
                }
                lstEmployee2.Items.Refresh();
            }
        }
        // DATA SHOW ----- FINANCE DEPARTMENT ------------------------------------------------------------------------ END ----->>>


        // DATA SHOW ----- SALES DEPARTMENT ------------------------------------------------------------------------ START ----->>>
        public void salesDepartmentShowData()
        {
            var json = File.ReadAllText(@"salesDepartment.json");
            var jsonObj = JObject.Parse(json);
            if (jsonObj != null)
            {
                JArray epmArray = (JArray)jsonObj["Employee"];
                List<Employee> emp1 = new List<Employee>();

                foreach (var item in epmArray)
                {
                    emp1.Add(new Employee()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        Title = item["Title"].ToString(),
                        FirstName = item["FirstName"].ToString(),
                        LastName = item["LastName"].ToString(),
                        Email = item["Email"].ToString(),
                        Contact = item["Contact"].ToString(),
                        Department = item["Department"].ToString(),
                        Designation = item["Designation"].ToString(),
                        Json = item.ToString()
                    });

                    if (json != null)
                    {
                        if (cmbMenu.SelectedItem.ToString() == "Insert")
                        {
                            lstEmployee.ItemsSource = emp1;
                        }
                        else if (cmbMenu.SelectedItem.ToString() == "Update")
                        {
                            if (cmbshowDepartment.SelectedItem.ToString() == "Sales Department")
                            {
                                lstEmployee1.ItemsSource = emp1;
                            }
                        }
                        else if (cmbMenu.SelectedItem.ToString() == "Delete")
                        {
                            if (cmbDeleteDataDepartmentWise.SelectedItem.ToString() == "Sales Department")
                            {
                                lstEmployee2.ItemsSource = emp1;
                            }
                        }
                    }
                }
                lstEmployee.Items.Refresh();
                lstEmployee1.Items.Refresh();
                lstEmployee2.Items.Refresh();
            }
        }

        public void salesDepartmentShowData2()
        {
            var json = File.ReadAllText(@"salesDepartment.json");
            var jsonObj = JObject.Parse(json);
            if (jsonObj != null)
            {
                JArray epmArray = (JArray)jsonObj["Employee"];
                List<Employee> emp1 = new List<Employee>();

                foreach (var item in epmArray)
                {
                    emp1.Add(new Employee()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        Title = item["Title"].ToString(),
                        FirstName = item["FirstName"].ToString(),
                        LastName = item["LastName"].ToString(),
                        Email = item["Email"].ToString(),
                        Contact = item["Contact"].ToString(),
                        Department = item["Department"].ToString(),
                        Designation = item["Designation"].ToString(),
                        Json = item.ToString()
                    });

                    if (json != null)
                    {
                        lstEmployee2.ItemsSource = emp1;
                    }
                }
                lstEmployee2.Items.Refresh();
            }
        }
        // DATA SHOW ----- SALES DEPARTMENT ------------------------------------------------------------------------ END ----->>>


        // DATA SHOW ----- HUMAN RESOURCE DEPARTMENT ------------------------------------------------------------------------ START ----->>>
        public void humanResourceDepartmentShowData()
        {
            var json = File.ReadAllText(@"humanResourceDepartment.json");
            var jsonObj = JObject.Parse(json);
            if (jsonObj != null)
            {
                JArray epmArray = (JArray)jsonObj["Employee"];
                List<Employee> emp1 = new List<Employee>();

                foreach (var item in epmArray)
                {
                    emp1.Add(new Employee()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        Title = item["Title"].ToString(),
                        FirstName = item["FirstName"].ToString(),
                        LastName = item["LastName"].ToString(),
                        Email = item["Email"].ToString(),
                        Contact = item["Contact"].ToString(),
                        Department = item["Department"].ToString(),
                        Designation = item["Designation"].ToString(),
                        Json = item.ToString()
                    });

                    if (json != null)
                    {
                        if (cmbMenu.SelectedItem.ToString() == "Insert")
                        {
                            lstEmployee.ItemsSource = emp1;
                        }
                        else if (cmbMenu.SelectedItem.ToString() == "Update")
                        {
                            if (cmbshowDepartment.SelectedItem.ToString() == "Human Resource Department")
                            {
                                lstEmployee1.ItemsSource = emp1;
                            }
                        }
                        else if (cmbMenu.SelectedItem.ToString() == "Delete")
                        {
                            if (cmbDeleteDataDepartmentWise.SelectedItem.ToString() == "Human Resource Department")
                            {
                                lstEmployee2.ItemsSource = emp1;
                            }
                        }
                    }
                }
                lstEmployee.Items.Refresh();
                lstEmployee1.Items.Refresh();
                lstEmployee2.Items.Refresh();
            }
        }

        public void humanResourceDepartmentShowData2()
        {
            var json = File.ReadAllText(@"humanResourceDepartment.json");
            var jsonObj = JObject.Parse(json);
            if (jsonObj != null)
            {
                JArray epmArray = (JArray)jsonObj["Employee"];
                List<Employee> emp1 = new List<Employee>();

                foreach (var item in epmArray)
                {
                    emp1.Add(new Employee()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        Title = item["Title"].ToString(),
                        FirstName = item["FirstName"].ToString(),
                        LastName = item["LastName"].ToString(),
                        Email = item["Email"].ToString(),
                        Contact = item["Contact"].ToString(),
                        Department = item["Department"].ToString(),
                        Designation = item["Designation"].ToString(),
                        Json = item.ToString()
                    });

                    if (json != null)
                    {
                        lstEmployee2.ItemsSource = emp1;
                    }
                }
                lstEmployee2.Items.Refresh();
            }
        }
        // DATA SHOW ----- HUMAN RESOURCE DEPARTMENT ------------------------------------------------------------------------ END ----->>>


        // DATA SHOW ----- PURCHASE DEPARTMENT ------------------------------------------------------------------------ START ----->>>
        public void purchaseDepartmentShowData()
        {
            var json = File.ReadAllText(@"purchaseDepartment.json");
            var jsonObj = JObject.Parse(json);
            if (jsonObj != null)
            {
                JArray epmArray = (JArray)jsonObj["Employee"];
                List<Employee> emp1 = new List<Employee>();

                foreach (var item in epmArray)
                {
                    emp1.Add(new Employee()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        Title = item["Title"].ToString(),
                        FirstName = item["FirstName"].ToString(),
                        LastName = item["LastName"].ToString(),
                        Email = item["Email"].ToString(),
                        Contact = item["Contact"].ToString(),
                        Department = item["Department"].ToString(),
                        Designation = item["Designation"].ToString(),
                        Json = item.ToString()
                    });

                    if (json != null)
                    {
                        if (cmbMenu.SelectedItem.ToString() == "Insert")
                        {
                            lstEmployee.ItemsSource = emp1;
                        }
                        else if (cmbMenu.SelectedItem.ToString() == "Update")
                        {
                            if (cmbshowDepartment.SelectedItem.ToString() == "Purchase Department")
                            {
                                lstEmployee1.ItemsSource = emp1;
                            }
                        }
                        else if (cmbMenu.SelectedItem.ToString() == "Delete")
                        {
                            if (cmbDeleteDataDepartmentWise.SelectedItem.ToString() == "Purchase Department")
                            {
                                lstEmployee2.ItemsSource = emp1;
                            }
                        }
                    }
                }
                lstEmployee.Items.Refresh();
                lstEmployee1.Items.Refresh();
                lstEmployee2.Items.Refresh();
            }
        }

        public void purchaseDepartmentShowData2()
        {
            var json = File.ReadAllText(@"purchaseDepartment.json");
            var jsonObj = JObject.Parse(json);
            if (jsonObj != null)
            {
                JArray epmArray = (JArray)jsonObj["Employee"];
                List<Employee> emp1 = new List<Employee>();

                foreach (var item in epmArray)
                {
                    emp1.Add(new Employee()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        Title = item["Title"].ToString(),
                        FirstName = item["FirstName"].ToString(),
                        LastName = item["LastName"].ToString(),
                        Email = item["Email"].ToString(),
                        Contact = item["Contact"].ToString(),
                        Department = item["Department"].ToString(),
                        Designation = item["Designation"].ToString(),
                        Json = item.ToString()
                    });

                    if (json != null)
                    {
                        lstEmployee2.ItemsSource = emp1;
                    }
                }
                lstEmployee2.Items.Refresh();
            }
        }
        // DATA SHOW ----- PURCHASE DEPARTMENT ------------------------------------------------------------------------ END ----->>>


        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string jsonFromFile;
                using (var reader = new StreamReader(path))
                {
                    jsonFromFile = reader.ReadToEnd();
                }
                json j = new json();
                j.text.Text = jsonFromFile;
                var employeeFromJson = JsonConvert.DeserializeObject<Employee>(jsonFromFile);

                this.Hide();
                j.Show();
            }

            catch (Exception)
            {
                Console.WriteLine("The File Could Not Be Read");             
            }
        }


        // ----------------------------------------------------------------------------------- UPDATE START -->>>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (em.Department=="Marketing Department")
            {               
                var jsonU = File.ReadAllText(@"marketingDepartment.json");
                var jsonObj = JObject.Parse(jsonU);
                JArray empUpdateArray = (JArray)jsonObj["Employee"];

                var DepartmentUp = cmbDepartment.SelectedItem.ToString();
                var DesignationUp = cmbDesignation.SelectedItem.ToString();
                var Id = Convert.ToInt32(txtId.Text);
                var Title = cmbTitle.SelectedItem.ToString();
                var FirstName = txtFirstName.Text;
                var LastName = txtLastName.Text;
                var Email = txtEmail.Text;
                var Contact = txtContactNo.Text;

                MessageBoxResult result;
                result = MessageBox.Show("Are You Sure???", "Update", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var employee in empUpdateArray.Where(obj => obj["Id"].Value<int>() == Id))
                    {
                        employee["Department"] = !string.IsNullOrEmpty(DepartmentUp) ? DepartmentUp : "";
                        employee["Designation"] = !string.IsNullOrEmpty(DesignationUp) ? DesignationUp : "";

                        employee["Title"] = !string.IsNullOrEmpty(Title) ? Title : "";
                        employee["FirstName"] = !string.IsNullOrEmpty(FirstName) ? FirstName : "";
                        employee["LastName"] = !string.IsNullOrEmpty(LastName) ? LastName : "";
                        employee["Email"] = !string.IsNullOrEmpty(Email) ? Email : "";
                        employee["Contact"] = !string.IsNullOrEmpty(Contact) ? Contact : "";
                    }
                    jsonObj["Employee"] = empUpdateArray;
                    string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.WriteAllText(@"marketingDepartment.json", output);

                    marketingDepartmentShowData();

                    AllClear();
                    btnUpdate.IsEnabled = false;

                    MessageBox.Show("Successful", "Update");
                }
                if (result == MessageBoxResult.No)
                {
                    AllClear();
                    btnUpdate.IsEnabled = false;
                }
            }

            else if (em.Department == "Operations Department")
            {
                var jsonU = File.ReadAllText(@"operationsDepartment.json");
                var jsonObj = JObject.Parse(jsonU);
                JArray empUpdateArray = (JArray)jsonObj["Employee"];

                var DepartmentUp = cmbDepartment.SelectedItem.ToString();
                var DesignationUp = cmbDesignation.SelectedItem.ToString();
                var Id = Convert.ToInt32(txtId.Text);
                var Title = cmbTitle.SelectedItem.ToString();
                var FirstName = txtFirstName.Text;
                var LastName = txtLastName.Text;
                var Email = txtEmail.Text;
                var Contact = txtContactNo.Text;

                MessageBoxResult result;
                result = MessageBox.Show("Are You Sure???", "Update", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var employee in empUpdateArray.Where(obj => obj["Id"].Value<int>() == Id))
                    {
                        employee["Department"] = !string.IsNullOrEmpty(DepartmentUp) ? DepartmentUp : "";
                        employee["Designation"] = !string.IsNullOrEmpty(DesignationUp) ? DesignationUp : "";

                        employee["Title"] = !string.IsNullOrEmpty(Title) ? Title : "";
                        employee["FirstName"] = !string.IsNullOrEmpty(FirstName) ? FirstName : "";
                        employee["LastName"] = !string.IsNullOrEmpty(LastName) ? LastName : "";
                        employee["Email"] = !string.IsNullOrEmpty(Email) ? Email : "";
                        employee["Contact"] = !string.IsNullOrEmpty(Contact) ? Contact : "";
                    }
                    jsonObj["Employee"] = empUpdateArray;
                    string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.WriteAllText(@"operationsDepartment.json", output);

                    operationsDepartmentShowData();

                    AllClear();
                    btnUpdate.IsEnabled = false;

                    MessageBox.Show("Successful", "Update");
                }
                if (result == MessageBoxResult.No)
                {
                    AllClear();
                    btnUpdate.IsEnabled = false;
                }
            }

            else if (em.Department == "Finance Department")
            {
                var jsonU = File.ReadAllText(@"financeDepartment.json");
                var jsonObj = JObject.Parse(jsonU);
                JArray empUpdateArray = (JArray)jsonObj["Employee"];

                var DepartmentUp = cmbDepartment.SelectedItem.ToString();
                var DesignationUp = cmbDesignation.SelectedItem.ToString();
                var Id = Convert.ToInt32(txtId.Text);
                var Title = cmbTitle.SelectedItem.ToString();
                var FirstName = txtFirstName.Text;
                var LastName = txtLastName.Text;
                var Email = txtEmail.Text;
                var Contact = txtContactNo.Text;

                MessageBoxResult result;
                result = MessageBox.Show("Are You Sure???", "Update", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var employee in empUpdateArray.Where(obj => obj["Id"].Value<int>() == Id))
                    {
                        employee["Department"] = !string.IsNullOrEmpty(DepartmentUp) ? DepartmentUp : "";
                        employee["Designation"] = !string.IsNullOrEmpty(DesignationUp) ? DesignationUp : "";

                        employee["Title"] = !string.IsNullOrEmpty(Title) ? Title : "";
                        employee["FirstName"] = !string.IsNullOrEmpty(FirstName) ? FirstName : "";
                        employee["LastName"] = !string.IsNullOrEmpty(LastName) ? LastName : "";
                        employee["Email"] = !string.IsNullOrEmpty(Email) ? Email : "";
                        employee["Contact"] = !string.IsNullOrEmpty(Contact) ? Contact : "";
                    }
                    jsonObj["Employee"] = empUpdateArray;
                    string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.WriteAllText(@"financeDepartment.json", output);

                    financeDepartmentShowData();

                    AllClear();
                    btnUpdate.IsEnabled = false;

                    MessageBox.Show("Successful", "Update");
                }
                if (result == MessageBoxResult.No)
                {
                    AllClear();
                    btnUpdate.IsEnabled = false;
                }
            }

            else if (em.Department == "Sales Department")
            {
                var jsonU = File.ReadAllText(@"salesDepartment.json");
                var jsonObj = JObject.Parse(jsonU);
                JArray empUpdateArray = (JArray)jsonObj["Employee"];

                var DepartmentUp = cmbDepartment.SelectedItem.ToString();
                var DesignationUp = cmbDesignation.SelectedItem.ToString();
                var Id = Convert.ToInt32(txtId.Text);
                var Title = cmbTitle.SelectedItem.ToString();
                var FirstName = txtFirstName.Text;
                var LastName = txtLastName.Text;
                var Email = txtEmail.Text;
                var Contact = txtContactNo.Text;

                MessageBoxResult result;
                result = MessageBox.Show("Are You Sure???", "Update", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var employee in empUpdateArray.Where(obj => obj["Id"].Value<int>() == Id))
                    {
                        employee["Department"] = !string.IsNullOrEmpty(DepartmentUp) ? DepartmentUp : "";
                        employee["Designation"] = !string.IsNullOrEmpty(DesignationUp) ? DesignationUp : "";

                        employee["Title"] = !string.IsNullOrEmpty(Title) ? Title : "";
                        employee["FirstName"] = !string.IsNullOrEmpty(FirstName) ? FirstName : "";
                        employee["LastName"] = !string.IsNullOrEmpty(LastName) ? LastName : "";
                        employee["Email"] = !string.IsNullOrEmpty(Email) ? Email : "";
                        employee["Contact"] = !string.IsNullOrEmpty(Contact) ? Contact : "";
                    }
                    jsonObj["Employee"] = empUpdateArray;
                    string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.WriteAllText(@"salesDepartment.json", output);

                    salesDepartmentShowData();

                    AllClear();
                    btnUpdate.IsEnabled = false;

                    MessageBox.Show("Successful", "Update");
                }
                if (result == MessageBoxResult.No)
                {
                    AllClear();
                    btnUpdate.IsEnabled = false;
                }
            }

            else if (em.Department == "Human Resource Department")
            {
                var jsonU = File.ReadAllText(@"humanResourceDepartment.json");
                var jsonObj = JObject.Parse(jsonU);
                JArray empUpdateArray = (JArray)jsonObj["Employee"];

                var DepartmentUp = cmbDepartment.SelectedItem.ToString();
                var DesignationUp = cmbDesignation.SelectedItem.ToString();
                var Id = Convert.ToInt32(txtId.Text);
                var Title = cmbTitle.SelectedItem.ToString();
                var FirstName = txtFirstName.Text;
                var LastName = txtLastName.Text;
                var Email = txtEmail.Text;
                var Contact = txtContactNo.Text;

                MessageBoxResult result;
                result = MessageBox.Show("Are You Sure???", "Update", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var employee in empUpdateArray.Where(obj => obj["Id"].Value<int>() == Id))
                    {
                        employee["Department"] = !string.IsNullOrEmpty(DepartmentUp) ? DepartmentUp : "";
                        employee["Designation"] = !string.IsNullOrEmpty(DesignationUp) ? DesignationUp : "";

                        employee["Title"] = !string.IsNullOrEmpty(Title) ? Title : "";
                        employee["FirstName"] = !string.IsNullOrEmpty(FirstName) ? FirstName : "";
                        employee["LastName"] = !string.IsNullOrEmpty(LastName) ? LastName : "";
                        employee["Email"] = !string.IsNullOrEmpty(Email) ? Email : "";
                        employee["Contact"] = !string.IsNullOrEmpty(Contact) ? Contact : "";
                    }
                    jsonObj["Employee"] = empUpdateArray;
                    string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.WriteAllText(@"humanResourceDepartment.json", output);

                    humanResourceDepartmentShowData();

                    AllClear();
                    btnUpdate.IsEnabled = false;

                    MessageBox.Show("Successful", "Update");
                }
                if (result == MessageBoxResult.No)
                {
                    AllClear();
                    btnUpdate.IsEnabled = false;
                }
            }

            else if (em.Department == "Purchase Department")
            {
                var jsonU = File.ReadAllText(@"purchaseDepartment.json");
                var jsonObj = JObject.Parse(jsonU);
                JArray empUpdateArray = (JArray)jsonObj["Employee"];

                var DepartmentUp = cmbDepartment.SelectedItem.ToString();
                var DesignationUp = cmbDesignation.SelectedItem.ToString();
                var Id = Convert.ToInt32(txtId.Text);
                var Title = cmbTitle.SelectedItem.ToString();
                var FirstName = txtFirstName.Text;
                var LastName = txtLastName.Text;
                var Email = txtEmail.Text;
                var Contact = txtContactNo.Text;

                MessageBoxResult result;
                result = MessageBox.Show("Are You Sure???", "Update", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var employee in empUpdateArray.Where(obj => obj["Id"].Value<int>() == Id))
                    {
                        employee["Department"] = !string.IsNullOrEmpty(DepartmentUp) ? DepartmentUp : "";
                        employee["Designation"] = !string.IsNullOrEmpty(DesignationUp) ? DesignationUp : "";

                        employee["Title"] = !string.IsNullOrEmpty(Title) ? Title : "";
                        employee["FirstName"] = !string.IsNullOrEmpty(FirstName) ? FirstName : "";
                        employee["LastName"] = !string.IsNullOrEmpty(LastName) ? LastName : "";
                        employee["Email"] = !string.IsNullOrEmpty(Email) ? Email : "";
                        employee["Contact"] = !string.IsNullOrEmpty(Contact) ? Contact : "";
                    }
                    jsonObj["Employee"] = empUpdateArray;
                    string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.WriteAllText(@"purchaseDepartment.json", output);

                    purchaseDepartmentShowData();

                    AllClear();
                    btnUpdate.IsEnabled = false;

                    MessageBox.Show("Successful", "Update");
                }
                if (result == MessageBoxResult.No)
                {
                    AllClear();
                    btnUpdate.IsEnabled = false;
                }
            }
        }
        // ----------------------------------------------------------------------------------- UPDATE END -->>>



        //----------------------------------------------------------------------------------- ALL_CLEAR START -->>>
        private void AllClear()
        {
            txtId.Clear();
            cmbDepartment.SelectedIndex = -1;
            cmbDesignation.SelectedIndex = -1;
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtContactNo.Clear();
            cmbTitle.SelectedIndex = -1;
            txtId.IsEnabled = true;
        }
        //----------------------------------------------------------------------------------- ALL_CLEAR END -->>>


        //----------------------------------------------------------------------------------- ALL_CLEAR2 START -->>>
        private void AllClear2()
        {
            cmbDepartment1.SelectedIndex = -1;
            cmbDesignation1.SelectedIndex = -1;
            txtId1.Text = "";
            txtFirstName1.Text = "";
            txtLastName1.Text = "";
            txtEmail1.Text ="";
            txtContactNo1.Text = "";
            cmbTitle1.SelectedItem = null;          
        }
        //----------------------------------------------------------------------------------- ALL_CLEAR2 END -->>>


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtId.Focus();            
        }

        //----------------------------------------------------------------------------------- WINDOW CLOSING START -->>>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Exit Store App", "Are You Sure???", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                MainWindow m = new MainWindow();
                m.Show();
            }
        }
        //----------------------------------------------------------------------------------- WINDOW CLOSING END -->>>


        //----------------------------------------------------------------------------------- BTN_INSERT START -->>>
        private void btnInsert_MouseEnter(object sender, MouseEventArgs e)
        {
            if (txtId.Text == "" | cmbTitle.SelectedItem == null | txtFirstName.Text == "" | txtLastName.Text == "" | txtEmail.Text == "" | txtContactNo.Text == "")
            {
                
                if (txtId.Text == "")
                {
                    MessageBox.Show("Missing Id", "Message", MessageBoxButton.OK);
                    txtId.Focus();
                }                       
                else if (cmbTitle.SelectedItem == null)
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Missing Title", "Message", MessageBoxButton.OK);
                    if (show == MessageBoxResult.OK)
                    {
                        cmbTitle.Text = "Mr";
                    }
                }
                else if (txtFirstName.Text == "")
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Missing First Name", "Message", MessageBoxButton.OK);
                    if (show == MessageBoxResult.OK)
                    {
                        txtFirstName.Focus();
                    }
                }
                else if (txtLastName.Text == "")
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Missing Last Name", "Message", MessageBoxButton.OK);
                    if (show == MessageBoxResult.OK)
                    {
                        txtLastName.Focus();
                    }
                }
                else if (txtEmail.Text == "")
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Missing Email", "Message", MessageBoxButton.OK);
                    if (show == MessageBoxResult.OK)
                    {
                        txtEmail.Focus();
                    }
                }
                else if (txtContactNo.Text == "")
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Missing Contact Number", "Message", MessageBoxButton.OK);
                    if (show == MessageBoxResult.OK)
                    {
                        txtContactNo.Focus();
                    }
                }
            }
        }
        //----------------------------------------------------------------------------------- BTN_INSERT END -->>>



        // FOR INSERT --- DESIGNATIONS --------------------------------------------------------------------------- START ----->>>
        private void cmbDepartment_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            List<string> MarketingDepartmentsDesignations = new List<string>()
            {
                "Chief marketing officer (CMO)",
                "Creative director",
                "Marketing manager and product marketing manager",
                "Digital marketing manager",
                "Communications manager",
                "Content marketing specialist"
            };

            List<string> OperationsDepartmentDesignations = new List<string>()
            {
                "Operations coordinator",
                "Operations analyst",
                "Operations supervisor",
                "Operations manager",
                "Project manager",
                "Program manager",
                "Operations engineer",
                "Director of operations"
            };

            List<string> FinanceDepartmentDesignations = new List<string>()
            {
                "Auditor",
                "Financial analyst",
                "Finance manager",
                "Finance clerk",
                "Finance officer",
                "Chief financial officer",
                "Finance assistant",
                "Finance director"
            };

            List<string> SalesDepartmentDesignations = new List<string>()
            {
                "National Sales Director",
                "Regional Sales Manager",
                "Sales Manager",
                "Inside Sales Representative",
                "Outside Sales Representative",
                "Sales Assistant",
                "Sales Engineer",
                "Wholesale and Manufacturing Sales"
            };

            List<string> HumanResourceDepartmentDesignations = new List<string>()
            {
                "HR assistant",
                "HR representative",
                "HR administrator",
                "HR analyst",
                "HR specialist",
                "HR generalist",
                "Personnel manager",
                "HR manager"
            };

            List<string> PurchaseDepartmentDesignations = new List<string>()
            {
                "Buyer",
                "Commodity Manager",
                "Procurement Director",
                "Procurement Officer",
                "Strategic Sourcing Director",
                "Purchasing Agent",
                "Materials Manager",
                "Purchasing Director"
            };

            if (cmbDepartment.Text == "Marketing Department")
            {
                cmbDesignation.SelectedIndex = -1;
                cmbDesignation.ItemsSource = MarketingDepartmentsDesignations;
                cmbDesignation1.ItemsSource = MarketingDepartmentsDesignations;

                cmbDesignation.SelectedItem = "Content marketing specialist";
            }

            else if (cmbDepartment.Text == "Operations Department")
            {
                cmbDesignation.ItemsSource = OperationsDepartmentDesignations;
                cmbDesignation1.ItemsSource = OperationsDepartmentDesignations;

                cmbDesignation.SelectedItem = "Operations coordinator";
            }
            else if (cmbDepartment.Text == "Finance Department")
            {
                cmbDesignation.ItemsSource = FinanceDepartmentDesignations;
                cmbDesignation1.ItemsSource = FinanceDepartmentDesignations;

                cmbDesignation.SelectedItem = "Chief financial officer";
            }
            else if (cmbDepartment.Text == "Sales Department")
            {
                cmbDesignation.ItemsSource = SalesDepartmentDesignations;
                cmbDesignation1.ItemsSource = SalesDepartmentDesignations;

                cmbDesignation.SelectedItem = "Sales Engineer";
            }
            else if (cmbDepartment.Text == "Human Resource Department")
            {
                cmbDesignation.ItemsSource = HumanResourceDepartmentDesignations;
                cmbDesignation1.ItemsSource = HumanResourceDepartmentDesignations;

                cmbDesignation.SelectedItem = "HR manager";
            }
            else if (cmbDepartment.Text == "Purchase Department")
            {
                cmbDesignation.ItemsSource = PurchaseDepartmentDesignations;
                cmbDesignation1.ItemsSource = PurchaseDepartmentDesignations;

                cmbDesignation.SelectedItem = "Purchasing Agent";
            }
        }
        // FOR INSERT --- DESIGNATIONS --------------------------------------------------------------------------- END ----->>>




        private void Delete_MouseEnter(object sender, MouseEventArgs e)
        {
            ToolTip = "Delte";
        }


        // FOR MENU ---- INSERT, UPDATE, DELETE ----------------------------------------------------------------- START ----->>>
        private void cmbMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbMenu.SelectedItem.ToString()=="Insert")
            {
                AllClear();
                lstEmployee.ItemsSource = "";

                lstEmployee2.ItemsSource = "";
                cmbDeleteDataDepartmentWise.SelectedIndex = -1;

                lstEmployee1.ItemsSource = "";
                cmbshowDepartment.SelectedIndex = -1;

                csInsert.Visibility = Visibility.Visible;
                csUpdate.Visibility = Visibility.Hidden;
                csDelete.Visibility = Visibility.Hidden;
                AllClear();
                txtId.Focus();
            }
            else if (cmbMenu.SelectedItem.ToString()=="Update")
            {
                AllClear();
                lstEmployee.ItemsSource = "";

                lstEmployee2.ItemsSource = "";
                cmbDeleteDataDepartmentWise.SelectedIndex = -1;

                lstEmployee1.ItemsSource = "";
                cmbshowDepartment.SelectedIndex = -1;

                csInsert.Visibility = Visibility.Hidden;
                csDelete.Visibility = Visibility.Hidden;
                csUpdate.Visibility = Visibility.Visible;
                btnUpdate2.IsEnabled = false;
            }
            else if (cmbMenu.SelectedItem.ToString() == "Delete")
            {
                AllClear();
                lstEmployee.ItemsSource = "";

                csInsert.Visibility = Visibility.Hidden;
                csUpdate.Visibility = Visibility.Hidden;
                csDelete.Visibility = Visibility.Visible;

                lstEmployee2.ItemsSource = "";
                cmbDeleteDataDepartmentWise.SelectedIndex = -1;

                lstEmployee1.ItemsSource = "";
                cmbshowDepartment.SelectedIndex = -1;

            }
        }
        // FOR MENU ---- INSERT, UPDATE, DELETE ----------------------------------------------------------------- END ----->>>


        // DATA SHOW ------------------------------------------------------------------------------ FOR UPDATE START -->>>
        private void cmbshow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbshowDepartment.SelectedIndex ==  0)
            {
                Refresh1();
                marketingDepartmentShowData();
            }
            else if (cmbshowDepartment.SelectedIndex == 1)
            {
                Refresh1();
                operationsDepartmentShowData();
            }
            else if (cmbshowDepartment.SelectedIndex == 2)
            {
                Refresh1();
                financeDepartmentShowData();
            }
            else if (cmbshowDepartment.SelectedIndex == 3)
            {
                Refresh1();
                salesDepartmentShowData();
            }
            else if (cmbshowDepartment.SelectedIndex == 4)
            {
                Refresh1();
                humanResourceDepartmentShowData();
            }
            else if (cmbshowDepartment.SelectedIndex == 5)
            {
                Refresh1();
                purchaseDepartmentShowData();
            }
        }
        // DATA SHOW ------------------------------------------------------------------------------ FOR UPDATE END -->>>


        // FOR UPDATE DESIGNATIONS
        private void cmbDepartment1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> MarketingDepartmentsDesignations = new List<string>()
            {
                "Chief marketing officer (CMO)",
                "Creative director",
                "Marketing manager and product marketing manager",
                "Digital marketing manager",
                "Communications manager",
                "Content marketing specialist"
            };

            List<string> OperationsDepartmentDesignations = new List<string>()
            {
                "Operations coordinator",
                "Operations analyst",
                "Operations supervisor",
                "Operations manager",
                "Project manager",
                "Program manager",
                "Operations engineer",
                "Director of operations"
            };

            List<string> FinanceDepartmentDesignations = new List<string>()
            {
                "Auditor",
                "Financial analyst",
                "Finance manager",
                "Finance clerk",
                "Finance officer",
                "Chief financial officer",
                "Finance assistant",
                "Finance director"
            };

            List<string> SalesDepartmentDesignations = new List<string>()
            {
                "National Sales Director",
                "Regional Sales Manager",
                "Sales Manager",
                "Inside Sales Representative",
                "Outside Sales Representative",
                "Sales Assistant",
                "Sales Engineer",
                "Wholesale and Manufacturing Sales"
            };

            List<string> HumanResourceDepartmentDesignations = new List<string>()
            {
                "HR assistant",
                "HR representative",
                "HR administrator",
                "HR analyst",
                "HR specialist",
                "HR generalist",
                "Personnel manager",
                "HR manager"
            };

            List<string> PurchaseDepartmentDesignations = new List<string>()
            {
                "Buyer",
                "Commodity Manager",
                "Procurement Director",
                "Procurement Officer",
                "Strategic Sourcing Director",
                "Purchasing Agent",
                "Materials Manager",
                "Purchasing Director"
            };

            if (cmbDepartment1.SelectedIndex==0)
            {
                cmbDesignation1.ItemsSource = MarketingDepartmentsDesignations;
            }

            else if (cmbDepartment1.SelectedIndex==1)
            {
                cmbDesignation1.ItemsSource = OperationsDepartmentDesignations;
            }
            else if (cmbDepartment1.SelectedIndex == 2)
            {
                cmbDesignation1.ItemsSource = FinanceDepartmentDesignations;
            }
            else if (cmbDepartment1.SelectedIndex == 3)
            {
                cmbDesignation1.ItemsSource = SalesDepartmentDesignations;
            }
            else if (cmbDepartment1.SelectedIndex == 4)
            {
                cmbDesignation1.ItemsSource = HumanResourceDepartmentDesignations;
            }
            else if (cmbDepartment1.SelectedIndex == 5)
            {
                cmbDesignation1.ItemsSource = PurchaseDepartmentDesignations;
            }
        }


        // DATA SHOW ------------------------------------------------------------------------------------------------- FOR DELETE START -->>>
        private void cmbDeleteDataDepartmentWise_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbDeleteDataDepartmentWise.SelectedIndex==0)
            {
                Refresh2();
                marketingDepartmentShowData();
            }

            else if (cmbDeleteDataDepartmentWise.SelectedIndex == 1)
            {
                Refresh2();
                operationsDepartmentShowData();
            }
            else if (cmbDeleteDataDepartmentWise.SelectedIndex == 2)
            {
                Refresh2();
                financeDepartmentShowData();
            }
            else if (cmbDeleteDataDepartmentWise.SelectedIndex == 3)
            {
                Refresh2();
                salesDepartmentShowData();
            }
            else if (cmbDeleteDataDepartmentWise.SelectedIndex == 4)
            {
                Refresh2();
                humanResourceDepartmentShowData();
            }
            else if (cmbDeleteDataDepartmentWise.SelectedIndex == 5)
            {
                Refresh2();
                purchaseDepartmentShowData();
            }
        }
        // DATA SHOW ------------------------------------------------------------------------------------------------- FOR DELETE END -->>>


        // ------------------------------------------------------------------------------------------------- BTN_UPDATE2 START -->>>
        private void btnUpdate2_Click(object sender, RoutedEventArgs e)
        {
            if (cmbDepartment1.Text == "Marketing Department")
            {
                var jsonU = File.ReadAllText(@"marketingDepartment.json");
                var jsonObj = JObject.Parse(jsonU);
                JArray empUpdateArray = (JArray)jsonObj["Employee"];

                var DepartmentUp = cmbDepartment1.SelectedItem.ToString();
                var DesignationUp = cmbDesignation1.SelectedItem.ToString();
                var Id = Convert.ToInt32(txtId1.Text);
                var Title = cmbTitle1.SelectedItem.ToString();
                var FirstName = txtFirstName1.Text;
                var LastName = txtLastName1.Text;
                var Email = txtEmail1.Text;
                var Contact = txtContactNo1.Text;

                MessageBoxResult result;
                result = MessageBox.Show("Are You Sure???", "Update", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var employee in empUpdateArray.Where(obj => obj["Id"].Value<int>() == Id))
                    {
                        employee["Department"] = !string.IsNullOrEmpty(DepartmentUp) ? DepartmentUp : "";
                        employee["Designation"] = !string.IsNullOrEmpty(DesignationUp) ? DesignationUp : "";

                        employee["Title"] = !string.IsNullOrEmpty(Title) ? Title : "";
                        employee["FirstName"] = !string.IsNullOrEmpty(FirstName) ? FirstName : "";
                        employee["LastName"] = !string.IsNullOrEmpty(LastName) ? LastName : "";
                        employee["Email"] = !string.IsNullOrEmpty(Email) ? Email : "";
                        employee["Contact"] = !string.IsNullOrEmpty(Contact) ? Contact : "";
                    }
                    jsonObj["Employee"] = empUpdateArray;
                    string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.WriteAllText(@"marketingDepartment.json", output);

                    marketingDepartmentShowData();

                    MessageBox.Show("Successful", "Update");
                    
                    AllClear2();
                    cmbMenu.IsEnabled = true;

                }
                if (result == MessageBoxResult.No)
                {
                    AllClear2();
                    cmbMenu.IsEnabled = true;
                }
            }

            if (cmbDepartment1.Text == "Operations Department")
            {
                var jsonU = File.ReadAllText(@"operationsDepartment.json");
                var jsonObj = JObject.Parse(jsonU);
                JArray empUpdateArray = (JArray)jsonObj["Employee"];

                var DepartmentUp = cmbDepartment1.SelectedItem.ToString();
                var DesignationUp = cmbDesignation1.SelectedItem.ToString();
                var Id = Convert.ToInt32(txtId1.Text);
                var Title = cmbTitle1.SelectedItem.ToString();
                var FirstName = txtFirstName1.Text;
                var LastName = txtLastName1.Text;
                var Email = txtEmail1.Text;
                var Contact = txtContactNo1.Text;

                MessageBoxResult result;
                result = MessageBox.Show("Are You Sure???", "Update", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var employee in empUpdateArray.Where(obj => obj["Id"].Value<int>() == Id))
                    {
                        employee["Department"] = !string.IsNullOrEmpty(DepartmentUp) ? DepartmentUp : "";
                        employee["Designation"] = !string.IsNullOrEmpty(DesignationUp) ? DesignationUp : "";

                        employee["Title"] = !string.IsNullOrEmpty(Title) ? Title : "";
                        employee["FirstName"] = !string.IsNullOrEmpty(FirstName) ? FirstName : "";
                        employee["LastName"] = !string.IsNullOrEmpty(LastName) ? LastName : "";
                        employee["Email"] = !string.IsNullOrEmpty(Email) ? Email : "";
                        employee["Contact"] = !string.IsNullOrEmpty(Contact) ? Contact : "";
                    }
                    jsonObj["Employee"] = empUpdateArray;
                    string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.WriteAllText(@"operationsDepartment.json", output);

                    operationsDepartmentShowData();

                    MessageBox.Show("Successful", "Update");

                    AllClear2();
                    cmbMenu.IsEnabled = true;

                }
                if (result == MessageBoxResult.No)
                {
                    AllClear2();
                    cmbMenu.IsEnabled = true;
                }
            }

            if (cmbDepartment1.Text == "Finance Department")
            {
                var jsonU = File.ReadAllText(@"financeDepartment.json");
                var jsonObj = JObject.Parse(jsonU);
                JArray empUpdateArray = (JArray)jsonObj["Employee"];

                var DepartmentUp = cmbDepartment1.SelectedItem.ToString();
                var DesignationUp = cmbDesignation1.SelectedItem.ToString();
                var Id = Convert.ToInt32(txtId1.Text);
                var Title = cmbTitle1.SelectedItem.ToString();
                var FirstName = txtFirstName1.Text;
                var LastName = txtLastName1.Text;
                var Email = txtEmail1.Text;
                var Contact = txtContactNo1.Text;

                MessageBoxResult result;
                result = MessageBox.Show("Are You Sure???", "Update", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var employee in empUpdateArray.Where(obj => obj["Id"].Value<int>() == Id))
                    {
                        employee["Department"] = !string.IsNullOrEmpty(DepartmentUp) ? DepartmentUp : "";
                        employee["Designation"] = !string.IsNullOrEmpty(DesignationUp) ? DesignationUp : "";

                        employee["Title"] = !string.IsNullOrEmpty(Title) ? Title : "";
                        employee["FirstName"] = !string.IsNullOrEmpty(FirstName) ? FirstName : "";
                        employee["LastName"] = !string.IsNullOrEmpty(LastName) ? LastName : "";
                        employee["Email"] = !string.IsNullOrEmpty(Email) ? Email : "";
                        employee["Contact"] = !string.IsNullOrEmpty(Contact) ? Contact : "";
                    }
                    jsonObj["Employee"] = empUpdateArray;
                    string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.WriteAllText(@"financeDepartment.json", output);

                    financeDepartmentShowData();

                    MessageBox.Show("Successful", "Update");

                    AllClear2();
                    cmbMenu.IsEnabled = true;

                }
                if (result == MessageBoxResult.No)
                {
                    AllClear2();
                    cmbMenu.IsEnabled = true;
                }
            }

            if (cmbDepartment1.Text == "Human Resource Department")
            {
                var jsonU = File.ReadAllText(@"humanResourceDepartment.json");
                var jsonObj = JObject.Parse(jsonU);
                JArray empUpdateArray = (JArray)jsonObj["Employee"];

                var DepartmentUp = cmbDepartment1.SelectedItem.ToString();
                var DesignationUp = cmbDesignation1.SelectedItem.ToString();
                var Id = Convert.ToInt32(txtId1.Text);
                var Title = cmbTitle1.SelectedItem.ToString();
                var FirstName = txtFirstName1.Text;
                var LastName = txtLastName1.Text;
                var Email = txtEmail1.Text;
                var Contact = txtContactNo1.Text;

                MessageBoxResult result;
                result = MessageBox.Show("Are You Sure???", "Update", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var employee in empUpdateArray.Where(obj => obj["Id"].Value<int>() == Id))
                    {
                        employee["Department"] = !string.IsNullOrEmpty(DepartmentUp) ? DepartmentUp : "";
                        employee["Designation"] = !string.IsNullOrEmpty(DesignationUp) ? DesignationUp : "";

                        employee["Title"] = !string.IsNullOrEmpty(Title) ? Title : "";
                        employee["FirstName"] = !string.IsNullOrEmpty(FirstName) ? FirstName : "";
                        employee["LastName"] = !string.IsNullOrEmpty(LastName) ? LastName : "";
                        employee["Email"] = !string.IsNullOrEmpty(Email) ? Email : "";
                        employee["Contact"] = !string.IsNullOrEmpty(Contact) ? Contact : "";
                    }
                    jsonObj["Employee"] = empUpdateArray;
                    string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.WriteAllText(@"humanResourceDepartment.json", output);

                    humanResourceDepartmentShowData();

                    MessageBox.Show("Successful", "Update");

                    AllClear2();
                    cmbMenu.IsEnabled = true;

                }
                if (result == MessageBoxResult.No)
                {
                    AllClear2();
                    cmbMenu.IsEnabled = true;
                }
            }

            if (cmbDepartment1.Text == "Sales Department")
            {
                var jsonU = File.ReadAllText(@"salesDepartment.json");
                var jsonObj = JObject.Parse(jsonU);
                JArray empUpdateArray = (JArray)jsonObj["Employee"];

                var DepartmentUp = cmbDepartment1.SelectedItem.ToString();
                var DesignationUp = cmbDesignation1.SelectedItem.ToString();
                var Id = Convert.ToInt32(txtId1.Text);
                var Title = cmbTitle1.SelectedItem.ToString();
                var FirstName = txtFirstName1.Text;
                var LastName = txtLastName1.Text;
                var Email = txtEmail1.Text;
                var Contact = txtContactNo1.Text;

                MessageBoxResult result;
                result = MessageBox.Show("Are You Sure???", "Update", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var employee in empUpdateArray.Where(obj => obj["Id"].Value<int>() == Id))
                    {
                        employee["Department"] = !string.IsNullOrEmpty(DepartmentUp) ? DepartmentUp : "";
                        employee["Designation"] = !string.IsNullOrEmpty(DesignationUp) ? DesignationUp : "";

                        employee["Title"] = !string.IsNullOrEmpty(Title) ? Title : "";
                        employee["FirstName"] = !string.IsNullOrEmpty(FirstName) ? FirstName : "";
                        employee["LastName"] = !string.IsNullOrEmpty(LastName) ? LastName : "";
                        employee["Email"] = !string.IsNullOrEmpty(Email) ? Email : "";
                        employee["Contact"] = !string.IsNullOrEmpty(Contact) ? Contact : "";
                    }
                    jsonObj["Employee"] = empUpdateArray;
                    string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.WriteAllText(@"salesDepartment.json", output);

                    salesDepartmentShowData();

                    MessageBox.Show("Successful", "Update");

                    AllClear2();
                    cmbMenu.IsEnabled = true;

                }
                if (result == MessageBoxResult.No)
                {
                    AllClear2();
                    cmbMenu.IsEnabled = true;
                }
            }

            if (cmbDepartment1.Text == "Purchase Department")
            {
                var jsonU = File.ReadAllText(@"purchaseDepartment.json");
                var jsonObj = JObject.Parse(jsonU);
                JArray empUpdateArray = (JArray)jsonObj["Employee"];

                var DepartmentUp = cmbDepartment1.SelectedItem.ToString();
                var DesignationUp = cmbDesignation1.SelectedItem.ToString();
                var Id = Convert.ToInt32(txtId1.Text);
                var Title = cmbTitle1.SelectedItem.ToString();
                var FirstName = txtFirstName1.Text;
                var LastName = txtLastName1.Text;
                var Email = txtEmail1.Text;
                var Contact = txtContactNo1.Text;

                MessageBoxResult result;
                result = MessageBox.Show("Are You Sure???", "Update", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    foreach (var employee in empUpdateArray.Where(obj => obj["Id"].Value<int>() == Id))
                    {
                        employee["Department"] = !string.IsNullOrEmpty(DepartmentUp) ? DepartmentUp : "";
                        employee["Designation"] = !string.IsNullOrEmpty(DesignationUp) ? DesignationUp : "";

                        employee["Title"] = !string.IsNullOrEmpty(Title) ? Title : "";
                        employee["FirstName"] = !string.IsNullOrEmpty(FirstName) ? FirstName : "";
                        employee["LastName"] = !string.IsNullOrEmpty(LastName) ? LastName : "";
                        employee["Email"] = !string.IsNullOrEmpty(Email) ? Email : "";
                        employee["Contact"] = !string.IsNullOrEmpty(Contact) ? Contact : "";
                    }
                    jsonObj["Employee"] = empUpdateArray;
                    string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.WriteAllText(@"purchaseDepartment.json", output);

                    purchaseDepartmentShowData();

                    MessageBox.Show("Successful", "Update");

                    AllClear2();
                    cmbMenu.IsEnabled = true;

                }
                if (result == MessageBoxResult.No)
                {
                    AllClear2();
                    cmbMenu.IsEnabled = true;
                }
            }
        }


        private void Delete1_Click(object sender, RoutedEventArgs e)
        {
            if (cmbDeleteDataDepartmentWise.SelectedItem.ToString() == "Marketing Department")
            {
                var jsonD = File.ReadAllText(@"marketingDepartment.json");
                var jsonObj = JObject.Parse(jsonD);
                JArray empDeleteArray = (JArray)jsonObj["Employee"];

                Button b = sender as Button;
                Employee empbtn = b.CommandParameter as Employee;
                int empId = empbtn.Id;

                if (empId >= 0)
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Are You Sure???", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (show == MessageBoxResult.OK)
                    {
                        var employeeToDeleted = empDeleteArray.FirstOrDefault(obj => obj["Id"].Value<int>() == empId);
                        empDeleteArray.Remove(employeeToDeleted);

                        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                        File.WriteAllText(@"marketingDepartment.json", output);

                        Refresh2();
                        marketingDepartmentShowData2();                       
                    }
                    if (show == MessageBoxResult.Cancel)
                    {
                        //cmbDeleteDataDepartmentWise.SelectedIndex=-1;
                        //Refresh2();
                    }
                }
            }

            else if (cmbDeleteDataDepartmentWise.SelectedItem.ToString() == "Operations Department")
            {
                var jsonD = File.ReadAllText(@"operationsDepartment.json");
                var jsonObj = JObject.Parse(jsonD);
                JArray empDeleteArray = (JArray)jsonObj["Employee"];

                Button b = sender as Button;
                Employee empbtn = b.CommandParameter as Employee;
                int empId = empbtn.Id;

                if (empId >= 0)
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Are You Sure???", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (show == MessageBoxResult.OK)
                    {
                        var employeeToDeleted = empDeleteArray.FirstOrDefault(obj => obj["Id"].Value<int>() == empId);
                        empDeleteArray.Remove(employeeToDeleted);

                        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                        File.WriteAllText(@"operationsDepartment.json", output);
                        Refresh2();
                        operationsDepartmentShowData2();
                    }
                    if (show == MessageBoxResult.Cancel)
                    {
                        //cmbDeleteDataDepartmentWise.SelectedIndex = -1;
                        //Refresh2();
                    }
                }
            }

            else if (cmbDeleteDataDepartmentWise.SelectedItem.ToString() == "Finance Department")
            {
                var jsonD = File.ReadAllText(@"financeDepartment.json");
                var jsonObj = JObject.Parse(jsonD);
                JArray empDeleteArray = (JArray)jsonObj["Employee"];

                Button b = sender as Button;
                Employee empbtn = b.CommandParameter as Employee;
                int empId = empbtn.Id;

                if (empId >= 0)
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Are You Sure???", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (show == MessageBoxResult.OK)
                    {
                        var employeeToDeleted = empDeleteArray.FirstOrDefault(obj => obj["Id"].Value<int>() == empId);
                        empDeleteArray.Remove(employeeToDeleted);

                        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                        File.WriteAllText(@"financeDepartment.json", output);
                        Refresh2();
                        financeDepartmentShowData2();
                    }
                    if (show == MessageBoxResult.Cancel)
                    {
                        //cmbDeleteDataDepartmentWise.SelectedIndex = -1;
                        //Refresh2();
                    }
                }
            }

            else if (cmbDeleteDataDepartmentWise.SelectedItem.ToString() == "Human Resource Department")
            {
                var jsonD = File.ReadAllText(@"humanResourceDepartment.json");
                var jsonObj = JObject.Parse(jsonD);
                JArray empDeleteArray = (JArray)jsonObj["Employee"];

                Button b = sender as Button;
                Employee empbtn = b.CommandParameter as Employee;
                int empId = empbtn.Id;

                if (empId >= 0)
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Are You Sure???", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (show == MessageBoxResult.OK)
                    {
                        var employeeToDeleted = empDeleteArray.FirstOrDefault(obj => obj["Id"].Value<int>() == empId);
                        empDeleteArray.Remove(employeeToDeleted);

                        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                        File.WriteAllText(@"humanResourceDepartment.json", output);
                        Refresh2();
                        humanResourceDepartmentShowData2();
                    }
                    if (show == MessageBoxResult.Cancel)
                    {
                        //cmbDeleteDataDepartmentWise.SelectedIndex = -1;
                        //Refresh2();
                    }
                }
            }

            else if (cmbDeleteDataDepartmentWise.SelectedItem.ToString() == "Sales Department")
            {
                var jsonD = File.ReadAllText(@"salesDepartment.json");
                var jsonObj = JObject.Parse(jsonD);
                JArray empDeleteArray = (JArray)jsonObj["Employee"];

                Button b = sender as Button;
                Employee empbtn = b.CommandParameter as Employee;
                int empId = empbtn.Id;

                if (empId >= 0)
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Are You Sure???", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (show == MessageBoxResult.OK)
                    {
                        var employeeToDeleted = empDeleteArray.FirstOrDefault(obj => obj["Id"].Value<int>() == empId);
                        empDeleteArray.Remove(employeeToDeleted);

                        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                        File.WriteAllText(@"salesDepartment.json", output);
                        Refresh2();
                        salesDepartmentShowData2();
                    }
                    if (show == MessageBoxResult.Cancel)
                    {
                        //cmbDeleteDataDepartmentWise.SelectedIndex = -1;
                        //Refresh2();
                    }
                }
            }

            else if (cmbDeleteDataDepartmentWise.SelectedItem.ToString() == "Purchase Department")
            {
                var jsonD = File.ReadAllText(@"purchaseDepartment.json");
                var jsonObj = JObject.Parse(jsonD);
                JArray empDeleteArray = (JArray)jsonObj["Employee"];

                Button b = sender as Button;
                Employee empbtn = b.CommandParameter as Employee;
                int empId = empbtn.Id;

                if (empId >= 0)
                {
                    MessageBoxResult show;
                    show = MessageBox.Show("Are You Sure???", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (show == MessageBoxResult.OK)
                    {
                        var employeeToDeleted = empDeleteArray.FirstOrDefault(obj => obj["Id"].Value<int>() == empId);
                        empDeleteArray.Remove(employeeToDeleted);

                        string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                        File.WriteAllText(@"purchaseDepartment.json", output);
                        Refresh2();
                        purchaseDepartmentShowData2();
                    }
                    if (show == MessageBoxResult.Cancel)
                    {
                        //cmbDeleteDataDepartmentWise.SelectedIndex = -1;
                        //Refresh2();
                    }
                }
            }
        }
        // ------------------------------------------------------------------------------------------------- BTN_UPDATE2 END -->>>

    }
}
