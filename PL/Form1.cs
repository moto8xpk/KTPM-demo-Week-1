using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DTO;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = ProductBUS.getAllProducts();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



 //       private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
   //     {

     //   }

        private void dataGridView1_CellDoubleClick(Object sender, DataGridViewCellEventArgs e)
        {
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "CellDoubleClick Event");

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = txtSearch.Text.Trim();
            List<Product> products = ProductBUS.searchByName(keyword);
            dataGridView1.DataSource = products;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String productId=dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            Product product = ProductBUS.searchById(productId);
            txtId.Text = product.id.ToString();
            txtName.Text = product.name.ToString();
            txtCateId.Text = product.cateid.ToString();
            txtPrice.Text = product.price.ToString();
            txtDesc.Text = product.description.ToString();
            txtImageLink.Text = product.imagelink.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                id = Int32.Parse(txtId.Text),
                name = txtName.Text.ToString(),
                cateid = Int32.Parse(txtCateId.Text),
                price = Int32.Parse(txtPrice.Text),
                description = txtDesc.Text.ToString(),
                imagelink = txtImageLink.Text.ToString()
            };

            var confirmResult = MessageBox.Show("Are you sure to update this item ??",
                                     "Confirm Update!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (ProductBUS.updateById(product))
                    MessageBox.Show("Success !");
                else
                    MessageBox.Show("Fuck You !");
                dataGridView1.DataSource = ProductBUS.getAllProducts();

                this.clearText();
            }
            else
            {
                // If 'No', do something here.
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String id = txtId.Text.ToString();

            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (ProductBUS.deleteById(id))
                    MessageBox.Show("Success !");
                else
                    MessageBox.Show("Fuck You !");
                dataGridView1.DataSource = ProductBUS.getAllProducts();

                this.clearText();
            }
            else
            {
                // If 'No', do something here.
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                id = Int32.Parse(txtId.Text),
                name = txtName.Text.ToString(),
                cateid = Int32.Parse(txtCateId.Text),
                price = Int32.Parse(txtPrice.Text),
                description = txtDesc.Text.ToString(),
                imagelink = txtImageLink.Text.ToString()
            };

            if (ProductBUS.Insert(product))
                MessageBox.Show("Success !");
            else
                MessageBox.Show("Fuck You !");
            dataGridView1.DataSource = ProductBUS.getAllProducts();
            this.clearText();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // If 'Yes', do something here.
            }
            else
            {
                // If 'No', do something here.
            }
        }
        public void clearText()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtCateId.Text = "";
            txtPrice.Text = "";
            txtDesc.Text = "";
            txtImageLink.Text = "";
        }
    }
}
