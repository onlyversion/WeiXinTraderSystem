   M S B A M L   `   `   `  ���� J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gss.PopUpWindow.ConverterGss.PopUpWindow.Converter  E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK4clr-namespace:Gss.Common.Utility;assembly=Gss.CommonGss.Common.Utility (    "Gss.PopUpWindow.PendingOrderWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  1cvt'clr-namespace:Gss.PopUpWindow.Converter  >uti4clr-namespace:Gss.Common.Utility;assembly=Gss.Common  -     � Title$  挂单交易��$	��300�� � WindowStartupLocation$ CenterOwner=� � WindowStyle$ 
ToolWindow=� � SizeToContent$ Height=� � 
ResizeMode$ NoResize=� � 	Resources  	  Order  Recovery:   4Gss.PopUpWindow.Converter.ProductVisibilityConverter  ProductVisibilityConverter  BoolVisibilityCv7   1Gss.PopUpWindow.Converter.DigitIncrementConverter  DigitIncrementCv:   4Gss.PopUpWindow.Converter.DigitFormatStringConverter  
DigitFmtCv �� 
TargetType �� Property �� Value$  Xceed.Wpf.Toolkit.DoubleUpDown0  *Gss.Common.Utility.DoubleUpDownInputFilter	 �� Triggers
 P� Property P� Value �� Path �� Self �� RelativeSource��%�  &	        &	      &	 
     &	      &	      &	      '��      '�� �     '  �     �� ��   ��     �� " ��.���  � ��$	 2,5q���  � ��$
 Bold"���  � ��$ Center=���  � ��$ Right=��� " ��.���  � ��$ 2q���  � ��$
 Bold"��� "  .���  �@ 	DigitOnly . 	 P� 
 �@=�HasError . . ���  �@�ToolTip �� $2 ,(Validation.Errors).CurrentItem.ErrorContent�# Z  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [ .����  �� CornerRadius$ 5��$��1q�$��10q�
����=H�._�%  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy �� *	IsTrading+ ��  �� AncestorType$ WindowL�   BusyContent �� $��交易进行中...��$��Center=�$��20(�.���� .+��� .+�� $��5q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��	商品：���� $��	手数：��$��1��$��0���� $��有效期：��$��2��$��0���� -   $��CbProductName��$��0��$��1��$	��2,5q� �� SelectedIndex$ 0������ *ProductList+ �� $ WindowL� �� Mode$ FindAncestor=����� .R��� ���� *ProductName+y��� *State+ �� 	Converter# [   -   $��IntCount��$��1��$��1��$	��2,5q�,  &Xceed.Wpf.Toolkit.Primitives.InputBase   	Watermark$ 输入订单数量���	  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 	  	Increment$ 1X�(
  "System.Windows.Controls.DatePicker
  |�.  $��2��$��1��$	��2,5q�{�.   
  SelectedDate �� $ DueDate� �� $ WindowL�$ FindAncestor=�� $��5q� �� $��* ��� $
��Auto ��� $��* �.+��� $��2q�$��Right=�$��Center=�$��18(�$
��Bold"�
���  ������ $' !SelectedValue.RecoveryPriceString� �� ElementName$ CbProductName���� $	�� / ��$��1��$��Center=�$��Center=��� $��2��$��2q�$
��Left=�$��Center=�$��18(�$
��Bold"�
����  ����� $$ SelectedValue.OrderPriceString�$ CbProductName��  $��5,5,5,1q�   TextAlignment$ Center=� 	  Minimum$ 0X�$ 请输入挂单价��  	  FormatString  �� $ SelectedValue.SpreadDigit�$ CbProductName��# [  �� $ SelectedValue.SpreadDigit�$ CbProductName��# [ �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]!   Value! �� $ PendingOrderPrice� �� $ WindowL�$ FindAncestor=�" �� Mode$" TwoWay=��� $��Normal"�$��5,1,5,5q����� *" SelectedValue.PendingOrderSpread+# �� StringFormat$/# )挂价单必须远离市价至少 {0} 点��� $��5q� �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �.+��� -   $��
CbStopLoss��$��	止损：��$	��2,5q�$��Center=�$ d� 	IsChecked$ �� $ EnableStopLoss� �� $ WindowL�$ FindAncestor=�$" TwoWay=�  $  F2��$	 .01X�$	��2,5q�$��1��$ 0X�! �� $ StopLoss� �� $ WindowL�$ FindAncestor=�$" TwoWay=�{��� $ 	IsChecked�$ 
CbStopLoss���� -   $��CbStopProfit��$��	止盈：��$	��2,5q�$��2��$��Center=�$ �� $ EnableStopProfit� �� $ WindowL�$ FindAncestor=�$" TwoWay=�  $  F2��$	 .01X�$	��2,5q�$��3��$ 0X�! �� $ 
StopProfit� �� $ WindowL�$ FindAncestor=�$" TwoWay=�{��� $ 	IsChecked�$ CbStopProfit��� $��5q� �� $��* ��� $��* �.+��� $��0��$��买跌��#��[ $��88��$	��2,5q�
�����F�
���   �$
��Bold"�  BtnStyle#��[ �� $��1��$��买涨��#��[  $��88��$	��2,5q�
�����F�
���   �$
��Bold"�#��[ 