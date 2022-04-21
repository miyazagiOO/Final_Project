using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Form1 : Form
    {
        public Cost cost = new Cost();
        public Form1()
        {
            InitializeComponent();
        }

        public double Cost_of_Item()
        {
            Double Sum = 0;
            int i = 0;

            for (i = 0; i < (dataGridView1.Rows.Count);i++)
            {
                Sum = Sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            return Sum;
        }

        private void AddCost()
        {
           if(dataGridView1.Rows.Count > 0)
            {
                labelTotal.Text = String.Format("{0:0.00}", (Cost_of_Item()));
            }
        }

        Bitmap bitmap;
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                int height = dataGridView1.Height;
                dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                bitmap = new Bitmap(dataGridView1.Width,dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                dataGridView1.Height = height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            try
            {
                labelTotal.Text = "";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                comboBoxPayment.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void Number(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (labelCost.Text == "0")
            {
                labelCost.Text = "";
                labelCost.Text = b.Text;

            }
            else if (b.Text == ".")
            {
                if (!labelCost.Text.Contains("."))
                {
                    labelCost.Text = labelCost.Text + b.Text;
                }
            }
            else
                labelCost.Text = labelCost.Text + b.Text;
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            labelCost.Text = "0";
        }

        private void buttonRemove_Item_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            AddCost();
            if (comboBoxPayment.Text == "Cash") ;
        }

        private void buttonCoffee_Click(object sender, EventArgs e)
        {
            double CostofItem = cost.getCoffee();
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
              if((bool)(row.Cells[0].Value = "กาแฟ"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * CostofItem;
                    
                }
            }
            dataGridView1.Rows.Add("กาแฟ", "1",CostofItem);
            AddCost();
        }

        private void buttonStraw_Click(object sender, EventArgs e)
        {
            double CostofItem = cost.getstbr();
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "สตรอว์เบอร์รี่"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("สตรอว์เบอร์รี่", "1", CostofItem);
            AddCost();
        }

        private void buttonChoco_Click(object sender, EventArgs e)
        {
            double CostofItem = cost.getChoco();
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "ช็อคโกแล็ต"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("ช็อคโกแล็ต", "1", CostofItem);
            AddCost();
        }

        private void buttonCookies_Click(object sender, EventArgs e)
        {
            double CostofItem = cost.getCookies();
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "คุ้กกี้ แอน ครีม"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("คุ้กกี้ แอน ครีม", "1", CostofItem);
            AddCost();
        }

        private void buttonRum_Click(object sender, EventArgs e)
        {
            double CostofItem = cost.getRum();
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "รัมเรซิ่น"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("รัมเรซิ่น", "1", CostofItem);
            AddCost();
        }

        private void buttonChocship_Click(object sender, EventArgs e)
        {
            double CostofItem = cost.getChocship();
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "ช็อกโกแล็ตชิพ"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("ช็อกโกแล็ตชิพ", "1", CostofItem);
            AddCost();
        }

        private void buttonMint_Click(object sender, EventArgs e)
        {
            double CostofItem = cost.getMint();
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "มิ้นท์ ช็อก"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("มิ้นท์ ช็อก", "1", CostofItem);
            AddCost();
        }

        private void buttonOrenge_Click(object sender, EventArgs e)
        {
            double CostofItem = cost.getOrenge();
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "ส้ม"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("ส้ม", "1", CostofItem);
            AddCost();
        }

        private void buttonLime_Click(object sender, EventArgs e)
        {
            double CostofItem = cost.getLime();
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "มะนาว"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("มะนาว", "1", CostofItem);
            AddCost();
        }

        private void buttonThaiTea_Click(object sender, EventArgs e)
        {
            double CostofItem = cost.getThaitea();
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "ชาไทย"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("ชาไทย", "1", CostofItem);
            AddCost();
        }

        private void buttonBurber_Click(object sender, EventArgs e)
        {
            double CostofItem = cost.getBurber();
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "บูลเบอร์รี่ชีสเค้ก"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("บูลเบอร์รี่ชีสเค้ก", "1", CostofItem);
            AddCost();
        }

        private void buttonMango_Click(object sender, EventArgs e)
        {
            double CostofItem = cost.getMango();
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if ((bool)(row.Cells[0].Value = "มะม่วง"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value + 1) * CostofItem;

                }
            }
            dataGridView1.Rows.Add("มะม่วง", "1", CostofItem);
            AddCost();
        }

        private void Change()
        {
            if(dataGridView1.Rows.Count > 0)
            {
                double c,
                C = Convert.ToInt32(labelChange.Text);
                labelChange.Text = String.Format("{0:c2",C  );
            }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            Change change = new Change();
            labelChange.Text = change.getChange(Convert.ToDouble(labelCost.Text), Convert.ToDouble(labelTotal.Text)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int height = dataGridView1.Height;
                dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                dataGridView1.Height = height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }








            //string[] items, Qty, Amount;
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    items[i] = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //    Qty[i] = dataGridView1.Rows[i].Cells[1].Value.ToString();
            //    Amount[i] = dataGridView1.Rows[i].Cells[2].Value.ToString();
            //}

        }
    }
    
}
