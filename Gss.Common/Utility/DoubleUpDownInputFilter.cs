using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit;

namespace Gss.Common.Utility {
    /// <summary>
    /// DoubleUpDown控件输入过滤辅助类
    /// </summary>
    public class DoubleUpDownInputFilter : DependencyObject {

        public static bool GetDigitOnly( DependencyObject obj ) {
            return ( bool )obj.GetValue( DigitOnlyProperty );
        }

        public static void SetDigitOnly( DependencyObject obj, bool value ) {
            obj.SetValue( DigitOnlyProperty, value );
        }

        // Using a DependencyProperty as the backing store for DigitOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DigitOnlyProperty =
            DependencyProperty.RegisterAttached( "DigitOnly", typeof( bool ), typeof( DoubleUpDownInputFilter ), new UIPropertyMetadata( false, OnDigitOnlyChanged ) );


        private static void OnDigitOnlyChanged( DependencyObject d, DependencyPropertyChangedEventArgs e ) {
            DoubleUpDown dp = d as DoubleUpDown;
            if( dp == null )
                return;

            if( ( bool )e.NewValue )
                dp.PreviewTextInput += DbUpDown_PreviewTextInput;
            else
                dp.PreviewTextInput -= DbUpDown_PreviewTextInput;
        }

        private static void DbUpDown_PreviewTextInput( object sender, TextCompositionEventArgs e ) {
            DoubleUpDown dp = ( DoubleUpDown )sender;

            char input = e.Text[0];
            if( !Char.IsDigit( input ) ) {
                if( input == '.' ) {//判断小数点是否有效
                    if( DoubleUpDownInputHelper.IsDotValid( dp ) )
                        return;
                }

                if( input == '-' ) {//判断负号是否有效
                    if( DoubleUpDownInputHelper.IsNegativeSignValid( dp ) )
                        return;
                }

                e.Handled = true;
            }
        }
    }

    public static class DoubleUpDownInputHelper {
        public static bool IsDotValid( DoubleUpDown dp ) {
            return !dp.Text.Contains( '.' );
        }

        public static bool IsNegativeSignValid( DoubleUpDown dp ) {
            return dp.Minimum < 0;
        }
    }
}
