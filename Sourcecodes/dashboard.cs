using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dashboard
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DashboardForm());
        }
    }

    public class DashboardForm : Form
    {
        private Button settingButton;
        private Button employeeButton;
        private Button salaryButton;

        public DashboardForm()
        {
            InitializeComponent();

            Label myLabel = new Label();
            myLabel.Text = "Grifindo Toys Payroll System";
            myLabel.Location = new Point(10, 10);
            this.Controls.Add(myLabel);




            
// Initialize buttons
            employeeButton = new Button();
            employeeButton.Text = "Employee";
            employeeButton.Size = new Size(100, 50);
            employeeButton.Location = new Point(50, 50);
            employeeButton.Click += EmployeeButton_Click;


            salaryButton = new Button();
            salaryButton.Text = "Salary";
            salaryButton.Size = new Size(100, 50);
            salaryButton.Location = new Point(employeeButton.Right + 20, employeeButton.Top);
            salaryButton.Click += SalaryButton_Click;


            settingButton = new Button();
            settingButton.Text = "Settings";
            settingButton.Size = new Size(100,50);
            settingButton.Location = new Point(salaryButton.Right + 20, employeeButton.Top);
            settingButton.Click += SettingButton_Click;

            // Add buttons to the form
            Controls.Add(employeeButton);
            Controls.Add(salaryButton);
            Controls.Add(settingButton);
            
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.ClientSize = new Size(450, 150);
            this.Name = "DashboardForm";
            this.Text = "Dashboard";

            this.ResumeLayout(false);
        }





        private void SettingButton_Click(object sender, EventArgs e)
        {
            // Open settings page
            settingsWindow settingsWindow = new settingsWindow();
            settingsWindow.Show();
        }

        private void EmployeeButton_Click(object sender, EventArgs e)
        {
            // Open employee page
            EmployeeWindow EmployeeWindow = new EmployeeWindow();
            EmployeeWindow.Show();
        }

        private void SalaryButton_Click(object sender, EventArgs e)
        {
            // Open salary page
            SalaryWindow SalaryWindow = new SalaryWindow();
            SalaryWindow.Show();
        }


        public class settingsWindow  : Form
        {
            private TextBox range;
            private TextBox startdate;
            private TextBox enddate;
            private TextBox noofleaves;

            public settingsWindow ()
            {
                this.Text = "Settings Window";
                this.Size = new Size(450, 300);

                range = new TextBox();
                range.Location = new Point(50, 50);
                range.Text = "Enter Range";
                range.Size = new Size(200, 20);
                this.Controls.Add(range);





                Button rangeC = new Button();
                rangeC.Text = "Change";
                rangeC.Location = new Point(300, 50);
                this.Controls.Add(rangeC);


                startdate = new TextBox();
                startdate.Location = new Point(50, 100);
                startdate.Text = "Enter Start date";
                startdate.Size = new Size(200, 20);
                this.Controls.Add(startdate);

                Button sDate = new Button();
                sDate.Text = "Change";
                sDate.Location = new Point(300, 100);
                this.Controls.Add(sDate);

                enddate = new TextBox();
                enddate.Location = new Point(50, 150);
                enddate.Text = "Enter End date";
                enddate.Size = new Size(200, 20);
                this.Controls.Add(enddate);

                Button eDate = new Button();
                eDate.Text = "Change";
                eDate.Location = new Point(300, 150);
                this.Controls.Add(eDate);

                noofleaves = new TextBox();
                noofleaves.Location = new Point(50, 200);
                noofleaves.Text = "Enter No of Leaves";
                noofleaves.Size = new Size(200, 20);
                this.Controls.Add(noofleaves);

                Button Leaves = new Button();
                Leaves.Text = "Change";
                Leaves.Location = new Point(300, 200);
                this.Controls.Add(Leaves);

            }
        }



        public class EmployeeWindow  : Form
        {
            private TextBox nameTextBox;
            private TextBox salaryTextBox;
            private TextBox overtimerateTextBox;
            private TextBox AllowancesTextBox;

            public EmployeeWindow ()
            {
                this.Text = "Employee window";
                this.Size = new Size(300, 450);
                
                nameTextBox = new TextBox();
                nameTextBox.Location = new Point(40, 50);
                nameTextBox.Text = "Enter Name";
                nameTextBox.Size = new Size(200, 20);
                this.Controls.Add(nameTextBox);

                salaryTextBox = new TextBox();
                salaryTextBox.Location = new Point(40, 100);
                salaryTextBox.Text = "Enter Monthly Salary";
                salaryTextBox.Size = new Size(200, 20);
                this.Controls.Add(salaryTextBox);

                overtimerateTextBox = new TextBox();
                overtimerateTextBox.Location = new Point(40, 150);
                overtimerateTextBox.Text = "Enter Overtime Rates";
                overtimerateTextBox.Size = new Size(200, 20);
                this.Controls.Add(overtimerateTextBox);

                AllowancesTextBox = new TextBox();
                AllowancesTextBox.Location = new Point(40, 200);
                AllowancesTextBox.Text = "Enter Allowances";
                AllowancesTextBox.Size = new Size(200, 20);
                this.Controls.Add(AllowancesTextBox);


                Button Register = new Button();
                Register.Text = "Register";
                Register.Location = new Point(50, 250);
                this.Controls.Add(Register);



                Button Update = new Button();
                Update.Text = "Update";
                Update.Location = new Point(150, 250);
                this.Controls.Add(Update);

                Button Delete = new Button();
                Delete.Text = "Delete";
                Delete.Location = new Point(50, 300);
                this.Controls.Add(Delete);

                Button All = new Button();
                All.Text = "All";
                All.Location = new Point(150, 300);
                this.Controls.Add(All);

                Button Search = new Button();
               Search.Text = "Search employee";
                Search.Location = new Point(100, 350);
                this.Controls.Add(Search);
            }
        }

        public class SalaryWindow  : Form
        {

            private TextBox StartDate;
            private TextBox EndDate;
            private TextBox NoLeaves;
            private TextBox NoAbsent;
            private TextBox NoHolidays;
            private TextBox Taxrate;

            public SalaryWindow ()
            {
                this.Text = "Salary Window";
                this.Size = new Size(300, 550);


                StartDate = new TextBox();
                StartDate.Location = new Point(40, 50);
                StartDate.Text = "Enter Start date";
                StartDate.Size = new Size(200, 20);


                this.Controls.Add(StartDate);

                EndDate = new TextBox();
                EndDate.Location = new Point(40, 100);
                EndDate.Text = "Enter End date";
                EndDate.Size = new Size(200, 20);
                this.Controls.Add(EndDate);

                NoLeaves= new TextBox();
                NoLeaves.Location = new Point(40, 150);
                NoLeaves.Text = "Enter No of leaves";
                NoLeaves.Size = new Size(200, 20);
                this.Controls.Add(NoLeaves);

                NoAbsent = new TextBox();
                NoAbsent.Location = new Point(40, 200);
                NoAbsent.Text = "Enter No of Absents";
                NoAbsent.Size = new Size(200, 20);
                this.Controls.Add(NoAbsent);

                NoHolidays = new TextBox();
                NoHolidays.Location = new Point(40, 250);
                NoHolidays.Text = "Enter No of Holidays";
                NoHolidays.Size = new Size(200, 20);
                this.Controls.Add(NoHolidays);

                Taxrate = new TextBox();
                Taxrate.Location = new Point(40, 300);
                Taxrate.Text = "Enter the tax rate";
                Taxrate.Size = new Size(200, 20);
                this.Controls.Add(Taxrate);

                Button NoPay = new Button();
                NoPay.Text = "No Pay value";
                NoPay.Location = new Point(50, 350);
                this.Controls.Add(NoPay);

                Button BasePay = new Button();
                BasePay.Text = "Base Pay value";
                BasePay.Location = new Point(150, 350);
                this.Controls.Add(BasePay);



                Button GrossPay = new Button();
               GrossPay.Text = "Gross Pay value";
                GrossPay.Location = new Point(100, 400);
                this.Controls.Add(GrossPay);
            }
        }


    }
}
