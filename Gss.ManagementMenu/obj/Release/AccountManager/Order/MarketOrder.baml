   M S B A M L   `   `   `  ���� E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter  M IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl K*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter 9   3Gss.ManagementMenu.AccountManager.Order.MarketOrder   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     >cus.clr-namespace:Gss.ManagementMenu.CustomControl     :cvt*clr-namespace:Gss.ManagementMenu.Converter     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  -     +� IsFocusScope  .  � 	Resources 2   ,Gss.Common.Converter.DateTimeFormatConverter   DateTimeCvt; 5Gss.ManagementMenu.Converter.TransactionTypeConverter  TransactionTypeCvt��%   &	        &	          .��]� .+�&   System.Windows.Controls.DataGrid  -   $��DgResult��   AutoGenerateColumns .     CanUserResizeRows .  $��15(�   
IsReadOnly .    SelectionMode$ Single=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 单号��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 160 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 �� *	OrderID+  $ 商品��$ 88 	 �� *ProductName+  $ 类型��$ 60 	 �� *	OrderType+
 �� 	Converter#
 [   $ 手数��$ 60 	 �� *OrderQuantity+  $ 	成交价��$ 60 	 �� *
OrderPrice+4  .System.Windows.Controls.DataGridTemplateColumn  $ 	即时价��$ 75    CellTemplate �� .R���  �� Orientation$ 
Horizontal=�.+��� $��15��$��15��  �� 
TargetType �� Triggers �� Binding �� Path �� Value �� Property �� Value��%;  '��       �� " �� ��  �� $ IsPriceRising� True.a���  � ��$2 ,/Gss.ProductInfoView;component/Images/Up.png����  �@�ToolTip$ 上涨����  �� $ IsPriceRising�	 False.a���  � ��$4 ./Gss.ProductInfoView;component/Images/Down.png����  �@�ToolTip$ 下跌���� ���� " �� ��  �� $ IsPriceRising� True.a���  � �� �� $ RealTimePriceString� �� Mode$ OneWay=���  � ��
 �  ����  �� $ IsPriceRising�	 False.a���  � �� �� $ RealTimePriceString�$ OneWay=���  � ��
 � � �  $ 70 $ 盈亏�� �� .R��� -   
������ 
������  �� 
IsReadOnly . ���� *LossOrProfit+$ OneWay=�.������ " �� ��  �� $ 
IsEarnings� True.a���  � ��
 �  ����  �� $ 
IsEarnings�	 False.a���  � ��
 � � �.��  $ 	止损价��$ 60 	 �� *
StopLoss+  $ 	止盈价��$ 60 	 �� *
StopProfit+  $ 	保证金��$ 60 	 �� *OccupiedDeposit+  $ 	手续费��$ 66 	 �� *
TradeFee+  $ 订单时间��$	 140 	 �� *	OrderTime+#
 [  