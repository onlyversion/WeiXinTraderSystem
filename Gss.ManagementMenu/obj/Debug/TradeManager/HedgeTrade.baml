   M S B A M L   `   `   `  ����E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter  5      M IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter 5      0   *Gss.ManagementMenu.TradeManager.HedgeTrade   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  5      4cvt*clr-namespace:Gss.ManagementMenu.Converter  5        +� IsFocusScope  .  � 	Resources 5      ; 5Gss.ManagementMenu.Converter.TransactionTypeConverter   TransactionTypeCvt)  #System.Windows.Controls.DataGridRow �� 
TargetType  DataGridRowBaseStyle �� BasedOn �� Property �� Value-   'Gss.Common.Converter.PlusMinusConverter  PlusMinusConverter=  7Gss.ManagementMenu.Converter.LossOrProfitColorConverter  LossOrProfitColorConverter��%�   &	        '       7  &	 `     &	 s       5	   
   6'   �� 5
   
   "  6   8   .�5      ��  � ��$ 52��6*   5        5   
   6#     5   
   6)   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��1* �6   �� 5      $
��auto �6   .+�5   
   �  � Orientation$ 
Horizontal=�6   .+�5      ��  �� Orientation$ 
Horizontal=�6   	 � DataContext	 62   �� *HedgingTradeRequestInfo+.+�5      �� $��时间段：��6   $��2q�6'   (  "System.Windows.Controls.DatePicker  5      $��2q�6   |�.  
   SelectedDate
 6:   �� *	StartTime+�� 5      $	��至��6   $��2q�6$     5      $��2q�6   |�.  
 6:   �� *	EndTime+5!      �� 5"      $��查询��6   $��60��6"   $��26��6-   $	��5,2q�69    � ToolTip$0 *根据查询条件获取对冲记录数据��6G   ��6b   �� *GetHedgingHistoryListCmd+5#      %  Xceed.Wpf.Toolkit.BusyIndicator  5$   
   $��1��6      IsBusy 6+   �� *IsLoadingHedgingTradeList+   BusyContent 5%      �� 5&      $��加载中...��6   $��20(�6*   $
��Bold"�68   $��Center=�6J   $��Center=�6e   .��5(      &   System.Windows.Controls.DataGrid  -   5        $��DgResult��5(      $��1��6'   $��13(�64      AutoGenerateColumns .     CanUserResizeRows .     SelectionMode$ Single=�6x      
IsReadOnly .    CanUserSortColumns .  ��5)      �� *HedgingInfo.LTdOrderList+ 5*      ��%}   '��       �� 5+      " ��6   .�5,      ��  � ��$ 0,5,0,5q�63   �� 5-       � ��
 �  ��67   5.      5/         Columns 50      4  .System.Windows.Controls.DataGridTemplateColumn  53      ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ 70
 6-    	  Header$ 商品��68      CellTemplate 54      �� 55      .R�56   "   �� $��0q�6;   
������  �� 
IsReadOnly . ��6*   Z� ��57   <   �� *ProductName+58      5:        5@      $ 类型��6.   $ 70
 6;    5A      �� 5B      .R�5C   "   �� $��Center=�6.   .+�5D   &   �� $��0,5,0,0q�60   $��Center=�6�   ��6A   �� *	OrderType+ �� 	Converter# [  6�   �� 5E   &   $��1��6-   $��0,3,0,3q�68   ���	#FFA7C0DC6I   �� 5F   &   $��0,0,0,5q�60   $��Center=�6�   ��6A   �� *
OrderType2+ �� TargetNullValue$	 ---��# [  6�   5G   #   5H      5J        5M      $ 订单数量��6.   $ 70
 6=    5N      �� 5O      .R�5P   "   �� $��Center=�6.   .+�5Q   &   �� $��Center=�6O   ��60   �� *OrderQuantity+6O   �� 5R   &   $��1��6-   $��0,3,0,3q�68   ���	#FFA7C0DC6I   �� 5S   &   $��Center=�6f   ��60   �� *OrderQuantity2+$	 ---��6f   5T   #   5U      5W        5Y      $ 	平均价��6.   $ 70
 6<    5Z      �� 5[      .R�5\   "   �� $��Center=�6.   .+�5]   &   �� $��Center=�6N   ��60   �� *AveragePrice+6N   �� 5^   &   $��1��6-   $��0,3,0,3q�68   ���	#FFA7C0DC6I   �� 5_   &   $��Center=�6e   ��60   �� *AveragePrice2+$	 ---��6e   5`   #   5a      5c        5e      $ 	实时价��6.   $ 60
 6;    5f      �� 5g      .R�5h   "   �� $��Center=�6.   .+�5i   &   �� $��Center=�6O   ��60   �� *RealTimePrice+6O   �� 5j   &   $��1��6-   $��0,3,0,3q�68   ���	#FFA7C0DC6I   �� 5k   &   $��Center=�6f   ��60   �� *RealTimePrice2+$	 ---��6f   5l   #   5m      5o        5q      $ 盈亏��6.   $ 60
 6:    5r      �� 5s      .R�5t   "   �� $��Center=�6.   .+�5u   &   �� $��Center=�6N   ��60   �� *LossOrProfit+6N   �� 5v   &   $��1��6-   $��0,3,0,3q�68   ���	#FFA7C0DC6I   �� 5w   &   $��Center=�6e   ��60   �� *LossOrProfit2+$	 ---��6e   5x   #   5y      5{        5}      $ 	手续费��6.   $ 60
 6;    5~      �� 5      .R�5�   "   �� $��Center=�6.   .+�5�   &   �� $��Center=�6x   ��60   �� *
TradeFee+# [ 6x   �� 5�   &   $��1��6-   $��0,3,0,3q�68   ���	#FFA7C0DC6I   �� 5�   &   $��Center=�6�   ��60   �� *	TradeFee2+# [ $	 ---��6�   5�   #   5�      5�        5�      $ 	总数量��6.   $ 60
 6;    5�      �� 5�      .R�5�   "   �� $��Center=�6.   .+�5�   &   �� $��Center=�6Q   ��60   �� *HedgingQuantity+6Q   5�   #   5�      5�        5�      $ 	总工费��6.   $ 60
 6;    5�      �� 5�      .R�5�   "   �� $��Center=�6.   .+�5�   &   �� $��Center=�6Q   ��60   �� *HedgingTradeFee+6Q   5�   #   5�      5�        5�      $ 	总盈亏��6.   $ 60
 6;    5�      �� 5�      .R�5�   "   �� $��Center=�6.   .+�5�   &   �� $��Center=�6�   ��60   �� *HedgingLossOrProfit+��6U   �� *HedgingLossOrProfit+# [ 6�   5�   #   5�      5�      5�      5�      �� 5�   
   $��2��6   $ 
Horizontal=�6"   .+�5�      �� .��6   	数量:6   �� 5�      $��Center=�6>   $��0,0,20,0q�6Y   ��6   �� *HedgingInfo.Quantity+6Y   �� 5�      .��6   手续费：6   �� 5�      $��Center=�6m   $��0,0,20,0q�6�   ��6   �� *HedgingInfo.Tradefee+# [ 6�   �� 5�      .��6   	盈亏：6   �� 5�      $��Center=�6B   $��0,0,20,0q�6]   ��6   �� *HedgingInfo.ProfitValue+6]   5�      5�      5�      