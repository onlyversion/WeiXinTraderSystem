   M S B A M L   `   `   `  ����J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gss.PopUpWindow.ConverterGss.PopUpWindow.Converter  5   	   E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK4clr-namespace:Gss.Common.Utility;assembly=Gss.CommonGss.Common.Utility 5   	   G CGss.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.EntitiesGss.Entities.ValidationHelper 5   
   '    !Gss.PopUpWindow.MarketOrderWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   1cvt'clr-namespace:Gss.PopUpWindow.Converter  5   	   >uti4clr-namespace:Gss.Common.Utility;assembly=Gss.Common  5   	   XValidationHelperAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.Entities  5   
   -   5          � Title$  即时成交��5   	   $	��300��6    � WindowStartupLocation$ CenterOwner=�5	   	    � WindowStyle$ 
ToolWindow=�6-    � SizeToContent$ Height=�6F    � 
ResizeMode$ NoResize=�6]    � 	Resources 5
         BoolVisibilityCv7   1Gss.PopUpWindow.Converter.DigitIncrementConverter  DigitIncrementCv:   4Gss.PopUpWindow.Converter.DigitFormatStringConverter  
DigitFmtCv:   4Gss.PopUpWindow.Converter.ProductVisibilityConverter  ProductVisibilityConverter 	 Order  Recovery �� 
TargetType �� Property �� Value$  Xceed.Wpf.Toolkit.DoubleUpDown0  *Gss.Common.Utility.DoubleUpDownInputFilter	 �� Triggers
 P� Property P� Value �� Path �� Self �� RelativeSource��%
  &	        &	      &	 &     &	 9     &	 L     &	 _     '�� r     '�� .    '  �    �� 5   
   6'     5   
   6&     5   
   6)     5   
   6)   �� 5   
   6   �� 5   
   6   �� 5   
   " ��6   .�5      ��  � ��$ 2q�6'   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Center=�62   �� 5       � ��$ Right=�64   5      �� 5   
   " ��6   .�5      ��  � ��$ 2q�6'   �� 5       � ��$
 Bold"�6+   5      �� 5    
   "  6   .�5!      ��  �@ 	DigitOnly . 6F   	 5"      P� 5#      
 �@=�HasError . . �5$      ��  �@�ToolTip 5%      �� 5&      $2 ,(Validation.Errors).CurrentItem.ErrorContent�6&   # Z 6Z   5(      5)      5+      5,       J� CommandBindings 5.      )  #System.Windows.Input.CommandBinding  5/   
   -   5           Command# [ 5/      6d     50   
   -   5        # [ 50      6j   .��53      ��  �� CornerRadius$ 5��6   $��1q�6   $��10q�62   
����=H�._�54   
   %  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy 6   �� *	IsTrading+ ��  �� AncestorType$ WindowL�   BusyContent 55      �� 56      $��交易进行中...��6   $��Center=�6,   $��20(�6I   .��58      �� .+�59      �� .+�5:      � $��5q�6    � RowDefinitions 5;      �� 5<      $
��Auto �6,   �� 5=      $
��Auto �6,    � ColumnDefinitions 5?      �� 5@      $
��Auto �6/   �� 5A      $��* �6/   .+�5C      �� $��	商品：��6$   �� 5D      $��	手数：��6$   $��1��6/   $��0��6<   �� 5E      -   5        $��CbProductName��5E   #   $��0��68   $��1��6E   $	��2,5q�6U    �� SelectedIndex$ 0��6c   ��5F   #   �� *ProductList+ �� $ WindowL� �� Mode$ FindAncestor=���5G      �� 5H   "   .R�5I   &   �� ��60   �� *ProductName+y�6O   �� *State+ �� 	Converter# [ 5J   #   5L      �� 5M      $��1��6)   $��1��66   .��5N        -   5        $��IntCount��5N   0   $��1��6@   $��1��6M   $	��2,5q�6]   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   	Watermark$ 输入订单数量��6j   �	  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 	  SelectAllOnGotFocus .  	  	Increment$ 1X�5P   0   5S      5T      5U      � 5W      $��5q�6    5X      �� 5Y      $
��Auto �6,   �� 5Z      $
��Auto �6,    5\      �� 5]      $��* �6/   �� 5^      $
��Auto �6/   .+�5`      �� $��2,5,10,5q�6$   $��Right=�66   $��Center=�6R   $
��Bold"�6m   
���  ��$��18(�6�   ��5a   $   �� $' !SelectedValue.RecoveryPriceString� �� ElementName$ CbProductName���� 5b      $��0��6"   $��1��6/   $��买跌��6?   #��[ 6L   $��88��6p   $	��2,5q�6|   
�����F�
���   �$
��Bold"�6�     BtnStyle#��[ 5c   !   �� 5d      $��1��6$   $��0��61   $��2,5,10,5q�6A   $��Right=�6S   $��Center=�6o   $��18(�6�   $
��Bold"�6�   
����  ���5e   $   �� $$ SelectedValue.OrderPriceString�$ CbProductName���� 5f      $��1��6!   $��1��6.   $��买涨��6>   #��[ 6K   $��88��6l   $	��2,5q�6w   
�����F�
���   �$
��Bold"�6�   #��[ 5g   "   5h      �� 5j      $��5q�6!   .+�5k      �  5l      �� 5m   "   $
��Auto �63   �� 5n   "   $��* �63   �� 5o   "   $
��Auto �63   �� 5p   "   $��* �63   .+�5r      �� -   5        $��
CbStopLoss��5r   '   $��	止损：��69   $	��2,5q�6G   $��Center=�6T    d� 	IsChecked 5s   '   �� $ EnableStopLoss� �� $ WindowL�$ FindAncestor=� �� Mode$ TwoWay=�  5t      $	��2,5q�60   $��1��6=     	  Minimum$  0X�6M   $ 输入止损价��6Y   �
  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]! 
  Value! 5u   0   �� $ StopLoss� �� $ WindowL�$ FindAncestor=�$ TwoWay=�" 	  FormatString" 5v   0   �� $ SelectedValue.SpreadDigit�$ CbProductName��# [  5w   0   �� $ SelectedValue.SpreadDigit�$ CbProductName��# [ {�5x   0   �� $ 	IsChecked�$ 
CbStopLoss���� 5y      -   5        $��CbStopProfit��5y   '   $��	止盈：��6;   $	��2,5q�6I   $��2��6V   $��Center=�6f    5z   '   �� $ EnableStopProfit� �� $ WindowL�$ FindAncestor=�$ TwoWay=�  5{      $	��2,5q�60   $��3��6=   $  0X�6M   $ 输入止盈价��6Y   ! 5|   0   �� $ 
StopProfit� �� $ WindowL�$ FindAncestor=�$ TwoWay=�" 5}   0   �� $ SelectedValue.SpreadDigit�$ CbProductName��# [  5~   0   �� $ SelectedValue.SpreadDigit�$ CbProductName��# [ {�5   0   �� $ 	IsChecked�$ CbStopProfit��5�      �� 5�      -   5        $��CbDeviation��5�   #   $
��Left=�66   $*��$允许成交价与报价最大偏差��6Q   �� 5�      # �� Orientation$# 
Horizontal=�6%   $��Right=�6>   {�6Z   �� $ 	IsChecked�$ CbDeviation��.+�5�      �� $��最大偏差��6(   $��2q�64   $��Center=�6?   $ �� TextAlignment$$ Center=�6Z   $��Normal"�6r   %  Xceed.Wpf.Toolkit.IntegerUpDown  5�      $��2q�61   $��88��6<   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]%   Minimum$% 0X�6G   2  ,Gss.Common.Utility.IntergerUpDownInputFilter&   	DigitOnly$
& TrueX�6S   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]'   DefaultValue$' 0X�6�   (   Value( 5�   1   �� $ AllowMaxPriceDiff� �� $ WindowL�$ FindAncestor=�$ TwoWay=��� 5�      $	��点��6(   $��Normal"�62   5�      5�      5�      5�      5�      5�      5�      