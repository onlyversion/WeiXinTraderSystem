   M S B A M L   `   `   `  ����  Gss.ManagementMenu9    3Gss.ManagementMenu.SystemSetting.RoleManagerControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        � 	Resources  5       �� 
TargetType �� Property �� Value   TreeViewMainReadTemplate �� ItemsSource �� Orientation d� 	IsChecked �� Mode  dataGridRowmenu m� CommandTarget	 �� Path
 �� RelativeSource �� AncestorType m� Command  dataGridMenu)  #System.Windows.Controls.DataGridRow  DataGridRowBaseStyle �� BasedOn&   System.Windows.Controls.DataGrid  DataGridStyle��%  '��       &	  �     'Q� >    &	 �    &	 J    '  �    7  7  '  q    7  7  �� 5	   
   " ��6   .�5
      ��  � ��$ Stretch=�64   �� 5       � ��$ Center=�62   �� 5       � ��$ 5,2,5,2q�6'   �� 5       � ��$ 26��6'   �� 5       � ��$ 60��6&   5      �� 5   
    6D   �� *
Children+.R�5      �� $ 
Horizontal=�6   $��Center=�62   .+�5      �� $��Center=�6U    6   �� *PrivilegeTreeNode.Check+$ TwoWay=�6U   �� 5      $��Center=�6Y   $��22��6t   $��5,5,0,0q�6�   ��6   �� *!PrivilegeTreeNode.PrivilegeName+$ TwoWay=�6�   5      5      �� 5   
   " Q�6   .�5      ��  �@Q�
IsExpanded . 6+   5      �� 5   
   -   5        .@�5      m� $��添加角色��6    6%   �� $	 PlacementTarget�
 �� $ ContextMenuL� 6�   �� *AddRoleCommand+m� 5      $��删除角色��6    6%   �� $	 PlacementTarget�
 �� $ ContextMenuL� 6�   �� *DelRoleCommand+m� 5      $��编辑角色��6    6%   �� $	 PlacementTarget�
 �� $ ContextMenuL� 6�   �� *EditRoleCommand+5      �� 5   
   -   5        .@�5       m� $��添加角色��6    6%   �� $	 PlacementTarget�
 �� $ ContextMenuL� 6�   �� *AddRoleCommand+5!      �� 5"   
   "  6   8   .�5#      ��  � ��$ 26��6*   �� 5$       �@�ContextMenu8  6,   5%      �� 5&   
   "  6   8   .�5'      ��  �@�ContextMenu8  6,   5(      5)      .��5+      %  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy 6   �� *IsBusy+   BusyContent 5,   
   �� 5-      $��加载中...��6   $��20(�6&   $
��Bold"�64   $��Center=�6F   $��Center=�6a   .��5/   
   � -   5         �Name$ 
LayoutRoot��5/      
�������$��20q�66    � ColumnDefinitions 50      �� 51      $	��270 �6#   �� 52      $��* �6#   .+�54      �� $��用户角色��6   $��0��6%   $��5,5,5,5q�66   .��55        -   5        $��dataGrid��55   �   $��5q�6      AutoGenerateColumns .     SelectionMode$ Single=�6B      
IsReadOnly .    CanUserResizeRows .  ��56      �� *
RoleList+ �� SelectedItem 69   �� *CurentRoleInfo+   Columns 57      4  .System.Windows.Controls.DataGridTemplateColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ 角色名称��61      MinWidth$	 100Q�6?      CellTemplate 5:      �� 5;   "   .R�5<   &   �� $��0q�6?   
������  �� 
IsReadOnly . ��6.   Z� ��5=   *   �� *
RoleName+5>   #   5@      0  *System.Windows.Controls.DataGridTextColumn  5A      $ 备注��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *Remark+6T   5C      5D      �� 5E      $��权限配置��6   $��1��6%   $��5q�66   .��5F      �  � RowDefinitions 5G      �� 5H      $��* �6(   �� 5I      $��40 �6(   .+�5K      R� -   5        $��TreeViewMain��5K   Q   $��0q�6   $��5,5,5,5q�64   $��5q�6E   #��[  5L      ��5K   e   �� *PrivilegeTreeNodeList+5M      �� 5N      $ 
Horizontal=�6!   $��3��6:   $��1��6G   $
��Left=�6W   .+�5O      �� $��保存��6!   ��6.   �� *ConfigRolePrivilegesCommand+5P      5Q      5S      5T      5U      5W      