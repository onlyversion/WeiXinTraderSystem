   M S B A M L   `   `   `  ���� M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  ;    5Gss.ManagementMenu.CustomControl.InquiryCustomControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     >cus.clr-namespace:Gss.ManagementMenu.CustomControl     -   $	��Icc��  � 	Resources   	  Excel �� Text��%   &	        �� $ Excel�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$
 Find��  -   # [  .���  � RowDefinitions �� $
��Auto ��� $
��Auto �.+�� $��2q�   �� 
TargetType �� Property �� Value��%^   '��       �� " ��.���  � ��$ Center=���  � ��$ 2q���  � ��
 �   �.+���  �� Orientation$ 
Horizontal=�y��� *AccountVisibility+	 �� ElementName$		 Icc��.+��� $��客户账号：���� $��2q�$��88������ *AccountName+$		 Icc��
 �� Mode$
 TwoWay=��� $ 
Horizontal=�y��� *OrgNameVisibility+$		 Icc��.+��� $��会员名称：��3   -Gss.ManagementMenu.CustomControl.AutoComboBox  -     Name$	 ACB��$
��AUTO��$	��180��$��24��   DisplayName$ OrgNameAndOrgCode��   SelectedValuePath$ OrgID��   ItemsSource �� *
POrgList+$		 Icc��   SelectedValue �� *	OrgName+$		 Icc��$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $ 
Horizontal=�y��� *IsProductNameVisibility+$		 Icc��.+��� $��商品名称：���� -   $��CbProductName�� �� SelectedIndex$ 0��$��Center=�$��2q�$��88������ *ProductItems+$		 Icc���� $ 
Horizontal=�y��� *IsProductNameVisibility+$		 Icc��.+��� $��行情编码：���� -   $��CbStockCode��$ 0��$��Center=�$��2q�$��88������ *
Stockcodes+$		 Icc���� $ 
Horizontal=�.+��� $��开始时间:��(  "System.Windows.Controls.DatePicker  |�.  $��2q�$��Center=�   SelectedDate �� *	StartDate+$		 Icc���� $ 
Horizontal=�.+��� $��结束时间:��  |�.  $��2q�$��Center=� �� *	EndDate+$		 Icc���� $ 
Horizontal=�y��� *IsOrdersTypeVisibility+$		 Icc��.+��� $��订单类型:���� -   $��CbOrdersType��$��Center=�$��2q�$ 0��$��66��.@��� $��全部���� $��买涨���� $��买跌���� $ 
Horizontal=��� -   $��查询��$��60��$��26��$	��5,2q�$
��Left=�$
��Find���� $y�	Collapsed=�$��Excel��$��60��$��26��$	��5,2q�$
��Left=�#��[  5   /Gss.ManagementMenu.CustomControl.DataPagePicker  5   /Gss.ManagementMenu.CustomControl.DataPagePicker   PageChanged$  DataPagePicker_PageChanged��$��1��$��2q�   CurrentPageItemCount �� *CurrentPageItemCount+$		 Icc��   	PageIndex �� *	PageIndex+$
 TwoWay=�$		 Icc��   	PageCount �� *	PageCount+$		 Icc��   PageSize �� *
PageSize+$
 TwoWay=�$		 Icc��