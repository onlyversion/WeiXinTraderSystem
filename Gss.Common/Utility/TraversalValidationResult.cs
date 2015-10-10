using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Gss.Common.Utility {
    public static class TraversalValidationResult {
        public static bool GetHasValidationError( UIElement element ) {
            if( element == null )
                return false;

            if( element is Panel ) {
                foreach( var item in ( element as Panel ).Children ) {
                    if( GetHasValidationError( item as UIElement ) )
                        return true;

                    continue;
                }
            }

            if( element is ItemsControl ) {
                if( element is ComboBox )
                    return Validation.GetHasError( element );

                foreach( var item in ( element as ItemsControl ).Items ) {
                    if( GetHasValidationError( item as UIElement ) )
                        return true;

                    continue;
                }
            }

            if( element is ContentControl ) {
                object content = ( element as ContentControl ).Content;
                if( content is UIElement )
                    return GetHasValidationError( ( element as ContentControl ).Content as UIElement );
                else
                    return false;
            }

            return Validation.GetHasError( element );
        }

    }
}
