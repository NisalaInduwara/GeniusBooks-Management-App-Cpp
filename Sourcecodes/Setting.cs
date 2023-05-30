// defining a class for salary setting component
public class settingComponent
    {

        // defining the parameters of the setting component
        private int salaryCycleDays;
        private DateTime salaryCycleBeginDate;
        private DateTime salaryCycleEndDate;
        private int leavesPerYear;


        // method to set and get salary cycle days
        public int SalaryCycleDays
        {
            get { return salaryCycleDays; }
            set { salaryCycleDays = value; }
        }

        // method to set and get Salary Cycle Begin Date
        public DateTime SalaryCycleBeginDate
        {
            get { return salaryCycleBeginDate; }
            set { salaryCycleBeginDate = value; }
        }

        // method to set and get Salary Cycle End Date
        public DateTime SalaryCycleEndDate
        {
            get { return salaryCycleEndDate; }
            set { salaryCycleEndDate = value; }
        }

        // method to set and get number of leaves per year
        public int LeavesPerYear
        {
            get { return leavesPerYear; }
            set { leavesPerYear = value; }
        }

         public void SetDefaultSettings()
        {
            // Set default values for settings
            salaryCycleDays = 30;
            salaryCycleBeginDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            salaryCycleEndDate = salaryCycleBeginDate.AddDays(salaryCycleDays - 1);
            leavesPerYear = 12;
        }
    }
