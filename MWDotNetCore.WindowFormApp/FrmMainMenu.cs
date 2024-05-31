using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MWDotNetCore.WindowFormApp
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void newBlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_blog frm = new frm_blog();
            frm.ShowDialog();
        }

        private void blogListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBlogList frmBlogList = new frmBlogList();
            frmBlogList.ShowDialog();
        }
    }
}
