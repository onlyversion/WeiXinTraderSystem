   M S B A M L   `   `   `  ����M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  5      ;    5Gss.ManagementMenu.CustomControl.InquiryCustomControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >cus.clr-namespace:Gss.ManagementMenu.CustomControl     5      -   5        $	��Icc��5        � 	Resources  5       	  Excel �� Text��%)   &	        �� 5   
   $ Excel��6(   5       J� CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$
 Find��5
      6P     5   
   -   5        # [  5      6c   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��2q�6     5       �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��$ Center=�6:   �� 5       � ��$ 2q�6/   �� 5       � ��
 �   �63   5      5      .+�5      ��  �� Orientation$ 
Horizontal=�6   y�62   �� *AccountVisibility+	 �� ElementName$		 Icc��.+�5      �� $��客户账号：��6   �� 5      $��2q�6   $��88��6%   ��5      �� *AccountName+$		 Icc��
 �� Mode$
 TwoWay=�5      �� 5      $ 
Horizontal=�6   y�62   �� *OrgNameVisibility+$		 Icc��.+�5       �� $��会员名称：��6   3   -Gss.ManagementMenu.CustomControl.AutoComboBox  5&      -   5          Name$	 ACB��5&   #   $
��AUTO��60   $	��180��6=   $��24��6L      DisplayName$ OrgNameAndOrgCode��6�      SelectedValuePath$ OrgID��6�      ItemsSource 6X   �� *
POrgList+$		 Icc��   SelectedValue 5'      �� *	OrgName+$		 Icc��$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5*      �� 5,      $ 
Horizontal=�6   y�62   �� *IsProductNameVisibility+$		 Icc��.+�5-      �� $��商品名称：��6   �� 5.      -   5        $��CbProductName��5.       �� SelectedIndex$ 0��60   $��Center=�6B   $��2q�6]   $��88��6h   ��5/      �� *ProductItems+$		 Icc��50      �� 52      $ 
Horizontal=�6   y�62   �� *IsProductNameVisibility+$		 Icc��.+�53      �� $��行情编码：��6   �� 54      -   5        $��CbStockCode��54      $ 0��6.   $��Center=�6@   $��2q�6[   $��88��6f   ��55      �� *
Stockcodes+$		 Icc��56      �� 59      $ 
Horizontal=�6   .+�5:      �� $��开始时间:��6   (  "System.Windows.Controls.DatePicker  5;      |�.  $��2q�60   $��Center=�6;      SelectedDate 5<      �� *	StartDate+$		 Icc��5=      �� 5>      $ 
Horizontal=�6   .+�5?      �� $��结束时间:��6     5@      |�.  $��2q�60   $��Center=�6;    5A      �� *	EndDate+$		 Icc��5B      �� 5C      $ 
Horizontal=�6   y�62   �� *IsOrdersTypeVisibility+$		 Icc��.+�5D      �� $��订单类型:��6   �� 5E      -   5        $��CbOrdersType��5E      $��Center=�6/   $��2q�6J   $ 0��6U   $��66��6g   .@�5F      �� $��全部��6#   �� 5G      $��买涨��6#   �� 5H      $��买跌��6#   5I      5J      �� 5K      $ 
Horizontal=�6   5M      �� 5N      -   5        $��查询��5N      $��60��6#   $��26��6.   $	��5,2q�6:   $
��Left=�6G   $
��Find��6c   6r   �� 5O      $y�	Collapsed=�6   $��Excel��6-   $��60��6=   $��26��6H   $	��5,2q�6T   $
��Left=�6a   #��[  6}   5P      5   /Gss.ManagementMenu.CustomControl.DataPagePicker  5Q   
   5   /Gss.ManagementMenu.CustomControl.DataPagePicker   PageChanged$  DataPagePicker_PageChanged��5V      $��1��5Q      $��2q�6*      CurrentPageItemCount 5R      �� *CurrentPageItemCount+$		 Icc��   	PageIndex 5S      �� *	PageIndex+$
 TwoWay=�$		 Icc��   	PageCount 5T      �� *	PageCount+$		 Icc��   PageSize 5U      �� *
PageSize+$
 TwoWay=�$		 Icc��5V      5W      5X      