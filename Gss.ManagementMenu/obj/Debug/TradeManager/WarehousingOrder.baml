   M S B A M L   `   `   `  ����E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter  5      M IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter 5      S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl 5      6   0Gss.ManagementMenu.TradeManager.WarehousingOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     5      :cvt*clr-namespace:Gss.ManagementMenu.Converter     5      >cus.clr-namespace:Gss.ManagementMenu.CustomControl     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  5        +� IsFocusScope  .  � 	Resources 5	      ; 5Gss.ManagementMenu.Converter.TransactionTypeConverter   TransactionTypeCv2   ,Gss.Common.Converter.DateTimeFormatConverter  
DateTimeCv-   'Gss.Common.Converter.PlusMinusConverter  PlusMinusConverter)  #System.Windows.Controls.DataGridRow �� 
TargetType  DataGridRowBaseStyle �� BasedOn �� Property �� Value��%�   &	        &	      &	 &     '  9     7    5
   
   6'     5   
   6(     5   
   6#   �� 5   
   "  6   8   .�5      ��  � ��$ 26��6*   5      5      .��5      ]� .+�5   
   ;  5Gss.ManagementMenu.CustomControl.InquiryCustomControl  ;  5Gss.ManagementMenu.CustomControl.InquiryCustomControl   DoSearch$# InquiryCustomControl_DoSearch��6T   $	��Top=�6#      OrgNameVisibility$ Visible=�68      CurrentPageItemCount 5   #   �� *Items.Count+	 �� ElementName$	 DgResult��
   	PageCount
 5   #   �� *	PageCount+ �� RelativeSource ��  �� AncestorType$ UserControlL� �� Mode$ FindAncestor=�   ProductList 5   #   �� *ProductInfoes+   POrgList 6I   �� *
POrgList+%  Xceed.Wpf.Toolkit.BusyIndicator  5   
      IsBusy 6   �� *IsLoadingWarehousingHistory+   BusyContent 5      �� 5      $��加载中...��6   $��20(�6*   $
��Bold"�68   $��Center=�6J   $��Center=�6e   .��5      &   System.Windows.Controls.DataGrid  -   5        $��DgResult��5      $��1��6'      AutoGenerateColumns .     CanUserResizeRows .     SelectionMode$ Single=�6j      
IsReadOnly . $��2��6�   ��5      ��    Columns 5      4	  .System.Windows.Controls.DataGridTemplateColumn	  5"      ,
  &System.Windows.Controls.DataGridColumn 
  Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6-    
  Header$ 会员编码��68    	  CellTemplate 5#      �� 5$      .R�5%   "   �� $��0q�6;   
������  �� 
IsReadOnly . ��6*   Z� ��5&   <   �� *	Telephone+5'      5)      	  5+      $ 70 6-   $ 会员名称��68    5,      �� 5-      .R�5.   "   �� $��0q�6;   
������  . ��6*   Z� ��5/   <   �� *	OrgName+50      52      	  54      $ 60 6-   $ 账号��68    55      �� 56      .R�57   "   �� $��0q�6;   
������  . ��6*   Z� ��58   <   �� *AccountName+59      5;      	  5=      $ 60 6-   $ 姓名��68    5>      �� 5?      .R�5@   "   �� $��0q�6;   
������  . ��6*   Z� ��5A   <   �� *
UserName+5B      5D      	  5G      $ 70 6-   $ 入库单号��68    5H      �� 5I      .R�5J   "   �� $��0q�6;   
������  . ��6*   Z� ��5K   <   �� *	HistoryID+5L      5N      	  5P      $ 70 6-   $ 订单单号��68    5Q      �� 5R      .R�5S   "   �� $��0q�6;   
������  . ��6*   Z� ��5T   <   �� *	OrderID+5U      5W      	  5Y      $ 70 6-   $ 商品名称��68    5Z      �� 5[      .R�5\   "   �� $��0q�6;   
������  . ��6*   Z� ��5]   <   �� *ProductName+5^      5`      0  *System.Windows.Controls.DataGridTextColumn  5a      $ 70 6)   $ 手数��64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *
TradeCount+  5b      $ 70 6)   $ 订单类型��64    6B   �� *	OrderType+ �� 	Converter# [    5c      $ 70 6)   $ 	订单价��64    6A   �� *
OrderPrice+  5d      $ 70 6)   $ 	入库价��64    6A   �� *
TradePrice+  5f      $ 70 6)   $ 货款��64    6@   �� *	Payment+  5h      $ 70 6)   $ 	手续费��64    6A   �� *BasicLaborCharge+# [   5i      $	 140 6)   $ 订单时间��65    6C   �� *	OrderTime+# [   5j      $	 140 6)   $ 入库时间��65    6C   �� *	TradeTime+# [ 5l      5m      5n      5o      