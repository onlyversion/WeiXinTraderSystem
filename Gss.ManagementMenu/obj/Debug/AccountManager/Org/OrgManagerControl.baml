   M S B A M L   `   `   `  ����M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  5      S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  5	      =    7Gss.ManagementMenu.AccountManager.Org.OrgManagerControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      8cus.clr-namespace:Gss.ManagementMenu.CustomControl  5      7my.clr-namespace:Gss.ManagementMenu.CustomControl  5	        � 	Resources  5         RolePrivilege �� Text  	OrgTicket  BoolVisibilityCvt  SetCommissionRatio  SetDefaultCommissionRatio  SetAllCommissionRatio  CmMgrAccount �� 	Converter m� CommandTarget �� Path �� RelativeSource �� AncestorType m� Command 	 cMenu)  #System.Windows.Controls.DataGridRow �� 
TargetType  DataGridRowBaseStyle	 �� BasedOn
 �� Property �� Value&   System.Windows.Controls.DataGrid 	 DataGridStyle��%�  &	        &	 )     &	 L     &	 _     &	 �     &	 �     &	 �     7  7  7   7  7  7  7  7  7  7  7  7  &	 x    7  '  e    7  7  '  �    7 	 7  �� 5   
   $ 微会员角色��60   �� 5   
   $ 	二维码��6,   �� 5   
   6'   �� 5   
   $ 修改返佣��65   �� 5   
   $ 修改默认返佣��6<   �� 5   
   $ 批量返佣��68   �� 5   
   -   5        .@�5      m� $��新增微会员��6�   y�6   �� *'%AccountAuthority.OrgManagerAddAccount+8    6�   �� $ PlacementTarget� �� $ ContextMenuL� 6�   �� *AddOrgCommand+m� 5      $��微会员资料��6�   y�6   �� *(&AccountAuthority.OrgManagerAccountInfo+8   6�   �� $ PlacementTarget� �� $ ContextMenuL� 6�   �� *ShowOrgDetialCommand+m� 5      8  y�6   �� *!AccountAuthority.orgManagerRole+8   6}   �� $ PlacementTarget� �� $ ContextMenuL�6�   �� 5      m� 5      $��删除微会员��6�   y�6   �� *'%AccountAuthority.OrgManagerDelAccount+8   6�   �� $ PlacementTarget� �� $ ContextMenuL� 6�   �� *DeleteOrgCommand+m� 5      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      $��修改返佣��6�   8  y�6   �� */-AccountAuthority.OrgManagerSetCommissionRatio+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6  m� 5      $��修改默认返佣��6�   8  y�6   �� *64AccountAuthority.OrgManagerSetDefaultCommissionRatio+8 	  6�   �� $ PlacementTarget� �� $ ContextMenuL�6  m� 5      $��批量返佣��6�   8 
 y�6   �� *20AccountAuthority.OrgManagerSetAllCommissionRatio+8   6�   �� $ PlacementTarget� �� $ ContextMenuL�6  5      �� 5    
   -   5        .@�5!      m� $��新增微会员��6�   y�6   �� *'%AccountAuthority.OrgManagerAddAccount+8    6�   �� $ PlacementTarget� �� $ ContextMenuL� 6�   �� *AddOrgCommand+5"   
   �� 5$   
   "  6   8	   .�5%      �� 
 �@�ContextMenu8  6,   �� 5&      
 � ��$ 26��6*   5'      �� 5(   
   "  6   8	   .�5)      �� 
 �@�ContextMenu8  6,   5*      5+       J� CommandBindings 5-      )  #System.Windows.Input.CommandBinding  5.   
   -   5           Command# [  5.      5/   J     50   
   -   5        # [ 50      51        52   
   -   5        # [ 52      6G     53   
   -   5        # [ 53      6N     54   
   -   5        # [ 54      6J    J� InputBindings 56      �� 57   
   
 �� Key$ F5��6<    �� Command 6   �� *GetOrgsListCommand+6<   .��5:      ]� .+�5;   
   �  � RowDefinitions 5<      �� 5=      $
��auto �6    �� 5>      $
��auto �6    �� 5?      $��* �6    .+�5C      � .+�5D      �� $��微会员名称：��6   $��2q�6)   3   -Gss.ManagementMenu.CustomControl.AutoComboBox  5N      -   5          Name$ 
ACB_Search��5N   #   $
��AUTO��67   $	��180��6D   $��24��6S      DisplayName$ OrgNameAndOrgCode��6�      SelectedValuePath$ OrgID��6�      ItemsSource 6_   �� *
POrgList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�   SelectedValue 5O      �� *OrgSelectCondition.Account+$ TwoWay=�$ PropertyChanged=��� 5R      $��负责人：��6   $��2q�6'   �� 5S      $��2q�6   $��88��6_   ��6%   �� *OrgSelectCondition.UserName+$ TwoWay=�6_   �� 5T      $��证件号码：��6   $��2q�6(   �� 5U      $��2q�6   $	��150��6^   ��6%   �� *OrgSelectCondition.CardNum+$ TwoWay=�6^   �� 5V      -	   5        $��查询��5V      $��60��6&   $��26��61   $	��5,2q�6=    � ToolTip$- '根据查询条件获取微会员列表��6J   $��Right=�6c   ��5W      �� *GetOrgsListCommand+6=   5X      5   /Gss.ManagementMenu.CustomControl.DataPagePicker  5[      5   /Gss.ManagementMenu.CustomControl.DataPagePicker   PageChanged$ dataPage_PageChanged��6    $��5,2,2,2q�6C   $��1��6T      CurrentPageItemCount 6a   �� *Items.Count+ �� ElementName$ dataGrid��   	PageCount 5\       �� *OrgSelectCondition.PageCount+$ TwoWay=�   PageSize 6_   �� *OrgSelectCondition.PageSize+$ TwoWay=�   	PageIndex 5]       �� *OrgSelectCondition.PageIndex+$ TwoWay=�%  Xceed.Wpf.Toolkit.BusyIndicator  5_      $��2��6!       IsBusy  6.   �� *OrgSelectCondition.IsBusy+!   BusyContent! 5`      �� 5a      $��加载中...��6    $��20(�6.   $
��Bold"�6<   $��Center=�6N   $��Center=�6i   .��5c        -
   5        $��dataGrid��5c   �   "   CanUserAddRows" .  #   AutoGenerateColumns# .  $   SelectionMode$$ Single=�6P   %   CanUserResizeRows% .  ��5d      �� *	OrgList+& �� SelectedItem& 67   �� *
CurOrgInfo+$ TwoWay=�'   Columns' 5e      4  .System.Windows.Controls.DataGridCheckBoxColumn  5g      ,	  &System.Windows.Controls.DataGridColumn( 	  Header$( 选择��61   ) 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$) 40
 6Y   1  +System.Windows.Controls.DataGridBoundColumn*   Binding* 6=   �� *	IsCheck+6Y     5h      $( 启用��61   $) 40
 6X   + 	  
IsReadOnly+ . * 6=   �� *Status+6c   4  .System.Windows.Controls.DataGridTemplateColumn  5j      $( 会员编码��61   $) 70
 6?   + . ,   CellTemplate, 5k      �� 5l   "   .R�5m   &   �� $��0q�6?   
������ - �� 
IsReadOnly- . ��6.   Z� ��6~   �� *	TelePhone+5n   #   5p        5s      $( 会员名称��61   $	) 100
 6?   + . , 5t      �� 5u   "   .R�5v   &   �� $��0q�6?   
������ - . ��6.   Z� ��6~   �� *	OrgName+5w   #   5y      0  *System.Windows.Controls.DataGridTextColumn  5z      $( 上级微会员��6-   $	) 100
 6^   + . * 6<   �� *ParentOrgName+6j     5{      $( 法人��6-   $) 50
 6V   + . * 69   �� *
Coperson+6a     5}      $( 手机��61   $) 70
 6=   + . , 5~      �� 5   "   .R�5�   &   �� $��0q�6?   
������ - . ��6.   Z� ��5�   .   �� *
PhoneNum+5�   #   5�        5�      $( 证件类型��6-   $) 70
 6^   + . * 6;   �� *CardTypeString+6i     5�      $( 证件编号��61   . 	  MinWidth$. 60Q�6?   + . , 5�      �� 5�   "   .R�5�   &   �� $��0q�6?   
������ - . ��6.   Z� ��5�   .   �� *	CardNum+5�   #   5�        5�      $( 	负责人��6-   $) 60
 6W   + . * 6:   �� *
Reperson+6b     5�      $( Email��6-   $) 60
 6V   + . * 6<   �� *Email+6a     5�      $( 地址��6-   $) 60
 6U   + . * 69   �� *	Address+6`     5�      $( 创建时间��6-   $	) 140
 6W   + . * 6;   �� *	AddTime+6c   5�      5�      5�      5�      5�      