   M S B A M L   `   `   `  ����M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  5      E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter 5      K*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter  5      @    :Gss.ManagementMenu.AccountManager.Order.MarketOrderHistory   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >cus.clr-namespace:Gss.ManagementMenu.CustomControl     5      HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     5      :cvt*clr-namespace:Gss.ManagementMenu.Converter     5        � 	Resources  5      2  ,Gss.Common.Converter.DateTimeFormatConverter   DateTimeCvt;  5Gss.ManagementMenu.Converter.TransactionTypeConverter  TransactionTypeCvt5  /Gss.ManagementMenu.Converter.TradeTypeConverter  TradeTypeCvt=   7Gss.ManagementMenu.Converter.LossOrProfitColorConverter  LossOrProfitColorConverter��%t   &	        &	      &	 &     &	 9       5   
   6(     5   
   6'     5   
   6!     5   
   6)   5      .��5      ]� .+�5   
   ;   5Gss.ManagementMenu.CustomControl.InquiryCustomControl  ;   5Gss.ManagementMenu.CustomControl.InquiryCustomControl   DoSearch$# InquiryCustomControl_DoSearch��69   $	��Top=�6#      IsUserIDVisbility$ 	Collapsed=�6b      AccountVisibility$ 	Collapsed=�5   #      CurrentPageItemCount 5   #   �� *Items.Count+ �� ElementName$ DgResult��   	PageCount 5   #   �� *	PageCount+ �� RelativeSource ��  �� AncestorType$ UserControlL�	 �� Mode$	 FindAncestor=�
   ProductList
 5   #   �� *ProductInfoes+&   System.Windows.Controls.DataGrid  5   
   -   5        $��DgResult��5   �      AutoGenerateColumns .     CanUserResizeRows .     SelectionMode$ Single=�6I      
IsReadOnly . $��15(�6r      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ 客户账号��6%    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$ 70
 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *TradeAccount+6T     5      $ 历史单号��6%   $ 70
 6Q    63   �� *	HistoryID+6Q     5      $ 商品名称��6%   $ 70
 6T    63   �� *ProductName+6T     5      $ 订单类型��6%   $ 70
 6�    63   �� *	OrderType+ �� 	Converter# [ 6�     5      $ 手数��6%   $ 70
 6Q    61   �� *
TradeCount+6Q     5       $ 	订单价��6%   $ 70
 6R    62   �� *
OrderPrice+6R     5!      $ 	平仓价��6%   $ 70
 6R    62   �� *
TradePrice+6R     5"      $ 	止损价��6%   $ 70
 6P    62   �� *
StopLoss+6P     5#      $ 	止盈价��6%   $ 70
 6R    62   �� *
StopProfit+6R   4  .System.Windows.Controls.DataGridTemplateColumn  5%      $ 盈亏��6*    	  MinWidth$ 60Q�66      CellTemplate 5&      �� 5'      .R�5(      �� $��Center=�6*   .+�5)   "   �� $��Center=�6�   ��6,   �� *LossOrProfit+��6J   �� *LossOrProfit+# [ 6�   5*      5+      5-        5.      $ 	手续费��6%   $ 70
 6X    62   �� *BasicLaborCharge+6X     50      $ 订单单号��6%   $ 70
 6O    63   �� *	OrderID+6O     51      $ 订单时间��6%   $	 150Q�63   $ 70
 6�    6B   �� *	OrderTime+# [  6�     52      $ 平仓时间��6%   $	 150Q�63   $ 70
 6�    6B   �� *	TradeTime+# [  6�     53      $ 平仓方式��6%   $ 70
 6{    63   �� *	TradeType+# [ 6{   55      56      57      