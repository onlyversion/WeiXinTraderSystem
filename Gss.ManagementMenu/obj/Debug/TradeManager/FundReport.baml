   M S B A M L   `   `   `  ����E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter  5      M IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter 5      S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      0   *Gss.ManagementMenu.TradeManager.FundReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     5      :cvt*clr-namespace:Gss.ManagementMenu.Converter     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  5      8cus.clr-namespace:Gss.ManagementMenu.CustomControl  5      3system&clr-namespace:System;assembly=mscorlib  5        +� IsFocusScope  .  � 	Resources 5         BoolVisibilityCvt  HistoryOrder �� Text  	CmPayMent m� Command �� 	Converter m� CommandTarget �� Path �� RelativeSource �� AncestorType)  #System.Windows.Controls.DataGridRow	 �� 
TargetType  DataGridRowBaseStyle
 �� BasedOn �� Property �� Value��%�  &	        &	      &	 9     7  7   '  �     7  7  �� 5   
   6'   �� 5   
   $ 订单信息��6/   �� 5   
   -   5        .@�5      m� 8   y�6   �� *+)AccountAuthority.AllowFundReportOrderInfo+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   "	  6   8
   .�5      ��  � ��$ 26��6*   �� 5       �@�ContextMenu8  6,   5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [ 5      6q   .��5      �� $��0��6   $��1q�6   ���	#FFD1CFCF �� CornerRadius$ 5��6F   ._�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5       $��0 �6    �� 5!      $��2 �6    �� 5"      $��40 �6    �� 5$      $��* �6    �� 5%      $
��auto �6    .+�5'      �  � Orientation$ 
Horizontal=�6   $��5q�61   .+�5(      �� $��客户账号：��6   $��2q�6)   �� 5)      $��80��6   $��2q�6(   ��63   �� *#!FundReportSelectCondition.Account+�� 5+      $��会员名称：��6   $��2q�6)   3  -Gss.ManagementMenu.CustomControl.AutoComboBox  51      -   5          Name$ 
ACB_Search��51   #   $
��AUTO��67   $	��180��6D   $��24��6S      DisplayName$ OrgNameAndOrgCode��6�      SelectedValuePath$ OrgID��6�      ItemsSource 6`   �� *
POrgList+   SelectedValue 52      �� *#!FundReportSelectCondition.OrgName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 55      $��	状态：��6   $��2q�6'   �� 56      -   5        $��cmbState��56       �� SelectedIndex$ 0��6+   $��Center=�6=   $��2q�6X   $��88��6c    �� SelectedValue 6r   �� *!FundReportSelectCondition.State+.@�57      ��
全部��6(   ��58      
入金��6(   ��59      
出金��6(   ��5:      
调节��6(   ��5;      经纪人提成��6+   ��5<      
赠金��6(   5=      �� 5>      $��	时间：��6   $��2q�6&   (  "System.Windows.Controls.DatePicker  5?      $��2q�6   |�.  $	��130��6w   $
��Auto��6�      SelectedDate 6:   �� *%#FundReportSelectCondition.StartTime+6�   �� 5@      $	��至��6   $��2q�6$     5A      $��2q�6   |�.  $	��130��6u   $
��Auto��6�    6:   �� *#!FundReportSelectCondition.EndTime+6�   �� 5B      -   5        $��查询��5B      $��60��6&   $��26��61   $	��5,2q�6=   ��6J   �� *GetFundReportCommand+6s   5D      �� 5E      $��2��6   $��1q�6"   ���	#FFD1CFCF66   5  /Gss.ManagementMenu.CustomControl.DataPagePicker  5F      5  /Gss.ManagementMenu.CustomControl.DataPagePicker   PageChanged$ dataPage_PageChanged��6!   $��5,2,2,2q�6D   $��3��6U      CurrentPageItemCount 6b   �� *Items.Count+ �� ElementName$ dataGrid��   	PageCount 5G       �� *%#FundReportSelectCondition.PageCount+$ TwoWay=�    PageSize  6f   �� *$"FundReportSelectCondition.PageSize+$ TwoWay=�!   	PageIndex! 5H       �� *%#FundReportSelectCondition.PageIndex+$ TwoWay=�&   System.Windows.Controls.DataGrid  5J      -   5        $��dataGrid��5J      $��4��6'   $	��5,0q�64   ���	#FFD1CFCF"   CanUserResizeRows" .  #   SelectionMode$# Single=�5K   5   $   
IsReadOnly$ . %   AutoGenerateColumns% .  ��5J   Y   �� *FundChangeInfo.TOderLst+&   Columns& 5L      4  .System.Windows.Controls.DataGridTemplateColumn  5N      ,	  &System.Windows.Controls.DataGridColumn' 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$' 70
 6-   ( 	  Header$( 会员编码��68   )   CellTemplate) 5O      �� 5P      .R�5Q   "   �� $��0q�6;   
������ * �� 
IsReadOnly* . ��6*   Z� ��5R   <   �� *	Telephone+5S      5U        5W      $' 70
 6-   $( 所属会员��68   ) 5X      �� 5Y      .R�5Z   "   �� $��0q�6;   
������ * . ��6*   Z� ��5[   <   �� *	OrgName+5\      5^        5`      $' 70
 6-   $( 用户账号��68   ) 5a      �� 5b      .R�5c   "   �� $��0q�6;   
������ * . ��6*   Z� ��5d   <   �� *	Account+5e      5g        5i      $' 70
 6-   $( 客户名称��68   ) 5j      �� 5k      .R�5l   "   �� $��0q�6;   
������ * . ��6*   Z� ��5m   <   �� *
UserName+5n      5p      0  *System.Windows.Controls.DataGridTextColumn  5s      $( 金额��6)   $' 70
 6M   1  +System.Windows.Controls.DataGridBoundColumn+   Binding+ 65   �� *Amt+6M     5t      $( 类型��6)   $' 70
 6V   + 65   �� *ReasonString+6V     5u      $( 时间��6)   $	' 140
 6s   + 65   �� *OpTime+, �� StringFormat$, yyyy-MM-dd HH:mm:ss��6s   5x      �� 5y      $��Bottom=�6   $��5��61   - �� Orientation$- 
Horizontal=�6?   .+�5z      �� .��6   	入金:6   �� 5{      $��Center=�6@   $��0,0,20,0q�6[   ��6   �� *FundChangeInfo.AMT+6[   �� 5|      .��6   	出金:6   �� 5}      $��Center=�6A   $��0,0,20,0q�6\   ��6   �� *FundChangeInfo.AMT2+6\   �� 5�      .��6   经济人提成:6    �� 5�      $��Center=�6A   $��0,0,20,0q�6\   ��6   �� *FundChangeInfo.AMT5+6\   �� 5�      .��6   	赠金:6   �� 5�      $��Center=�6A   $��0,0,20,0q�6\   ��6   �� *FundChangeInfo.AMT6+6\   5�      5�      5�      5�      