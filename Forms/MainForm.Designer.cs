namespace Popple
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.visualButton1 = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.bBrowse = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.bGetDatabases = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.visualPanel1 = new VisualPlus.Toolkit.Controls.Layout.VisualPanel();
            this.visualPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.DefaultExt = "nsf";
            this.OpenFileDialog.Filter = "Lotus Notes Database|*.nsf";
            this.OpenFileDialog.Multiselect = true;
            this.OpenFileDialog.Title = "Open Lotus Notes Databases (.nsf)";
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ForeColor = System.Drawing.Color.LightGray;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.ImageList;
            this.treeView1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(445, 235);
            this.treeView1.TabIndex = 1;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "BlueNinja.ico");
            this.ImageList.Images.SetKeyName(1, "folder");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "NSF Databases";
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.DefaultExt = "sql";
            this.SaveFileDialog.FileName = "export.sql";
            this.SaveFileDialog.Filter = "SQL File|*.sql";
            // 
            // visualButton1
            // 
            this.visualButton1.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.visualButton1.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.visualButton1.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.visualButton1.BackColorState.Pressed = System.Drawing.Color.SteelBlue;
            this.visualButton1.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.visualButton1.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.visualButton1.Border.HoverVisible = true;
            this.visualButton1.Border.Rounding = 6;
            this.visualButton1.Border.Thickness = 1;
            this.visualButton1.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.visualButton1.Border.Visible = true;
            this.visualButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.visualButton1.ForeColor = System.Drawing.Color.LightGray;
            this.visualButton1.Image = null;
            this.visualButton1.Location = new System.Drawing.Point(15, 278);
            this.visualButton1.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.visualButton1.Name = "visualButton1";
            this.visualButton1.Size = new System.Drawing.Size(123, 45);
            this.visualButton1.TabIndex = 6;
            this.visualButton1.Text = "Search Server";
            this.visualButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.visualButton1.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.visualButton1.TextStyle.Enabled = System.Drawing.Color.LightGray;
            this.visualButton1.TextStyle.Hover = System.Drawing.Color.White;
            this.visualButton1.TextStyle.Pressed = System.Drawing.Color.White;
            this.visualButton1.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.visualButton1.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualButton1.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.visualButton1.Click += new System.EventHandler(this.OnSearchServerButtonClick);
            // 
            // bBrowse
            // 
            this.bBrowse.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.bBrowse.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.bBrowse.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.bBrowse.BackColorState.Pressed = System.Drawing.Color.SteelBlue;
            this.bBrowse.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.bBrowse.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.bBrowse.Border.HoverVisible = true;
            this.bBrowse.Border.Rounding = 6;
            this.bBrowse.Border.Thickness = 1;
            this.bBrowse.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.bBrowse.Border.Visible = true;
            this.bBrowse.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bBrowse.ForeColor = System.Drawing.Color.LightGray;
            this.bBrowse.Image = null;
            this.bBrowse.Location = new System.Drawing.Point(179, 278);
            this.bBrowse.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(123, 45);
            this.bBrowse.TabIndex = 7;
            this.bBrowse.Text = "Search Computer";
            this.bBrowse.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.bBrowse.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.bBrowse.TextStyle.Enabled = System.Drawing.Color.LightGray;
            this.bBrowse.TextStyle.Hover = System.Drawing.Color.White;
            this.bBrowse.TextStyle.Pressed = System.Drawing.Color.White;
            this.bBrowse.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.bBrowse.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.bBrowse.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.bBrowse.Click += new System.EventHandler(this.OnSearchComputerButtonClick);
            // 
            // bGetDatabases
            // 
            this.bGetDatabases.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.bGetDatabases.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.bGetDatabases.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.bGetDatabases.BackColorState.Pressed = System.Drawing.Color.SteelBlue;
            this.bGetDatabases.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.bGetDatabases.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.bGetDatabases.Border.HoverVisible = true;
            this.bGetDatabases.Border.Rounding = 6;
            this.bGetDatabases.Border.Thickness = 1;
            this.bGetDatabases.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.bGetDatabases.Border.Visible = true;
            this.bGetDatabases.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bGetDatabases.ForeColor = System.Drawing.Color.LightGray;
            this.bGetDatabases.Image = null;
            this.bGetDatabases.Location = new System.Drawing.Point(337, 278);
            this.bGetDatabases.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.bGetDatabases.Name = "bGetDatabases";
            this.bGetDatabases.Size = new System.Drawing.Size(123, 45);
            this.bGetDatabases.TabIndex = 8;
            this.bGetDatabases.Text = "Export Documents";
            this.bGetDatabases.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.bGetDatabases.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.bGetDatabases.TextStyle.Enabled = System.Drawing.Color.LightGray;
            this.bGetDatabases.TextStyle.Hover = System.Drawing.Color.White;
            this.bGetDatabases.TextStyle.Pressed = System.Drawing.Color.White;
            this.bGetDatabases.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.bGetDatabases.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.bGetDatabases.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.bGetDatabases.Click += new System.EventHandler(this.OnExportDocumentsButtonClick);
            // 
            // visualPanel1
            // 
            this.visualPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.visualPanel1.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.visualPanel1.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.visualPanel1.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.visualPanel1.Border.HoverColor = System.Drawing.Color.SteelBlue;
            this.visualPanel1.Border.HoverVisible = true;
            this.visualPanel1.Border.Rounding = 6;
            this.visualPanel1.Border.Thickness = 1;
            this.visualPanel1.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.visualPanel1.Border.Visible = true;
            this.visualPanel1.Controls.Add(this.treeView1);
            this.visualPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualPanel1.Location = new System.Drawing.Point(15, 25);
            this.visualPanel1.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.visualPanel1.Name = "visualPanel1";
            this.visualPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.visualPanel1.Size = new System.Drawing.Size(445, 235);
            this.visualPanel1.TabIndex = 9;
            this.visualPanel1.Text = "visualPanel1";
            this.visualPanel1.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.visualPanel1.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualPanel1.TextStyle.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualPanel1.TextStyle.Pressed = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.visualPanel1.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.visualPanel1.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.visualPanel1.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.BorderColor = System.Drawing.Color.RoyalBlue;
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.CaptionFont = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionForeColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(481, 335);
            this.Controls.Add(this.visualPanel1);
            this.Controls.Add(this.bGetDatabases);
            this.Controls.Add(this.bBrowse);
            this.Controls.Add(this.visualButton1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.LightGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.MinimumSize = new System.Drawing.Size(420, 167);
            this.Name = "MainForm";
            this.Text = "Notes To SQL";
            this.visualPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList ImageList;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        public System.Windows.Forms.TreeView treeView1;
        public VisualPlus.Toolkit.Controls.Interactivity.VisualButton visualButton1;
        public VisualPlus.Toolkit.Controls.Interactivity.VisualButton bBrowse;
        public VisualPlus.Toolkit.Controls.Interactivity.VisualButton bGetDatabases;
        private VisualPlus.Toolkit.Controls.Layout.VisualPanel visualPanel1;
    }
}

