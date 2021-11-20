using OneSevenTest.DataAccess;
using OneSevenTest.Helper;
using OneSevenTest.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using OneSevenTest.Controls;

namespace OneSevenTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Properties

        private List<TblProduct> Stock = new List<TblProduct>();
        internal static List<IdCar> car = new List<IdCar>();

        #endregion Properties


        /// <summary>
        /// Evento to load any product in DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //parent.Controls.Add(browser);

                Stock = Querys.Instance.GetTable();

                if(Stock.Count == 0)
                {
                    MessageBox.Show("Pleas click button to update DB with API", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                List<String> categorys = new List<string>();
                categorys.Add("all");
                categorys.AddRange(Stock.Select(x => x.Category).Distinct());

                tblProductBindingSource.DataSource = categorys;

                int i = 0;
                foreach(TblProduct product in Stock)
                {
                    ProductSlot slot = new ProductSlot();
                    slot.Enumeration = i++;
                    slot.description = product.Description;
                    slot.title = product.Title;
                    slot.category = product.Category;
                    slot.image = product.Image;
                    slot.price = product.Price;
                    slot.idProduct = product.IdProduct;
                    slot.LoadData();
                    flpStore.Controls.Add(slot);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                foreach(ProductSlot control in flpStore.Controls.OfType<ProductSlot>())
                {
                    if (cbxCategory.SelectedValue == null)
                        return;

                    if (cbxCategory.SelectedValue.ToString().Trim() == "all")
                    {
                        control.Show();
                    }
                    else
                    {
                        if (control.category.Trim() != cbxCategory.SelectedValue.ToString().Trim())
                            control.Hide();
                        else
                            control.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<TblProduct> products = new List<TblProduct>();
            try
            {
                products = ApiHelper.Instance.GetNewItemsApi();
                if (products.Count > 0)
                {
                    Querys.Instance.CleanTable();
                    Querys.Instance.SaveNewItems(products);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
