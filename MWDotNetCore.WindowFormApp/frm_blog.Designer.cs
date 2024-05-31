namespace MWDotNetCore.WindowFormApp
{
    partial class frm_blog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbtitle = new Label();
            lbauthor = new Label();
            lb_content = new Label();
            txt_title = new TextBox();
            txtauthor = new TextBox();
            txtcontent = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // lbtitle
            // 
            lbtitle.AutoSize = true;
            lbtitle.Location = new Point(275, 68);
            lbtitle.Name = "lbtitle";
            lbtitle.Size = new Size(44, 25);
            lbtitle.TabIndex = 0;
            lbtitle.Text = "Title";
            // 
            // lbauthor
            // 
            lbauthor.AutoSize = true;
            lbauthor.Location = new Point(275, 130);
            lbauthor.Name = "lbauthor";
            lbauthor.Size = new Size(67, 25);
            lbauthor.TabIndex = 1;
            lbauthor.Text = "Author";
            // 
            // lb_content
            // 
            lb_content.AutoSize = true;
            lb_content.Location = new Point(275, 192);
            lb_content.Name = "lb_content";
            lb_content.Size = new Size(75, 25);
            lb_content.TabIndex = 2;
            lb_content.Text = "Content";
            // 
            // txt_title
            // 
            txt_title.Location = new Point(275, 96);
            txt_title.Name = "txt_title";
            txt_title.Size = new Size(280, 31);
            txt_title.TabIndex = 3;
            // 
            // txtauthor
            // 
            txtauthor.Location = new Point(275, 158);
            txtauthor.Name = "txtauthor";
            txtauthor.Size = new Size(280, 31);
            txtauthor.TabIndex = 4;
            // 
            // txtcontent
            // 
            txtcontent.Location = new Point(275, 230);
            txtcontent.Multiline = true;
            txtcontent.Name = "txtcontent";
            txtcontent.Size = new Size(280, 96);
            txtcontent.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ActiveCaption;
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(275, 345);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 6;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.ActiveBorder;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(412, 345);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(0, 192, 192);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(275, 345);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "&Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // frm_blog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 550);
            Controls.Add(btnUpdate);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtcontent);
            Controls.Add(txtauthor);
            Controls.Add(txt_title);
            Controls.Add(lb_content);
            Controls.Add(lbauthor);
            Controls.Add(lbtitle);
            Name = "frm_blog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blog";
            Load += frm_blog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbtitle;
        private Label lbauthor;
        private Label lb_content;
        private TextBox txt_title;
        private TextBox txtauthor;
        private TextBox txtcontent;
        private Button btnSave;
        private Button btnCancel;
        private Button btnUpdate;
    }
}
