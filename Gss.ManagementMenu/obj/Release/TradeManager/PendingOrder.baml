   M S B A M L   `   `   `  ���� M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter  E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  2    ,Gss.ManagementMenu.TradeManager.PendingOrder   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     :cvt*clr-namespace:Gss.ManagementMenu.Converter     HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  8cus.clr-namespace:Gss.ManagementMenu.CustomControl    +� IsFocusScope  .  � 	Resources  
  Cancel �� Text  HistoryOrder2  ,Gss.Common.Converter.DateTimeFormatConverter  DateTimeCvt;  5Gss.ManagementMenu.Converter.TransactionTypeConverter  TransactionTypeCvt  BoolVisibilityCvt-  'Gss.Common.Converter.PlusMinusConverter  PlusMinusConverter  menu m� Command �� 	Converter m� CommandTarget �� Path �� RelativeSource �� AncestorType)  #System.Windows.Controls.DataGridRow	 �� 
TargetType  DataGridRowBaseStyle
 �� BasedOn �� Property �� Value��%  &	        &	      &	 *     &	 /     &	 4     &	 9     &	 >     7   7  7  7  '  T    7  7  �� $ 撤销���� $ 订单信息��    ��   �� -   .@�m� 8   y��� *.,AccountAuthority.AllowViewPendingOrderCancel+8   �� $ PlacementTarget� �� $ ContextMenuL�m� 8  y��� *1/AccountAuthority.AllowViewPendingOrderOrderInfo+8   �� $ PlacementTarget� �� $ ContextMenuL��� "	  8
   .���  � ��$ 26����  �@�ContextMenu8   J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [ .��]� .+�;   5Gss.ManagementMenu.CustomControl.InquiryCustomControl  ;   5Gss.ManagementMenu.CustomControl.InquiryCustomControl   DoSearch$# InquiryCustomControl_DoSearch��$	��Top=�   OrgNameVisibility$ Visible=�   IsProductNameVisibility$ Visible=�   CurrentPageItemCount �� *Items.Count+ �� ElementName$ DgResult��   	PageCount �� *	PageCount+ �� $ UserControlL� �� Mode$ FindAncestor=�   ProductList �� *ProductInfoes+   POrgList �� *
POrgList+�� $��Bottom=� �� Orientation$ 
Horizontal=�.+��� .��	数量:�� $��Center=�$��0,0,20,0q����� *TradeHoldOrderInfo.Quantity+�� .��预付款：�� $��Center=�$��0,0,20,0q����� * TradeHoldOrderInfo.FrozenMoney+# [ %  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy �� *IsLoadingPendingOrderList+   BusyContent �� $��加载中...��$��20(�$
��Bold"�$��Center=�$��Center=�.��&	   System.Windows.Controls.DataGrid	  -    	 Name$ DgResult�� 	  AutoGenerateColumns .   	  SelectionMode$ Single=� 	  
IsReadOnly .  	  CanUserResizeRows .  ���� *$"TradeHoldOrderInfo.TdHoldOrderList+���� "	 	   DataGridStyle#
 [   �� Triggers  �� ! �� Binding! �� $ 
Visibility�$ TbMsg��" �� Value" 	Collapsed.a���  � y�$ Visible=��� ! �� $ 
Visibility�$ TbMsg��" Visible.a���  � y�$ 	Collapsed=�# 	  Columns# 0
  *System.Windows.Controls.DataGridTextColumn
  ,  &System.Windows.Controls.DataGridColumn$   Header$$ 会员编码��%   Width5  /System.Windows.Controls.DataGridLengthConverter$% 88 1  +System.Windows.Controls.DataGridBoundColumn&   Binding& �� *	Telephone+
  $$ 所属会员��$% 70 & �� *	OrgName+
  $$ 客户账号��$% 88 & �� *TradeAccount+
  $$ 客户名称��$% 88 & �� *
UserName+
  $$ 单号��$	% 100 & �� *	OrderID+
  $$ 商品��$% 88 & �� *ProductName+
  $$ 类型��$% 60 & �� *	OrderType+# [ 
  $$ 手数��$% 60 & �� *OrderQuantity+
  $$ 	挂单价��$% 60 & �� *
OrderPrice+
  $$ 	即时价��$% 60 & �� *RealTimePriceString+
  $$ 	止损价��$% 60 & �� *
StopLoss+
  $$ 	止盈价��$% 60 & �� *
StopProfit+
  $$ 	预付款��$% 60 & �� *FrozenDeposit+# [ 
  $$ 	有效期��$	% 100 & �� *	DueDate+# [ 
  $$ 订单时间��$	% 140 & �� *	OrderTime+# [ 