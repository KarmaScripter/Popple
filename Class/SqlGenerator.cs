namespace Popple
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ISqlGenerator" />
    public class SqlGenerator : ISqlGenerator
    {
        /// <summary>
        /// Creates the database.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        /// <returns></returns>
        public string CreateDatabase( string databaseName )
        {
            return string.Format( @"DROP DATABASE IF EXISTS {0};
                GO

                CREATE DATABASE {0};
                GO

                USE [{0}];", databaseName );
        }

        /// <summary>
        /// Sets the variables.
        /// </summary>
        /// <returns></returns>
        public string SetVariables()
        {
            return string.Empty;
        }

        /// <summary>
        /// Creates the table.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public string CreateTable( DataTable dataTable )
        {
            var _sqlBuilder = new StringBuilder();
            _sqlBuilder.AppendFormat( "CREATE TABLE [{0}] (\r\n", dataTable.Name );
            _sqlBuilder.AppendLine( "[id] INT NOT NULL," );

            foreach( var _column in dataTable.Columns.Values )
            {
                _sqlBuilder.AppendFormat( "[{0}] {1} NULL,\r\n", _column.Name, _column.Type );
            }

            _sqlBuilder.Append( "PRIMARY KEY ([id])" );

            if( dataTable.LinkedTable != null )
            {
                _sqlBuilder.Append( ",\r\n" );

                _sqlBuilder.AppendFormat( "CONSTRAINT[{0}_constraint] FOREIGN KEY([{1}id]) REFERENCES"
                    + " [{1}]([id]) ON DELETE CASCADE ON UPDATE CASCADE);\r\n",
                    dataTable.Name, dataTable.LinkedTable );

                _sqlBuilder.AppendFormat( "CREATE INDEX[{0}_idx] ON [{0}]([{1}id]);\r\n",
                    dataTable.Name, dataTable.LinkedTable );
            }
            else
            {
                _sqlBuilder.Append( ");\r\n" );
            }

            return _sqlBuilder.ToString();
        }

        /// <summary>
        /// Begins the insert table.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public string BeginInsertTable( DataTable dataTable )
        {
            var _sqlBuilder = new StringBuilder();
            _sqlBuilder.AppendFormat( "INSERT INTO [{0}] ([id],[", dataTable.Name );
            _sqlBuilder.Append( string.Join( "],[", dataTable.Columns.Keys ) );
            _sqlBuilder.AppendLine( "]) VALUES" );

            return _sqlBuilder.ToString();
        }

        /// <summary>
        /// Inserts the table rows to list.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public List<string> InsertTableRowsToList( DataTable dataTable )
        {
            var _rows = new List<string>( dataTable.RowCount );

            for( var _i = 0; _i < dataTable.RowCount; _i++ )
            {
                var _columnValues = new List<string>( dataTable.Columns.Count );

                foreach( var _column in dataTable.Columns.Values )
                {
                    if( _column.Values.ContainsKey( _i + 1 ) )
                    {
                        if( _column.Values[ _i + 1 ] != null )
                        {
                            var _value = _column.Values[ _i + 1 ].ToString();

                            switch( _column.Type )
                            {
                                case "decimal(20,10)":
                                    switch( _value )
                                    {
                                        case "":
                                            _value = "NULL";
                                            break;

                                        case "Infinity":
                                            _value = "9999999999.9999999999";
                                            break;

                                        default:
                                        {
                                            if( !double.TryParse( _value, out var _temp ) )
                                            {
                                                _value = "NULL";
                                            }

                                            break;
                                        }
                                    }

                                    break;

                                case "datetime":
                                    if( _value == "" )
                                    {
                                        _value = "NULL";
                                    }
                                    else
                                    {
                                        if( DateTime.TryParse( _value, out var _temp ) )
                                        {
                                            _value = _column.Values[ _i + 1 ] is DateTime
                                                ? ( (DateTime)_column.Values[ _i + 1 ] ).ToString( "yyyy-MM-dd HH:mm:ss" )
                                                : _temp.ToString( "yyyy-MM-dd HH:mm:ss" );

                                            _value = "'" + _value + "'";
                                        }
                                        else
                                        {
                                            _value = "NULL";
                                        }
                                    }

                                    break;

                                default:
                                    _value = "'" + _value.Replace( "'", "''" ) + "'";
                                    break;
                            }

                            _columnValues.Add( _value );
                        }
                        else
                        {
                            _columnValues.Add( "NULL" );
                        }
                    }
                    else
                    {
                        _columnValues.Add( "NULL" );
                    }
                }

                _rows.Add( "(" + ( _i + 1 ) + "," + String.Join( ",", _columnValues ) + ")" );
            }

            return _rows;
        }

        /// <summary>
        /// Inserts the table rows to string.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public string InsertTableRowsToString( DataTable dataTable )
        {
            var _sqlBuilder = new StringBuilder();
            var _rows = InsertTableRowsToList( dataTable );
            var _index = 0;

            do
            {
                _sqlBuilder.Append( string.Join( ",\r\n",
                    _rows.GetRange( _index, Math.Min( 1000, _rows.Count - _index ) ) ) );

                _sqlBuilder.AppendLine( ";" );
                _index += 1000;

                if( _index < _rows.Count )
                {
                    _sqlBuilder.AppendLine();
                    _sqlBuilder.Append( BeginInsertTable( dataTable ) );
                }
            }
            while( _index < _rows.Count );

            return _sqlBuilder.ToString();
        }

        /// <summary>
        /// Ends the insert table.
        /// </summary>
        /// <param name="dataTable">The data table.</param>
        /// <returns></returns>
        public string EndInsertTable( DataTable dataTable )
        {
            return string.Empty;
        }

        /// <summary>
        /// Restores the variables.
        /// </summary>
        /// <returns></returns>
        public string RestoreVariables()
        {
            return string.Empty;
        }
    }
}