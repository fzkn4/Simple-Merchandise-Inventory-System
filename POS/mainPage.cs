using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Configuration;
using MySqlX.XDevAPI.Relational;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace POS
{
    public partial class mainPage : Form
    {
        int item_id;
        string item_name;
        string item_unit;

        static string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

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

        public mainPage()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            hidePanels();
            panel1.Visible = true;

            //adding items to dropdown box
            itemClass.Items.Add("Class 1");
            itemClass.Items.Add("Class 2");
            itemClass.Items.Add("Class 3");
            itemClass.Items.Add("Class 4");

            userName.Text = Form1.user_name;
            userPosition.Text = Form1.user_position;

            updateTable();

        }


        private void close_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void showInventory(object sender, EventArgs e)
        {
            hidePanels();
            panel1.Visible = true;
        }

        private void showStockin(object sender, EventArgs e)
        {
            hidePanels();
            stockIn_panel.Visible = true;
        }

        private void hidePanels()
        {
            panel1.Visible = false;
            stockIn_panel.Visible = false;
            panel3.Visible = false;
        }

        private void buttonSelected(Guna2Button active, Guna2Button button2, Guna2Button button3)
        {

        }

        private void stockOut_Click(object sender, EventArgs e)
        {
            hidePanels();
            panel3.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }


        private void addItem()
        {
            MySqlConnection conn1 = new MySqlConnection(connection);
            MySqlCommand cmd;
            conn1.Open();
            try
            {
                cmd = conn1.CreateCommand();
                cmd.CommandText = "Insert INTO items(itemID,itemName,itemUnits, itemDate, itemQuantity)VALUES(" + setItemID() + ",'" + itemName.Text + "','" + itemUnit.Text + "', @dateValue, 0)";
                cmd.Parameters.Add("@dateValue", MySqlDbType.Date).Value = date.Value.Date;
                cmd.ExecuteNonQuery();


                loginFailed failed = new loginFailed();
                failed.message = "Added Successfully!";
                failed.ShowDialog();

            }

            catch (Exception ex)
            {
                loginFailed failed = new loginFailed();
                failed.message = ex.Message;
                failed.ShowDialog();
            }
            conn1.Close();

        }

        private int setItemID()
        {
            int id = 0;
            MySqlConnection con = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "SELECT COUNT(itemID) as itemCount from items";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    id = dr.GetInt32("itemCount");

                }
                con.Close();
            }

            catch (Exception ex)
            {
                loginFailed failed = new loginFailed();
                failed.message = ex.Message;
                failed.ShowDialog();
            }
            return id++;
        }

        private void save_Click(object sender, EventArgs e)
        {
            addItem();
            clearFields();
            updateTable();
        }

        private void updateTable()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand("SELECT itemName, itemUnits, itemQuantity, ItemID from items", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "items");
                table.DataSource = ds.Tables["items"].DefaultView;
                table.Columns[0].HeaderText = "Items";
                con.Close();
            }
            catch (Exception e)
            {
                loginFailed failed = new loginFailed();
                failed.message = e.Message;
                failed.ShowDialog();
            }
        }

        private void updateItem()
        {
            try
            {
                MySqlConnection conzx = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand("update items set itemName=@name, itemUnits=@itemUnit where itemID=@id", conzx);
                conzx.Open();
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(item_id);
                cmd.Parameters.AddWithValue("@name", itemName.Text);
                cmd.Parameters.AddWithValue("@itemUnit", itemUnit.Text);
                cmd.ExecuteNonQuery();

                loginFailed failed = new loginFailed();
                failed.message = "Updated successfully!";
                failed.ShowDialog();

                conzx.Close();
            }
            catch (Exception e)
            {
                loginFailed failed = new loginFailed();
                failed.message = e.Message;
                failed.ShowDialog();
            }

            updateTable();

        }

        private void cellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                try
                {
                    itemName.Text = table.Rows[e.RowIndex].Cells[0].Value.ToString();
                    itemUnit.Text = table.Rows[e.RowIndex].Cells[1].Value.ToString();
                    item_name = itemName.Text;
                    item_unit = itemUnit.Text;
                    item_id = Int32.Parse(table.Rows[e.RowIndex].Cells[3].Value.ToString());
                }
                catch (Exception ex)
                {
                    //loginFailed failed = new loginFailed();
                    //failed.message = ex.Message;
                    //failed.ShowDialog();

                    errorWindow error = new errorWindow();
                    error.ShowDialog();
                }
            }

        }

        private void clearTextfields_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void update_Click(object sender, EventArgs e)
        {
            updateItem();
            clearFields();
        }

        private void clearFields()
        {
            productCode.Clear();
            itemName.Clear();
            category.Clear();
            size.Clear();
            itemCase.Clear();
            packs.Clear();
            packaging.Clear();
            itemUnit.Clear();
            itemPrice.Clear();
            itemDescription.Clear();
        }

        private void deleteItem()
        {
            try
            {
                MySqlConnection conzx = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand("delete from items where itemID=@id", conzx);
                conzx.Open();
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(item_id);
                cmd.ExecuteNonQuery();

                loginFailed failed = new loginFailed();
                failed.message = "Deleted successfully!";
                failed.ShowDialog();

                conzx.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            updateTable();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            deleteItem();
            clearFields();
        }

        private void stockIn_item_keypressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchItemStockIN();
            }
        }

        private void searchItemStockIN()
        {
            MySqlConnection con = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "SELECT * FROM items WHERE itemName=@item_name";
                cmd.CommandTimeout = 3600;
                cmd.Parameters.Add("@item_name", MySqlDbType.String).Value = stockInItem.Text;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    stockInItem.Text = dr["itemName"].ToString();
                    stockInUnit.Text = dr["itemUnits"].ToString();
                    stockInQuantity.Text = dr["itemQuantity"].ToString();
                }
                else
                {
                    loginFailed failed = new loginFailed();
                    failed.message = "Item doesn't exist.";
                    failed.ShowDialog();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                loginFailed failed = new loginFailed();
                failed.message = ex.Message;
                failed.ShowDialog();
            }
        }

        private void stockInSave_Click(object sender, EventArgs e)
        {
            int quantity = int.Parse(stockInQuantity.Text);
            int added_quantity = int.Parse(stockInAddedQuantity.Text);
            int total = quantity + added_quantity;

            try
            {
                MySqlConnection conzx = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand("update items set itemQuantity=@item_quantity where itemName=@item_name", conzx);
                //  insert into stockin where values itemID.quantity

                conzx.Open();
                cmd.Parameters.Add("@item_quantity", MySqlDbType.Int32).Value = Convert.ToInt32(total);
                cmd.Parameters.Add("@item_name", MySqlDbType.String).Value = stockInItem.Text;
                cmd.ExecuteNonQuery();

                loginFailed failed = new loginFailed();
                failed.message = "Updated Successfully!";
                failed.ShowDialog();

                conzx.Close();
            }
            catch (Exception ex)
            {
                loginFailed failed = new loginFailed();
                failed.message = ex.Message;
                failed.ShowDialog();
            }

            updateTable();
            stockIn_clear();
        }

        private void stockInUpdate_Click(object sender, EventArgs e)
        {
            stock_in_update();
        }

        private void stock_in_update()
        {
            //nothing but an empty shell.

            stockIn_clear();
        }

        private void stockOutSave_Click(object sender, EventArgs e)
        {
            stockOut_Save();
        }

        private void stockOut_Save()
        {
            int quantity = int.Parse(stockOutQuantity.Text);
            int out_quantity = int.Parse(stockOutOutQuantity.Text);
            int total = quantity - out_quantity;

            try
            {
                MySqlConnection conzx = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand("update items set itemQuantity=@item_quantity where itemName=@item_name", conzx);
                conzx.Open();
                cmd.Parameters.Add("@item_quantity", MySqlDbType.Int32).Value = Convert.ToInt32(total);
                cmd.Parameters.Add("@item_name", MySqlDbType.String).Value = stockOutItem.Text;
                cmd.ExecuteNonQuery();

                loginFailed failed = new loginFailed();
                failed.message = "Transaction success!";
                failed.ShowDialog();

                conzx.Close();
            }
            catch (Exception ex)
            {
                loginFailed failed = new loginFailed();
                failed.message = ex.Message;
                failed.ShowDialog();
            }

            updateTable();
            stockOut_clear();
        }

        private void stockout_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchStockOutItem();
            }
        }

        private void searchStockOutItem()
        {
            MySqlConnection con = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "SELECT * FROM items WHERE itemName=@item_name";
                cmd.CommandTimeout = 3600;
                cmd.Parameters.Add("@item_name", MySqlDbType.String).Value = stockOutItem.Text;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    stockOutItem.Text = dr["itemName"].ToString();
                    stockOutUnit.Text = dr["itemUnits"].ToString();
                    stockOutQuantity.Text = dr["itemQuantity"].ToString();
                }
                else
                {
                    loginFailed failed = new loginFailed();
                    failed.message = "Item doesn't exist.";
                    failed.ShowDialog();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                loginFailed failed = new loginFailed();
                failed.message = ex.Message;
                failed.ShowDialog();
            }
        }
        private void stockOut_clear()
        {
            stockOutItem.Clear();
            stockOutQuantity.Clear();
            stockOutOutQuantity.Clear();
            stockOutUnit.Clear();
        }

        private void stockOutClear_Click(object sender, EventArgs e)
        {
            stockOut_clear();
        }

        private void stockInClear_Click(object sender, EventArgs e)
        {
            stockIn_clear();
        }

        private void stockIn_clear()
        {
            stockInItem.Clear();
            stockInQuantity.Clear();
            stockInUnit.Clear();
            stockInAddedQuantity.Clear();
        }

        private void stockOutUpdate_Click(object sender, EventArgs e)
        {


            stockOut_clear();
        }
    }
}
