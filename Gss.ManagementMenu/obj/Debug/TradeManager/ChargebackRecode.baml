   M S B A M L   `   `   `  ����E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter  5      M IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter 5      S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl 5      6   0Gss.ManagementMenu.TradeManager.ChargebackRecode   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     5      :cvt*clr-namespace:Gss.ManagementMenu.Converter     5      >cus.clr-namespace:Gss.ManagementMenu.CustomControl     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  5        +� IsFocusScope  .  � 	Resources 5	         BoolVisibilityCvt; 5Gss.ManagementMenu.Converter.TransactionTypeConverter  TransactionTypeCv2   ,Gss.Common.Converter.DateTimeFormatConverter  
DateTimeCv: 4Gss.ManagementMenu.Converter.ChargebackTypeConverter  ChargebackTypeConverter=  7Gss.ManagementMenu.Converter.LossOrProfitColorConverter  LossOrProfitColorConverter-   'Gss.Common.Converter.PlusMinusConverter  PlusMinusConverter  HistoryOrder �� Text  	CmPayMent m� Command �� 	Converter m� CommandTarget �� Path �� RelativeSource �� AncestorType)  #System.Windows.Controls.DataGridRow	 �� 
TargetType  DataGridRowBaseStyle
 �� BasedOn �� Property �� Value��%E  &	        &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     7  7   '  b    7  7  �� 5
   
   6'     5   
   6'     5   
   6(     5   
   6&     5   
   6)     5   
   6#   �� 5   
   $ 订单信息��6/   �� 5   
   -   5        .@�5      m� 8   y�6   �� *53AccountAuthority.AllowViewChargebackRecordOrderInfo+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   "	  6   8
   .�5      ��  �@�ContextMenu8  6,   �� 5       � ��$ 26��6*   5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [ 5      6q   .��5!      ]� .+�5"   
   ;  5Gss.ManagementMenu.CustomControl.InquiryCustomControl  ;	  5Gss.ManagementMenu.CustomControl.InquiryCustomControl 	  DoSearch$# InquiryCustomControl_DoSearch��6T   $	��Top=�6#      OrgNameVisibility$ Visible=�68      CurrentPageItemCount 5#   #   �� *Items.Count+ �� ElementName$ DgResult��   	PageCount 5$   #   �� *	PageCount+ �� $ UserControlL� �� Mode$ FindAncestor=�   ProductList 5%   #   �� *ProductInfoes+   POrgList 6I   �� *
POrgList+�� 5'   
   $��Bottom=�6    �� Orientation$ 
Horizontal=�6-   .+�5(      �� .��6   	数量:6   �� 5)      $��Center=�6B   $��0,0,20,0q�6]   ��6   �� *LTradeOrderInfo.Quantity+6]   �� 5+      .��6   	盈亏：6   �� 5,      $��Center=�6F   $��0,0,20,0q�6a   ��6   �� *LTradeOrderInfo.ProfitValue+6a   �� 5.      .��6   手续费：6   �� 5/      $��Center=�6q   $��0,0,20,0q�6�   ��6   �� *LTradeOrderInfo.Tradefee+# [ 6�   53      %
  Xceed.Wpf.Toolkit.BusyIndicator
  54   
    
  IsBusy 6   �� *IsLoadingChargebackRecode+ 
  BusyContent 55      �� 56      $��加载中...��6   $��20(�6*   $
��Bold"�68   $��Center=�6J   $��Center=�6e   .��58      &   System.Windows.Controls.DataGrid  -   5        $��DgResult��58      $��1��6'      AutoGenerateColumns .     CanUserResizeRows .     SelectionMode$ Single=�6j      
IsReadOnly . $��2��6�   ��59      �� *LTradeOrderInfo.TOrderLst+   Columns 5:      4  .System.Windows.Controls.DataGridTemplateColumn  5<      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6-       Header$  会员编码��68   !   CellTemplate! 5=      �� 5>      .R�5?   "   �� $��0q�6;   
������ " �� 
IsReadOnly" . ��6*   Z� ��5@   <   �� *	Telephone+5A      5C        5E      $ 70 6-   $  所属会员��68   ! 5F      �� 5G      .R�5H   "   �� $��0q�6;   
������ " . ��6*   Z� ��5I   <   �� *	OrgName+5J      5L        5N      $ 70 6-   $  客户账号��68   ! 5O      �� 5P      .R�5Q   "   �� $��0q�6;   
������ " . ��6*   Z� ��5R   <   �� *TradeAccount+5S      5U        5W      $ 70 6-   $  客户名称��68   ! 5X      �� 5Y      .R�5Z   "   �� $��0q�6;   
������ " . ��6*   Z� ��5[   <   �� *
UserName+5\      5^        5`      $ 70 6-   $  历史单号��68   ! 5a      �� 5b      .R�5c   "   �� $��0q�6;   
������ " . ��6*   Z� ��5d   <   �� *	HistoryID+5e      5g        5i      $ 70 6-   $  商品名称��68   ! 5j      �� 5k      .R�5l   "   �� $��0q�6;   
������ " . ��6*   Z� ��5m   <   �� *ProductName+5n      5p      0  *System.Windows.Controls.DataGridTextColumn  5q      $ 70 6*   $  订单类型��65   1  +System.Windows.Controls.DataGridBoundColumn#   Binding# 6C   �� *	OrderType+# [   5r      $ 50 6)   $  手数��64   # 6@   �� *
TradeCount+  5s      $ 60 6)   $  	订单价��64   # 6A   �� *
OrderPrice+  5t      $ 60 6)   $  	平仓价��64   # 6A   �� *
TradePrice+  5u      $ 60 6)   $  	止损价��64   # 6A   �� *
StopLoss+  5v      $ 60 6)   $  	止盈价��64   # 6A   �� *
StopProfit+  5y      $ 60 6)   $  盈亏��64   $   MinWidth$$ 88Q�6@   # 6N   �� *LossOrProfit+%   	CellStyle% 5z      �� 5{      *  $System.Windows.Controls.DataGridCell"	  6$    	 DataGridCellBaseStyle#
 [	 6G   .�5|   "   ��  � �� 5}   &   �� 5~   *   .R�5   .   �� $��Center=�68   ��6S   �� *LossOrProfit+��6q   �� *LossOrProfit+# [ 5�   +   5�   #   5�      5�        5�      $ 70 6)   $  	手续费��64   # 6A   �� *BasicLaborCharge+# [   5�      $ 70 6)   $  订单单号��64   # 6B   �� *	OrderID+  5�      $	 140 6)   $  订单时间��65   $	$ 150Q�6C   # 6R   �� *	OrderTime+# [   5�      $	 140 6)   $  平仓时间��65   $	$ 150Q�6C   # 6R   �� *	TradeTime+# [   5�      $ 70 6)   $  平仓方式��64   # 5�      `� 5�      & `� 	Converter#& [ 6+   .1�5�   "   �� $ 	TradeType�6*   �� 5�   "   $ 
TradePrice�6*   �� 5�   "   $ StopLoss�6*   �� 5�   "   $ 
StopProfit�6*   5�      5�      5�      5�      5�      5�      