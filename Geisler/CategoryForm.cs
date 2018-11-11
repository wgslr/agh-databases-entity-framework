﻿using System;
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
        int? currentCategoryId;

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
            context.Customers.Load();
            this.categoryBindingSource.DataSource = context.Categories.Local.ToBindingList();
            this.productsBindingSource.DataSource = context.Products.Local.ToBindingList();
            this.customerBindingSource.DataSource = context.Customers.Local.ToBindingList();
        }

        private void onSaveClick(object sender, EventArgs e)
        {
            context.SaveChanges();
            this.categoriesGridView.Refresh();
            this.productsGridView.Refresh();

        }


        private void onCategorySelected(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            Category category = (Category)categoriesGridView.Rows[row].DataBoundItem;

            if (category != null)
            {
                this.currentCategoryId = category.CategoryId;

                this.productsBindingSource.DataSource = (from p in context.Products
                                                         where p.CategoryID == category.CategoryId
                                                         select p).ToList();

                //this.productsBindingSource.DataSource = new BindingList<Product>(context.Products
                //    .Where(p => p.CategoryID == category.CategoryId).ToList());
            }
        }

        private void onDefaultProductValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["CategoryId"].Value = currentCategoryId;
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {

        }

        private void customersSaveButton_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }


        private void customerCombo_DropDown(object sender, EventArgs e)
        {
            this.customerCombo.DataSource = context.Customers.Local.ToBindingList(); 
        }

        private void categoryCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.categoryCombo.SelectedValue != null)
            {
                int catId = (int)this.categoryCombo.SelectedValue;
                this.productCombo.DataSource = (from p in context.Products where p.CategoryID == catId select p).ToList();
            }
            else
            {
                this.productCombo.DataSource = new BindingList<Product>();
            }
            this.productCombo.SelectedIndex = -1;
        }
    }
}