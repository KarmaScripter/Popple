namespace Popple
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [ SuppressMessage( "ReSharper", "UnusedVariable" ) ]
    internal class MySqlGenerator : ISqlGenerator
    {
        public string CreateDatabase( string databaseName )
        {
            return "DROP DATABASE IF EXISTS `"
                + databaseName
                + "`;\n"
                + "\n"
                + "CREATE DATABASE `"
                + databaseName
                + "`;\n"
                + "USE `"
                + databaseName
                + "`;\n"
                + "\n";
        }

        public string SetVariables()
        {
            return "/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;\n"
                + "/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;\n"
                + "/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;\n"
                + "/*!40101 SET NAMES utf8 */;\n"
                + "/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;\n"
                + "/*!40103 SET TIME_ZONE='+00:00' */;\n"
                + "/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;\n"
                + "/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;\n"
                + "/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;\n"
                + "/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;\n";
        }

        public string CreateTable( DataTable dataTable )
        {
            var _query = "CREATE TABLE `" + dataTable.Name + "` (\n" + "`id` INT NOT NULL,\n";

            foreach( var _column in dataTable.Columns.Values )
            {
                _query += "`" + _column.Name + "` " + _column.Type + " NULL,\n";
            }

            _query += "PRIMARY KEY (`id`)";

            if( dataTable.LinkedTable != null )
            {
                _query += ",\n"
                    + "KEY `"
                    + dataTable.Name
                    + "_idx` (`"
                    + dataTable.LinkedTable
                    + "id`),\n"
                    + "CONSTRAINT `"
                    + dataTable.Name
                    + "` FOREIGN KEY (`"
                    + dataTable.LinkedTable
                    + "id`) REFERENCES `"
                    + dataTable.LinkedTable
                    + "` (`id`) ON DELETE CASCADE ON UPDATE CASCADE";
            }

            _query += ");\n";
            return _query;
        }

        public string BeginInsertTable( DataTable dataTable )
        {
            var _query = "LOCK TABLES `"
                + dataTable.Name
                + "` WRITE;\n"
                + "/*!40000 ALTER TABLE `"
                + dataTable.Name
                + "` DISABLE KEYS */;\n"
                + "INSERT INTO `"
                + dataTable.Name
                + "` (`id`,`"
                + String.Join( "`,`", dataTable.Columns.Keys )
                + "`) VALUES";

            return _query;
        }

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
                                            if( _column.Values[ _i + 1 ] is DateTime )
                                            {
                                                _value = ( (DateTime)_column.Values[ _i + 1 ] )
                                                    .ToString( "yyyy-MM-dd HH:mm:ss" );
                                            }
                                            else
                                            {
                                                _value = _temp.ToString( "yyyy-MM-dd HH:mm:ss" );
                                            }

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

        public string InsertTableRowsToString( DataTable dataTable )
        {
            return string.Join( ",", InsertTableRowsToList( dataTable ) ) + ";";
        }

        public string EndInsertTable( DataTable dataTable )
        {
            var _query = "/*!40000 ALTER TABLE `"
                + dataTable.Name
                + "` ENABLE KEYS */;\n"
                + "UNLOCK TABLES;\n";

            return _query;
        }

        public string RestoreVariables()
        {
            const string _query = "/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;\n"
                + "/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;\n"
                + "/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;\n"
                + "/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;\n"
                + "/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;\n"
                + "/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;\n"
                + "/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;\n"
                + "/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;\n";

            return _query;
        }
    }
}