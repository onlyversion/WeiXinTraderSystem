   M S B A M L   `   `   `  ���� M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  =    7Gss.ManagementMenu.AccountManager.Org.OrgManagerControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  8cus.clr-namespace:Gss.ManagementMenu.CustomControl  7my.clr-namespace:Gss.ManagementMenu.CustomControl    � 	Resources     RolePrivilege �� Text  	OrgTicket  BoolVisibilityCvt  SetCommissionRatio  SetDefaultCommissionRatio  SetAllCommissionRatio  CmMgrAccount �� 	Converter m� CommandTarget �� Path �� RelativeSource �� AncestorType m� Command 	 cMenu)  #System.Windows.Controls.DataGridRow �� 
TargetType  DataGridRowBaseStyle	 �� BasedOn
 �� Property �� Value&   System.Windows.Controls.DataGrid 	 DataGridStyle��%�  &	        &	      &	 0     &	 5     &	 M     &	 k     &	 �     7  7  7   7  7  7  7  7  7  7  7  7  &	 '    7  '  �    7  7  '  "    7 	 7  �� $ 微会员角色���� $ 	二维码���� �� $ 修改返佣���� $ 修改默认返佣���� $ 批量返佣���� -   .@�m� $��新增微会员��y��� *'%AccountAuthority.OrgManagerAddAccount+8    �� $ PlacementTarget� �� $ ContextMenuL� �� *AddOrgCommand+m� $��微会员资料��y��� *(&AccountAuthority.OrgManagerAccountInfo+8   �� $ PlacementTarget� �� $ ContextMenuL� �� *ShowOrgDetialCommand+m� 8  y��� *!AccountAuthority.orgManagerRole+8   �� $ PlacementTarget� �� $ ContextMenuL��� m� $��删除微会员��y��� *'%AccountAuthority.OrgManagerDelAccount+8   �� $ PlacementTarget� �� $ ContextMenuL� �� *DeleteOrgCommand+m� 8   �� $ PlacementTarget� �� $ ContextMenuL�m� $��修改返佣��8  y��� */-AccountAuthority.OrgManagerSetCommissionRatio+8   �� $ PlacementTarget� �� $ ContextMenuL�m� $��修改默认返佣��8  y��� *64AccountAuthority.OrgManagerSetDefaultCommissionRatio+8 	  �� $ PlacementTarget� �� $ ContextMenuL�m� $��批量返佣��8 
 y��� *20AccountAuthority.OrgManagerSetAllCommissionRatio+8   �� $ PlacementTarget� �� $ ContextMenuL��� -   .@�m� $��新增微会员��y��� *'%AccountAuthority.OrgManagerAddAccount+8    �� $ PlacementTarget� �� $ ContextMenuL� �� *AddOrgCommand+�� "  8	   .��� 
 �@�ContextMenu8  �� 
 � ��$ 26���� "  8	   .��� 
 �@�ContextMenu8   J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [   -   # [   -   # [   -   # [  J� InputBindings �� 
 �� Key$ F5�� �� Command �� *GetOrgsListCommand+.��]� .+��  � RowDefinitions �� $
��auto ��� $
��auto ��� $��* �.+�� .+��� $��微会员名称：��$��2q�3   -Gss.ManagementMenu.CustomControl.AutoComboBox  -     Name$ 
ACB_Search��$
��AUTO��$	��180��$��24��   DisplayName$ OrgNameAndOrgCode��   SelectedValuePath$ OrgID��   ItemsSource �� *
POrgList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=�   SelectedValue �� *OrgSelectCondition.Account+$ TwoWay=�$ PropertyChanged=��� $��负责人：��$��2q��� $��2q�$��88������ *OrgSelectCondition.UserName+$ TwoWay=��� $��证件号码：��$��2q��� $��2q�$	��150������ *OrgSelectCondition.CardNum+$ TwoWay=��� -	   $��查询��$��60��$��26��$	��5,2q� � ToolTip$- '根据查询条件获取微会员列表��$��Right=����� *GetOrgsListCommand+5   /Gss.ManagementMenu.CustomControl.DataPagePicker  5   /Gss.ManagementMenu.CustomControl.DataPagePicker   PageChanged$ dataPage_PageChanged��$��5,2,2,2q�$��1��   CurrentPageItemCount �� *Items.Count+ �� ElementName$ dataGrid��   	PageCount �� *OrgSelectCondition.PageCount+$ TwoWay=�   PageSize �� *OrgSelectCondition.PageSize+$ TwoWay=�   	PageIndex �� *OrgSelectCondition.PageIndex+$ TwoWay=�%  Xceed.Wpf.Toolkit.BusyIndicator  $��2��    IsBusy  �� *OrgSelectCondition.IsBusy+!   BusyContent! �� $��加载中...��$��20(�$
��Bold"�$��Center=�$��Center=�.��  -
   $��dataGrid��"   CanUserAddRows" .  #   AutoGenerateColumns# .  $   SelectionMode$$ Single=�%   CanUserResizeRows% .  ���� *	OrgList+& �� SelectedItem& �� *
CurOrgInfo+$ TwoWay=�'   Columns' 4  .System.Windows.Controls.DataGridCheckBoxColumn  ,	  &System.Windows.Controls.DataGridColumn( 	  Header$( 选择��) 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$) 40
 1  +System.Windows.Controls.DataGridBoundColumn*   Binding* �� *	IsCheck+  $( 启用��$) 40
 + 	  
IsReadOnly+ . * �� *Status+4  .System.Windows.Controls.DataGridTemplateColumn  $( 会员编码��$) 70
 + . ,   CellTemplate, �� .R��� $��0q�
������ - �� 
IsReadOnly- . ��Z� ���� *	TelePhone+  $( 会员名称��$	) 100
 + . , �� .R��� $��0q�
������ - . ��Z� ���� *	OrgName+0  *System.Windows.Controls.DataGridTextColumn  $( 上级微会员��$	) 100
 + . * �� *ParentOrgName+  $( 法人��$) 50
 + . * �� *
Coperson+  $( 手机��$) 70
 + . , �� .R��� $��0q�
������ - . ��Z� ���� *
PhoneNum+  $( 证件类型��$) 70
 + . * �� *CardTypeString+  $( 证件编号��. 	  MinWidth$. 60Q�+ . , �� .R��� $��0q�
������ - . ��Z� ���� *	CardNum+  $( 	负责人��$) 60
 + . * �� *
Reperson+  $( Email��$) 60
 + . * �� *Email+  $( 地址��$) 60
 + . * �� *	Address+  $( 创建时间��$	) 140
 + . * �� *	AddTime+