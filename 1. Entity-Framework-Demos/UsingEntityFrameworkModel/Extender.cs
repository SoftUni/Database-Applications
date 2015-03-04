namespace UsingEntityFrameworkModel
{
    public partial class Employee
    {
        public override string ToString()
        {
            return string.Format("{0} {1} - {2}", this.FirstName, this.LastName, this.JobTitle);
        }
    }

    public partial class Department
    {
        public override string ToString()
        {
            return this.Name;
        }
    }
}
