using System;
using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;

namespace Gss.Common.Utility {
    /// <summary>
    /// IntergerUpDown控件输入过滤辅助类
    /// </summary>
    public class IntergerUpDownInputFilter : DependencyObject {
        public static bool? GetDigitOnly( DependencyObject obj ) {
            return ( bool? )obj.GetValue( DigitOnlyProperty );
        }

        public static void SetDigitOnly( DependencyObject obj, bool? value ) {
            obj.SetValue( DigitOnlyProperty, value );
        }

        // Using a DependencyProperty as the backing store for DigitOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DigitOnlyProperty =
            DependencyProperty.RegisterAttached( "DigitOnly", typeof( bool? ), typeof( IntergerUpDownInputFilter ), new UIPropertyMetadata( null, OnDigitOnlyChanged ) );

        private static void OnDigitOnlyChanged( DependencyObject d, DependencyPropertyChangedEventArgs e ) {
            IntegerUpDown intUpDown = d as IntegerUpDown;
            if( intUpDown == null )
                return;

            if( e.NewValue != null && ( bool )e.NewValue )
                intUpDown.PreviewTextInput += IntUpDown_PreviewTextInput;
            else
                intUpDown.PreviewTextInput -= IntUpDown_PreviewTextInput;
        }

        private static void IntUpDown_PreviewTextInput( object sender, TextCompositionEventArgs e ) {
            IntegerUpDown dp = ( IntegerUpDown )sender;

            char input = e.Text[0];
            if( !Char.IsDigit( input ) ) {
                e.Handled = true;
            }
        }
    }
}
