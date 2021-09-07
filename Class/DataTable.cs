namespace Popple
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public class DataTable
    {
        /// <summary>
        /// The name
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// The linked table
        /// </summary>
        public readonly string LinkedTable;

        /// <summary>
        /// The columns
        /// </summary>
        public Dictionary<string, DataColumn> Columns = new Dictionary<string, DataColumn>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTable"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public DataTable( string name )
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTable"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="linkedTable">The linked table.</param>
        public DataTable( string name, string linkedTable )
        {
            Name = name;
            LinkedTable = linkedTable;
        }

        /// <summary>
        /// Adds the row.
        /// </summary>
        /// <returns></returns>
        public int AddRow()  
        {
            RowCount++;

            return RowCount;
        }

        /// <summary>
        /// Gets the row count.
        /// </summary>
        /// <value>
        /// The row count.
        /// </value>
        public int RowCount { get; private set; }
    }
}