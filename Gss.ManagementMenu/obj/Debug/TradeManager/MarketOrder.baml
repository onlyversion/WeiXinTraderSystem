   M S B A M L   `   `   `  ����E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter  5      M IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter 5      S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl 5      1   +Gss.ManagementMenu.TradeManager.MarketOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     5      :cvt*clr-namespace:Gss.ManagementMenu.Converter     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  5      8cus.clr-namespace:Gss.ManagementMenu.CustomControl  5        +� IsFocusScope  .  � 	Resources 5	         
Chargeback �� Text  Warehousing  
AllowStore  RecordRealWeight  HistoryOrder;  5Gss.ManagementMenu.Converter.RiskCoefficientConverter  RiskCoefficientConverter2   ,Gss.Common.Converter.DateTimeFormatConverter  DateTimeCvt; 5Gss.ManagementMenu.Converter.TransactionTypeConverter  TransactionTypeCvt-   'Gss.Common.Converter.PlusMinusConverter  PlusMinusConverter 	 BoolVisibilityCvt 
 CmMarketOrder m� Command �� 	Converter m� CommandTarget �� Path �� RelativeSource �� AncestorType)  #System.Windows.Controls.DataGridRow	 �� 
TargetType  DataGridRowBaseStyle
 �� BasedOn �� Property �� Value��%}  &	        &	       &	 @     &	 f     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
     7   7 	 7  7 	 '  t    7  7 
 �� 5
   
   $ 平仓��6-   �� 5   
   $ 入库��6.   �� 5   
   $ 入库设置��6-   �� 5   
   $ 买跌检测��63   �� 5   
   $ 订单信息��6/     5   
   6'     5   
   6(     5   
   6'     5   
   6#   �� 5   
   6'   �� 5   
   -   5        .@�5      m� 8   y�6   �� *1/AccountAuthority.AllowViewMarketOrderChargeback+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8  y�6   �� *0.AccountAuthority.AllowViewMarketOrderOrderInfo+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   "	  6   8
   .�5      ��  � ��$ 26��6*   �� 5       �@�ContextMenu8  6,   5      5        J� CommandBindings 5"      )  #System.Windows.Input.CommandBinding  5#   
   -   5           Command# [  5#      6m     5$   
   -   5        # [ 5$      6o     5%   
   -   5        # [ 5%      6m     5&   
   -   5        # [ 5&      6y     5'   
   -   5        # [ 5'      6q   .��5*      ]� .+�5+   
   ;  5Gss.ManagementMenu.CustomControl.InquiryCustomControl  ;  5Gss.ManagementMenu.CustomControl.InquiryCustomControl   DoSearch$# InquiryCustomControl_DoSearch��6T      DoExcel$" InquiryCustomControl_DoExcel��5,   f   $	��Top=�5+   #      OrgNameVisibility$ Visible=�68      IsProductNameVisibility$ Visible=�6}      CurrentPageItemCount 5,   #   �� *Items.Count+ �� ElementName$ DgResult��   	PageCount 5-   #   �� *	PageCount+ �� $ UserControlL� �� Mode$ FindAncestor=�   ProductList 5.   #   �� *ProductInfoes+   POrgList 6J   �� *
POrgList+�� 50   
   $��Bottom=�6    �� Orientation$ 
Horizontal=�6-   .+�51      �� .��6   	数量:6   �� 52      $��Center=�6A   $��0,0,20,0q�6\   ��6   �� *TradeOrderInfo.Quantity+6\   �� 54      .��6   保证金：6   �� 55      $��Center=�6p   $��0,0,20,0q�6�   ��6   �� *TradeOrderInfo.OccMoney+# [ 6�   �� 57      .��6   手续费：6   �� 58      $��Center=�6p   $��0,0,20,0q�6�   ��6   �� *TradeOrderInfo.Tradefee+# [ 6�   �� 5<      .��6   	盈亏：6   �� 5=      $��0,0,20,0q�6   $��Center=�6l   ��6*   �� *" TradeOrderInfo.TotalLossOrProfit+ �� StringFormat$ F2��6l   5>      %	  Xceed.Wpf.Toolkit.BusyIndicator	  5@   
    	  IsBusy 6   �� *IsLoadingMarketOrderList+ 	  BusyContent 5A      �� 5B      $��加载中...��6   $��20(�6*   $
��Bold"�68   $��Center=�6J   $��Center=�6e   .��5D      &
   System.Windows.Controls.DataGrid
  -   5        $��DgResult��5D   v    
  AutoGenerateColumns .   
  SelectionMode$ Single=�63    
  
IsReadOnly .   
  CanUserResizeRows  .  ��5E      �� *TradeOrderInfo.TdOrderList+! 
  Columns! 5F      4  .System.Windows.Controls.DataGridTemplateColumn  5K      ,  &System.Windows.Controls.DataGridColumn"   Width5  /System.Windows.Controls.DataGridLengthConverter$" 70 6-   #   Header$# 会员编码��68   $   CellTemplate$ 5L      �� 5M      .R�5N   "   �� $��0q�6;   
������ % �� 
IsReadOnly% . ��6*   Z� ��5O   *   �� *	Telephone+5P      5R        5W      $" 70 6-   $# 会员名称��68   $ 5X      �� 5Y      .R�5Z   "   �� $��0q�6;   
������ % . ��6*   Z� ��5[   <   �� *	OrgName+5\      5^        5`      $" 70 6-   $# 账号��68   $ 5a      �� 5b      .R�5c   "   �� $��0q�6;   
������ % . ��6*   Z� ��5d   <   �� *TradeAccount+5e      5g        5h      $" 70 6-   $# 姓名��68   $ 5i      �� 5j      .R�5k   "   �� $��0q�6;   
������ % . ��6*   Z� ��5l   <   �� *
UserName+5m      5o      0  *System.Windows.Controls.DataGridTextColumn  5s      $" 70 6)   $# 订单��64   1  +System.Windows.Controls.DataGridBoundColumn&   Binding& 6@   �� *	OrderID+  5t      $" 70 6)   $# 商品��64   & 6@   �� *ProductName+  5u      $# 类型��6)   '   MinWidth$' 60Q�6�   & 65   �� *	OrderType+# [ 6�     5v      $# 手数��6)   $" 60 6W   & 65   �� *OrderQuantity+6W     5w      $# 	成交价��6)   $" 60 6U   & 66   �� *
OrderPrice+6U     5y      $# 	即时价��6-   $" 60 6:   (   
IsReadOnly( . $ 5z      �� 5{      .R�5|   "   �� -   5        % . 
������ $��0q�5|   g   $��0q�6s   $��0q�5}   }   ��5|   *   Z� ��5}   L   �� *RealTimePriceString+) �� Mode$) OneWay=�.��6�   5   #   5�      5�        5�      $# 盈亏��6)   $" 60 65   & 6@   �� *LossOrProfit+*   	CellStyle* 5�      �� 5�      *  $System.Windows.Controls.DataGridCell"	  6$     DataGridCellBaseStyle#
 [ 6G   + �� Triggers+ 5�   "   �� 5�   &   , �� Binding, 62   �� $ 
IsEarnings�- �� Value- True6V   .a�5�   *   ��  � ��
 �  ��6G   5�   '   �� 5�   &   , 62   �� $ 
IsEarnings�	- False6V   .a�5�   *   ��  � ��
 � � �6G   5�   '   5�      5�        5�      $# 风险系数%��6)   $" 88 68   & 6C   �� *RiskCoefficient+* 5�      �� 5�      "	  6$   #
 [ 6G   .�5�   "   ��  � �� 5�   &   �� 5�   *   .R�5�   .   �� $��Center=�68   ��6S   �� *RiskCoefficient+��5�   8   �� *RiskCoefficient+# [ 5�   +   5�   #   5�      5�        5�      $# 	止损价��6)   $" 60 6S   & 66   �� *
StopLoss+6S     5�      $# 	止盈价��6)   $" 60 6U   & 66   �� *
StopProfit+6U     5�      $# 	保证金��6)   $" 60 6�   & 66   �� *OccupiedDeposit+# [ 6�     5�      $# 	手续费��6)   $" 66 66   & 6A   �� *
TradeFee+# [   5�      $# 订单时间��6-   $	" 140 6<   $ 5�      �� 5�      .R�5�   "   �� $��0q�6;   
������ % . ��6*   Z� ��5�   *   �� *	OrderTime+# [ 5�      5�      5�      5�      5�      5�      