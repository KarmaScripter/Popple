namespace Popple
{
    partial class ExportTarget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportTarget));
            this.ServerRadioButton = new System.Windows.Forms.RadioButton();
            this.FileRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.btnCancel = new VisualPlus.Toolkit.Controls.Interactivity.VisualButton();
            this.ServerTypeComboBox = new VisualPlus.Toolkit.Controls.Interactivity.VisualComboBox();
            this.SuspendLayout();
            // 
            // ServerRadioButton
            // 
            this.ServerRadioButton.AutoSize = true;
            this.ServerRadioButton.Checked = true;
            this.ServerRadioButton.Location = new System.Drawing.Point(81, 51);
            this.ServerRadioButton.Margin = new System.Windows.Forms.Padding(1);
            this.ServerRadioButton.Name = "ServerRadioButton";
            this.ServerRadioButton.Size = new System.Drawing.Size(57, 17);
            this.ServerRadioButton.TabIndex = 1;
            this.ServerRadioButton.TabStop = true;
            this.ServerRadioButton.Text = "Server";
            this.ServerRadioButton.UseVisualStyleBackColor = true;
            // 
            // FileRadioButton
            // 
            this.FileRadioButton.AutoSize = true;
            this.FileRadioButton.Location = new System.Drawing.Point(161, 51);
            this.FileRadioButton.Margin = new System.Windows.Forms.Padding(1);
            this.FileRadioButton.Name = "FileRadioButton";
            this.FileRadioButton.Size = new System.Drawing.Size(43, 17);
            this.FileRadioButton.TabIndex = 2;
            this.FileRadioButton.Text = "File";
            this.FileRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Target:";
            // 
            // btnOK
            // 
            this.btnOK.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btnOK.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnOK.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnOK.BackColorState.Pressed = System.Drawing.Color.SteelBlue;
            this.btnOK.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnOK.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnOK.Border.HoverVisible = true;
            this.btnOK.Border.Rounding = 6;
            this.btnOK.Border.Thickness = 1;
            this.btnOK.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.btnOK.Border.Visible = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOK.ForeColor = System.Drawing.Color.LightGray;
            this.btnOK.Image = null;
            this.btnOK.Location = new System.Drawing.Point(12, 81);
            this.btnOK.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(102, 29);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnOK.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btnOK.TextStyle.Enabled = System.Drawing.Color.LightGray;
            this.btnOK.TextStyle.Hover = System.Drawing.Color.White;
            this.btnOK.TextStyle.Pressed = System.Drawing.Color.White;
            this.btnOK.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnOK.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.btnOK.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btnCancel.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnCancel.BackColorState.Hover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnCancel.BackColorState.Pressed = System.Drawing.Color.SteelBlue;
            this.btnCancel.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.btnCancel.Border.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnCancel.Border.HoverVisible = true;
            this.btnCancel.Border.Rounding = 6;
            this.btnCancel.Border.Thickness = 1;
            this.btnCancel.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.btnCancel.Border.Visible = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.ForeColor = System.Drawing.Color.LightGray;
            this.btnCancel.Image = null;
            this.btnCancel.Location = new System.Drawing.Point(140, 81);
            this.btnCancel.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 29);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnCancel.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btnCancel.TextStyle.Enabled = System.Drawing.Color.LightGray;
            this.btnCancel.TextStyle.Hover = System.Drawing.Color.White;
            this.btnCancel.TextStyle.Pressed = System.Drawing.Color.White;
            this.btnCancel.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnCancel.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.btnCancel.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // ServerTypeComboBox
            // 
            this.ServerTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ServerTypeComboBox.BackColorState.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ServerTypeComboBox.BackColorState.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ServerTypeComboBox.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ServerTypeComboBox.Border.HoverColor = System.Drawing.Color.SteelBlue;
            this.ServerTypeComboBox.Border.HoverVisible = true;
            this.ServerTypeComboBox.Border.Rounding = 6;
            this.ServerTypeComboBox.Border.Thickness = 1;
            this.ServerTypeComboBox.Border.Type = VisualPlus.Enumerators.ShapeTypes.Rounded;
            this.ServerTypeComboBox.Border.Visible = true;
            this.ServerTypeComboBox.ButtonColor = System.Drawing.Color.SteelBlue;
            this.ServerTypeComboBox.ButtonImage = null;
            this.ServerTypeComboBox.ButtonStyle = VisualPlus.Toolkit.Controls.Interactivity.VisualComboBox.ButtonStyles.Arrow;
            this.ServerTypeComboBox.ButtonWidth = 30;
            this.ServerTypeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ServerTypeComboBox.DropDownHeight = 100;
            this.ServerTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServerTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServerTypeComboBox.ForeColor = System.Drawing.Color.LightGray;
            this.ServerTypeComboBox.FormattingEnabled = true;
            this.ServerTypeComboBox.ImageList = null;
            this.ServerTypeComboBox.ImageVisible = false;
            this.ServerTypeComboBox.Index = 0;
            this.ServerTypeComboBox.IntegralHeight = false;
            this.ServerTypeComboBox.ItemHeight = 24;
            this.ServerTypeComboBox.ItemImageVisible = true;
            this.ServerTypeComboBox.Location = new System.Drawing.Point(97, 9);
            this.ServerTypeComboBox.MenuItemHover = System.Drawing.Color.SteelBlue;
            this.ServerTypeComboBox.MenuItemNormal = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ServerTypeComboBox.MenuTextColor = System.Drawing.Color.White;
            this.ServerTypeComboBox.MouseState = VisualPlus.Enumerators.MouseStates.Normal;
            this.ServerTypeComboBox.Name = "ServerTypeComboBox";
            this.ServerTypeComboBox.SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.ServerTypeComboBox.Size = new System.Drawing.Size(152, 30);
            this.ServerTypeComboBox.State = VisualPlus.Enumerators.MouseStates.Normal;
            this.ServerTypeComboBox.TabIndex = 10;
            this.ServerTypeComboBox.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ServerTypeComboBox.TextDisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.ServerTypeComboBox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ServerTypeComboBox.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.ServerTypeComboBox.TextRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ServerTypeComboBox.TextStyle.Disabled = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(129)))), ((int)(((byte)(129)))));
            this.ServerTypeComboBox.TextStyle.Enabled = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ServerTypeComboBox.TextStyle.Hover = System.Drawing.Color.Empty;
            this.ServerTypeComboBox.TextStyle.Pressed = System.Drawing.Color.Empty;
            this.ServerTypeComboBox.TextStyle.TextAlignment = System.Drawing.StringAlignment.Center;
            this.ServerTypeComboBox.TextStyle.TextLineAlignment = System.Drawing.StringAlignment.Center;
            this.ServerTypeComboBox.TextStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.ServerTypeComboBox.Watermark.Active = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ServerTypeComboBox.Watermark.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerTypeComboBox.Watermark.Inactive = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));
            this.ServerTypeComboBox.Watermark.Text = "Watermark text";
            this.ServerTypeComboBox.Watermark.Visible = false;
            // 
            // ExportTarget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.BorderColor = System.Drawing.Color.SteelBlue;
            this.CaptionAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.CaptionForeColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(286, 131);
            this.Controls.Add(this.ServerTypeComboBox);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileRadioButton);
            this.Controls.Add(this.ServerRadioButton);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.LightGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.MinimizeBox = false;
            this.Name = "ExportTarget";
            this.Text = "Export SQL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton ServerRadioButton;
        private System.Windows.Forms.RadioButton FileRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public VisualPlus.Toolkit.Controls.Interactivity.VisualButton btnOK;
        public VisualPlus.Toolkit.Controls.Interactivity.VisualButton btnCancel;
        private VisualPlus.Toolkit.Controls.Interactivity.VisualComboBox ServerTypeComboBox;
    }
}