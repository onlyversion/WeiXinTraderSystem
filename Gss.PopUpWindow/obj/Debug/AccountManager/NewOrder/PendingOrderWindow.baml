   M S B A M L   `   `   `  ����J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gss.PopUpWindow.ConverterGss.PopUpWindow.Converter  5   	   E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK4clr-namespace:Gss.Common.Utility;assembly=Gss.CommonGss.Common.Utility 5   	   (    "Gss.PopUpWindow.PendingOrderWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   1cvt'clr-namespace:Gss.PopUpWindow.Converter  5   	   >uti4clr-namespace:Gss.Common.Utility;assembly=Gss.Common  5   	   -   5          � Title$  挂单交易��5   	   $	��300��6    � WindowStartupLocation$ CenterOwner=�5   	    � WindowStyle$ 
ToolWindow=�6-    � SizeToContent$ Height=�6F    � 
ResizeMode$ NoResize=�6]    � 	Resources 5	       	  Order  Recovery:   4Gss.PopUpWindow.Converter.ProductVisibilityConverter  ProductVisibilityConverter  BoolVisibilityCv7   1Gss.PopUpWindow.Converter.DigitIncrementConverter  DigitIncrementCv:   4Gss.PopUpWindow.Converter.DigitFormatStringConverter  
DigitFmtCv �� 
TargetType �� Property �� Value$  Xceed.Wpf.Toolkit.DoubleUpDown0  *Gss.Common.Utility.DoubleUpDownInputFilter	 �� Triggers
 P� Property P� Value �� Path �� Self �� RelativeSource��%  &	        &	      &	 &     &	 9     &	 L     &	 _     '�� r     '�� 0    '  �    �� 5
   
   6   �� 5   
   6     5   
   6)   �� 5   
   6'     5   
   6&     5   
   6)   �� 5   
   " ��6   .�5      ��  � ��$	 2,5q�6'   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Center=�62   �� 5       � ��$ Right=�64   5      �� 5   
   " ��6   .�5      ��  � ��$ 2q�6'   �� 5       � ��$
 Bold"�6+   5      �� 5   
   "  6   .�5      ��  �@ 	DigitOnly . 6F   	 5       P� 5!      
 �@=�HasError . . �5"      ��  �@�ToolTip 5#      �� 5$      $2 ,(Validation.Errors).CurrentItem.ErrorContent�6&   # Z 6Z   5&      5'      5)      5*       J� CommandBindings 5,      )  #System.Windows.Input.CommandBinding  5-   
   -   5           Command# [  5-      6c     5.   
   -   5        # [ 5.      6i   .��51      ��  �� CornerRadius$ 5��6   $��1q�6   $��10q�62   
����=H�._�52   
   %  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy 6   �� *	IsTrading+ ��  �� AncestorType$ WindowL�   BusyContent 53      �� 54      $��交易进行中...��6   $��Center=�6,   $��20(�6I   .��56      �� .+�57      �� .+�58      � $��5q�6    � RowDefinitions 59      �� 5:      $
��Auto �6,   �� 5;      $
��Auto �6,   �� 5<      $
��Auto �6,    � ColumnDefinitions 5>      �� 5?      $
��Auto �6/   �� 5@      $��* �6/   .+�5B      �� $��	商品：��6$   �� 5C      $��	手数：��6$   $��1��6/   $��0��6<   �� 5D      $��有效期：��6$   $��2��60   $��0��6=   �� 5E      -   5        $��CbProductName��5E   #   $��0��68   $��1��6E   $	��2,5q�6U    �� SelectedIndex$ 0��6c   ��5F   #   �� *ProductList+ �� $ WindowL� �� Mode$ FindAncestor=���5G      �� 5H   "   .R�5I   &   �� ��60   �� *ProductName+y�6O   �� *State+ �� 	Converter# [ 5J   #   5L        5S      -   5        $��IntCount��5S   ,   $��1��6<   $��1��6I   $	��2,5q�6Y   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   	Watermark$ 输入订单数量��6f   �	  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 	  	Increment$ 1X�5U   ,   (
  "System.Windows.Controls.DatePicker
  5X      |�.  $��2��68   $��1��6E   $	��2,5q�6U   {�.   
  SelectedDate 5Y   %   �� $ DueDate� �� $ WindowL�$ FindAncestor=�5Z      � 5\      $��5q�6    5]      �� 5^      $��* �6/   �� 5_      $
��Auto �6/   �� 5`      $��* �6/   .+�5b      �� $��2q�6w   $��Right=�6�   $��Center=�6�   $��18(�6�   $
��Bold"�6�   
���  ����6$   �� $' !SelectedValue.RecoveryPriceString� �� ElementName$ CbProductName��6�   �� 5c      $	�� / ��6$   $��1��6/   $��Center=�6?   $��Center=�6Z   �� 5d      $��2��6t   $��2q�6�   $
��Left=�6�   $��Center=�6�   $��18(�6�   $
��Bold"�6�   
����  ���6$   �� $$ SelectedValue.OrderPriceString�$ CbProductName��6�   5e        5f      $��5,5,5,1q�6(      TextAlignment$ Center=�69    	  Minimum$ 0X�6P   $ 请输入挂单价��6\     	  FormatString  5g   (   �� $ SelectedValue.SpreadDigit�$ CbProductName��# [  5h   (   �� $ SelectedValue.SpreadDigit�$ CbProductName��# [ �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]!   Value! 5i   (   �� $ PendingOrderPrice� �� $ WindowL�$ FindAncestor=�" �� Mode$" TwoWay=��� 5j      $��Normal"�6    $��5,1,5,5q�66   ��5k       �� *" SelectedValue.PendingOrderSpread+# �� StringFormat$/# )挂价单必须远离市价至少 {0} 点��� 5m      $��5q�6    5n      �� 5o      $
��Auto �6/   �� 5p      $��* �6/   �� 5q      $
��Auto �6/   �� 5r      $��* �6/   .+�5t      �� -   5        $��
CbStopLoss��5t   #   $��	止损：��65   $	��2,5q�6C   $��Center=�6P   $ d� 	IsChecked$ 5u   #   �� $ EnableStopLoss� �� $ WindowL�$ FindAncestor=�$" TwoWay=�  5v      $  F2��6,   $	 .01X�6>   $	��2,5q�6N   $��1��6[   $ 0X�6k   ! 5w   ,   �� $ StopLoss� �� $ WindowL�$ FindAncestor=�$" TwoWay=�{�5x   ,   �� $ 	IsChecked�$ 
CbStopLoss���� 5y      -   5        $��CbStopProfit��5y   #   $��	止盈：��67   $	��2,5q�6E   $��2��6R   $��Center=�6b   $ 5z   #   �� $ EnableStopProfit� �� $ WindowL�$ FindAncestor=�$" TwoWay=�  5{      $  F2��6,   $	 .01X�6>   $	��2,5q�6N   $��3��6[   $ 0X�6k   ! 5|   ,   �� $ 
StopProfit� �� $ WindowL�$ FindAncestor=�$" TwoWay=�{�5}   ,   �� $ 	IsChecked�$ CbStopProfit��5~      � 5�      $��5q�6    5�      �� 5�      $��* �6/   �� 5�      $��* �6/   .+�5�      �� $��0��6!   $��买跌��61   #��[ 6>   $��88��6b   $	��2,5q�6m   
�����F�
���   �$
��Bold"�6�     BtnStyle#��[ 5�   !   �� 5�      $��1��6!   $��买涨��61   #��[  6>   $��88��6_   $	��2,5q�6j   
�����F�
���   �$
��Bold"�6�   #��[ 5�   !   5�      5�      5�      5�      5�      5�      