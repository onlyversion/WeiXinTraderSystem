   M S B A M L   `   `   `  ���� E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter  M IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter 0   *Gss.ManagementMenu.TradeManager.HedgeTrade   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  4cvt*clr-namespace:Gss.ManagementMenu.Converter    +� IsFocusScope  .  � 	Resources ; 5Gss.ManagementMenu.Converter.TransactionTypeConverter   TransactionTypeCvt)  #System.Windows.Controls.DataGridRow �� 
TargetType  DataGridRowBaseStyle �� BasedOn �� Property �� Value-   'Gss.Common.Converter.PlusMinusConverter  PlusMinusConverter=  7Gss.ManagementMenu.Converter.LossOrProfitColorConverter  LossOrProfitColorConverter��%c   &	        '       7  &	 -     &	 2       �� "  8   .���  � ��$ 52��    .���  � RowDefinitions �� $
��auto ��� $��1* ��� $
��auto �.+��  � Orientation$ 
Horizontal=�.+���  �� Orientation$ 
Horizontal=�	 � DataContext	 �� *HedgingTradeRequestInfo+.+��� $��时间段：��$��2q�(  "System.Windows.Controls.DatePicker  $��2q�|�.  
   SelectedDate
 �� *	StartTime+�� $	��至��$��2q�  $��2q�|�.  
 �� *	EndTime+�� $��查询��$��60��$��26��$	��5,2q� � ToolTip$0 *根据查询条件获取对冲记录数据������ *GetHedgingHistoryListCmd+%  Xceed.Wpf.Toolkit.BusyIndicator  $��1��   IsBusy �� *IsLoadingHedgingTradeList+   BusyContent �� $��加载中...��$��20(�$
��Bold"�$��Center=�$��Center=�.��&   System.Windows.Controls.DataGrid  -   $��DgResult��$��1��$��13(�   AutoGenerateColumns .     CanUserResizeRows .     SelectionMode$ Single=�   
IsReadOnly .    CanUserSortColumns .  ���� *HedgingInfo.LTdOrderList+ ��%J   '��       �� " ��.���  � ��$ 0,5,0,5q���  � ��
 �  ��   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ 70
  	  Header$ 商品��   CellTemplate �� .R��� $��0q�
������  �� 
IsReadOnly . ��Z� ���� *ProductName+  $ 类型��$ 70
  �� .R��� $��Center=�.+��� $��0,5,0,0q�$��Center=����� *	OrderType+ �� 	Converter# [  �� $��1��$��0,3,0,3q����	#FFA7C0DC�� $��0,0,0,5q�$��Center=����� *
OrderType2+ �� TargetNullValue$	 ---��# [    $ 订单数量��$ 70
  �� .R��� $��Center=�.+��� $��Center=����� *OrderQuantity+�� $��1��$��0,3,0,3q����	#FFA7C0DC�� $��Center=����� *OrderQuantity2+$	 ---��  $ 	平均价��$ 70
  �� .R��� $��Center=�.+��� $��Center=����� *AveragePrice+�� $��1��$��0,3,0,3q����	#FFA7C0DC�� $��Center=����� *AveragePrice2+$	 ---��  $ 	实时价��$ 60
  �� .R��� $��Center=�.+��� $��Center=����� *RealTimePrice+�� $��1��$��0,3,0,3q����	#FFA7C0DC�� $��Center=����� *RealTimePrice2+$	 ---��  $ 盈亏��$ 60
  �� .R��� $��Center=�.+��� $��Center=����� *LossOrProfit+�� $��1��$��0,3,0,3q����	#FFA7C0DC�� $��Center=����� *LossOrProfit2+$	 ---��  $ 	手续费��$ 60
  �� .R��� $��Center=�.+��� $��Center=����� *
TradeFee+# [ �� $��1��$��0,3,0,3q����	#FFA7C0DC�� $��Center=����� *	TradeFee2+# [ $	 ---��  $ 	总数量��$ 60
  �� .R��� $��Center=�.+��� $��Center=����� *HedgingQuantity+  $ 	总工费��$ 60
  �� .R��� $��Center=�.+��� $��Center=����� *HedgingTradeFee+  $ 	总盈亏��$ 60
  �� .R��� $��Center=�.+��� $��Center=����� *HedgingLossOrProfit+���� *HedgingLossOrProfit+# [ �� $��2��$ 
Horizontal=�.+��� .��	数量:�� $��Center=�$��0,0,20,0q����� *HedgingInfo.Quantity+�� .��手续费：�� $��Center=�$��0,0,20,0q����� *HedgingInfo.Tradefee+# [ �� .��	盈亏：�� $��Center=�$��0,0,20,0q����� *HedgingInfo.ProfitValue+