   M S B A M L   `   `   `  ����M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter  5      S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  5      E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter 5      S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  5      C    =Gss.ManagementMenu.AccountManager.Dealer.DealerAccountControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :cvt*clr-namespace:Gss.ManagementMenu.Converter     5      >cus.clr-namespace:Gss.ManagementMenu.CustomControl     5      HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  5      7my.clr-namespace:Gss.ManagementMenu.CustomControl  5      -   5          +� IsFocusScope  .  � 	Resources 5
         ViewAccount �� Text  RolePrivilege 
 Delete  
BindingOrg;   5Gss.ManagementMenu.Converter.CertificateEnumConverter  CertificateCvt2  ,Gss.Common.Converter.DateTimeFormatConverter  DateTimeCvt  BoolVisibilityCvt  CmDealerAccount �� 	Converter m� Command m� CommandTarget �� Path �� RelativeSource �� AncestorType 	 cMenu)  #System.Windows.Controls.DataGridRow	 �� 
TargetType 	 DataGridRowBaseStyle
 �� BasedOn 
 DGRStyle �� Property �� Value&   System.Windows.Controls.DataGrid  DataGridStyle �� Triggers �� Binding �� Value��%�  &	        &	 ,     &	 X     &	 �     &	 �     &	 �     &	 �     &	 �     7  7   7  7  7  7  7  &	 �    7  &	
 K    7 	 7  7  '  �    7  7  7 
 �� 5   
   $ 会员账户资料��6.   �� 5   
   $ 会员账户角色��60   �� 5   
   $ 删除会员账户��6)   �� 5   
   $ 	微会员��6-     5   
   6'     5   
   6(   �� 5   
   6'   �� 5   
   -   5        .@�5      m� $��新增会员账户��6�   y�6   �� *1/AccountAuthority.DealerAccountManagerAddAccount+8    6�   �� *CreateDealerAccountCmd+m� 5      8  y�6   �� *20AccountAuthority.DealerAccountManagerAccountInfo+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8  y�6   �� *+)AccountAuthority.DealerAccountManagerRole+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   �� 5      m� 5      8  y�6   �� *1/AccountAuthority.DealerAccountManagerDelAccount+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   -   5        .@�5      m� $��新增会员账户��6�   y�6   �� *1/AccountAuthority.DealerAccountManagerAddAccount+8    6�   �� *CreateDealerAccountCmd+5      �� 5    
   "	  6   8
   .�5!      ��  �@�ContextMenu8  6,   �� 5#       �@�ContextMenu8  6,   �� 5$       � ��$ 26��6*   5%      �� 5(   
   "	  6   8
   .�5)      ��  �@�ContextMenu8  6,   �� 5*       � ��8  63    5+      �� 5,       6   �� *!AccountAuthority.AccMgrReadonly+ True6R   .a�5-      ��  � �� 6;   Z� 5.      50      52       J� CommandBindings 54      )  #System.Windows.Input.CommandBinding  55   
   -   5           Command# [  55      6@     56   
   -   5        # [ 56      6;     57   
   -   5        # [ 57      6s     58   
   -   5        # [ 58      6?   .��5;      ]� .+�5<   
   �  � RowDefinitions 5=      �� 5>      $
��auto �6    �� 5?      $
��auto �6    �� 5@      $��* �6    .+�5C      � .+�5D      �� $��客户账号：��6   $��2q�6(   �� 5E      $��2q�6   $��88��6e   ��6%   �� *#!OrgAccountSelectCondition.Account+ �� Mode$ TwoWay=�6e   �� 5F      $��客户姓名：��6   $��2q�6(   �� 5G      $��2q�6   $��88��6f   ��6%   �� *$"OrgAccountSelectCondition.UserName+$ TwoWay=�6f   �� 5H      $��会员名称：��6   $��2q�6(   3   -Gss.ManagementMenu.CustomControl.AutoComboBox  5P      -   5          Name$ 
ACB_Search��5P   #   $
��AUTO��67   $	��180��6D   $��24��6S      DisplayName$ OrgNameAndOrgCode��6�      SelectedValuePath$ OrgID��6�      ItemsSource 6_   �� *
POrgList+$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�   SelectedValue 5Q      �� *#!OrgAccountSelectCondition.OrgName+$ TwoWay=�$ PropertyChanged=��� 5W      $��证件号码：��6   $��2q�6(   �� 5Y      $��2q�6   $	��150��6e   ��6%   �� *#!OrgAccountSelectCondition.CardNum+$ TwoWay=�6e   �� 5Z      -	   5        $��查询��5Z      $��60��6&   $��26��61   $	��5,2q�6=    � ToolTip$0 *根据查询条件获取客户账号列表��6J   $��Right=�6d   ��5[      �� *GetDealerListCommand+6?   5]      5   /Gss.ManagementMenu.CustomControl.DataPagePicker  5^      5   /Gss.ManagementMenu.CustomControl.DataPagePicker   PageChanged$ dataPage_PageChanged��6    $��5,2,2,2q�6C   $��1��6T      CurrentPageItemCount 6a   �� *Items.Count+ �� ElementName$ dataGrid��   	PageCount 5_       �� *%#OrgAccountSelectCondition.PageCount+$ TwoWay=�   PageSize 6f   �� *$"OrgAccountSelectCondition.PageSize+$ TwoWay=�    	PageIndex  5`       �� *%#OrgAccountSelectCondition.PageIndex+$ TwoWay=�%	  Xceed.Wpf.Toolkit.BusyIndicator	  5a      $��2��6!   ! 	  IsBusy! 6.   �� *" OrgAccountSelectCondition.IsBusy+" 	  BusyContent" 5b      �� 5c      $��加载中...��6    $��20(�6.   $
��Bold"�6<   $��Center=�6N   $��Center=�6i   .��5e        -
   5        $��dataGrid��5e      #   AutoGenerateColumns# .  $   SelectionMode$$ Single=�6H   %   
IsReadOnly% . &   CanUserResizeColumns& .  '   CanUserResizeRows' .  ��5f      �� *DealerAccountList+(   Columns( 5g      4
  .System.Windows.Controls.DataGridCheckBoxColumn
  5i      ,  &System.Windows.Controls.DataGridColumn)   Width5  /System.Windows.Controls.DataGridLengthConverter$) 40 61   *   Header$* 启用��6=   +   
IsReadOnly+ .  1  +System.Windows.Controls.DataGridBoundColumn,   Binding, 6\   �� *AccInfo.IsAccountEnabled+4  .System.Windows.Controls.DataGridTemplateColumn  5p      $) 70 62   $* 会员编码��6=   -   CellTemplate- 5q      �� 5r   "   .R�5s   &   �� $��0q�6?   
������ . �� 
IsReadOnly. . ��6.   Z� ��6~   �� *AccInfo.Telephone+5t   #   5v        5{      $) 70 61   $* 会员名称��6=   - 5|      �� 5}   "   .R�5~   &   �� $��0q�6?   
������ . . ��6.   Z� ��6~   �� *AccInfo.OrgName+5   #   5�        5�      $) 60 62   $* 账号��6=   - 5�      �� 5�   "   .R�5�   &   �� $��0q�6?   
������ . . ��6.   Z� ��6~   �� *AccInfo.AccountName+5�   #   5�        5�      $) 70 61   $* 姓名��6=   - 5�      �� 5�   "   .R�5�   &   �� $��0q�6?   
������ . . ��6.   Z� ��6~   �� *AccInfo.UserName+5�   #   5�        5�      $) 70 61   $* 手机��6=   /   MinWidth$	/ 100Q�6I   - 5�      �� 5�   "   .R�5�   &   �� $��0q�6?   
������ . . ��6.   Z� ��5�   @   �� *AccInfo.CellPhoneNumber+5�   #   5�      0  *System.Windows.Controls.DataGridTextColumn  5�      $) 70 6-   $* 证件类型��69   $/ 70Q�6�   , 6G   �� *AccInfo.CeritificateEnum+# [ 6�     5�      $) 70 61   $* 证件号码��6=   - 5�      �� 5�   "   .R�5�   &   �� $��0q�6?   
������ . . ��6.   Z� ��5�   .   �� *AccInfo.CertificateNumber+5�   #   5�        5�      $) 90 6-   $* 固话��69   , 6E   �� *AccInfo.TelephoneNumber+  5�      $	) 100 6.   $* 邮箱��6:   , 6F   �� *AccInfo.Email+  5�      $	) 140 6-   $* 创建时间��6:   , 6H   �� *AccInfo.OpenAccountTime+# [ 5�      5�      5�      5�      5�      