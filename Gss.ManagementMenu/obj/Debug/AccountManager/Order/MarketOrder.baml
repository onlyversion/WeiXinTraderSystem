   M S B A M L   `   `   `  ����E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter  5   �   M IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl 6
  K*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter 6E  9   3Gss.ManagementMenu.AccountManager.Order.MarketOrder   6   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6L   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6�   HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     6�   >cus.clr-namespace:Gss.ManagementMenu.CustomControl     6
  :cvt*clr-namespace:Gss.ManagementMenu.Converter     6E  Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6|  X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  6�  -   5          +� IsFocusScope  .  � 	Resources 5      2   ,Gss.Common.Converter.DateTimeFormatConverter   DateTimeCvt; 5Gss.ManagementMenu.Converter.TransactionTypeConverter  TransactionTypeCvt��%:   &	        &	        5   
   6(     5   
   6'   5      .��5      ]� .+�5	   
   &   System.Windows.Controls.DataGrid  -   5        $��DgResult��5	   i      AutoGenerateColumns .     CanUserResizeRows .  $��15(�6I      
IsReadOnly .    SelectionMode$ Single=�6y      Columns 5
      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 单号��6B      Width5  /System.Windows.Controls.DataGridLengthConverter$	 160 6N   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6&   �� *	OrderID+6N     5      $ 商品��6F   $ 88 6R   	 6&   �� *ProductName+6R     5      $ 类型��6s   $ 60 6   	 6&   �� *	OrderType+
 �� 	Converter#
 [ 6     5      $ 手数��6H   $ 60 6T   	 6&   �� *OrderQuantity+6T     5      $ 	成交价��6E   $ 60 6R   	 6&   �� *
OrderPrice+6R   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ 	即时价��6*   $ 75 67      CellTemplate 5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6)   .+�5   "   �� $��15��6(   $��15��64    5   &    �� 
TargetType �� Triggers �� Binding �� Path �� Value �� Property �� Value��%�  '��       �� 5   *   " ��60    5   .   �� 5   2    6>   �� $ IsPriceRising� True6e   .a�5   6   ��  � ��$2 ,/Gss.ProductInfoView;component/Images/Up.png��6O   �� 5   6    �@�ToolTip$ 上涨��6P   5   3   �� 5   2    6>   �� $ IsPriceRising�	 False6e   .a�5   6   ��  � ��$4 ./Gss.ProductInfoView;component/Images/Down.png��6O   �� 5   6    �@�ToolTip$ 下跌��6P   5   3   5!   +   5"   '   5#   #   �� 5$   "   ��5%   "   �� 5&   &   " ��6,    5'   *   �� 5(   .    6:   �� $ IsPriceRising� True6a   .a�5)   2   ��  � �� 6I   �� $ RealTimePriceString� �� Mode$ OneWay=��� 5*   2    � ��
 �  ��6O   5+   /   �� 5,   .    6:   �� $ IsPriceRising�	 False6a   .a�5-   2   ��  � �� 6I   �� $ RealTimePriceString�$ OneWay=��� 5.   2    � ��
 � � �6O   5/   /   51   '   53   #   54      56      58        5G      $ 70 6)   $ 盈亏��64    5H      �� 5I      .R�5J      �� -   5        
������ 
������  �� 
IsReadOnly . ��5J   {   �� *LossOrProfit+$ OneWay=�.��6�   ��5K   "   �� 5L   &   " ��6,    5M   *   �� 5N   .    6:   �� $ 
IsEarnings� True6^   .a�5O   2   ��  � ��
 �  ��6O   5P   /   �� 5Q   .    6:   �� $ 
IsEarnings�	 False6^   .a�5R   2   ��  � ��
 � � �6O   5S   /   5U   '   .��5V   1   5W      5X      5Z        5[      $ 	止损价��6C   $ 60 6P   	 6&   �� *
StopLoss+6P     5\      $ 	止盈价��6E   $ 60 6R   	 6&   �� *
StopProfit+6R     5]      $ 	保证金��6J   $ 60 6W   	 6&   �� *OccupiedDeposit+6W     5_      $ 	手续费��6C   $ 66 6P   	 6&   �� *
TradeFee+6P     5`      $ 订单时间��6l   $	 140 6z   	 6&   �� *	OrderTime+#
 [  6z   5b      5d      5e      