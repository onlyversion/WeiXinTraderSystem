   M S B A M L   `   `   `  ����   Gss.ManagementMenu9    3Gss.ManagementMenu.SystemSetting.RoleManagerControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � 	Resources   �� 
TargetType �� Property �� Value   TreeViewMainReadTemplate �� ItemsSource �� Orientation d� 	IsChecked �� Mode  dataGridRowmenu m� CommandTarget	 �� Path
 �� RelativeSource �� AncestorType m� Command  dataGridMenu)  #System.Windows.Controls.DataGridRow  DataGridRowBaseStyle �� BasedOn&   System.Windows.Controls.DataGrid  DataGridStyle��%?  '��       &	  �     'Q� t    &	 �    &	 �    '  s    7  7  '  �    7  7  �� " ��.���  � ��$ Stretch=���  � ��$ Center=���  � ��$ 5,2,5,2q���  � ��$ 26����  � ��$ 60����  �� *
Children+.R��� $ 
Horizontal=�$��Center=�.+��� $��Center=� �� *PrivilegeTreeNode.Check+$ TwoWay=��� $��Center=�$��22��$��5,5,0,0q����� *!PrivilegeTreeNode.PrivilegeName+$ TwoWay=��� " Q�.���  �@Q�
IsExpanded . �� -   .@�m� $��添加角色�� �� $	 PlacementTarget�
 �� $ ContextMenuL� �� *AddRoleCommand+m� $��删除角色�� �� $	 PlacementTarget�
 �� $ ContextMenuL� �� *DelRoleCommand+m� $��编辑角色�� �� $	 PlacementTarget�
 �� $ ContextMenuL� �� *EditRoleCommand+�� -   .@�m� $��添加角色�� �� $	 PlacementTarget�
 �� $ ContextMenuL� �� *AddRoleCommand+�� "  8   .���  � ��$ 26����  �@�ContextMenu8  �� "  8   .���  �@�ContextMenu8  .��%  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy �� *IsBusy+   BusyContent �� $��加载中...��$��20(�$
��Bold"�$��Center=�$��Center=�.��� -    �Name$ 
LayoutRoot��
�������$��20q� � ColumnDefinitions �� $	��270 ��� $��* �.+��� $��用户角色��$��0��$��5,5,5,5q�.��  -   $��dataGrid��$��5q�   AutoGenerateColumns .     SelectionMode$ Single=�   
IsReadOnly .    CanUserResizeRows .  ���� *
RoleList+ �� SelectedItem �� *CurentRoleInfo+   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 角色名称��   MinWidth$	 100Q�   CellTemplate �� .R��� $��0q�
������  �� 
IsReadOnly . ��Z� ���� *
RoleName+0  *System.Windows.Controls.DataGridTextColumn  $ 备注��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Remark+�� $��权限配置��$��1��$��5q�.���  � RowDefinitions �� $��* ��� $��40 �.+�R� -   $��TreeViewMain��$��0q�$��5,5,5,5q�$��5q�#��[  ���� *PrivilegeTreeNodeList+�� $ 
Horizontal=�$��3��$��1��$
��Left=�.+��� $��保存������ *ConfigRolePrivilegesCommand+