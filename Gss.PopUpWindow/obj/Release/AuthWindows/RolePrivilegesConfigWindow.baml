   M S B A M L   `   `   `  ����   Gss.PopUpWindow<    6Gss.PopUpWindow.AuthWindows.RolePrivilegesConfigWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit    � WindowStartupLocation$  CenterOwner=� � WindowStyle$ 
ToolWindow=� � SizeToContent$ Height=� � 
ResizeMode$ CanMinimize=�$	��600�� � Title$ 配置角色\权限��$	��600��$	��600�� � 	Resources  �� 
TargetType �� Property �� Value   TreeViewMainReadTemplate	 �� ItemsSource
 �� Orientation d� 	IsChecked �� Mode)  #System.Windows.Controls.DataGridRow  DataGridRowBaseStyle �� BasedOn��%�  '��       &	  �     'Q� {    '  �    7  �� " ��.���  � ��$ Stretch=���  � ��$ Center=���  � ��$ 5,2,5,2q���  � ��$ 26����  � ��$ 60���� 	 �� *
Children+.R��� $
 
Horizontal=�$��Center=�.+��� {�.  $��Center=� �� *PrivilegeTreeNode.Check+$ TwoWay=��� $��Center=�$��22��$��5,5,0,0q����� *!PrivilegeTreeNode.PrivilegeName+$ TwoWay=��� " Q�.���  �@Q�
IsExpanded . �� "  8   .���  � ��$ 26��.��%  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy �� *IsBusy+   BusyContent �� $��加载中...��$��20(�$
��Bold"�$��Center=�$��Center=�.��� -    �Name$ 
LayoutRoot��
�������$��20q� � ColumnDefinitions �� $	��230 ��� $��5 ��� $��* �.+��� $��用户角色��$��0��$��5,5,0,5q�.��&   System.Windows.Controls.DataGrid  -   $��dataGrid��$��5q�   AutoGenerateColumns .     SelectionMode$ Single=�   
IsReadOnly .    CanUserResizeRows .  ���� *
RoleList+ �� SelectedItem �� *CurentRoleInfo+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 角色名称��   MinWidth$ 80Q�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
RoleName+  $ 备注��   Width5  /System.Windows.Controls.DataGridLengthConverter$ *  �� *Remark+�� $��1���� $��权限配置��$��2��$��0,5,5,5q�.���  � RowDefinitions �� $��* ��� $��40 �.+�R� -   $��TreeViewMain��$��0q�$��5,5,5,5q�$��5q�#��[  ���� *PrivilegeTreeNodeList+�� $
 
Horizontal=�$��3��$��1��$
��Left=�.+��� -   $��btnOK��$��确定���� -   $��	btnCancel��$��取消��