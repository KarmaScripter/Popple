namespace Popple
{
    using Syncfusion.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Syncfusion.Windows.Forms.MetroForm" />
    public partial class ExportTarget : MetroForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportTarget"/> class.
        /// </summary>
        public ExportTarget()
        {
            InitializeComponent();

            ServerTypeComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Gets a value indicating whether [file export].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [file export]; otherwise, <c>false</c>.
        /// </value>
        public bool FileExport
        {
            get
            {
                return FileRadioButton.Checked;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [server export].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [server export]; otherwise, <c>false</c>.
        /// </value>
        public bool ServerExport
        {
            get
            {
                return ServerRadioButton.Checked;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [my SQL export].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [my SQL export]; otherwise, <c>false</c>.
        /// </value>
        public bool MySqlExport
        {
            get
            {
                return ServerTypeComboBox.SelectedIndex == 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [SQL server export].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [SQL server export]; otherwise, <c>false</c>.
        /// </value>
        public bool SqlServerExport
        {
            get
            {
                return ServerTypeComboBox.SelectedIndex == 1;
            }
        }
    }
}