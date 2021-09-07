namespace Popple
{
    using System.Diagnostics.CodeAnalysis;

    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    public readonly struct InputItem
    {
        public readonly string Label;

        public readonly string Text;

        public readonly bool IsPassword;

        public InputItem( string label )
        {
            Label = label;
            Text = "";
            IsPassword = false;
        }

        public InputItem( string label, string text )
        {
            Label = label;
            Text = text;
            IsPassword = false;
        }

        public InputItem( string label, bool isPassword )
        {
            Label = label;
            Text = "";
            IsPassword = isPassword;
        }

        public InputItem( string label, string text, bool isPassword )
        {
            Label = label;
            Text = text;
            IsPassword = isPassword;
        }
    }
}