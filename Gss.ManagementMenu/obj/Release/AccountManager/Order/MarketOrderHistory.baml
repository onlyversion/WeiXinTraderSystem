   M S B A M L   `   `   `  ���� M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter K*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter  @    :Gss.ManagementMenu.AccountManager.Order.MarketOrderHistory   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >cus.clr-namespace:Gss.ManagementMenu.CustomControl     HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     :cvt*clr-namespace:Gss.ManagementMenu.Converter       � 	Resources  2  ,Gss.Common.Converter.DateTimeFormatConverter   DateTimeCvt;  5Gss.ManagementMenu.Converter.TransactionTypeConverter  TransactionTypeCvt5  /Gss.ManagementMenu.Converter.TradeTypeConverter  TradeTypeCvt=   7Gss.ManagementMenu.Converter.LossOrProfitColorConverter  LossOrProfitColorConverter��%<   &	        &	      &	 
     &	              .��]� .+�;   5Gss.ManagementMenu.CustomControl.InquiryCustomControl  ;   5Gss.ManagementMenu.CustomControl.InquiryCustomControl   DoSearch$# InquiryCustomControl_DoSearch��$	��Top=�   IsUserIDVisbility$ 	Collapsed=�   AccountVisibility$ 	Collapsed=�   CurrentPageItemCount �� *Items.Count+ �� ElementName$ DgResult��   	PageCount �� *	PageCount+ �� RelativeSource ��  �� AncestorType$ UserControlL�	 �� Mode$	 FindAncestor=�
   ProductList
 �� *ProductInfoes+&   System.Windows.Controls.DataGrid  -   $��DgResult��   AutoGenerateColumns .     CanUserResizeRows .     SelectionMode$ Single=�   
IsReadOnly . $��15(�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Header$ 客户账号�� 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ 70
 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *TradeAccount+  $ 历史单号��$ 70
  �� *	HistoryID+  $ 商品名称��$ 70
  �� *ProductName+  $ 订单类型��$ 70
  �� *	OrderType+ �� 	Converter# [   $ 手数��$ 70
  �� *
TradeCount+  $ 	订单价��$ 70
  �� *
OrderPrice+  $ 	平仓价��$ 70
  �� *
TradePrice+  $ 	止损价��$ 70
  �� *
StopLoss+  $ 	止盈价��$ 70
  �� *
StopProfit+4  .System.Windows.Controls.DataGridTemplateColumn  $ 盈亏�� 	  MinWidth$ 60Q�   CellTemplate �� .R��� $��Center=�.+��� $��Center=����� *LossOrProfit+���� *LossOrProfit+# [   $ 	手续费��$ 70
  �� *BasicLaborCharge+  $ 订单单号��$ 70
  �� *	OrderID+  $ 订单时间��$	 150Q�$ 70
  �� *	OrderTime+# [    $ 平仓时间��$	 150Q�$ 70
  �� *	TradeTime+# [    $ 平仓方式��$ 70
  �� *	TradeType+# [ 