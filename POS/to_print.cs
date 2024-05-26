using DGVPrinterHelper;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class to_print : Form
    {
        static string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public to_print()
        {
            InitializeComponent();
            updateStockInTable();
            autoSuggest(itemsearch);
        }

        private void updateStockInTable()
        {

            try

            {
                MySqlConnection con = new MySqlConnection(connection);

                MySqlCommand cmd = new MySqlCommand("SELECT stock_in_id as 'Transaction ID', item_name as 'Item Name', AddedQuantity as 'Added Quantity', careOf as 'Care Of' from stockin", con);
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(stockIn_table.Width, stockIn_table.Height);
            stockIn_table.DrawToBitmap(bmp, new Rectangle(0, 0, stockIn_table.Width, stockIn_table.Height));
            e.Graphics.DrawImage(bmp, 120, 20);
        }

        private void stockInReport_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Stock in Report";
            printer.SubTitle = string.Format("Date From: {0}        Date to: {1}", from.Value, to.Value);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "End of me";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(stockIn_table);

        }

        private void set_Click(object sender, EventArgs e)
        {
            if (itemsearch.Text.Length > 0)
            {

                items_withname();
            }
            else
            {
                all_items();
            }
        }


        private void all_items()
        {
            try

            {
                MySqlConnection con = new MySqlConnection(connection);

                MySqlCommand cmd = new MySqlCommand("SELECT stock_in_id as 'Transaction ID', item_name as 'Item Name', AddedQuantity as 'Added Quantity', careOf as 'Care Of' from stockin where stock_in_date >= @datefrom and stock_in_date<=@dateto", con);
                cmd.Parameters.Add("@datefrom", MySqlDbType.Date).Value = from.Value;
                cmd.Parameters.Add("@dateto", MySqlDbType.Date).Value = to.Value;
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

        private void items_withname()
        {
            try

            {
                MySqlConnection con = new MySqlConnection(connection);

                MySqlCommand cmd = new MySqlCommand("SELECT stock_in_id as 'Transaction ID', item_name as 'Item Name', AddedQuantity as 'Added Quantity', careOf as 'Care Of' from stockin where stock_in_date >= @datefrom and stock_in_date<=@dateto and item_name ='"+itemsearch.Text+"'", con);
                cmd.Parameters.Add("@datefrom", MySqlDbType.Date).Value = from.Value;
                cmd.Parameters.Add("@dateto", MySqlDbType.Date).Value = to.Value;
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
    }
}
