   M S B A M L   `   `   `  ����M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter  5      J FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null^@clr-namespace:Gss.PopUpWindow.Converter;assembly=Gss.PopUpWindowGss.PopUpWindow.Converter 5      E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter 5      S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  5      ;    5Gss.ManagementMenu.AccountManager.ClientOnlineControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :cvt*clr-namespace:Gss.ManagementMenu.Converter     5      SpopCvt@clr-namespace:Gss.PopUpWindow.Converter;assembly=Gss.PopUpWindow     5      HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  5      7my.clr-namespace:Gss.ManagementMenu.CustomControl  5        +� IsFocusScope  .  � 	Resources 5	         AccountInfo �� Text  	FundsInfo 
 Delete  HistoryOrder0  *Gss.PopUpWindow.Converter.SexEnumConverter 
 SexCvt1  +Gss.PopUpWindow.Converter.BankEnumConverter  BankCvt7  1Gss.PopUpWindow.Converter.ClientTypeEnumConverter  	ClientCvt;  5Gss.PopUpWindow.Converter.ContractStatusEnumConverter  ContractCvt;   5Gss.ManagementMenu.Converter.CertificateEnumConverter  CertificateCvt2  ,Gss.Common.Converter.DateTimeFormatConverter 	 DateTimeCvt 
 BoolVisibilityCvt?  9Gss.ManagementMenu.Converter.VisibilityToBooleanConverter  VisibilityBoolCvt-  'Gss.Common.Converter.PlusMinusConverter  PlusMinusConverter  CmClientOnline m� Command �� 	Converter m� CommandTarget �� Path �� RelativeSource �� AncestorType	 �� 
TargetType  ShowColumnMenuItemStyle
 �� Property �� Value �� Mode  
CmDataGrid � DataContext �� Mode)	  #System.Windows.Controls.DataGridRow  DataGridRowBaseStyle �� BasedOn  DGRStyle&
   System.Windows.Controls.DataGrid  DataGridStyle �� Triggers �� Binding �� Value��%O  &	        &	 &     &	 L     &	 r     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
 
    &	     &	 0    &	 C    7   7 
 7  7 
 7  7 
 7  7 
 &	     7  &	 �    7  &	 �    7  7  '
  _    7  7  7  �� 5
   
   $ 账户资料��6.   �� 5   
   $ 资金信息��6,   �� 5   
   $ 删除账号��6)   �� 5   
   $ 订单信息��6/     5   
   6"     5   
   6#     5   
   6)     5   
   6-     5   
   6'     5   
   6(   �� 5   
   6'     5   
   6+     5   
   6#   �� 5   
   -   5        .@�5      m� 8   y�6   �� *86AccountAuthority.ClientOnlineAccountManagerAccountInfo+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8  y�6   �� *64AccountAuthority.ClientOnlineAccountManagerFundsInfo+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   �� 5      m� 5      8  y�6   �� *75AccountAuthority.ClientOnlineAccountManagerDelAccount+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8  y�6   �� *64AccountAuthority.ClientOnlineAccountManagerOrderInfo+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5!   
   "	 m�6   .�5"      �� 
 �@m�IsCheckable . 6,   �� 5#      
 �@m�	IsChecked 6*   �� *
Visibility+8   $ TwoWay=�5$      �� 5&   
   -   5         5&   )   ��  �� $ DataGridL�$ FindAncestor=�.@�5'      m� $��	显示列��6�   8��   6   �� $ PlacementTarget� �� $ ContextMenuL���6�   �� *	Columns+��5(      �� 5)      .R�5*      �� ��6$   �� *Header+5+      5-      5.      �� 51   
   "	 	 6   8   .�53      �� 
 �@�ContextMenu8  6,   �� 54      
 � ��$ 26��6*   55      �� 57   
   "	 
 6   8   .�58      �� 
 � ��8  63   �� 59      
 �@�ContextMenu8  6,    5:      �� 5;       6   �� *!AccountAuthority.AccMgrReadonly+ True6R   .a�5<      �� 
 � �� 6;   Z� 5=      5?      5@       J� CommandBindings 5B      )  #System.Windows.Input.CommandBinding  5C   
   -   5           Command# [  5C      6o     5D   
   -   5        # [ 5D      6k     5E   
   -   5        # [ 5E      6e     5F   
   -   5        # [ 5F      6q   .��5I      ]� .+�5J   
   �  � RowDefinitions 5K      �� 5L      $
��auto �6    �� 5M      $
��auto �6    �� 5N      $��* �6    �� 5O      $
��auto �6    .+�5Q      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�62   $��0��6G   .+�5R      �� $ 
Horizontal=�6   .+�5S      �� $��客户账号：��6   $��2q�6,   �� 5T      $��2q�6   $��88��6l   ��6)   �� *&$OnlineAccountSelectCondition.Account+$ TwoWay=�6l   �� 5U      $��客户姓名：��6   $��2q�6,   �� 5V      $��2q�6   $��88��6m   ��6)   �� *'%OnlineAccountSelectCondition.UserName+$ TwoWay=�6m   �� 5W      $��证件号码：��6   $��2q�6,   �� 5X      $��2q�6   $	��150��6l   ��6)   �� *&$OnlineAccountSelectCondition.CardNum+$ TwoWay=�6l   5Z      �� 5[      $��查询��6   $��60��6&   $��26��61   $	��5,2q�6=    � ToolTip$6 0根据查询条件获取在线客户账号列表��6J   $��Right=�6f   ��5\      �� *GetOnlineClientsCommand+5]      5   /Gss.ManagementMenu.CustomControl.DataPagePicker  5^      5   /Gss.ManagementMenu.CustomControl.DataPagePicker   PageChanged$ dataPage_PageChanged��6    $��5,2,2,2q�6C   $��1��6T      CurrentPageItemCount 6a   �� *Items.Count+ �� ElementName$ dataGrid��   	PageCount 5_       �� *(&OnlineAccountSelectCondition.PageCount+$ TwoWay=�   PageSize 6i   �� *'%OnlineAccountSelectCondition.PageSize+$ TwoWay=�   	PageIndex 5`       �� *(&OnlineAccountSelectCondition.PageIndex+$ TwoWay=��� 5b      $��3��6   $ 
Horizontal=�6'   .+�5c      �� .��6   账户余额:6   �� 5d      $��Center=�6F   $��0,0,20,0q�6a   ��6   �� *OnLineUserBaseInfo.Money+6a   �� 5i      .��6   保证金：6   �� 5j      $��Center=�6J   $��0,0,20,0q�6e   ��6   �� *OnLineUserBaseInfo.OccMoney+6e   5l      %  Xceed.Wpf.Toolkit.BusyIndicator  5m         IsBusy .  $��2��60      BusyContent 5n      �� 5o      $��加载中...��6    $��20(�6.   $
��Bold"�6<   $��Center=�6N   $��Center=�6i   .��5q      
  -   5          
 Name$  dataGrid��5q      ! 
  AutoGenerateColumns! .  " 
  SelectionMode$" Single=�6I   # 
  
IsReadOnly# . $ 
  CanUserResizeRows$ .  ��5r      �� *OnLineUserBaseInfo.TdUserList+% 
  Columns% 5s      4  .System.Windows.Controls.DataGridCheckBoxColumn  5u      ,  &System.Windows.Controls.DataGridColumn&   Width5  /System.Windows.Controls.DataGridLengthConverter$& 40 62   '   Header$' 启用��6>   -   5        dgEnable��1  +System.Windows.Controls.DataGridBoundColumn(   Binding( 5u   ]   �� *AccInfo.IsAccountEnabled+4  .System.Windows.Controls.DataGridTemplateColumn  5v      $& 70 62   $' 会员编码��6=   )   CellTemplate) 5w      �� 5x   "   .R�5y   &   �� $��0q�6?   
������ * �� 
IsReadOnly* . ��6.   Z� ��6~   �� *AccInfo.Telephone+5z   #   5|        5~      $& 70 62   $' 会员名称��6=   ) 5      �� 5�   "   .R�5�   &   �� $��0q�6?   
������ * . ��6.   Z� ��6~   �� *AccInfo.OrgName+5�   #   5�        5�      $& 60 61   $' 账号��6=   ) 5�      �� 5�   "   .R�5�   &   �� $��0q�6?   
������ * . ��6.   Z� ��6~   �� *AccInfo.AccountName+5�   #   5�        5�      $& 60 61   $' 姓名��6=   ) 5�      �� 5�   "   .R�5�   &   �� $��0q�6?   
������ * . ��6.   Z� ��6~   �� *AccInfo.UserName+5�   #   5�      0  *System.Windows.Controls.DataGridTextColumn  5�      $& 60 6-   $' 性别��69   ( 6E   �� *AccInfo.Sex+# [   5�      $& 70 6.   $' 账户余额��69   ( 6G   �� *FundsInfo.CurrentBalance+  5�      $& 70 6.   $' 冻结资金��69   ( 6G   �� *FundsInfo.DongJieMoney+  5�      $& 70 6.   $' 	预付款��69   ( 6F   �� *FundsInfo.FrozenDeposit+# [   5�      $& 70 6.   $' 	保证金��69   ( 6F   �� *FundsInfo.OccupiedDeposit+# [   5�      $' 手机��6-   ( 69   �� *AccInfo.CellPhoneNumber+  5�      $& 70 6.   $' 证件类型��69   ( 6G   �� *AccInfo.CeritificateEnum+# [   5�      $& 70 62   $' 证件号码��6=   ) 5�      �� 5�   "   .R�5�   &   �� $��0q�6?   
������ * . ��6.   Z� ��5�   .   �� *AccInfo.CertificateNumber+5�   #   5�        5�      $& 70 6.   $' 	联系人��69   ( 6F   �� *AccInfo.Contact+  5�      $& 70 6.   $' 联系地址��69   ( 6G   �� *AccInfo.Address+  5�      $& 60 6-   $' 固话��69   ( 6E   �� *AccInfo.TelephoneNumber+  5�      $& 60 6-   $' 邮箱��69   ( 6E   �� *AccInfo.Email+  5�      $	& 120 6.   $' 开户时间��6:   ( 6H   �� *AccInfo.OpenAccountTime+# [	   5�      $& 80 6-   $' 最近更新人��69   ( 6H   �� *AccInfo.LastUpdateManager+  5�      $	& 120 6.   $' 最近更新时间��6:   ( 6J   �� *AccInfo.LastUpdateTime+# [	   5�      $& 70 6.   $' 	开户人��69   ( 6F   �� *AccInfo.OpeningMan+  5�      $& 70 6.   $' 下单电话��69   ( 6G   �� *AccInfo.OrderPhoneNumber+  5�      $& 70 62   $' 是否在线��6=   ( 6K   �� *AccInfo.IsOnline+  5�      $	& 120 6.   $' 上次登录时间��6:   ( 6J   �� *AccInfo.LastLoginTime+# [	   5�      $	& 100 6.   $' 上次登录IP��6:   ( 6J   �� *AccInfo.LoginIP+  5�      $	& 100 6.   $' 上次登录MAC��6:   ( 6K   �� *AccInfo.LoginMAC+  5�      $& 70 61   $' 允许平仓��6=   ( 6K   �� *%#TransactionSettings.AllowChargeback+  5�      $& 70 61   $' 允许买涨��6=   ( 6K   �� * TransactionSettings.AllowOrder+  5�      $& 70 61   $' 允许出金��6=   ( 6K   �� *%#TransactionSettings.AllowEncashment+  5�      $& 70 61   $' 允许入金��6=   ( 6K   �� *#!TransactionSettings.AllowRecharge+  5�      $& 70 61   $' 允许买跌��6=   ( 6K   �� *#!TransactionSettings.AllowRecovery+  5�      $& 70 6.   $' 下单单位��69   ( 6G   �� *TransactionSettings.OrderUnit+  5�      $& 90 6.   $' 最小交易手数��69   ( 6I   �� *TransactionSettings.MinTrade+  5�      $	& 100 6.   $' 最大交易手数��6:   ( 6J   �� *TransactionSettings.MaxTrade+5     5     5     5     5     