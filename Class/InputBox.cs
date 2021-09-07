namespace Popple
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class InputBox
    {
        private InputBox( DialogForm dialog )
        {
            Result = dialog.InputResult;
            Items = new Dictionary<string, string>();

            for( var _i = 0; _i < dialog._label.Length; _i++ )
            {
                Items.Add( dialog._label[ _i ].Text, dialog._textBox[ _i ].Text );
            }
        }

        public static InputBox Show( string title, string label )
        {
            var _dialog = new DialogForm( title, new[ ]
            {
                new InputItem( label )
            }, InputBoxButtons.Ok );

            _dialog.ShowDialog();
            return new InputBox( _dialog );
        }

        public static InputBox Show( string title, string label, InputBoxButtons buttons )
        {
            var _dialog = new DialogForm( title, new[ ]
            {
                new InputItem( label )
            }, buttons );

            _dialog.ShowDialog();
            return new InputBox( _dialog );
        }

        public static InputBox Show( string title, string label, string text )
        {
            using( var _dialog = new DialogForm( title, new[ ]
            {
                new InputItem( label, text )
            }, InputBoxButtons.Ok ) )
            {
                _dialog.ShowDialog();
                return new InputBox( _dialog );
            }
        }

        public static InputBox Show( string title, string label, string text,
            InputBoxButtons buttons )
        {
            var _dialog = new DialogForm( title, new[ ]
            {
                new InputItem( label, text )
            }, buttons );

            _dialog.ShowDialog();
            return new InputBox( _dialog );
        }

        public static InputBox Show( string title, string[ ] labels )
        {
            var _items = new InputItem[ labels.Length ];

            for( var _i = 0; _i < labels.Length; _i++ )
            {
                _items[ _i ] = new InputItem( labels[ _i ] );
            }

            var _dialog = new DialogForm( title, _items, InputBoxButtons.Ok );
            _dialog.ShowDialog();
            return new InputBox( _dialog );
        }

        public static InputBox Show( string title, string[ ] labels, InputBoxButtons buttons )
        {
            var _items = new InputItem[ labels.Length ];

            for( var _i = 0; _i < labels.Length; _i++ )
            {
                _items[ _i ] = new InputItem( labels[ _i ] );
            }

            var _dialog = new DialogForm( title, _items, buttons );
            _dialog.ShowDialog();
            return new InputBox( _dialog );
        }

        public static InputBox Show( string title, InputItem item )
        {
            var _dialog = new DialogForm( title, new[ ]
            {
                item
            }, InputBoxButtons.Ok );

            _dialog.ShowDialog();
            return new InputBox( _dialog );
        }

        public static InputBox Show( string title, InputItem item, InputBoxButtons buttons )
        {
            var _dialog = new DialogForm( title, new[ ]
            {
                item
            }, buttons );

            _dialog.ShowDialog();
            return new InputBox( _dialog );
        }

        public static InputBox Show( string title, InputItem[ ] items )
        {
            var _dialog = new DialogForm( title, items, InputBoxButtons.Ok );
            _dialog.ShowDialog();
            return new InputBox( _dialog );
        }

        public static InputBox Show( string title, InputItem[ ] items, InputBoxButtons buttons )
        {
            var _dialog = new DialogForm( title, items, buttons );
            _dialog.ShowDialog();
            return new InputBox( _dialog );
        }

        public static InputBox Show( IWin32Window window, string title, string label )
        {
            var _dialog = new DialogForm( title, new[ ]
            {
                new InputItem( label )
            }, InputBoxButtons.Ok );

            _dialog.ShowDialog( window );
            return new InputBox( _dialog );
        }

        public static InputBox Show( IWin32Window window, string title, string label,
            InputBoxButtons buttons )
        {
            var _dialog = new DialogForm( title, new[ ]
            {
                new InputItem( label )
            }, buttons );

            _dialog.ShowDialog( window );
            return new InputBox( _dialog );
        }

        public static InputBox Show( IWin32Window window, string title, string label,
            string text )
        {
            using( var _dialog = new DialogForm( title, new[ ]
            {
                new InputItem( label, text )
            }, InputBoxButtons.Ok ) )
            {
                _dialog.ShowDialog( window );
                return new InputBox( _dialog );
            }
        }

        public static InputBox Show( IWin32Window window, string title, string label,
            string text, InputBoxButtons buttons )
        {
            var _dialog = new DialogForm( title, new[ ]
            {
                new InputItem( label, text )
            }, buttons );

            _dialog.ShowDialog( window );
            return new InputBox( _dialog );
        }

        public static InputBox Show( IWin32Window window, string title, string[ ] labels )
        {
            var _items = new InputItem[ labels.Length ];

            for( var _i = 0; _i < labels.Length; _i++ )
            {
                _items[ _i ] = new InputItem( labels[ _i ] );
            }

            var _dialog = new DialogForm( title, _items, InputBoxButtons.Ok );
            _dialog.ShowDialog( window );
            return new InputBox( _dialog );
        }

        public static InputBox Show( IWin32Window window, string title, string[ ] labels,
            InputBoxButtons buttons )
        {
            var _items = new InputItem[ labels.Length ];

            for( var _i = 0; _i < labels.Length; _i++ )
            {
                _items[ _i ] = new InputItem( labels[ _i ] );
            }

            var _dialog = new DialogForm( title, _items, buttons );
            _dialog.ShowDialog( window );
            return new InputBox( _dialog );
        }

        public static InputBox Show( IWin32Window window, string title, InputItem item )
        {
            var _dialog = new DialogForm( title, new[ ]
            {
                item
            }, InputBoxButtons.Ok );

            _dialog.ShowDialog( window );
            return new InputBox( _dialog );
        }

        public static InputBox Show( IWin32Window window, string title, InputItem item,
            InputBoxButtons buttons )
        {
            var _dialog = new DialogForm( title, new[ ]
            {
                item
            }, buttons );

            _dialog.ShowDialog( window );
            return new InputBox( _dialog );
        }

        public static InputBox Show( IWin32Window window, string title, InputItem[ ] items )
        {
            var _dialog = new DialogForm( title, items, InputBoxButtons.Ok );
            _dialog.ShowDialog( window );
            return new InputBox( _dialog );
        }

        public static InputBox Show( IWin32Window window, string title, InputItem[ ] items,
            InputBoxButtons buttons )
        {
            var _dialog = new DialogForm( title, items, buttons );
            _dialog.ShowDialog( window );
            return new InputBox( _dialog );
        }

        public Dictionary<string, string> Items { get; }

        public InputBoxResult Result { get; }
    }
}