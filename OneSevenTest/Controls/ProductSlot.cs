using OneSevenTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneSevenTest.Controls
{
    public partial class ProductSlot : UserControl
    {

        #region Properties

        public string image = string.Empty;
        public string title = string.Empty;
        public string category = string.Empty;
        public string description = string.Empty;
        public int idProduct = 0;
        public int quantity = 0;
        public decimal? price = 0;
        public int Enumeration = 0;

        #endregion Properties
        public ProductSlot()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                rtbDescription.Text = description;
                lblTitle.Text = title;
                lblCategory.Text = "Category: " + category;
                lblProductPrice.Text = "$ " + string.Format("{0:c}", price);
                pbProductImage.LoadAsync(image);
                pbProductImage.SizeMode = PictureBoxSizeMode.StretchImage;
                txtQuantityBox.Text = quantity.ToString();
                txtQuantityBox.TextAlign = HorizontalAlignment.Center;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtQuantityBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                txtQuantityBox.Text = (int.Parse(txtQuantityBox.Text) + 1).ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnLess_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtQuantityBox.Text) == 0)
                    return;
                else
                    txtQuantityBox.Text = (int.Parse(txtQuantityBox.Text) - 1).ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form1.car.Exists(x => x.IdProduct == idProduct))
                    Form1.car.Where(x => x.IdProduct == idProduct).Select(y => y.quantity = int.Parse(txtQuantityBox.Text));
                else
                    Form1.car.Add(new IdCar { quantity = int.Parse(txtQuantityBox.Text), IdProduct = idProduct });

                txtQuantityBox.Text = "0";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Form1.car.Exists(x => x.IdProduct == idProduct))
                    Form1.car = Form1.car.Where(x => x.IdProduct != idProduct).ToList();

                txtQuantityBox.Text = "0";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
