namespace Popple
{
    using System;
    using System.Windows.Forms;
    using System.Collections;

    public class NodeSorter : IComparer
    {
        public int Compare( object a, object b )
        {
            var _ta = a as TreeNode;
            var _tb = b as TreeNode;

            if( _ta                    != null
                && _ta.Nodes.Count > 0 == _tb.Nodes.Count > 0 )
            {
                return String.CompareOrdinal( _ta.Text, _tb.Text );
            }
            else
            {
                return _tb.Nodes.Count - _ta.Nodes.Count;
            }
        }
    }
}