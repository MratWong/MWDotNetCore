using MWDotNetCore.Share;
using MWDotNetCore.WindowFormApp.Models;
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
    public partial class frmBlogList : Form
    {
        private readonly DapperService _dapperService;
        public frmBlogList()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }

        private void frmBlogList_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        private void formLoad()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>("select * from tbl_blog");
            dgvData.DataSource = lst;
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var blogId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value);
            if (e.ColumnIndex == (int)EnumFormControlType.Edit)
            {
                frm_blog frm = new frm_blog(blogId);
                frm.ShowDialog();
                formLoad();

            }else if(e.ColumnIndex ==(int) EnumFormControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes) return;
                DeleteBlog(blogId);
            }
        }

        private void DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog] where BlogId = @BlogId";

            int result = _dapperService.Execute(query, new { BlogId = id });
            string message = result > 0 ? "Deleting Successfully." : "Deleting Failed.";
            MessageBox.Show(message);
            formLoad();
        }
    }
}
