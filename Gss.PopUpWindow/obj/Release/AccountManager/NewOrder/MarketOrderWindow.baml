   M S B A M L   `   `   `  ���� J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gss.PopUpWindow.ConverterGss.PopUpWindow.Converter  E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK4clr-namespace:Gss.Common.Utility;assembly=Gss.CommonGss.Common.Utility G CGss.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.EntitiesGss.Entities.ValidationHelper '    !Gss.PopUpWindow.MarketOrderWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  1cvt'clr-namespace:Gss.PopUpWindow.Converter  >uti4clr-namespace:Gss.Common.Utility;assembly=Gss.Common  XValidationHelperAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.Entities  -     � Title$  即时成交��$	��300�� � WindowStartupLocation$ CenterOwner=� � WindowStyle$ 
ToolWindow=� � SizeToContent$ Height=� � 
ResizeMode$ NoResize=� � 	Resources    BoolVisibilityCv7   1Gss.PopUpWindow.Converter.DigitIncrementConverter  DigitIncrementCv:   4Gss.PopUpWindow.Converter.DigitFormatStringConverter  
DigitFmtCv:   4Gss.PopUpWindow.Converter.ProductVisibilityConverter  ProductVisibilityConverter 	 Order  Recovery �� 
TargetType �� Property �� Value$  Xceed.Wpf.Toolkit.DoubleUpDown0  *Gss.Common.Utility.DoubleUpDownInputFilter	 �� Triggers
 P� Property P� Value �� Path �� Self �� RelativeSource��%�  &	        &	      &	 
     &	      &	      &	      '��      '�� �     '  �     ��       �� �� �� " ��.���  � ��$ 2q���  � ��$
 Bold"���  � ��$ Center=���  � ��$ Right=��� " ��.���  � ��$ 2q���  � ��$
 Bold"��� "  .���  �@ 	DigitOnly . 	 P� 
 �@=�HasError . . ���  �@�ToolTip �� $2 ,(Validation.Errors).CurrentItem.ErrorContent�# Z  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [ .����  �� CornerRadius$ 5��$��1q�$��10q�
����=H�._�%  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy �� *	IsTrading+ ��  �� AncestorType$ WindowL�   BusyContent �� $��交易进行中...��$��Center=�$��20(�.���� .+��� .+�� $��5q� � RowDefinitions �� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��	商品：���� $��	手数：��$��1��$��0���� -   $��CbProductName��$��0��$��1��$	��2,5q� �� SelectedIndex$ 0������ *ProductList+ �� $ WindowL� �� Mode$ FindAncestor=����� .R��� ���� *ProductName+y��� *State+ �� 	Converter# [ �� $��1��$��1��.��  -   $��IntCount��$��1��$��1��$	��2,5q�,  &Xceed.Wpf.Toolkit.Primitives.InputBase   	Watermark$ 输入订单数量���	  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 	  SelectAllOnGotFocus .  	  	Increment$ 1X�� $��5q� �� $
��Auto ��� $
��Auto � �� $��* ��� $
��Auto �.+��� $��2,5,10,5q�$��Right=�$��Center=�$
��Bold"�
���  ��$��18(����� $' !SelectedValue.RecoveryPriceString� �� ElementName$ CbProductName���� $��0��$��1��$��买跌��#��[ $��88��$	��2,5q�
�����F�
���   �$
��Bold"�  BtnStyle#��[ �� $��1��$��0��$��2,5,10,5q�$��Right=�$��Center=�$��18(�$
��Bold"�
����  ����� $$ SelectedValue.OrderPriceString�$ CbProductName���� $��1��$��1��$��买涨��#��[ $��88��$	��2,5q�
�����F�
���   �$
��Bold"�#��[ �� $��5q�.+��  �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �.+��� -   $��
CbStopLoss��$��	止损：��$	��2,5q�$��Center=� d� 	IsChecked �� $ EnableStopLoss� �� $ WindowL�$ FindAncestor=� �� Mode$ TwoWay=�  $	��2,5q�$��1��  	  Minimum$  0X�$ 输入止损价���
  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]! 
  Value! �� $ StopLoss� �� $ WindowL�$ FindAncestor=�$ TwoWay=�" 	  FormatString" �� $ SelectedValue.SpreadDigit�$ CbProductName��# [  �� $ SelectedValue.SpreadDigit�$ CbProductName��# [ {��� $ 	IsChecked�$ 
CbStopLoss���� -   $��CbStopProfit��$��	止盈：��$	��2,5q�$��2��$��Center=� �� $ EnableStopProfit� �� $ WindowL�$ FindAncestor=�$ TwoWay=�  $	��2,5q�$��3��$  0X�$ 输入止盈价��! �� $ 
StopProfit� �� $ WindowL�$ FindAncestor=�$ TwoWay=�" �� $ SelectedValue.SpreadDigit�$ CbProductName��# [  �� $ SelectedValue.SpreadDigit�$ CbProductName��# [ {��� $ 	IsChecked�$ CbStopProfit���� -   $��CbDeviation��$
��Left=�$*��$允许成交价与报价最大偏差���� # �� Orientation$# 
Horizontal=�$��Right=�{��� $ 	IsChecked�$ CbDeviation��.+��� $��最大偏差��$��2q�$��Center=�$ �� TextAlignment$$ Center=�$��Normal"�%  Xceed.Wpf.Toolkit.IntegerUpDown  $��2q�$��88���  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]%   Minimum$% 0X�2  ,Gss.Common.Utility.IntergerUpDownInputFilter&   	DigitOnly$
& TrueX��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]'   DefaultValue$' 0X�(   Value( �� $ AllowMaxPriceDiff� �� $ WindowL�$ FindAncestor=�$ TwoWay=��� $	��点��$��Normal"�