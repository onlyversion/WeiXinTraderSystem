   M S B A M L   `   `   `  ����M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter  5      E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter 5      S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  5      2    ,Gss.ManagementMenu.TradeManager.PendingOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :cvt*clr-namespace:Gss.ManagementMenu.Converter     5      HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  5      8cus.clr-namespace:Gss.ManagementMenu.CustomControl  5        +� IsFocusScope  .  � 	Resources 5	       
  Cancel �� Text  HistoryOrder2  ,Gss.Common.Converter.DateTimeFormatConverter  DateTimeCvt;  5Gss.ManagementMenu.Converter.TransactionTypeConverter  TransactionTypeCvt  BoolVisibilityCvt-  'Gss.Common.Converter.PlusMinusConverter  PlusMinusConverter  menu m� Command �� 	Converter m� CommandTarget �� Path �� RelativeSource �� AncestorType)  #System.Windows.Controls.DataGridRow	 �� 
TargetType  DataGridRowBaseStyle
 �� BasedOn �� Property �� Value��%�  &	        &	       &	 F     &	 Y     &	 l     &	      &	 �     7   7  7  7  '  �    7  7  �� 5
   
   $ 撤销��6)   �� 5   
   $ 订单信息��6/     5   
   6(     5   
   6'   �� 5   
   6'     5   
   6#   �� 5   
   -   5        .@�5      m� 8   y�6   �� *.,AccountAuthority.AllowViewPendingOrderCancel+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8  y�6   �� *1/AccountAuthority.AllowViewPendingOrderOrderInfo+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   "	  6   8
   .�5      ��  � ��$ 26��6*   �� 5       �@�ContextMenu8  6,   5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6e     5   
   -   5        # [ 5      6q   .��5       ]� .+�50   
   ;   5Gss.ManagementMenu.CustomControl.InquiryCustomControl  ;   5Gss.ManagementMenu.CustomControl.InquiryCustomControl   DoSearch$# InquiryCustomControl_DoSearch��6T   $	��Top=�6#      OrgNameVisibility$ Visible=�68      IsProductNameVisibility$ Visible=�6}      CurrentPageItemCount 51   #   �� *Items.Count+ �� ElementName$ DgResult��   	PageCount 52   #   �� *	PageCount+ �� $ UserControlL� �� Mode$ FindAncestor=�   ProductList 53   #   �� *ProductInfoes+   POrgList 6I   �� *
POrgList+�� 55   
   $��Bottom=�6    �� Orientation$ 
Horizontal=�6-   .+�56      �� .��6   	数量:6   �� 57      $��Center=�6E   $��0,0,20,0q�6`   ��6   �� *TradeHoldOrderInfo.Quantity+6`   �� 59      .��6   预付款：6   �� 5:      $��Center=�6w   $��0,0,20,0q�6�   ��6   �� * TradeHoldOrderInfo.FrozenMoney+# [ 6�   5<      %  Xceed.Wpf.Toolkit.BusyIndicator  5=   
      IsBusy 6   �� *IsLoadingPendingOrderList+   BusyContent 5>      �� 5?      $��加载中...��6   $��20(�6*   $
��Bold"�68   $��Center=�6J   $��Center=�6e   .��5A      &	   System.Windows.Controls.DataGrid	  -   5         	 Name$ DgResult��5A       	  AutoGenerateColumns .   	  SelectionMode$ Single=�6E    	  
IsReadOnly .  	  CanUserResizeRows .  ��5B      �� *$"TradeHoldOrderInfo.TdHoldOrderList+��5E      �� 5F      "	 	 6     DataGridStyle#
 [ 62     �� Triggers  5G      �� 5H      ! �� Binding! 6*   �� $ 
Visibility�$ TbMsg��" �� Value" 	Collapsed6a   .a�5I   "   ��  � y�$ Visible=�6?   5J      �� 5K      ! 6*   �� $ 
Visibility�$ TbMsg��" Visible6a   .a�5L   "   ��  � y�$ 	Collapsed=�6?   5M      5O      # 	  Columns# 5Q      0
  *System.Windows.Controls.DataGridTextColumn
  5R      ,  &System.Windows.Controls.DataGridColumn$   Header$$ 会员编码��6)   %   Width5  /System.Windows.Controls.DataGridLengthConverter$% 88 6U   1  +System.Windows.Controls.DataGridBoundColumn&   Binding& 67   �� *	Telephone+6U   
  5S      $$ 所属会员��6)   $% 70 6S   & 67   �� *	OrgName+6S   
  5T      $$ 客户账号��6)   $% 88 6X   & 67   �� *TradeAccount+6X   
  5U      $$ 客户名称��6)   $% 88 6T   & 67   �� *
UserName+6T   
  5X      $$ 单号��6)   $	% 100 6Q   & 65   �� *	OrderID+6Q   
  5Y      $$ 商品��6)   $% 88 6U   & 65   �� *ProductName+6U   
  5Z      $$ 类型��6)   $% 60 6�   & 65   �� *	OrderType+# [ 6�   
  5[      $$ 手数��6)   $% 60 6W   & 65   �� *OrderQuantity+6W   
  5\      $$ 	挂单价��6)   $% 60 6U   & 66   �� *
OrderPrice+6U   
  5]      $$ 	即时价��6)   $% 60 6^   & 66   �� *RealTimePriceString+6^   
  5_      $$ 	止损价��6)   $% 60 6S   & 66   �� *
StopLoss+6S   
  5`      $$ 	止盈价��6)   $% 60 6U   & 66   �� *
StopProfit+6U   
  5a      $$ 	预付款��6)   $% 60 6�   & 66   �� *FrozenDeposit+# [ 6�   
  5b      $$ 	有效期��6)   $	% 100 6z   & 66   �� *	DueDate+# [ 6z   
  5c      $$ 订单时间��6)   $	% 140 6}   & 67   �� *	OrderTime+# [ 6}   5e      5f      5g      5h      