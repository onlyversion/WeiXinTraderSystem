   M S B A M L   `   `   `  ���� E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter  M IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl 6   0Gss.ManagementMenu.TradeManager.WarehousingOrder   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     :cvt*clr-namespace:Gss.ManagementMenu.Converter     >cus.clr-namespace:Gss.ManagementMenu.CustomControl     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit    +� IsFocusScope  .  � 	Resources ; 5Gss.ManagementMenu.Converter.TransactionTypeConverter   TransactionTypeCv2   ,Gss.Common.Converter.DateTimeFormatConverter  
DateTimeCv-   'Gss.Common.Converter.PlusMinusConverter  PlusMinusConverter)  #System.Windows.Controls.DataGridRow �� 
TargetType  DataGridRowBaseStyle �� BasedOn �� Property �� Value��%c   &	        &	      &	 
     '       7        �� "  8   .���  � ��$ 26��.��]� .+�;  5Gss.ManagementMenu.CustomControl.InquiryCustomControl  ;  5Gss.ManagementMenu.CustomControl.InquiryCustomControl   DoSearch$# InquiryCustomControl_DoSearch��$	��Top=�   OrgNameVisibility$ Visible=�   CurrentPageItemCount �� *Items.Count+	 �� ElementName$	 DgResult��
   	PageCount
 �� *	PageCount+ �� RelativeSource ��  �� AncestorType$ UserControlL� �� Mode$ FindAncestor=�   ProductList �� *ProductInfoes+   POrgList �� *
POrgList+%  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy �� *IsLoadingWarehousingHistory+   BusyContent �� $��加载中...��$��20(�$
��Bold"�$��Center=�$��Center=�.��&   System.Windows.Controls.DataGrid  -   $��DgResult��$��1��   AutoGenerateColumns .     CanUserResizeRows .     SelectionMode$ Single=�   
IsReadOnly . $��2������    Columns 4	  .System.Windows.Controls.DataGridTemplateColumn	  ,
  &System.Windows.Controls.DataGridColumn 
  Width5  /System.Windows.Controls.DataGridLengthConverter$ 70  
  Header$ 会员编码�� 	  CellTemplate �� .R��� $��0q�
������  �� 
IsReadOnly . ��Z� ���� *	Telephone+	  $ 70 $ 会员名称�� �� .R��� $��0q�
������  . ��Z� ���� *	OrgName+	  $ 60 $ 账号�� �� .R��� $��0q�
������  . ��Z� ���� *AccountName+	  $ 60 $ 姓名�� �� .R��� $��0q�
������  . ��Z� ���� *
UserName+	  $ 70 $ 入库单号�� �� .R��� $��0q�
������  . ��Z� ���� *	HistoryID+	  $ 70 $ 订单单号�� �� .R��� $��0q�
������  . ��Z� ���� *	OrderID+	  $ 70 $ 商品名称�� �� .R��� $��0q�
������  . ��Z� ���� *ProductName+0  *System.Windows.Controls.DataGridTextColumn  $ 70 $ 手数��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
TradeCount+  $ 70 $ 订单类型�� �� *	OrderType+ �� 	Converter# [    $ 70 $ 	订单价�� �� *
OrderPrice+  $ 70 $ 	入库价�� �� *
TradePrice+  $ 70 $ 货款�� �� *	Payment+  $ 70 $ 	手续费�� �� *BasicLaborCharge+# [   $	 140 $ 订单时间�� �� *	OrderTime+# [   $	 140 $ 入库时间�� �� *	TradeTime+# [ 