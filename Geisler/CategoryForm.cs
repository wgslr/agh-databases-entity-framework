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
            this.categoryBindingSource.DataSource = context.Categories.Local.ToBindingList();
        }

        private void onSaveClick(object sender, EventArgs e)
        {
            context.SaveChanges();
            this.dataGridView1.Refresh();

        }
    }
}
