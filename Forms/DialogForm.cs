namespace Popple
{
    using System;
    using System.Drawing;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Syncfusion.Windows.Forms;
    using Microsoft.WindowsAPICodePack.Taskbar;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Syncfusion.Windows.Forms.MetroForm" />
    public class DialogForm : MetroForm
    {
        /// <summary>
        /// The message
        /// </summary>
        public readonly Label _message;

        /// <summary>
        /// The progress bar
        /// </summary>
        public readonly ProgressBar _progressBar;

        /// <summary>
        /// The b cancel
        /// </summary>
        private readonly Button _bCancel;

        /// <summary>
        /// Occurs when [cancelled].
        /// </summary>
        public event CancelEventHandler Cancelled;

        /// <summary>
        /// Initializes a new instance of the <see cref="DialogForm"/> class.
        /// </summary>
        public DialogForm()
        {
            _message = new Label();
            _progressBar = new ProgressBar();
            _bCancel = new Button();
            SuspendLayout();

            _message.AutoSize = true;
            _message.Location = new Point( 12, 9 );
            _message.Name = "message";
            _message.Size = new Size( 54, 13 );
            _message.TabIndex = 0;
            _message.Text = "Loading...";

            _progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _progressBar.Location = new Point( 12, 25 );
            _progressBar.Name = "progressBar";
            _progressBar.Size = new Size( 421, 23 );
            _progressBar.TabIndex = 1;

            _bCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            _bCancel.Location = new Point( 358, 54 );
            _bCancel.Name = "bCancel";
            _bCancel.Size = new Size( 75, 23 );
            _bCancel.TabIndex = 2;
            _bCancel.Text = "Cancel";
            _bCancel.UseVisualStyleBackColor = true;
            _bCancel.Click += bCancel_Click;

            AutoScaleDimensions = new SizeF( 6F, 13F );
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size( 445, 89 );
            ControlBox = false;
            Controls.Add( _bCancel );
            Controls.Add( _progressBar );
            Controls.Add( _message );
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "dialogForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Loading";
            ResumeLayout( false );
            PerformLayout();
        }

        /// <summary>
        /// Handles the Click event of the bCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bCancel_Click( object sender,
            EventArgs e )
        {
            if( TaskbarManager.IsPlatformSupported )
            {
                TaskbarManager.Instance.SetProgressState( TaskbarProgressBarState.Error );
            }

            if( MessageBox.Show( "Are you sure you want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2 ) == DialogResult.Yes )
            {
                _bCancel.Enabled = false;
                Text = "Cancelling...";

                Cancelled?.Invoke( this, new CancelEventArgs( true ) );
            }
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogForm));
            this.SuspendLayout();
            // 
            // DialogForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.BorderColor = System.Drawing.Color.Blue;
            this.CaptionBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.CaptionFont = new System.Drawing.Font("Source Code Pro", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClientSize = new System.Drawing.Size(447, 301);
            this.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.Name = "DialogForm";
            this.ResumeLayout(false);

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class InputBox
    {
        /// <summary>
        /// 
        /// </summary>
        /// <seealso cref="System.Windows.Forms.Form" />
        public class DialogForm : Form
        {
            /// <summary>
            /// The text box
            /// </summary>
            public readonly TextBox[ ] _textBox;

            /// <summary>
            /// The label
            /// </summary>
            public readonly Label[ ] _label;

            /// <summary>
            /// The button1
            /// </summary>
            private readonly Button _button1;

            /// <summary>
            /// The button2
            /// </summary>
            private readonly Button _button2;

            /// <summary>
            /// The button3
            /// </summary>
            private readonly Button _button3;

            /// <summary>
            /// Gets the input result.
            /// </summary>
            /// <value>
            /// The input result.
            /// </value>
            public InputBoxResult InputResult { get; private set; } = InputBoxResult.Cancel;

            /// <summary>
            /// Initializes a new instance of the <see cref="DialogForm"/> class.
            /// </summary>
            /// <param name="title">The title.</param>
            /// <param name="items">The items.</param>
            /// <param name="buttons">The buttons.</param>
            /// <exception cref="System.Exception">Invalid InputBoxButton Value</exception>
            public DialogForm( string title, InputItem[ ] items, InputBoxButtons buttons )
            {
                var _minWidth = 312;
                _label = new Label[ items.Length ];

                for( var _i = 0; _i < _label.Length; _i++ )
                {
                    _label[ _i ] = new Label();
                }

                _textBox = new TextBox[ items.Length ];

                for( var _i = 0; _i < _textBox.Length; _i++ )
                {
                    _textBox[ _i ] = new TextBox();
                }

                _button2 = new Button();
                _button3 = new Button();
                _button1 = new Button();
                SuspendLayout();

                for( var _i = 0; _i < items.Length; _i++ )
                {
                    _label[ _i ].AutoSize = true;
                    _label[ _i ].Location = new Point( 12, 9 + _i * 39 );
                    _label[ _i ].Name = "label[" + _i + "]";
                    _label[ _i ].Text = items[ _i ].Label;

                    if( _label[ _i ].Width > _minWidth )
                    {
                        _minWidth = _label[ _i ].Width;
                    }
                }

                for( var _i = 0; _i < items.Length; _i++ )
                {
                    _textBox[ _i ].Anchor =
                        AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                    _textBox[ _i ].Location = new Point( 12, 25 + _i * 39 );
                    _textBox[ _i ].Name = "textBox[" + _i + "]";
                    _textBox[ _i ].Size = new Size( 288, 20 );
                    _textBox[ _i ].TabIndex = _i;
                    _textBox[ _i ].Text = items[ _i ].Text;

                    if( items[ _i ].IsPassword )
                    {
                        _textBox[ _i ].UseSystemPasswordChar = true;
                    }
                }

                _button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                _button1.Location = new Point( 208, 15 + 39 * _label.Length );
                _button1.Name = "button1";
                _button1.Size = new Size( 92, 23 );
                _button1.TabIndex = items.Length + 2;
                _button1.Text = "button1";
                _button1.UseVisualStyleBackColor = true;

                _button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                _button2.Location = new Point( 110, 15 + 39 * _label.Length );
                _button2.Name = "button2";
                _button2.Size = new Size( 92, 23 );
                _button2.TabIndex = items.Length + 1;
                _button2.Text = "button2";
                _button2.UseVisualStyleBackColor = true;

                _button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                _button3.Location = new Point( 12, 15 + 39 * _label.Length );
                _button3.Name = "button3";
                _button3.Size = new Size( 92, 23 );
                _button3.TabIndex = items.Length;
                _button3.Text = "button3";
                _button3.UseVisualStyleBackColor = true;

                switch( buttons )
                {
                    case InputBoxButtons.Ok:
                        _button1.Text = "OK";
                        _button1.Click += OK_Click;
                        _button2.Visible = false;
                        _button3.Visible = false;
                        AcceptButton = _button1;
                        break;

                    case InputBoxButtons.OkCancel:
                        _button1.Text = "Cancel";
                        _button1.Click += Cancel_Click;
                        _button2.Text = "OK";
                        _button2.Click += OK_Click;
                        _button3.Visible = false;
                        AcceptButton = _button2;
                        break;

                    case InputBoxButtons.YesNo:
                        _button1.Text = "No";
                        _button1.Click += No_Click;
                        _button2.Text = "Yes";
                        _button2.Click += Yes_Click;
                        _button3.Visible = false;
                        AcceptButton = _button2;
                        break;

                    case InputBoxButtons.YesNoCancel:
                        _button1.Text = "Cancel";
                        _button1.Click += Cancel_Click;
                        _button2.Text = "No";
                        _button2.Click += No_Click;
                        _button3.Text = "Yes";
                        _button3.Click += Yes_Click;
                        AcceptButton = _button3;
                        break;

                    case InputBoxButtons.Save:
                        _button1.Text = "Save";
                        _button1.Click += Save_Click;
                        _button2.Visible = false;
                        _button3.Visible = false;
                        AcceptButton = _button1;
                        break;

                    case InputBoxButtons.SaveCancel:
                        _button1.Text = "Cancel";
                        _button1.Click += Cancel_Click;
                        _button2.Text = "Save";
                        _button2.Click += Save_Click;
                        _button3.Visible = false;
                        AcceptButton = _button2;
                        break;

                    default:
                        throw new Exception( "Invalid InputBoxButton Value" );
                }

                AutoScaleDimensions = new SizeF( 6F, 13F );
                AutoScaleMode = AutoScaleMode.Font;
                ClientSize = new Size( 312, 47 + 39 * items.Length );

                for( var _i = 0; _i < _label.Length; _i++ )
                {
                    Controls.Add( _label[ _i ] );
                }

                for( var _i = 0; _i < _textBox.Length; _i++ )
                {
                    Controls.Add( _textBox[ _i ] );
                }

                Controls.Add( _button1 );
                Controls.Add( _button2 );
                Controls.Add( _button3 );
                MaximizeBox = false;
                MinimizeBox = false;
                MaximumSize = new Size( 99999, 85 + 39 * items.Length );
                Name = "dialogForm";
                ShowIcon = false;
                ShowInTaskbar = false;
                Text = title;
                ResumeLayout( false );
                PerformLayout();

                foreach( var _l in _label )
                {
                    if( _l.Width > _minWidth )
                    {
                        _minWidth = _l.Width;
                    }
                }

                ClientSize = new Size( _minWidth  + 24, 47 + 39 * items.Length );
                MinimumSize = new Size( _minWidth + 40, 85 + 39 * items.Length );
            }

            /// <summary>
            /// Handles the Click event of the OK control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void OK_Click( object sender, EventArgs e )
            {
                InputResult = InputBoxResult.Ok;
                Close();
            }

            /// <summary>
            /// Handles the Click event of the Cancel control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void Cancel_Click( object sender, EventArgs e )
            {
                InputResult = InputBoxResult.Cancel;
                Close();
            }

            /// <summary>
            /// Handles the Click event of the Yes control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void Yes_Click( object sender, EventArgs e )
            {
                InputResult = InputBoxResult.Yes;
                Close();
            }

            /// <summary>
            /// Handles the Click event of the No control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void No_Click( object sender, EventArgs e )
            {
                InputResult = InputBoxResult.No;
                Close();
            }

            /// <summary>
            /// Handles the Click event of the Save control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
            private void Save_Click( object sender, EventArgs e )
            {
                InputResult = InputBoxResult.Save;
                Close();
            }
        }
    }
}