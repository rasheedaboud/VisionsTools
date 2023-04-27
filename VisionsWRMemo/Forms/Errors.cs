namespace VisionsWRMemo
{
    public partial class Errors : Form
    {

        public class ErrorData
        {
            public string EquipNum { get; set; }
            public string Success { get; set; }
            public string Message { get; set; }

        }

        private Home _home;
        private List<ErrorData> InspectionTaskErrors = new List<ErrorData>();

        public void SetErrors()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = InspectionTaskErrors;
            dataGridView1.Refresh();
        }

        public Errors()
        {
            InitializeComponent();
        }
        public Errors(Home home)
        {
            _home = home;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Errors_Load(object sender, EventArgs e)
        {
            InspectionTaskErrors = 
                    _home.InspectionTaskErrors
                            .Select(x => new ErrorData() 
                                {
                                    EquipNum=x.EquipNum,
                                    Message=x.Message,
                                    Success="Failed" 
                                }).ToList();
            SetErrors();
        }
    }
}
