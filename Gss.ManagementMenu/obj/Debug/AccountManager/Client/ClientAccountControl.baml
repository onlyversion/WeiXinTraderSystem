   M S B A M L   `   `   `  ����M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  5      S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  5      K*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter  5      J FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null^@clr-namespace:Gss.PopUpWindow.Converter;assembly=Gss.PopUpWindowGss.PopUpWindow.Converter 5      E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
      <    6Gss.ManagementMenu.AccountManager.ClientAccountControl   5      5my.clr-namespace:Gss.ManagementMenu.CustomControl  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >cus.clr-namespace:Gss.ManagementMenu.CustomControl     5      :cvt*clr-namespace:Gss.ManagementMenu.Converter     5      SpopCvt@clr-namespace:Gss.PopUpWindow.Converter;assembly=Gss.PopUpWindow     5      HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  5	      3system&clr-namespace:System;assembly=mscorlib  5
        +� IsFocusScope  .  � 	Resources 5         AccountInfo �� Text  	FundsInfo 
 Delete  AdjustMoney 
 CashIO  MarketOrder  PendingOrder  HistoryOrder0  *Gss.PopUpWindow.Converter.SexEnumConverter 
 SexCvt1  +Gss.PopUpWindow.Converter.BankEnumConverter 	 BankCvt7  1Gss.PopUpWindow.Converter.ClientTypeEnumConverter 
 	ClientCvt;  5Gss.PopUpWindow.Converter.ContractStatusEnumConverter  ContractCvt;   5Gss.ManagementMenu.Converter.CertificateEnumConverter  CertificateCvt4   .Gss.ManagementMenu.Converter.BankTypeConverter  BankTypeConverter2  ,Gss.Common.Converter.DateTimeFormatConverter  DateTimeCvt  BoolVisibilityCvt?  9Gss.ManagementMenu.Converter.VisibilityToBooleanConverter  VisibilityBoolCvt-	  'Gss.Common.Converter.PlusMinusConverter  PlusMinusConverter  CmClientAccount m� Command �� 	Converter m� CommandTarget �� Path �� RelativeSource �� AncestorType	 �� 
TargetType  ShowColumnMenuItemStyle
 �� Property �� Value �� Mode  
CmDataGrid � DataContext �� Mode)
  #System.Windows.Controls.DataGridRow  DataGridRowBaseStyle �� BasedOn  DGRStyle&   System.Windows.Controls.DataGrid  DataGridStyle �� Triggers �� Binding �� Value��%�	  &	        &	 ,     &	 X     &	 �     &	 �     &	 �     &	 �     &	     &	 <    &		 O    &	
 b    &	 u    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    7   7  7  7  7  7  7  7  7  7  &	 g    7  &	     7  &	     7  7  '  �    7  7  7  �� 5   
   $ 客户账户资料��6.   �� 5   
   $ 客户资金信息��6,   �� 5   
   $ 删除客户账户��6)   �� 5   
   $ 调节��6.   �� 5   
   $ 库存结算��6)   �� 5   
   $ 即时成交��6.   �� 5   
   $ 挂单交易��6/   �� 5   
   $ 订单信息��6/     5   
   6"     5   
   6#     5   
   6)     5   
   6-     5   
   6'     5   
   6      5   
   6(   �� 5   
   6'     5   
   6+   	  5   
   6#   �� 5"   
   -   5        .@�5$      m� 8   y�6   �� *20AccountAuthority.ClientAccountManagerAccountInfo+8   5%      �� $ PlacementTarget� �� $ ContextMenuL�6u   �� 5-      m� 5.      8  y�6   �� *20AccountAuthority.ClientAccountManagerMarketOrder+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   �� 50      m� 51      8  y�6   �� *0.AccountAuthority.ClientAccountManagerFundsInfo+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 53      8  y�6   �� *20AccountAuthority.ClientAccountManagerAdjustMoney+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 54      8  y�6   �� *0.AccountAuthority.ClientAccountManagerOrderInfo+8 	  6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   �� 55      56      �� 58   
   "	 m�6   .�59      �� 
 �@m�IsCheckable . 6,   �� 5:      
 �@m�	IsChecked 6*   �� *
Visibility+8   $ TwoWay=�5;      �� 5=   
   -   5        .@�5@      m� $��	显示列��5A      8��   5@      ��  �� $ DataGridL�$ FindAncestor=���5A   $   �� *	Columns+��5B      �� 5C      .R�5D      �� ��6$   �� *Header+5E      5G      5H      �� 5K   
   "	 
 6   8   .�5M      �� 
 �@�ContextMenu8  6,   �� 5N      
 � ��$ 26��6*   5O      �� 5Q   
   "	  6   8   .�5R      �� 
 � ��8  63   �� 5S      
 �@�ContextMenu8  6,    5T      �� 5U       6   �� *!AccountAuthority.AccMgrReadonly+ True6R   .a�5V      �� 
 � �� 6;   Z� 5W      5Y      5[       J� CommandBindings 5]      )  #System.Windows.Input.CommandBinding  5^   
   -   5           Command# [  5^      6o     5_   
   -   5        # [ 5_      6k     5`   
   -   5        # [ 5`      6e     5a   
   -   5        # [ 5a      6o     5b   
   -   5        # [ 5b      6e     5c   
   -   5        # [ 5c      6o     5d   
   -	   5        # [ 5d      6q     5e   
   -
   5        # [ 5e      6q   .��5i   
   �  � RowDefinitions 5j      �� 5k      $
��auto �6    �� 5l      $
��auto �6    �� 5m      $��* �6    �� 5n      $
��auto �6    .+�5p      � .+�5q      ��  �� Orientation$ 
Horizontal=�6   .+�5r      �� $��客户账号：��6   $��2q�6(   �� 5s      $��2q�6   $��88��6h   ��6%   �� *&$ClientAccountSelectCondition.Account+$ TwoWay=�6h   5t      �� 5u      $ 
Horizontal=�6   .+�5v      �� $��客户姓名：��6   $��2q�6,   �� 5w      $��2q�6   $��88��6i   ��6%   �� *'%ClientAccountSelectCondition.UserName+$ TwoWay=�6i   5x      �� 5y      $ 
Horizontal=�6   .+�5z      �� $��手机号码：��6   $��2q�6(   �� 5{      $��2q�6   $��88��6g   ��6&   �� *$"ClientAccountSelectCondition.Phone+$ TwoWay=�6g   5|      �� 5}      $ 
Horizontal=�6   .+�5~      �� $��会员名称：��6   $��2q�6(   3   -Gss.ManagementMenu.CustomControl.AutoComboBox  5      -   5          Name$ 
ACB_Search��5   #   $
��AUTO��67   $	��180��6D   $��24��6S      DisplayName$ OrgNameAndOrgCode��6�      SelectedValuePath$ OrgID��6�      ItemsSource 6_   �� *
POrgList+$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�   SelectedValue 5�      �� *&$ClientAccountSelectCondition.OrgName+$ TwoWay=�$ PropertyChanged=�5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��经纪人：��6   $��2q�6'   �� 5�      $��2q�6   $��88��6g   ��6%   �� *%#ClientAccountSelectCondition.Broker+$ TwoWay=�6g   5�      �� 5�      $ 
Horizontal=�6   y�62   �� *IsProductNameVisibility+ �� ElementName$	 Icc��.+�5�      �� $��是否经纪人：��6   �� 5�      $��Center=�6   $��2q�68   $��88��6C    �� Text 5�      �� *'%ClientAccountSelectCondition.IsBroker+$ TwoWay=�$ PropertyChanged=�.@�5�      �� $��全部��6#    �� 
IsSelected . 60   �� 5�      $	��是��6#   �� 5�      $	��否��6#   5�      5�      �� 5�      $ 
Horizontal=�6   .+�5�      �� $��开户时间：��6   (  "System.Windows.Controls.DatePicker  5�      |�.  $��2q�60   $��Center=�6;   $	��100��6V       SelectedDate  5�      �� *(&ClientAccountSelectCondition.StartTime+�� 5�      $��至：��6     5�      |�.  $��2q�60   $��Center=�6;   $	��100��6V     5�      �� *&$ClientAccountSelectCondition.EndTime+5�      �� 5�      -   5        $��查询��5�      $��60��6&   $��26��61   $	��5,2q�6=   ! � ToolTip$0! *根据查询条件获取客户账号列表��6K   $��Right=�6e   ��5�      �� *GetClientAccountCommand+6B   �� 5�      -   5        $��Excel��5�      $��60��6%   $��26��60   $	��5,2q�6<   $! 导出Excel报表��6J   $��Right=�6_   5�      5�      5   /Gss.ManagementMenu.CustomControl.DataPagePicker  5�      5   /Gss.ManagementMenu.CustomControl.DataPagePicker"   PageChanged$" dataPage_PageChanged��6    $��5,2,2,2q�6C   $��1��6T   #   CurrentPageItemCount# 6a   �� *Items.Count+$ dataGrid��$   	PageCount$ 5�       �� *(&ClientAccountSelectCondition.PageCount+$ TwoWay=�%   PageSize% 6i   �� *'%ClientAccountSelectCondition.PageSize+$ TwoWay=�&   	PageIndex& 5�       �� *(&ClientAccountSelectCondition.PageIndex+$ TwoWay=�%  Xceed.Wpf.Toolkit.BusyIndicator  5�      $��2��6H   '   IsBusy' 6!   �� *IsLoadingClientList+(   BusyContent( 5�      �� 5�      $��加载中...��6    $��20(�6.   $
��Bold"�6<   $��Center=�6N   $��Center=�6i   .��5�        -   5        $��dataGrid��5�      )   AutoGenerateColumns) .  *   SelectionMode$* Single=�6G   +   
IsReadOnly+ . ,   CanUserResizeRows, .  $-   HorizontalScrollBarVisibility$- Visible=�5�   G   ��6   �� *UserBaseInfo.TdUserList+.   Columns. 5�      4  .System.Windows.Controls.DataGridCheckBoxColumn  5�      ,  &System.Windows.Controls.DataGridColumn/   Width5  /System.Windows.Controls.DataGridLengthConverter$/ 40 61   0   Header$0 启用��6<   -   5        dgEnable��1  +System.Windows.Controls.DataGridBoundColumn1   Binding1 5�   [   �� *AccInfo.IsAccountEnabled+4  .System.Windows.Controls.DataGridTemplateColumn  5�      $/ 70 6-   $0 会员编码��68   2   CellTemplate2 5�      �� 5�   "   .R�5�   &   �� $��0q�6?   
������ 3 �� 
IsReadOnly3 . ��6.   Z� ��6~   �� *AccInfo.Telephone+5�   #   5�        5�      $/ 70 6-   $0 会员名称��68   2 5�      �� 5�   "   .R�5�   &   �� $��0q�6?   
������ 3 . ��6.   Z� ��6~   �� *AccInfo.OrgName+5�   #   5�        5�      $/ 60 6.   $0 账号��6:   2 5�      �� 5�   "   .R�5�   &   �� $��0q�6?   
������ 3 . ��6.   Z� ��6~   �� *AccInfo.AccountName+5�   #   5�        5�      $/ 60 6.   $0 姓名��6:   2 5�      �� 5�   "   .R�5�   &   �� $��0q�6?   
������ 3 . ��6.   Z� ��6~   �� *AccInfo.UserName+5�   #   5�      0  *System.Windows.Controls.DataGridTextColumn  5�      $/ 60 6*   $0 性别��66   1 6B   �� *AccInfo.Sex+# [   5�      $/ 70 6)   $0 账户余额��65   1 6C   �� *FundsInfo.CurrentBalance+  5�      $/ 70 6)   $0 冻结资金��65   1 6C   �� *FundsInfo.DongJieMoney+  5�      $/ 70 6)   $0 	保证金��65   1 6B   �� *FundsInfo.OccupiedDeposit+# [   5�      $	/ 100 6)   $0 手机��66   1 6B   �� *AccInfo.CellPhoneNumber+  5�      $/ 90 6-   $0 是否经纪人��68   1 6G   �� *AccInfo.IsBroker+  5�      $/ 90 6)   $0 经纪人账号��64   1 6C   �� *AccInfo.PAccount+  5�      $/ 90 6)   $0 经纪人姓名��64   1 6C   �� *AccInfo.PUserName+  5�      $	/ 140 6*   $0 开户时间��66   1 6D   �� *AccInfo.OpenAccountTime+# [   5�      $	/ 140 6*   $0 上次登录时间��66   1 6F   �� *AccInfo.LastLoginTime+# [ 5     5     �� 5     $��3��6   $ 
Horizontal=�6&   .+�5     �� .��6   账户余额:6   �� 5     $��Center=�6@   $��0,0,20,0q�6[   ��6   �� *UserBaseInfo.Money+6[   �� 5     .��6   冻结资金：6   �� 5     $��Center=�6r   $��0,0,20,0q�6�   ��6   �� *UserBaseInfo.DongJieMoney+# [ 6�   �� 5     .��6   保证金：6   �� 5     $��Center=�6r   $��0,0,20,0q�6�   ��6   �� *UserBaseInfo.OccMoney+# [ 6�   5     5     5     