using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Runtime.InteropServices;

namespace POS
{
    public partial class Form1 : Form
    {
        public static string user_name;
        public static string user_position;

        static string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        // window drop shadow 
        private const int CS_DropShadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = CS_DropShadow;
                return cp;
            }
        }

        //round borders
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = username;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            validateLogin();
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                username.SelectNextControl(sender as Control, true, true, true, true);
            }
            if (e.KeyCode == Keys.Enter)
            {
                validateLogin();
            }
        }

        private void validateLogin()
        {

            MySqlConnection con = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "SELECT user_id,name,username, password, position FROM users WHERE username=@username  and password=@password";
                cmd.CommandTimeout = 3600;
                cmd.Parameters.Add("@username", MySqlDbType.String).Value = username.Text;
                cmd.Parameters.Add("@password", MySqlDbType.String).Value = password.Text;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    user_name = dr["name"].ToString();
                    user_position = dr["position"].ToString(); 
                    mainPage m = new mainPage();
                    m.Show();
                    this.Hide();
                }
                else
                {
                    loginFailed failed = new loginFailed();
                    failed.ShowDialog();
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            username.Clear();
            password.Clear();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            registrationWindow register = new registrationWindow();
            register.Show();
            this.Hide();
        }

    }
}
