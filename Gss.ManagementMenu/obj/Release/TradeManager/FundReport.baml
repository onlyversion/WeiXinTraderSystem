   M S B A M L   `   `   `  ���� E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter  M IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 0   *Gss.ManagementMenu.TradeManager.FundReport   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     :cvt*clr-namespace:Gss.ManagementMenu.Converter     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  8cus.clr-namespace:Gss.ManagementMenu.CustomControl  3system&clr-namespace:System;assembly=mscorlib    +� IsFocusScope  .  � 	Resources    BoolVisibilityCvt  HistoryOrder �� Text  	CmPayMent m� Command �� 	Converter m� CommandTarget �� Path �� RelativeSource �� AncestorType)  #System.Windows.Controls.DataGridRow	 �� 
TargetType  DataGridRowBaseStyle
 �� BasedOn �� Property �� Value��%(  &	        &	      &	      7  7   '  �     7  7  �� �� $ 订单信息���� -   .@�m� 8   y��� *+)AccountAuthority.AllowFundReportOrderInfo+8   �� $ PlacementTarget� �� $ ContextMenuL��� "	  8
   .���  � ��$ 26����  �@�ContextMenu8   J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [ .���� $��0��$��1q����	#FFD1CFCF �� CornerRadius$ 5��._��  � RowDefinitions �� $
��auto ��� $��0 ��� $��2 ��� $��40 ��� $��* ��� $
��auto �.+��  � Orientation$ 
Horizontal=�$��5q�.+��� $��客户账号：��$��2q��� $��80��$��2q����� *#!FundReportSelectCondition.Account+�� $��会员名称：��$��2q�3  -Gss.ManagementMenu.CustomControl.AutoComboBox  -     Name$ 
ACB_Search��$
��AUTO��$	��180��$��24��   DisplayName$ OrgNameAndOrgCode��   SelectedValuePath$ OrgID��   ItemsSource �� *
POrgList+   SelectedValue �� *#!FundReportSelectCondition.OrgName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��	状态：��$��2q��� -   $��cmbState�� �� SelectedIndex$ 0��$��Center=�$��2q�$��88�� �� SelectedValue �� *!FundReportSelectCondition.State+.@���
全部����
入金����
出金����
调节����经纪人提成����
赠金���� $��	时间：��$��2q�(  "System.Windows.Controls.DatePicker  $��2q�|�.  $	��130��$
��Auto��   SelectedDate �� *%#FundReportSelectCondition.StartTime+�� $	��至��$��2q�  $��2q�|�.  $	��130��$
��Auto�� �� *#!FundReportSelectCondition.EndTime+�� -   $��查询��$��60��$��26��$	��5,2q����� *GetFundReportCommand+�� $��2��$��1q����	#FFD1CFCF5  /Gss.ManagementMenu.CustomControl.DataPagePicker  5  /Gss.ManagementMenu.CustomControl.DataPagePicker   PageChanged$ dataPage_PageChanged��$��5,2,2,2q�$��3��   CurrentPageItemCount �� *Items.Count+ �� ElementName$ dataGrid��   	PageCount �� *%#FundReportSelectCondition.PageCount+$ TwoWay=�    PageSize  �� *$"FundReportSelectCondition.PageSize+$ TwoWay=�!   	PageIndex! �� *%#FundReportSelectCondition.PageIndex+$ TwoWay=�&   System.Windows.Controls.DataGrid  -   $��dataGrid��$��4��$	��5,0q����	#FFD1CFCF"   CanUserResizeRows" .  #   SelectionMode$# Single=�$   
IsReadOnly$ . %   AutoGenerateColumns% .  ���� *FundChangeInfo.TOderLst+&   Columns& 4  .System.Windows.Controls.DataGridTemplateColumn  ,	  &System.Windows.Controls.DataGridColumn' 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$' 70
 ( 	  Header$( 会员编码��)   CellTemplate) �� .R��� $��0q�
������ * �� 
IsReadOnly* . ��Z� ���� *	Telephone+  $' 70
 $( 所属会员��) �� .R��� $��0q�
������ * . ��Z� ���� *	OrgName+  $' 70
 $( 用户账号��) �� .R��� $��0q�
������ * . ��Z� ���� *	Account+  $' 70
 $( 客户名称��) �� .R��� $��0q�
������ * . ��Z� ���� *
UserName+0  *System.Windows.Controls.DataGridTextColumn  $( 金额��$' 70
 1  +System.Windows.Controls.DataGridBoundColumn+   Binding+ �� *Amt+  $( 类型��$' 70
 + �� *ReasonString+  $( 时间��$	' 140
 + �� *OpTime+, �� StringFormat$, yyyy-MM-dd HH:mm:ss���� $��Bottom=�$��5��- �� Orientation$- 
Horizontal=�.+��� .��	入金:�� $��Center=�$��0,0,20,0q����� *FundChangeInfo.AMT+�� .��	出金:�� $��Center=�$��0,0,20,0q����� *FundChangeInfo.AMT2+�� .��经济人提成:�� $��Center=�$��0,0,20,0q����� *FundChangeInfo.AMT5+�� .��	赠金:�� $��Center=�$��0,0,20,0q����� *FundChangeInfo.AMT6+