   M S B A M L   `   `   `  ���� E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter  M IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl 6   0Gss.ManagementMenu.TradeManager.ChargebackRecode   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     :cvt*clr-namespace:Gss.ManagementMenu.Converter     >cus.clr-namespace:Gss.ManagementMenu.CustomControl     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit    +� IsFocusScope  .  � 	Resources    BoolVisibilityCvt; 5Gss.ManagementMenu.Converter.TransactionTypeConverter  TransactionTypeCv2   ,Gss.Common.Converter.DateTimeFormatConverter  
DateTimeCv: 4Gss.ManagementMenu.Converter.ChargebackTypeConverter  ChargebackTypeConverter=  7Gss.ManagementMenu.Converter.LossOrProfitColorConverter  LossOrProfitColorConverter-   'Gss.Common.Converter.PlusMinusConverter  PlusMinusConverter  HistoryOrder �� Text  	CmPayMent m� Command �� 	Converter m� CommandTarget �� Path �� RelativeSource �� AncestorType)  #System.Windows.Controls.DataGridRow	 �� 
TargetType  DataGridRowBaseStyle
 �� BasedOn �� Property �� Value��%}  &	        &	      &	 
     &	      &	      &	      &	      &	 6     7  7   '  �     7  7  ��           �� $ 订单信息���� -   .@�m� 8   y��� *53AccountAuthority.AllowViewChargebackRecordOrderInfo+8   �� $ PlacementTarget� �� $ ContextMenuL��� "	  8
   .���  �@�ContextMenu8  ��  � ��$ 26�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .��]� .+�;  5Gss.ManagementMenu.CustomControl.InquiryCustomControl  ;	  5Gss.ManagementMenu.CustomControl.InquiryCustomControl 	  DoSearch$# InquiryCustomControl_DoSearch��$	��Top=�   OrgNameVisibility$ Visible=�   CurrentPageItemCount �� *Items.Count+ �� ElementName$ DgResult��   	PageCount �� *	PageCount+ �� $ UserControlL� �� Mode$ FindAncestor=�   ProductList �� *ProductInfoes+   POrgList �� *
POrgList+�� $��Bottom=� �� Orientation$ 
Horizontal=�.+��� .��	数量:�� $��Center=�$��0,0,20,0q����� *LTradeOrderInfo.Quantity+�� .��	盈亏：�� $��Center=�$��0,0,20,0q����� *LTradeOrderInfo.ProfitValue+�� .��手续费：�� $��Center=�$��0,0,20,0q����� *LTradeOrderInfo.Tradefee+# [ %
  Xceed.Wpf.Toolkit.BusyIndicator
   
  IsBusy �� *IsLoadingChargebackRecode+ 
  BusyContent �� $��加载中...��$��20(�$
��Bold"�$��Center=�$��Center=�.��&   System.Windows.Controls.DataGrid  -   $��DgResult��$��1��   AutoGenerateColumns .     CanUserResizeRows .     SelectionMode$ Single=�   
IsReadOnly . $��2������ *LTradeOrderInfo.TOrderLst+   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70     Header$  会员编码��!   CellTemplate! �� .R��� $��0q�
������ " �� 
IsReadOnly" . ��Z� ���� *	Telephone+  $ 70 $  所属会员��! �� .R��� $��0q�
������ " . ��Z� ���� *	OrgName+  $ 70 $  客户账号��! �� .R��� $��0q�
������ " . ��Z� ���� *TradeAccount+  $ 70 $  客户名称��! �� .R��� $��0q�
������ " . ��Z� ���� *
UserName+  $ 70 $  历史单号��! �� .R��� $��0q�
������ " . ��Z� ���� *	HistoryID+  $ 70 $  商品名称��! �� .R��� $��0q�
������ " . ��Z� ���� *ProductName+0  *System.Windows.Controls.DataGridTextColumn  $ 70 $  订单类型��1  +System.Windows.Controls.DataGridBoundColumn#   Binding# �� *	OrderType+# [   $ 50 $  手数��# �� *
TradeCount+  $ 60 $  	订单价��# �� *
OrderPrice+  $ 60 $  	平仓价��# �� *
TradePrice+  $ 60 $  	止损价��# �� *
StopLoss+  $ 60 $  	止盈价��# �� *
StopProfit+  $ 60 $  盈亏��$   MinWidth$$ 88Q�# �� *LossOrProfit+%   	CellStyle% �� *  $System.Windows.Controls.DataGridCell"	   	 DataGridCellBaseStyle#
 [	 .���  � �� �� .R��� $��Center=����� *LossOrProfit+���� *LossOrProfit+# [   $ 70 $  	手续费��# �� *BasicLaborCharge+# [   $ 70 $  订单单号��# �� *	OrderID+  $	 140 $  订单时间��$	$ 150Q�# �� *	OrderTime+# [   $	 140 $  平仓时间��$	$ 150Q�# �� *	TradeTime+# [   $ 70 $  平仓方式��# `� & `� 	Converter#& [ .1��� $ 	TradeType��� $ 
TradePrice��� $ StopLoss��� $ 
StopProfit�