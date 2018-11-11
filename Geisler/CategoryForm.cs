using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Geisler
{
    public partial class CategoryForm : Form
    {
        ProdContext context = new ProdContext();

        public CategoryForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            context = new ProdContext();
            context.Categories.Load();
            context.Products.Load();
            this.categoryBindingSource.DataSource = context.Categories.Local.ToBindingList();
            this.productsBindingSource.DataSource = context.Products.Local.ToBindingList();

        }

        private void onSaveClick(object sender, EventArgs e)
        {
            context.SaveChanges();
            this.dataGridView1.Refresh();

        }

        private void onCategorySelected(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            Category category = (Category)dataGridView1.Rows[row].DataBoundItem;

            //this.productsBindingSource.DataSource = (from p in context.Products
            //                                         where p.CategoryID == category.CategoryId
            //                                         select p).ToList();

            this.productsBindingSource.DataSource = context.Products
                .Where(p => p.CategoryID == category.CategoryId).ToList();
        }
    }
}