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
using System.Globalization;
using System.Globalization;

namespace POS
{
    public partial class mainPage : Form
    {
        int stockItemID_searched = 0;
        int item_id = 0;
        string item_name = "";
        string item_unit = "";

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
            updateStockInTable();

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
            updateTable();
            refresh_autosuggest();
        }

        private void showStockin(object sender, EventArgs e)
        {
            hidePanels();
            stockIn_panel.Visible = true;
            updateStockInTable();
            refresh_autosuggest();

        }

        private void hidePanels()
        {
            panel1.Visible = false;
            stockIn_panel.Visible = false;
            panel3.Visible = false;
        }

        private void stockOut_Click(object sender, EventArgs e)
        {
            hidePanels();
            panel3.Visible = true;
            refresh_autosuggest();
            update_stockout_table();

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
                cmd.CommandText = "Insert INTO items(itemName,itemUnits, itemDate, itemQuantity)VALUES('" + itemName.Text + "','" + itemUnit.Text + "', @dateValue, 0)";
                cmd.Parameters.Add("@dateValue", MySqlDbType.Date).Value = date.Value.Date;
                cmd.ExecuteNonQuery();


                loginFailed failed = new loginFailed();
                failed.message = "Added Successfully!";
                failed.ShowDialog();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            conn1.Close();

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
                MySqlCommand cmd = new MySqlCommand("SELECT itemName as 'Item Name', itemUnits as 'Item Units', itemQuantity as 'Item Quantity', ItemID as 'Item ID' from items", con);
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
                MessageBox.Show(e.Message);

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
                MessageBox.Show(e.Message);

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
                    MessageBox.Show(ex.Message);

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
                    stockItemID_searched = Convert.ToInt32(dr["itemID"].ToString());
                }
                else
                {
                    MessageBox.Show("item doesn't exist.");

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
            updateItemQuantity(stockInItem.Text);
            insertStockIn();
            updateTable();
        }

        private void stockInUpdate_Click(object sender, EventArgs e)
        {
            edit_stockin();
            clearStockinfields();
        }

        private void stockOutSave_Click(object sender, EventArgs e)
        {
            stockOut_Save();
            insert_stockout();
            stockOut_clear();
        }

        private void insert_stockout()
        {
            MySqlConnection conn1 = new MySqlConnection(connection);
            MySqlCommand cmd;
            conn1.Open();
            try
            {
                cmd = conn1.CreateCommand();
                cmd.CommandText = "Insert INTO stockout(item_name, out_quantity, date, itemID)VALUES(@item_name, @out_quantity, @date, @itemID)";
                cmd.Parameters.Add("@item_name", MySqlDbType.String).Value = stockOutItem.Text;
                cmd.Parameters.Add("@out_quantity", MySqlDbType.Int32).Value = Convert.ToInt32(stockOutOutQuantity.Text);
                cmd.Parameters.Add("@date", MySqlDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("@itemID", MySqlDbType.Int32).Value = item_stockout_id;
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn1.Close();
            updateStockInTable();
            clearStockinfields();
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
                MessageBox.Show(ex.Message);

            }

            updateTable();
        }

        int item_stockout_id = 0;
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
                    item_stockout_id = Convert.ToInt32(dr["itemID"].ToString());
                }
                else
                {
                    MessageBox.Show("item doesn't exist");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void stockOut_clear()
        {
            stockOutItem.Clear();
            stockOutQuantity.Clear();
            stockOutOutQuantity.Clear();
            stockOutUnit.Clear();
            stockOutQuantity.Text = "";
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
            stockInQuantity.Text = "";
            stockInUnit.Clear();
            stockInAddedQuantity.Clear();
            stockInCareOf.Clear();
        }

        private void stockOutUpdate_Click(object sender, EventArgs e)
        {
            update_stockout_data();
            stockOut_clear();
        }


        private void autoSuggest(Guna2TextBox textbox)
        {
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();


            MySqlConnection con = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "SELECT itemName FROM items ";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    source.Add(dr["itemName"].ToString());
                }
                textbox.AutoCompleteCustomSource = source;
                textbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void autoSuggest2(Guna2TextBox textbox)
        {
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();


            MySqlConnection con = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "SELECT itemUnits FROM items ";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    source.Add(dr["itemUnits"].ToString());
                }
                textbox.AutoCompleteCustomSource = source;
                textbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void mainPage_Load(object sender, EventArgs e)
        {
            refresh_autosuggest();
            stockInQuantity.Enabled = false;
        }
        private void refresh_autosuggest()
        {
            autoSuggest(stockOutItem);
            autoSuggest(stockInItem);
            autoSuggest(itemName);
            autoSuggest2(itemUnit);
        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private int setStockIn_ID()
        {
            int id = 1;
            MySqlConnection con = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "SELECT COUNT(*) as stockInItemCount from stockin";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    id += dr.GetInt32("stockInItemCount");

                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return id++;
        }

        private void insertStockIn()
        {
            MySqlConnection conn1 = new MySqlConnection(connection);
            MySqlCommand cmd;
            conn1.Open();
            try
            {
                cmd = conn1.CreateCommand();
                cmd.CommandText = "Insert INTO stockin(item_name, AddedQuantity, Careof, itemID, stock_in_date)VALUES( @item_name, @addedQuantity, @careOf, @itemID, @stock_in_date)";
                cmd.Parameters.Add("@item_name", MySqlDbType.String).Value = stockInItem.Text;
                cmd.Parameters.Add("@addedQuantity", MySqlDbType.Int32).Value = Convert.ToInt32(stockInAddedQuantity.Text);
                cmd.Parameters.Add("@careOf", MySqlDbType.String).Value = stockInCareOf.Text;
                cmd.Parameters.Add("@itemID", MySqlDbType.Int32).Value = stockItemID_searched;
                cmd.Parameters.Add("@stock_in_date", MySqlDbType.Date).Value = DateTime.Now;
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn1.Close();
            updateStockInTable();
            clearStockinfields();

        }

        private int get_current_item_quantity(string name)
        {
            MySqlConnection con = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "SELECT itemQuantity FROM items where itemName='" + name + "'";
                cmd.CommandTimeout = 3600;
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    return Convert.ToInt32(dr["itemQuantity"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return 0;
        }
        private void edit_stockin()
        {
            int current = Convert.ToInt32(stockInAddedQuantity.Text);
            int prev = prev_added_quantity;
            if (current > prev)
            {
                update_stockin_data();
                updatestockin_greater_current(prev, current);
                updateStockInTable();
            }
            else if (current < prev)
            {
                update_stockin_data();
                updatestockin_lesser_current(prev, current);
                updateStockInTable();

            }
            else
            {
                update_stockin_data();
            }

            updateStockInTable();
            clearStockinfields();

        }

        private void update_stockin_data()
        {
            MySqlConnection conn1 = new MySqlConnection(connection);
            MySqlCommand cmd;
            conn1.Open();
            try
            {
                cmd = conn1.CreateCommand();
                cmd.CommandText = "update stockin set AddedQuantity=@addedQuantity, careOf=@careOf where stock_in_id=@transactionID";
                cmd.Parameters.Add("@transactionID", MySqlDbType.Int32).Value = transactionID;
                cmd.Parameters.Add("@addedQuantity", MySqlDbType.Int32).Value = Convert.ToInt32(stockInAddedQuantity.Text);
                cmd.Parameters.Add("@careOf", MySqlDbType.String).Value = stockInCareOf.Text;
                cmd.ExecuteNonQuery();
                updateItemQuantity(stockInItem.Text);
                MessageBox.Show("update successfully.");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn1.Close();
            updateStockInTable();
        }

        private void updatestockin_lesser_current(int prev, int current)
        {
            try
            {
                MySqlConnection conzx = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand("update items set itemQuantity=itemQuantity-@itemQuantity where itemID=@itemID", conzx);
                conzx.Open();
                cmd.Parameters.Add("@itemQuantity", MySqlDbType.Int32).Value = (prev - current);
                cmd.Parameters.Add("@itemID", MySqlDbType.Int32).Value = stockItemID_searched;
                clearStockinfields();

                cmd.ExecuteNonQuery();

                loginFailed failed = new loginFailed();
                failed.message = "Updated successfully!";
                failed.ShowDialog();

                conzx.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            updateStockInTable();
        }

        private void updatestockin_greater_current(int prev, int current)
        {
            try
            {
                MySqlConnection conzx = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand("update items set itemQuantity=itemQuantity+@itemQuantity where itemName='" + stockInItem.Text + "'", conzx);
                conzx.Open();
                cmd.Parameters.Add("@itemQuantity", MySqlDbType.Int32).Value = (current - prev);

                cmd.ExecuteNonQuery();

                loginFailed failed = new loginFailed();
                failed.message = "Updated successfully!";
                failed.ShowDialog();

                conzx.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            updateStockInTable();
        }

        private void updateItemQuantity(string name)
        {
            try
            {
                MySqlConnection conzx = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand("update items set itemQuantity=itemQuantity+@itemQuantity where itemName='" + name + "'", conzx);
                conzx.Open();
                cmd.Parameters.Add("@itemQuantity", MySqlDbType.Int32).Value = Convert.ToInt32(stockInAddedQuantity.Text.ToString());
                cmd.ExecuteNonQuery();

                loginFailed failed = new loginFailed();
                failed.message = "Updated successfully!";
                failed.ShowDialog();

                conzx.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            updateStockInTable();
        }
        int transactionID = 0;
        private void updateStockInTable()
        {

            try

            {
                MySqlConnection con = new MySqlConnection(connection);

                MySqlCommand cmd = new MySqlCommand("SELECT stock_in_id as 'Transaction ID', item_name as 'Item Name', AddedQuantity as 'Added Quantity', careOf as 'Care Of' from stockin where stock_in_date=@stockInDate", con);
                cmd.Parameters.Add("@stockInDate", MySqlDbType.Date).Value = DateTime.Now;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "stockin");
                stockIn_table.DataSource = ds.Tables["stockin"].DefaultView;

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }

        int prev_added_quantity = 0;
        private void stockInTable_cellClicked(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (stockIn_table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    try
                    {

                        transactionID = Convert.ToInt32(stockIn_table.Rows[e.RowIndex].Cells[0].Value.ToString());
                        stockInItem.Text = (stockIn_table.Rows[e.RowIndex].Cells[1].Value.ToString());
                        stockInAddedQuantity.Text = (stockIn_table.Rows[e.RowIndex].Cells[2].Value.ToString());
                        prev_added_quantity = Convert.ToInt32(stockIn_table.Rows[e.RowIndex].Cells[2].Value.ToString());
                        stockInCareOf.Text = (stockIn_table.Rows[e.RowIndex].Cells[1].Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception exx)
            {

            }

        }
        private void clearStockinfields()
        {
            stockInItem.Clear();
            stockInAddedQuantity.Clear();
            stockInQuantity.Clear();
            stockInUnit.Clear();
            stockInCareOf.Clear();
        }

        private void stockIn_table_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                stockIn_table.Rows[0].Selected = false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void stockInReport_Click(object sender, EventArgs e)
        {
            to_print window = new to_print();
            window.ShowDialog();
        }

        private void stockOutItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void stockOutItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchStockOutItem();
            }
        }

        private void stockOutOutQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void update_stockout_table()
        {

            try

            {
                MySqlConnection con = new MySqlConnection(connection);

                MySqlCommand cmd = new MySqlCommand("SELECT stock_out_id as 'Transaction ID', item_name as 'Item Name', out_quantity as 'Out Quantity', itemID as 'Item ID' from stockout where date=@date", con);
                cmd.Parameters.Add("@date", MySqlDbType.Date).Value = DateTime.Now;
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "stockout");
                stockout_table.DataSource = ds.Tables["stockout"].DefaultView;

                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }

        int out_transactionID = 0;
        private void stockout_table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (table.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    try
                    {

                        out_transactionID = Convert.ToInt32(stockIn_table.Rows[e.RowIndex].Cells[0].Value.ToString());
                        stockOutItem.Text = (stockIn_table.Rows[e.RowIndex].Cells[1].Value.ToString());
                        stockOutOutQuantity.Text = (stockIn_table.Rows[e.RowIndex].Cells[2].Value.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception exx)
            {

            }
        }

        private void update_stockout_data()
        {
            try
            {
                MySqlConnection conzx = new MySqlConnection(connection);
                MySqlCommand cmd = new MySqlCommand("update stockout set item_name=@item_name, out_quantity=@out where itemID=" + out_transactionID + "", conzx);
                conzx.Open();
                cmd.Parameters.Add("@item_name", MySqlDbType.String).Value = stockOutItem.Text;
                cmd.Parameters.Add("@out", MySqlDbType.Int32).Value = Convert.ToInt32(stockOutOutQuantity.Text);

                cmd.ExecuteNonQuery();

                loginFailed failed = new loginFailed();
                failed.message = "Updated successfully!";
                failed.ShowDialog();

                conzx.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            updateStockInTable();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            stockout_print window = new stockout_print();
            window.ShowDialog();
        }
    }
}
