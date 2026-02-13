using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InventoryApp
{
    public partial class Form1 : Form
    {
        private List<Product> products = new List<Product>();

        public Form1()
        {
            InitializeComponent();
            SetupUI();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private TextBox txtName;
        private TextBox txtQuantity;
        private TextBox txtPrice;
        private Button btnAdd;
        private DataGridView grid;

        private void SetupUI()
        {
            this.Text = "Inventory Management System";
            this.Width = 800;
            this.Height = 500;

            Label lblName = new Label() { Text = "Product Name", Left = 20, Top = 20 };
            txtName = new TextBox() { Left = 120, Top = 20, Width = 200 };

            Label lblQuantity = new Label() { Text = "Quantity", Left = 20, Top = 60 };
            txtQuantity = new TextBox() { Left = 120, Top = 60, Width = 200 };

            Label lblPrice = new Label() { Text = "Price", Left = 20, Top = 100 };
            txtPrice = new TextBox() { Left = 120, Top = 100, Width = 200 };

            btnAdd = new Button()
            {
                Text = "Add Product",
                Left = 120,
                Top = 140,
                Width = 120
            };

            btnAdd.Click += AddProduct;

            grid = new DataGridView()
            {
                Left = 350,
                Top = 20,
                Width = 400,
                Height = 300,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            grid.DataSource = products;

            this.Controls.Add(lblName);
            this.Controls.Add(txtName);
            this.Controls.Add(lblQuantity);
            this.Controls.Add(txtQuantity);
            this.Controls.Add(lblPrice);
            this.Controls.Add(txtPrice);
            this.Controls.Add(btnAdd);
            this.Controls.Add(grid);
        }

        private void AddProduct(object sender, EventArgs e)
        {
            if (int.TryParse(txtQuantity.Text, out int quantity) &&
                decimal.TryParse(txtPrice.Text, out decimal price))
            {
                products.Add(new Product
                {
                    Name = txtName.Text,
                    Quantity = quantity,
                    Price = price
                });

                grid.DataSource = null;
                grid.DataSource = products;

                txtName.Clear();
                txtQuantity.Clear();
                txtPrice.Clear();
            }
            else
            {
                MessageBox.Show("Please enter valid quantity and price.");
            }
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
