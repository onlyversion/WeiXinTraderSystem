   M S B A M L   `   `   `  ���� E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter  M IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 4   .Gss.ManagementMenu.TradeManager.PaymentManager   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     :cvt*clr-namespace:Gss.ManagementMenu.Converter     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  8cus.clr-namespace:Gss.ManagementMenu.CustomControl  3system&clr-namespace:System;assembly=mscorlib    +� IsFocusScope  .  � 	Resources    BoolVisibilityCvt? 9Gss.ManagementMenu.Converter.VisibilityToBooleanConverter  VisibilityBoolCvt  PaymentDetailsCmd �� Text  HistoryOrder  	CmPayMent m� Command �� 	Converter)  #System.Windows.Controls.DataGridRow �� 
TargetType  DataGridRowBaseStyle �� BasedOn �� Property �� Value��%f  &	        &	      &	 
     &	 %     &	 =     7  7   7  7   '  �     7  7  ��   �� $ 出入金详情���� $ 订单信息���� -   .@�m� 8   y��� *%#AccountAuthority.TradeChuJinDetails+8  m� 8  y��� *'%AccountAuthority.TradeChuJinOrderInfo+8  �� "  8   .���  �@�ContextMenu8  ��  � ��$ 26��	 J� CommandBindings	 )  #System.Windows.Input.CommandBinding  -   
   Command#
 [   -   #
 [ .���� $��0��$��1q����	#FFD1CFCF �� CornerRadius$ 5��._��  � RowDefinitions �� $
��auto ��� $��0 ��� $��2 ��� $��40 ��� $��* ��� $
��auto �.+��  � Orientation$ 
Horizontal=�$��5q�.+��� $��客户账号：��$��2q��� $��80��$��2q����� *ChuJinSelectCondition.Account+�� $��会员名称：��$��2q�3  -Gss.ManagementMenu.CustomControl.AutoComboBox  -     Name$ 
ACB_Search��$
��AUTO��$	��180��$��24��   DisplayName$ OrgNameAndOrgCode��   SelectedValuePath$ OrgID��   ItemsSource �� *
POrgList+   SelectedValue �� *ChuJinSelectCondition.OrgName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��	状态：��$��2q��� -   $��cmbState�� �� SelectedIndex$ 0��$��Center=�$��2q�$��88�� �� SelectedValue �� *ChuJinSelectCondition.State+.@���
全部����	已申请����	处理中����处理失败����	已付款����	已拒绝���� $��申请时间：��$��2q�(  "System.Windows.Controls.DatePicker  $��2q�|�.  $	��130��$
��Auto��   SelectedDate �� *!ChuJinSelectCondition.StartTime+�� $	��至��$��2q�  $��2q�|�.  $	��130��$
��Auto�� �� *ChuJinSelectCondition.EndTime+�� $��付款时间：��$��5,0,0,0q�  $��2q�|�.  $	��130��$
��Auto�� �� *$"ChuJinSelectCondition.PayStartTime+�� $	��至��$��2q�  $��2q�|�.  $	��130��$
��Auto�� �� *" ChuJinSelectCondition.PayEndTime+�� -   $��查询��$��60��$��26��$	��5,2q����� *GetChuJinCommand+�� $��2��$��1q����	#FFD1CFCF5  /Gss.ManagementMenu.CustomControl.DataPagePicker  5  /Gss.ManagementMenu.CustomControl.DataPagePicker   PageChanged$ dataPage_PageChanged��$��5,2,2,2q�$��3��   CurrentPageItemCount �� *Items.Count+ �� ElementName$ dataGrid��   	PageCount �� *!ChuJinSelectCondition.PageCount+$ TwoWay=�   PageSize �� * ChuJinSelectCondition.PageSize+$ TwoWay=�   	PageIndex �� *!ChuJinSelectCondition.PageIndex+$ TwoWay=�&   System.Windows.Controls.DataGrid  -   $��dataGrid��$��4��$	��5,0q����	#FFD1CFCF   CanUserResizeRows .     SelectionMode$ Single=�    
IsReadOnly  . !   AutoGenerateColumns! .  ���� *TradeChuJinInfo.TOrderLst+" �� SelectedItem" �� *	CurChuJin+#   Columns# 4	  .System.Windows.Controls.DataGridTemplateColumn	  ,
  &System.Windows.Controls.DataGridColumn$ 
  Width5  /System.Windows.Controls.DataGridLengthConverter$$ 70 % 
  Header$% 会员编码��& 	  CellTemplate& �� .R��� $��0q�
������ ' �� 
IsReadOnly' . ��Z� ���� *	TelePhone+	  $$ 70 $% 所属会员��& �� .R��� $��0q�
������ ' . ��Z� ���� *	OrgName+	  $$ 70 $% 用户账号��& �� .R��� $��0q�
������ ' . ��Z� ���� *	Account+	  $$ 70 $% 用户姓名��& �� .R��� $��0q�
������ ' . ��Z� ���� *
UserName+	  $$ 70 $% 	持卡人��& �� .R��� $��0q�
������ ' . ��Z� ���� *
CardName+	  $	$ 120 $% 银行卡号��& �� .R��� $��0q�
������ ' . ��Z� ���� *
BankCard+0  *System.Windows.Controls.DataGridTextColumn  $$ 70 $% 	开户行��( 
  MinWidth$	( 100Q�1  +System.Windows.Controls.DataGridBoundColumn)   Binding) �� *
OpenBank+  $$ 70 $% 金额��$( 80Q�) �� *Amt+  $$ 70 $% 状态��$( 80Q�) �� *StateString+  $	$ 120 $% 错误信息��) �� *ErrMsg+  $% 申请时间��$	$ 120 ) �� *	ApplyTime+* �� StringFormat$* yyyy-MM-dd HH:mm:ss��  $% 付款时间��$	$ 140 ) �� *FkTime+$* yyyy-MM-dd HH:mm:ss���� $��Bottom=�$��5��+ �� Orientation$+ 
Horizontal=�.+��� .��已申请金额:�� $��Center=�$��0,0,20,0q����� *TradeChuJinInfo.AMT+�� .��已付款金额:�� $��Center=�$��0,0,20,0q����� *TradeChuJinInfo.AMT2+�� .��已拒绝金额:�� $��Center=�$��0,0,20,0q����� *TradeChuJinInfo.AMT3+