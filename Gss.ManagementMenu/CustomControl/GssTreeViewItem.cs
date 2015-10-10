using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gss.ManagementMenu.CustomControl {
    public class GssTreeViewItem : TreeViewItem {
        public string Title {
            get { return ( string )GetValue( TitleProperty ); }
            set { SetValue( TitleProperty, value ); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register( "Title", typeof( string ), typeof( GssTreeViewItem ), new UIPropertyMetadata( "" ) );

        public double TitleSize {
            get { return ( double )GetValue( TitleSizeProperty ); }
            set { SetValue( TitleSizeProperty, value ); }
        }

        // Using a DependencyProperty as the backing store for TitleSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleSizeProperty =
            DependencyProperty.Register( "TitleSize", typeof( double ), typeof( GssTreeViewItem ), new UIPropertyMetadata() );

        public FontWeight  TitleWeight {
            get { return ( FontWeight  )GetValue( TitleWeightProperty ); }
            set { SetValue( TitleWeightProperty, value ); }
        }

        // Using a DependencyProperty as the backing store for TitleWeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleWeightProperty =
            DependencyProperty.Register( "TitleWeight", typeof( FontWeight  ), typeof( GssTreeViewItem ), new UIPropertyMetadata( FontWeights.Normal ) );

        public ImageSource Icon {
            get { return ( ImageSource )GetValue( IconProperty ); }
            set { SetValue( IconProperty, value ); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register( "Icon", typeof( ImageSource ), typeof( GssTreeViewItem ), new UIPropertyMetadata( null ) );

        public double IconSize {
            get { return ( double )GetValue( IconSizeProperty ); }
            set { SetValue( IconSizeProperty, value ); }
        }

        // Using a DependencyProperty as the backing store for IconSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconSizeProperty =
            DependencyProperty.Register( "IconSize", typeof( double ), typeof( GssTreeViewItem ), new UIPropertyMetadata( 20d ) );

        public FrameworkElement View {
            get { return ( FrameworkElement )GetValue( ViewProperty ); }
            set { SetValue( ViewProperty, value ); }
        }

        // Using a DependencyProperty as the backing store for View.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewProperty =
            DependencyProperty.Register( "View", typeof( FrameworkElement ), typeof( GssTreeViewItem ), new UIPropertyMetadata( null ) );

    }
}
