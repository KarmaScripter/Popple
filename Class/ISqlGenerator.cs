namespace Popple
{
    using System.Collections.Generic;

    internal interface ISqlGenerator
    {
        string CreateDatabase( string databaseName );

        string SetVariables();

        string CreateTable( DataTable dataTable );

        string BeginInsertTable( DataTable dataTable );

        List<string> InsertTableRowsToList( DataTable dataTable );

        string InsertTableRowsToString( DataTable dataTable );

        string EndInsertTable( DataTable dataTable );

        string RestoreVariables();
    }
}