namespace Popple
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Domino;
    using System.IO;
    using MySql.Data.MySqlClient;
    using System.Text.RegularExpressions;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;
    using Syncfusion.Windows.Forms;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Syncfusion.Windows.Forms.MetroForm" />
    [ SuppressMessage( "ReSharper", "FunctionComplexityOverflow" ) ]
    [ SuppressMessage( "ReSharper", "PossibleNullReferenceException" ) ]
    [ SuppressMessage( "ReSharper", "AccessToModifiedClosure" ) ]
    [ SuppressMessage( "ReSharper", "ConvertToLambdaExpressionWhenPossible" ) ]
    [ SuppressMessage( "ReSharper", "RedundantAssignment" ) ]
    [ SuppressMessage( "ReSharper", "AccessToDisposedClosure" ) ]
    public partial class MainForm : MetroForm
    {
        /// <summary>
        /// The on local computer
        /// </summary>
        private bool _onLocalComputer;

        /// <summary>
        /// The notes server
        /// </summary>
        private string _notesServer = "";

        /// <summary>
        /// The notes domain
        /// </summary>
        private string _notesDomain = "";

        /// <summary>
        /// The notes password
        /// </summary>
        private string _notesPassword = "";

        /// <summary>
        /// The mysql server
        /// </summary>
        private string _mysqlServer = "";

        /// <summary>
        /// The mysql database
        /// </summary>
        private string _mysqlDatabase = "";

        /// <summary>
        /// The mysql username
        /// </summary>
        private string _mysqlUsername = "";

        /// <summary>
        /// The mysql password
        /// </summary>
        private string _mysqlPassword = "";

        /// <summary>
        /// The mysql number rows per insert
        /// </summary>
        private int _insertRows = 1000;

        /// <summary>
        /// The exclude field
        /// </summary>
        private readonly Regex _regex = new Regex( "^(Form)$" );

        /// <summary>
        /// The SQL generator
        /// </summary>
        private static ISqlGenerator _sqlGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            SaveFileDialog.InitialDirectory =
                Environment.GetFolderPath( Environment.SpecialFolder.DesktopDirectory );

            treeView1.TreeViewNodeSorter = new NodeSorter();

            var _args = Environment.GetCommandLineArgs();
            var _notesFile = "";
            var _showHelp = false;
            var _error = new List<string>();

            for( var _i = 1; _i < _args.Length; _i++ )
            {
                switch( _args[ _i ] )
                {
                    case "-notesServer":
                        if( _args.Length > _i + 1 )
                        {
                            _notesServer = _args[ ++_i ];
                        }
                        else
                        {
                            _error.Add( "Need argument after -notesServer" );
                            _showHelp = true;
                        }

                        break;

                    case "-notesDomain":
                        if( _args.Length > _i + 1 )
                        {
                            _notesDomain = _args[ ++_i ];
                        }
                        else
                        {
                            _error.Add( "Need argument after -notesDomain" );
                            _showHelp = true;
                        }

                        break;

                    case "-notesPassword":
                        if( _args.Length > _i + 1 )
                        {
                            _notesPassword = _args[ ++_i ];
                        }
                        else
                        {
                            _error.Add( "Need argument after -notesPassword" );
                            _showHelp = true;
                        }

                        break;

                    case "-mysqlServer":
                        if( _args.Length > _i + 1 )
                        {
                            _mysqlServer = _args[ ++_i ];
                        }
                        else
                        {
                            _error.Add( "Need argument after -mysqlServer" );
                            _showHelp = true;
                        }

                        break;

                    case "-mysqlDatabase":
                        if( _args.Length > _i + 1 )
                        {
                            _mysqlDatabase = _args[ ++_i ];
                        }
                        else
                        {
                            _error.Add( "Need argument after -mysqlDatabase" );
                            _showHelp = true;
                        }

                        break;

                    case "-mysqlUsername":
                        if( _args.Length > _i + 1 )
                        {
                            _mysqlUsername = _args[ ++_i ];
                        }
                        else
                        {
                            _error.Add( "Need argument after -mysqlUsername" );
                            _showHelp = true;
                        }

                        break;

                    case "-mysqlPassword":
                        if( _args.Length > _i + 1 )
                        {
                            _mysqlPassword = _args[ ++_i ];
                        }
                        else
                        {
                            _error.Add( "Need argument after -mysqlPassword" );
                            _showHelp = true;
                        }

                        break;

                    case "-notesFile":
                        if( _args.Length > _i + 1 )
                        {
                            _notesFile = _args[ ++_i ];
                        }
                        else
                        {
                            _error.Add( "Need argument after -notesFile" );
                            _showHelp = true;
                        }

                        break;

                    case "/?":
                    case "-?":
                    case "/help":
                    case "-help":
                        _showHelp = true;
                        break;

                    default:
                        _error.Add( _args[ _i ] + " is not a valid argument." );
                        _showHelp = true;
                        break;
                }
            }

            if( _notesFile != "" )
            {
                try
                {
                    var _nSession = InitSession( _notesPassword );
                    NotesDatabase _db;

                    if( File.Exists( _notesFile )
                        || _notesServer == "" && _notesDomain == "" )
                    {
                        _db = _nSession.GetDatabase( "", _notesFile, false );
                        _onLocalComputer = true;
                    }
                    else
                    {
                        _db = _nSession.GetDatabase( _notesServer + "//" + _notesDomain, _notesFile,
                            false );

                        _onLocalComputer = false;
                    }

                    treeView1.Nodes.Add( _db.FilePath, _db.Title, "database", "database" );
                }
                catch( Exception _ex )
                {
                    _error.Add( "Error loading -notesFile: " + _ex.Message );
                }
            }

            if( _showHelp )
            {
                const string _argString = "Arguments:\n"
                    + "\n"
                    + "-notesServer: The Domino server name\n"
                    + "-notesDomain: The Domino server domain\n"
                    + "-notesPassword: The password for Lotus Notes\n"
                    + "-notesFile: The file path to the nsf database\n"
                    + "-mysqlDatabase: The database name for the exported documents\n"
                    + "-mysqlServer: The mysql server address or IP address\n"
                    + "-mysqlUsername: The username for the mysql server\n"
                    + "-mysqlPassword: The password for the mysql server\n"
                    + "\n"
                    + "Examples:\n"
                    + "\n"
                    + "nsf2sql.exe -notesServer domino -notesDomain company"
                    + " -notesPassword \"your password\" -notesFile banner.nsf"
                    + " -mysqlDatabase banner_nsf";

                if( _error.Count > 0 )
                {
                    var _messageText = "Errors:\n\n" + String.Join( "\n\n", _error );
                    _messageText += "\n\n" + _argString;

                    MessageBox.Show( _messageText, "NSF2SQL Command Line Arguments",
                        MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
                else
                {
                    MessageBox.Show( _argString, "NSF2SQL Command Line Arguments",
                        MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
            }
        }

        /// <summary>
        /// Called when [search server button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="ea">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnSearchServerButtonClick( object sender, EventArgs ea )
        {
            treeView1.Nodes.Clear();
            _onLocalComputer = false;

            var _input = InputBox.Show( "Domino Server", new[ ]
            {
                new InputItem( "Server", _notesServer ),
                new InputItem( "Domain", _notesDomain ),
                new InputItem( "Password", _notesPassword, true )
            }, InputBoxButtons.OkCancel );

            if( _input.Result == InputBoxResult.Ok )
            {
                _notesServer = _input.Items[ "Server" ];
                _notesDomain = _input.Items[ "Domain" ];
                _notesPassword = _input.Items[ "Password" ];

                var _progressdialog = new ProgressDialog();
                _progressdialog.Title = "Get Databases";
                _progressdialog.Style = ProgressBarStyle.Marquee;

                _progressdialog.DoWork += delegate( object dialog, DoWorkEventArgs e )
                {
                    try
                    {
                        var _nSession = InitSession( _notesPassword );
                        _progressdialog.ReportProgress( 0 );

                        var _directory =
                            _nSession.GetDbDirectory( _notesServer + "//" + _notesDomain );

                        var _db = _directory.GetFirstDatabase( DB_TYPES.DATABASE );
                        var _i = 0;

                        while( _db != null )
                        {
                            if( _progressdialog.IsCancelled )
                            {
                                e.Cancel = true;
                                return;
                            }

                            var _path = _db.FilePath.Split( '\\' );

                            treeView1.Invoke( (MethodInvoker)delegate
                            {
                                var _nodes = treeView1.Nodes;

                                for( var _n = 0; _n < _path.Length - 1; _n++ )
                                {
                                    var _folder = _path[ _n ].ToUpper();

                                    if( !_nodes.ContainsKey( _folder ) )
                                    {
                                        _nodes.Add( _folder, _folder, "folder", "folder" );
                                    }

                                    _nodes = _nodes[ _folder ].Nodes;
                                }

                                _nodes.Add( _db.FilePath, _db.Title, "database", "database" );
                            } );

                            _db = _directory.GetNextDatabase();
                            _progressdialog.ReportProgress( _i );
                            _i++;
                        }
                    }
                    catch( Exception _ex )
                    {
                        MessageBox.Show( _ex.Message );
                    }
                };

                _progressdialog.ProgressChanged += delegate( object dialog,
                    ProgressChangedEventArgs e )
                {
                    _progressdialog.Message = e.ProgressPercentage + " Databases Found";
                };

                _progressdialog.Completed += delegate( object dialog,
                    RunWorkerCompletedEventArgs e )
                {
                    if( e.Cancelled )
                    {
                        treeView1.Nodes.Clear();
                    }
                    else
                    {
                        treeView1.Sort();
                    }
                };

                _progressdialog.Run();
            }
        }

        /// <summary>
        /// Handles the Click event of the bSearchComputer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnSearchComputerButtonClick( object sender, EventArgs e )
        {
            if( OpenFileDialog.ShowDialog() == DialogResult.OK )
            {
                try
                {
                    treeView1.Nodes.Clear();

                    var _input = InputBox.Show( "Lotus Notes Password",
                        new InputItem( "Password", _notesPassword, true ),
                        InputBoxButtons.OkCancel );

                    if( _input.Result == InputBoxResult.Ok )
                    {
                        _notesPassword = _input.Items[ "Password" ];
                        var _nSession = InitSession( _notesPassword );
                        _onLocalComputer = true;

                        foreach( var _file in OpenFileDialog.FileNames )
                        {
                            var _db = _nSession.GetDatabase( "", _file, false );
                            treeView1.Nodes.Add( _file, _db.Title, "database", "database" );
                        }

                        treeView1.Sort();
                    }
                }
                catch( Exception _ex )
                {
                    MessageBox.Show( _ex.Message );
                }

                OpenFileDialog.FileName = "";
            }
        }

        /// <summary>
        /// Handles the Click event of the bExportDocuments control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="ea">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnExportDocumentsButtonClick( object sender, EventArgs ea )
        {
            if( treeView1.SelectedNode == null
                || treeView1.SelectedNode.Nodes.Count > 0 )
            {
                MessageBox.Show( "Select a database." );
                return;
            }

            var _total = 0;
            long _startTicks = 0;
            long _lastTicks = 0;
            var _timeLeft = "";
            var _timeElapsed = "0:00:00";
            var _databasePath = treeView1.SelectedNode.Name;
            var _pDialog = new ProgressDialog();
            _pDialog.Title = "Exporting Documents";

            _pDialog.DoWork += delegate( object dialog, DoWorkEventArgs e )
            {
                var _exportdialog = new ExportTarget();

                try
                {
                    var _nSession = InitSession( _notesPassword );
                    var _tables = new Dictionary<string, DataTable>();

                    NotesDatabase _db;

                    if( _onLocalComputer )
                    {
                        _db = _nSession.GetDatabase( "", _databasePath, false );
                    }
                    else
                    {
                        _db = _nSession.GetDatabase( _notesServer + "//" + _notesDomain,
                            _databasePath, false );
                    }

                    _total = _db.AllDocuments.Count;
                    var _allDocuments = _db.AllDocuments;
                    var _doc = _allDocuments.GetFirstDocument();
                    _startTicks = DateTime.Now.Ticks;

                    for( var _i = 0; _i < _total; _i++ )
                    {
                        if( _pDialog.IsCancelled )
                        {
                            e.Cancel = true;
                            return;
                        }

                        if( _doc.HasItem( "Form" )
                            && (string)_doc.GetItemValue( "Form" )[ 0 ] != "" )
                        {
                            var _form = (string)_doc.GetItemValue( "Form" )[ 0 ];

                            if( !_tables.ContainsKey( _form ) )
                            {
                                _tables.Add( _form, new DataTable( _form ) );
                            }

                            var _row = _tables[ _form ].AddRow();

                            foreach( NotesItem _item in _doc.Items )
                            {
                                if( _pDialog.IsCancelled )
                                {
                                    e.Cancel = true;
                                    return;
                                }

                                var _field = _item.Name;

                                if( _field == null
                                    || this._regex.IsMatch( _field ) )
                                {
                                    continue;
                                }

                                var _type = "";

                                switch( _item.type )
                                {
                                    case IT_TYPE.NUMBERS:
                                        _type = "decimal(20,10)";
                                        break;

                                    case IT_TYPE.DATETIMES:
                                        _type = "datetime";
                                        break;

                                    default:
                                        _type = "text";
                                        break;
                                }

                                object _values = _item.Values;
                                bool _multiple = _item.Values.Length > 1;

                                if( !_tables[ _form ].Columns.ContainsKey( _field ) )
                                {
                                    _tables[ _form ].Columns.Add( _field,
                                        new DataColumn( _field, _type ) );
                                }

                                if( _multiple
                                    && !_tables[ _form ].Columns[ _field ].HasMultiple )
                                {
                                    _tables[ _form ].Columns[ _field ].HasMultiple = _multiple;
                                }

                                if( !_tables[ _form ].Columns[ _field ].Values
                                    .ContainsKey( _row ) )
                                {
                                    _tables[ _form ].Columns[ _field ].Values
                                        .Add( _row, _values );
                                }
                                else
                                {
                                    var _j = 1;

                                    while( _tables[ _form ].Columns.ContainsKey( _field + _j )
                                        && _tables[ _form ].Columns[ _field + _j ].Values.ContainsKey( _row ) )
                                    {
                                        _j++;
                                    }

                                    _field += _j;

                                    if( !_tables[ _form ].Columns.ContainsKey( _field ) )
                                    {
                                        _tables[ _form ].Columns.Add( _field,
                                            new DataColumn( _field, _type ) );
                                    }

                                    if( _multiple
                                        && !_tables[ _form ].Columns[ _field ].HasMultiple )
                                    {
                                        _tables[ _form ].Columns[ _field ].HasMultiple = _multiple;
                                    }

                                    _tables[ _form ].Columns[ _field ].Values.Add( _row, _values );
                                }
                            }
                        }

                        _pDialog.ReportProgress( _i, "Parsing Documents" );
                        _doc = _allDocuments.GetNextDocument( _doc );
                    }

                    var _newTables = new Dictionary<string, DataTable>( _tables.Count );
                    _lastTicks = 0;
                    _startTicks = DateTime.Now.Ticks;
                    _total = _tables.Count;
                    var _count = 0;

                    foreach( var _table in _tables.Values )
                    {
                        if( _pDialog.IsCancelled )
                        {
                            e.Cancel = true;
                            return;
                        }

                        _pDialog.ReportProgress( ++_count, "Formatting Tables" );
                        var _columns = new Dictionary<string, DataColumn>( _table.Columns );

                        foreach( var _column in _columns.Values )
                        {
                            if( _column.HasMultiple )
                            {
                                var _tableName = _table.Name + "_" + _column.Name;
                                var _newTable = new DataTable( _tableName, _table.Name );
                                var _values = new DataColumn( _column.Name, _column.Type );
                                var _ids = new DataColumn( _table.Name + "id", "int" );

                                foreach( var _cell in _column.Values )
                                {
                                    if( _pDialog.IsCancelled )
                                    {
                                        e.Cancel = true;
                                        return;
                                    }

                                    var _id = _cell.Key;
                                    object[ ] _valueArray;

                                    if( _cell.Value.GetType().IsArray )
                                    {
                                        _valueArray = (object[ ])_cell.Value;
                                    }
                                    else
                                    {
                                        _valueArray = new[ ]
                                        {
                                            _cell.Value
                                        };
                                    }

                                    foreach( var _value in _valueArray )
                                    {
                                        if( _pDialog.IsCancelled )
                                        {
                                            e.Cancel = true;
                                            return;
                                        }

                                        var _row = _newTable.AddRow();
                                        _ids.Values.Add( _row, _id );
                                        _values.Values.Add( _row, _value );
                                    }
                                }

                                _newTable.Columns.Add( _table.Name + "id", _ids );
                                _newTable.Columns.Add( _column.Name, _values );
                                _newTables.Add( _tableName, _newTable );
                                _table.Columns.Remove( _column.Name );
                            }
                            else
                            {
                                var _values = new Dictionary<int, object>( _column.Values );

                                foreach( var _cell in _values )
                                {
                                    if( _pDialog.IsCancelled )
                                    {
                                        e.Cancel = true;
                                        return;
                                    }

                                    var _id = _cell.Key;
                                    object _value;

                                    if( _cell.Value.GetType().IsArray )
                                    {
                                        _value = ( (object[ ])_cell.Value ).Length > 0
                                            ? ( (object[ ])_cell.Value )[ 0 ]
                                            : null;
                                    }
                                    else
                                    {
                                        _value = _cell.Value;
                                    }

                                    _column.Values[ _id ] = _value;
                                }
                            }
                        }

                        _newTables.Add( _table.Name, _table );
                    }

                    _total = _newTables.Count;
                    var _complete = false;

                    _lastTicks = 0;
                    _count = 0;
                    var _result = DialogResult.Cancel;

                    Invoke( (MethodInvoker)delegate
                    {
                        if( _exportdialog != null )
                        {
                            _result = _exportdialog.ShowDialog( this );
                        }
                    } );

                    if( _result == DialogResult.Cancel )
                    {
                        e.Cancel = true;
                        return;
                    }

                    if( _exportdialog.SqlServerExport )
                    {
                        _sqlGenerator = new SqlGenerator();
                    }
                    else if( _exportdialog.MySqlExport )
                    {
                        _sqlGenerator = new MySqlGenerator();
                    }

                    do
                    {
                        if( _exportdialog.ServerExport )
                        {
                            InputBox _input = null;

                            Invoke( (MethodInvoker)delegate
                            {
                                _input = InputBox.Show( _pDialog.Window, "SQL server info?", new[ ]
                                {
                                    new InputItem( "Server", _mysqlServer ),
                                    new InputItem( "Database", _mysqlDatabase ),
                                    new InputItem( "Username", _mysqlUsername ),
                                    new InputItem( "Password", _mysqlPassword, true ),
                                    new InputItem( "Number of rows per INSERT",
                                        _insertRows.ToString() )
                                }, InputBoxButtons.OkCancel );
                            } );

                            if( _input.Result == InputBoxResult.Ok )
                            {
                                _mysqlServer = _input.Items[ "Server" ];
                                _mysqlDatabase = _input.Items[ "Database" ];
                                _mysqlUsername = _input.Items[ "Username" ];
                                _mysqlPassword = _input.Items[ "Password" ];

                                int.TryParse( _input.Items[ "Number of rows per INSERT" ],
                                    out _insertRows );

                                DbConnection _conn = null;

                                if( _exportdialog.MySqlExport )
                                {
                                    _conn = new MySqlConnection( "SERVER="
                                        + _mysqlServer
                                        + ";USERNAME="
                                        + _mysqlUsername
                                        + ";PASSWORD="
                                        + _mysqlPassword
                                        + ";" );
                                }
                                else if( _exportdialog.SqlServerExport )
                                {
                                    _conn = new SqlConnection( "Server="
                                        + _mysqlServer
                                        + ";User Id="
                                        + _mysqlUsername
                                        + ";Password="
                                        + _mysqlPassword
                                        + ";" );
                                }

                                try
                                {
                                    _startTicks = DateTime.Now.Ticks;
                                    _conn.Open();

                                    string[ ] _tokens = null;

                                    if( _exportdialog.SqlServerExport )
                                    {
                                        _tokens = _sqlGenerator
                                            .CreateDatabase( _mysqlDatabase ).Split( new[ ]
                                            {
                                                "GO\r\n"
                                            }, StringSplitOptions.None );
                                    }
                                    else
                                    {
                                        _tokens = new[ ]
                                        {
                                            _sqlGenerator.CreateDatabase( _mysqlDatabase )
                                            + _sqlGenerator.SetVariables()
                                        };
                                    }

                                    var _command = _conn.CreateCommand();

                                    foreach( var _sqlString in _tokens )
                                    {
                                        _command.CommandText = _sqlString;
                                        _command.ExecuteNonQuery();
                                    }

                                    foreach( var _table in _newTables.Values.Where( t =>
                                        string.IsNullOrEmpty( t.LinkedTable ) ) )
                                    {
                                        if( _pDialog.IsCancelled )
                                        {
                                            e.Cancel = true;
                                            return;
                                        }

                                        _pDialog.ReportProgress( ++_count, "Inserting SQL" );

                                        if( _table.Columns.Count > 0 )
                                        {
                                            _command.CommandText =
                                                _sqlGenerator.CreateTable( _table );

                                            _command.ExecuteNonQuery();

                                            var _rows =
                                                _sqlGenerator.InsertTableRowsToList( _table );

                                            for( var _i = 0; _i < _rows.Count;
                                                _i += _insertRows )
                                            {
                                                _command.CommandText =
                                                    _sqlGenerator.BeginInsertTable( _table );

                                                _command.CommandText += String.Join( ",",
                                                        _rows.GetRange( _i,
                                                            Math.Min( _rows.Count - _i,
                                                                _insertRows ) ) )
                                                    + ";\n";

                                                _command.CommandText +=
                                                    _sqlGenerator.EndInsertTable( _table );

                                                _command.ExecuteNonQuery();
                                                _pDialog.ReportProgress( _count, "Inserting SQL" );
                                            }
                                        }
                                    }

                                    foreach( var _table in _newTables.Values.Where( t =>
                                        !string.IsNullOrEmpty( t.LinkedTable ) ) )
                                    {
                                        if( _pDialog.IsCancelled )
                                        {
                                            e.Cancel = true;
                                            return;
                                        }

                                        _pDialog.ReportProgress( ++_count, "Inserting SQL" );

                                        if( _table.Columns.Count > 0 )
                                        {
                                            _command.CommandText =
                                                _sqlGenerator.CreateTable( _table );

                                            _command.ExecuteNonQuery();

                                            var _rows =
                                                _sqlGenerator.InsertTableRowsToList( _table );

                                            for( var _i = 0; _i < _rows.Count;
                                                _i += _insertRows )
                                            {
                                                _command.CommandText =
                                                    _sqlGenerator.BeginInsertTable( _table );

                                                _command.CommandText += String.Join( ",",
                                                        _rows.GetRange( _i,
                                                            Math.Min( _rows.Count - _i,
                                                                _insertRows ) ) )
                                                    + ";\n";

                                                _command.CommandText +=
                                                    _sqlGenerator.EndInsertTable( _table );

                                                _command.ExecuteNonQuery();
                                                _pDialog.ReportProgress( _count, "Inserting SQL" );
                                            }
                                        }
                                    }

                                    _command.CommandText = _sqlGenerator.RestoreVariables();

                                    if( !string.IsNullOrEmpty( _command.CommandText ) )
                                    {
                                        _command.ExecuteNonQuery();
                                    }

                                    _complete = true;
                                }
                                catch( Exception _ex )
                                {
                                    MessageBox.Show( _ex.Message );
                                }
                                finally
                                {
                                    _conn.Close();
                                }

                                _conn.Dispose();
                            }
                        }
                        else if( _exportdialog.FileExport )
                        {
                            SaveFileDialog.FileName = "export.sql";
                            _result = DialogResult.Cancel;

                            Invoke( (MethodInvoker)delegate
                            {
                                _result = SaveFileDialog.ShowDialog( _pDialog.Window );
                            } );

                            if( _result == DialogResult.OK )
                            {
                                InputBox _input = null;

                                Invoke( (MethodInvoker)delegate
                                {
                                    _input = InputBox.Show( _pDialog.Window, "Database name?",
                                        "Database Name", _mysqlDatabase, InputBoxButtons.OkCancel );
                                } );

                                if( _input.Result == InputBoxResult.Ok )
                                {
                                    _mysqlDatabase = _input.Items[ "Database Name" ];
                                    var _file = new StreamWriter( SaveFileDialog.FileName, false );

                                    try
                                    {
                                        _startTicks = DateTime.Now.Ticks;

                                        _file.WriteLine( _sqlGenerator.CreateDatabase( _mysqlDatabase ) );

                                        _file.WriteLine( _sqlGenerator.SetVariables() );

                                        foreach( var _table in _newTables.Values.Where( t =>
                                            string.IsNullOrEmpty( t.LinkedTable ) ) )
                                        {
                                            if( _pDialog.IsCancelled )
                                            {
                                                e.Cancel = true;
                                                return;
                                            }

                                            _pDialog.ReportProgress( ++_count, "Formatting SQL" );

                                            if( _table.Columns.Count > 0 )
                                            {
                                                _file.WriteLine( _sqlGenerator.CreateTable( _table ) );

                                                _file.WriteLine( _sqlGenerator.BeginInsertTable( _table ) );

                                                _file.WriteLine( _sqlGenerator.InsertTableRowsToString( _table ) );

                                                _file.WriteLine( _sqlGenerator.EndInsertTable( _table ) );
                                            }
                                        }

                                        foreach( var _table in _newTables.Values.Where( t => !string.IsNullOrEmpty( t.LinkedTable ) ) )
                                        {
                                            if( _pDialog.IsCancelled )
                                            {
                                                e.Cancel = true;
                                                return;
                                            }

                                            _pDialog.ReportProgress( ++_count, "Formatting SQL" );

                                            if( _table.Columns.Count > 0 )
                                            {
                                                _file.WriteLine( _sqlGenerator.CreateTable( _table ) );

                                                _file.WriteLine( _sqlGenerator.BeginInsertTable( _table ) );

                                                _file.WriteLine( _sqlGenerator.InsertTableRowsToString( _table ) );

                                                _file.WriteLine( _sqlGenerator.EndInsertTable( _table ) );
                                            }
                                        }

                                        _file.WriteLine( _sqlGenerator.RestoreVariables() );
                                        _complete = true;
                                    }
                                    catch( Exception _ex )
                                    {
                                        MessageBox.Show( _ex.ToString() );
                                    }
                                    finally
                                    {
                                        _file.Close();
                                    }
                                }
                            }
                        }
                    }
                    while( !_complete );
                }
                catch( Exception _ex )
                {
                    MessageBox.Show( _ex.ToString() );
                    e.Cancel = true;
                }

                _exportdialog.Dispose();
            };

            _pDialog.ProgressChanged += delegate( object dialog, ProgressChangedEventArgs e )
            {
                if( _lastTicks == 0 )
                {
                    _lastTicks = DateTime.Now.Ticks;
                    _timeLeft = "Calculating...";
                }
                else if( e.ProgressPercentage > 0
                    && DateTime.Now.Ticks     > _lastTicks + 10000000 )
                {
                    _lastTicks = DateTime.Now.Ticks;

                    var _ticksPassed = _lastTicks - _startTicks;
                    long _thingsCompleted = e.ProgressPercentage;
                    var _thingsLeft = _total - _thingsCompleted;

                    var _ticks = _thingsLeft * _ticksPassed / _thingsCompleted;

                    _timeLeft = TicksToString( _ticks );
                    _timeElapsed = TicksToString( _ticksPassed );
                }

                _pDialog.Message = e.UserState
                    + ": "
                    + e.ProgressPercentage
                    + "/"
                    + _total
                    + " Time Remaining: "
                    + _timeLeft
                    + " Time Elapsed: "
                    + _timeElapsed;

                if( _total == 0 )
                {
                    _pDialog.Progress = 0;
                }
                else
                {
                    _pDialog.Progress = 100 * e.ProgressPercentage / _total % 101;
                }
            };

            _pDialog.Completed += delegate( object dialog, RunWorkerCompletedEventArgs e )
            {
                if( !e.Cancelled )
                {
                    MessageBox.Show( "Completed Successfully" );
                }
            };

            _pDialog.Run();
        }

        /// <summary>
        /// Handles the NodeMouseDoubleClick event of the treeView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
        private void treeView1_NodeMouseDoubleClick( object sender, TreeNodeMouseClickEventArgs e )
        {
            if( treeView1.SelectedNode?.Nodes.Count == 0 )
            {
                OnExportDocumentsButtonClick( sender, e );
            }
        }

        /// <summary>
        /// Tickses to string.
        /// </summary>
        /// <param name="ticks">The ticks.</param>
        /// <returns></returns>
        private string TicksToString( long ticks )
        {
            var _seconds = ticks  / 10000000;
            var _hours = _seconds / 3600;
            _seconds %= 3600;
            var _minutes = _seconds / 60;
            _seconds %= 60;

            return ( _hours > 0
                    ? _hours + ":"
                    : "" )
                + ( _minutes < 10
                    ? "0"
                    : "" )
                + _minutes
                + ":"
                + ( _seconds < 10
                    ? "0"
                    : "" )
                + _seconds;
        }

        /// <summary>
        /// Initializes the session.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        private NotesSession InitSession( string password )
        {
            var _nSession = new NotesSession();
            _nSession.Initialize( password );
            return _nSession;
        }
    }
}