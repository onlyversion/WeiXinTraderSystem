   M S B A M L   `   `   `  ���� E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter  M IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl 1   +Gss.ManagementMenu.TradeManager.MarketOrder   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     :cvt*clr-namespace:Gss.ManagementMenu.Converter     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  8cus.clr-namespace:Gss.ManagementMenu.CustomControl    +� IsFocusScope  .  � 	Resources    
Chargeback �� Text  Warehousing  
AllowStore  RecordRealWeight  HistoryOrder;  5Gss.ManagementMenu.Converter.RiskCoefficientConverter  RiskCoefficientConverter2   ,Gss.Common.Converter.DateTimeFormatConverter  DateTimeCvt; 5Gss.ManagementMenu.Converter.TransactionTypeConverter  TransactionTypeCvt-   'Gss.Common.Converter.PlusMinusConverter  PlusMinusConverter 	 BoolVisibilityCvt 
 CmMarketOrder m� Command �� 	Converter m� CommandTarget �� Path �� RelativeSource �� AncestorType)  #System.Windows.Controls.DataGridRow	 �� 
TargetType  DataGridRowBaseStyle
 �� BasedOn �� Property �� Value��%s  &	        &	      &	 $     &	 <     &	 T     &	 l     &	 q     &	 v     &	 {     &		 �     &	
 �     7   7 	 7  7 	 '  �    7  7 
 �� $ 平仓���� $ 入库���� $ 入库设置���� $ 买跌检测���� $ 订单信息��        �� �� -   .@�m� 8   y��� *1/AccountAuthority.AllowViewMarketOrderChargeback+8   �� $ PlacementTarget� �� $ ContextMenuL�m� 8  y��� *0.AccountAuthority.AllowViewMarketOrderOrderInfo+8   �� $ PlacementTarget� �� $ ContextMenuL��� "	  8
   .���  � ��$ 26����  �@�ContextMenu8   J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [   -   # [   -   # [   -   # [ .��]� .+�;  5Gss.ManagementMenu.CustomControl.InquiryCustomControl  ;  5Gss.ManagementMenu.CustomControl.InquiryCustomControl   DoSearch$# InquiryCustomControl_DoSearch��   DoExcel$" InquiryCustomControl_DoExcel��$	��Top=�   OrgNameVisibility$ Visible=�   IsProductNameVisibility$ Visible=�   CurrentPageItemCount �� *Items.Count+ �� ElementName$ DgResult��   	PageCount �� *	PageCount+ �� $ UserControlL� �� Mode$ FindAncestor=�   ProductList �� *ProductInfoes+   POrgList �� *
POrgList+�� $��Bottom=� �� Orientation$ 
Horizontal=�.+��� .��	数量:�� $��Center=�$��0,0,20,0q����� *TradeOrderInfo.Quantity+�� .��保证金：�� $��Center=�$��0,0,20,0q����� *TradeOrderInfo.OccMoney+# [ �� .��手续费：�� $��Center=�$��0,0,20,0q����� *TradeOrderInfo.Tradefee+# [ �� .��	盈亏：�� $��0,0,20,0q�$��Center=����� *" TradeOrderInfo.TotalLossOrProfit+ �� StringFormat$ F2��%	  Xceed.Wpf.Toolkit.BusyIndicator	   	  IsBusy �� *IsLoadingMarketOrderList+ 	  BusyContent �� $��加载中...��$��20(�$
��Bold"�$��Center=�$��Center=�.��&
   System.Windows.Controls.DataGrid
  -   $��DgResult�� 
  AutoGenerateColumns .   
  SelectionMode$ Single=� 
  
IsReadOnly .   
  CanUserResizeRows  .  ���� *TradeOrderInfo.TdOrderList+! 
  Columns! 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn"   Width5  /System.Windows.Controls.DataGridLengthConverter$" 70 #   Header$# 会员编码��$   CellTemplate$ �� .R��� $��0q�
������ % �� 
IsReadOnly% . ��Z� ���� *	Telephone+  $" 70 $# 会员名称��$ �� .R��� $��0q�
������ % . ��Z� ���� *	OrgName+  $" 70 $# 账号��$ �� .R��� $��0q�
������ % . ��Z� ���� *TradeAccount+  $" 70 $# 姓名��$ �� .R��� $��0q�
������ % . ��Z� ���� *
UserName+0  *System.Windows.Controls.DataGridTextColumn  $" 70 $# 订单��1  +System.Windows.Controls.DataGridBoundColumn&   Binding& �� *	OrderID+  $" 70 $# 商品��& �� *ProductName+  $# 类型��'   MinWidth$' 60Q�& �� *	OrderType+# [   $# 手数��$" 60 & �� *OrderQuantity+  $# 	成交价��$" 60 & �� *
OrderPrice+  $# 	即时价��$" 60 (   
IsReadOnly( . $ �� .R��� -   % . 
������ $��0q�$��0q�$��0q���Z� ���� *RealTimePriceString+) �� Mode$) OneWay=�.��  $# 盈亏��$" 60 & �� *LossOrProfit+*   	CellStyle* �� *  $System.Windows.Controls.DataGridCell"	    DataGridCellBaseStyle#
 [ + �� Triggers+ �� , �� Binding, �� $ 
IsEarnings�- �� Value- True.a���  � ��
 �  ���� , �� $ 
IsEarnings�	- False.a���  � ��
 � � �  $# 风险系数%��$" 88 & �� *RiskCoefficient+* �� "	  #
 [ .���  � �� �� .R��� $��Center=����� *RiskCoefficient+���� *RiskCoefficient+# [   $# 	止损价��$" 60 & �� *
StopLoss+  $# 	止盈价��$" 60 & �� *
StopProfit+  $# 	保证金��$" 60 & �� *OccupiedDeposit+# [   $# 	手续费��$" 66 & �� *
TradeFee+# [   $# 订单时间��$	" 140 $ �� .R��� $��0q�
������ % . ��Z� ���� *	OrderTime+# [ 