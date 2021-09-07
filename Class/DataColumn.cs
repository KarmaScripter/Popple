namespace Popple
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [ SuppressMessage( "ReSharper", "FieldCanBeMadeReadOnly.Global" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public class DataColumn
    {
        /// <summary>
        /// The name
        /// </summary>
        public string Name;

        /// <summary>
        /// The type
        /// </summary>
        public string Type;

        /// <summary>
        /// The has multiple
        /// </summary>
        public bool HasMultiple = false;

        /// <summary>
        /// The values
        /// </summary>
        public Dictionary<int, object> Values = new Dictionary<int, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DataColumn"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        public DataColumn( string name, string type )
        {
            Name = name;
            Type = type;
        }
    }
}