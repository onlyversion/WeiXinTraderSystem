   M S B A M L   `   `   `  ����  Gss.PopUpWindow<    6Gss.PopUpWindow.AuthWindows.RolePrivilegesConfigWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  6@     � WindowStartupLocation$  CenterOwner=�5   	    � WindowStyle$ 
ToolWindow=�6-    � SizeToContent$ Height=�5   	    � 
ResizeMode$ CanMinimize=�5   	   $	��600��6"    � Title$ 配置角色\权限��5   	   $	��600��6   $	��600��6&    � 	Resources 5       �� 
TargetType �� Property �� Value   TreeViewMainReadTemplate	 �� ItemsSource
 �� Orientation d� 	IsChecked �� Mode)  #System.Windows.Controls.DataGridRow  DataGridRowBaseStyle �� BasedOn��%  '��       &	  �     'Q� E    '  �    7  �� 5	   
   " ��6   .�5
      ��  � ��$ Stretch=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ 5,2,5,2q�6'   �� 5       � ��$ 26��6'   �� 5       � ��$ 60��6&   5      �� 5   
   	 6D   �� *
Children+.R�5      �� $
 
Horizontal=�6   $��Center=�62   .+�5      �� {�.  $��Center=�6h    6   �� *PrivilegeTreeNode.Check+$ TwoWay=�6h   �� 5      $��Center=�6Y   $��22��6t   $��5,5,0,0q�6�   ��6   �� *!PrivilegeTreeNode.PrivilegeName+$ TwoWay=�6�   5      5      �� 5   
   " Q�6   .�5      ��  �@Q�
IsExpanded . 6+   5      �� 5   
   "  6   8   .�5      ��  � ��$ 26��6*   5      5      .��5      %  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy 6   �� *IsBusy+   BusyContent 5   
   �� 5      $��加载中...��6   $��20(�6&   $
��Bold"�64   $��Center=�6F   $��Center=�6a   .��5!   
   � -   5         �Name$ 
LayoutRoot��5!      
�������$��20q�66    � ColumnDefinitions 5"      �� 5#      $	��230 �6#   �� 5$      $��5 �6#   �� 5%      $��* �6#   .+�5'      �� $��用户角色��6   $��0��6%   $��5,5,0,5q�66   .��5(      &   System.Windows.Controls.DataGrid  -   5        $��dataGrid��5(   �   $��5q�6      AutoGenerateColumns .     SelectionMode$ Single=�6B      
IsReadOnly .    CanUserResizeRows .  ��5)      �� *
RoleList+ �� SelectedItem 69   �� *CurentRoleInfo+   Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn   Header$ 角色名称��6-      MinWidth$ 80Q�6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *
RoleName+6Y     5,      $ 备注��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T    69   �� *Remark+6T   5.      5/      �� 50      $��1��6   �� 51      $��权限配置��6   $��2��6%   $��0,5,5,5q�66   .��52      �  � RowDefinitions 53      �� 54      $��* �6(   �� 55      $��40 �6(   .+�57      R� -   5        $��TreeViewMain��57   Q   $��0q�6   $��5,5,5,5q�64   $��5q�6E   #��[  58      ��57   e   �� *PrivilegeTreeNodeList+59      �� 5:      $
 
Horizontal=�6!   $��3��6:   $��1��6G   $
��Left=�6W   .+�5;      �� -   5        $��btnOK��5;   .   $��确定��6!   6;   �� 5<      -   5        $��	btnCancel��5<   .   $��取消��6!   6?   5=      5>      5@      5A      5B      5D      