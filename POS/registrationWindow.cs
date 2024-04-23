using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace POS
{
    public partial class registrationWindow : Form
    {
        static string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        //collection for comboBox
        public System.Windows.Forms.ComboBox.ObjectCollection Items { get; }

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


        public registrationWindow()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            positionOption.Items.Add("User");
            positionOption.Items.Add("Administrator");
            positionOption.Items.Add("Owner");
            positionOption.Items.Add("Other");

            passwordConfirm.Visible = false;

        }

        private void registrationWindow_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RegisterAccount()
        {

            if (checkPassword())
            {
                MySqlConnection conn1 = new MySqlConnection(connection);
                MySqlCommand cmd;
                conn1.Open();
                try
                {
                    cmd = conn1.CreateCommand();
                    cmd.CommandText = "Insert INTO users(user_id, name,username,password, position)VALUES("+ setUID() + ",'" + name.Text + "','" + username.Text + "','" + password.Text + "', '" + positionOption.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registered Successfully!");
                    passwordConfirm.Visible = false;
                    clearTextfields();
                }

                catch (Exception ex)
                {
                    loginFailed failed = new loginFailed();
                    failed.message = ex.Message;
                    failed.ShowDialog();
                }
                conn1.Close();
            }
            else
            {
                passwordConfirm.Visible = true;
            }
        }

        private Boolean checkPassword()
        {
            if (password.Text.Equals(confirmPassword.Text))
            {
                return true;
            }
            return false;
        }

        private void clearTextfields()
        {
            name.Clear();
            username.Clear();
            password.Clear();
            confirmPassword.Clear();
        }

        private void checkTextfields()
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            RegisterAccount();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            clearTextfields();
        }

        private int setUID()
        {
            int id = 0;
            MySqlConnection con = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "SELECT COUNT(user_id) as user_count from users";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    id = dr.GetInt32("user_count");
                    
                }
                con.Close();
            }

            catch (Exception ex)
            {
                loginFailed failed = new loginFailed();
                failed.message = ex.Message;
                failed.ShowDialog();
            }
            return id;
        }
    }
}
