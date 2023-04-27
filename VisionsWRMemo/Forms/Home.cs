using VisionsWRMemo.Core;

namespace VisionsWRMemo
{

    public partial class Home : Form
    {

        private string _username;
        private string _password;
        private string _server;
        private string _site;
        private string _path;
        private static Home _home;

        public List<Domain.InspectionTask> InspectionTaskErrors { get; set; } = new();
 
        //};

        //private VisAPIClient _client => new(new BasicHttpBinding(),
        //                                new EndpointAddress("http://nwsvsnapts2:7137/VisAPI/VisAPI_BH"));



        //};

        //private VisAPIClient _client => new(new BasicHttpBinding(),
        //                                new EndpointAddress("http://nwsvsnapts2:7137/VisAPI/VisAPI_BH"));



        //};

        //private VisAPIClient _client => new(new BasicHttpBinding(),
        //                                new EndpointAddress("http://nwsvsnapts2:7137/VisAPI/VisAPI_BH"));



        public Home()
        {
            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _home = this;
        }

        private static DialogResult Message(string message,
                                            string caption,
                                            MessageBoxButtons buttons)
        {
            return MessageBox.Show(message, caption, buttons);
        }

        private static DialogResult LoginError(string message = null) =>
            Message(message == null ? "Invalid login attempt" : message, "Login Error", MessageBoxButtons.OK);
        private static DialogResult NetworkError() =>
            Message($"Unable to connect to remote endpoint.", "Network Error.", MessageBoxButtons.OK);

        private bool UserExists(string userList) =>
                userList.Contains(_username.ToUpper());

        private void QueryUser(Http.QueryUserApiResponse response)
        {
            if (UserExists(response.UserList))
            {
                gbLogin.Visible = false;
                pnlVisionsUpload.Visible = true;                
            }
            else
            {
                LoginError(response.ErrorMsg);
            }
        }

        private void TryLoginUser()
        {
            var response = Http.login(_site, _username, _password, _server);

            if (response.QueryUsersResult)
            {
                QueryUser(response);

            }
            else
            {
                LoginError(response.ErrorMsg);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_username) &&
               !string.IsNullOrEmpty(_password) &&
               !string.IsNullOrEmpty(_server) &&
               !string.IsNullOrEmpty(_site))
            {
                try
                {
#if DEBUG
                    gbLogin.Visible = false;
                    pnlVisionsUpload.Visible = true;
#else
                    TryLoginUser();
#endif
                    this.Text = $"{this.Text} | Server:{this._server}";
                }
                catch (Exception)
                {
                    NetworkError();
                }
            }
            else
            {
                LoginError();
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            _username = txtUserName.Text;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            _password = txtPassword.Text;
        }


        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            _server = txtServer.Text;
        }

        private void txtSite_TextChanged(object sender, EventArgs e)
        {
            _site = txtSite.Text;
        }


        private void DisableElementsDuringUpload()
        {
            btnDownloadTemplate.Enabled = false;
            btnSelectFileForImport.Enabled = false;
            btnUploadToVisions.Enabled = false;
            pbUpload.Visible = true;
        }
        private void ShowElementsAfterUpload()
        {
            btnDownloadTemplate.Enabled = true;
            btnSelectFileForImport.Enabled = true;
            btnUploadToVisions.Enabled = true;
            pbUpload.Visible = false;
            if (InspectionTaskErrors.Count > 0)
            {
                MessageBox.Show("Upload completed with errors", "Success");
                SetErrorGridAndShow();
            }
            else
            {
                MessageBox.Show("Upload complete", "Success");
            }
        }

        private void SetErrorGridAndShow()
        {
            if (InspectionTaskErrors.Count > 0)
            {
                var errors = new Errors(this);
                errors.Visible = true;
                errors.Show();
            }
        }

        private void ErrorOccuredDuringUpload()
        {
            btnDownloadTemplate.Enabled = true;
            btnSelectFileForImport.Enabled = true;
            btnUploadToVisions.Enabled = true;
            pbUpload.Visible = false;
            MessageBox.Show("Upload failed.", "Error");
        }


        private async void btnUploadToVisions_Click(object sender, EventArgs e)
        {
            try
            {

                DisableElementsDuringUpload();

                InspectionTaskErrors = await Task.Run(() => Http.createTask(_path, _site, _username, _password, _server));
                ShowElementsAfterUpload();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
                ErrorOccuredDuringUpload();
            }

        }

        private void lblSelectedFiles_Click(object sender, EventArgs e)
        {

        }
        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnDownloadTemplate_Click(object sender, EventArgs e)
        {
            var path = ExcelData.createTemplate();
            linkTemplateFilePath.Text = "Template";
            linkTemplateFilePath.Links.Add(0, path.Length, path);
            linkTemplateFilePath.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlVisionsUpload_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkTemplateFilePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Link != null &&
                e.Link.LinkData != null &&
                !string.IsNullOrEmpty(e.Link.LinkData.ToString()))
            {
                ExcelData.launchTemplate(e.Link.LinkData.ToString());
            }
        }

        private void btnSelectFileForImport_Click(object sender, EventArgs e)
        {

            openFileDialog1.Title = "Select File";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblSelectedFiles.Text = openFileDialog1.FileName;
                _path = openFileDialog1.FileName;

            }

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void lblSupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("For support contact info@arcsolutions.ca", "Support");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
