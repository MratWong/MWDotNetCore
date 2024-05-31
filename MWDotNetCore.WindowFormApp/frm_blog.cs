using MWDotNetCore.Share;
using MWDotNetCore.WindowFormApp.Models;
using System.Data.SqlClient;
using System.Data;

namespace MWDotNetCore.WindowFormApp
{
    public partial class frm_blog : Form
    {

        private readonly DapperService _dapperService;
        private readonly int _blogId;
        public frm_blog()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public frm_blog(int blogId)
        {
            InitializeComponent();
            _blogId = blogId;
            _dapperService = new DapperService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            var model = _dapperService.QueryFirstOrDefault<BlogModel>("select * from tbl_blog where blogid = @BlogId",
                            new { BlogId = _blogId }
                        );
            txt_title.Text = model.BlogTitle;
            txtauthor.Text = model.BlogAuthor;
            txtcontent.Text = model.BlogContent;

            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BlogModel blog = new BlogModel();
                blog.BlogTitle = txt_title.Text.Trim();
                blog.BlogAuthor = txtauthor.Text.Trim();
                blog.BlogContent = txtcontent.Text.Trim();

                int result = _dapperService.Execute(Queries.BlogQuery.BlogCreate, blog);
                string message = result > 0 ? "Saving Successfully." : "Saving Failed.";
                var messageBoxIcon = result > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Error;
                MessageBox.Show(message, "Blog", MessageBoxButtons.OK, messageBoxIcon);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            ClearControl();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
        }
        private void ClearControl()
        {
            txt_title.Clear();
            txtauthor.Clear();
            txtcontent.Clear();
            txt_title.Focus();
        }

        private void frm_blog_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new BlogModel
                {
                    BlogId = _blogId,
                    BlogTitle = txt_title.Text.Trim(),
                    BlogAuthor = txtauthor.Text.Trim(),
                    BlogContent = txtcontent.Text.Trim()
                };

                string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

                int result = _dapperService.Execute(query, item);

                string message = result > 0 ? "Updating Successful." : "Updating Failed.";
                MessageBox.Show(message);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
