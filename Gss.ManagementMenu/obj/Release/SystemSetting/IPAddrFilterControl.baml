   M S B A M L   `   `   `  ����   Gss.ManagementMenu:    4Gss.ManagementMenu.SystemSetting.IPAddrFilterControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  -     +� IsFocusScope  .  � 	Resources    
ViewDetail �� Text 
 Delete 
 AddCmd  
RefreshCmd  BoolVisibilityCvt  
CmIpFilter m� Command m� CommandTarget �� Path �� RelativeSource �� AncestorType  CmIpFilter2)  #System.Windows.Controls.DataGridRow �� 
TargetType  DataGridRowBaseStyle	 �� BasedOn
 �� Property �� Value&   System.Windows.Controls.DataGrid  DataGridStyle��%  &	        &	      &	 0     &	 B     &	 T     &	 Y     7   7  7  7  &	 q    7  7  '      7  7  '  f    7  7  �� $ 显示详细���� $ 删除记录���� $ 新增���� $ 刷新���� �� .@�m� 8    �� $ PlacementTarget� �� $ ContextMenuL�m� 8   �� $ PlacementTarget� �� $ ContextMenuL�m� 8   �� $ PlacementTarget� �� $ ContextMenuL�m� 8   �� $ PlacementTarget� �� $ ContextMenuL��� .@�m� 8    �� $ PlacementTarget� �� $ ContextMenuL�m� 8   �� $ PlacementTarget� �� $ ContextMenuL��� "  8	   .�-   �� 
 �@�ContextMenu8  �� 
 � ��$ 26���� 
 � ��$ Center=��� "  8	   .��� 
 �@�ContextMenu8   J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [   -   # [   -   # [ .��]� .+�%  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy �� *IsLoadingIPAddrFilter+   BusyContent �� $��加载中...��$��20(�$
��Bold"�$��Center=�$��Center=�.��  -     Name$ DgShow��   AutoGenerateColumns .     SelectionMode$ Single=�   
IsReadOnly .    CanUserResizeRows .  ���� *IPAddrFilterInfoes+   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 起始IP��   MinWidth$	 150Q�   CellTemplate �� .R��� $��0q�
������  �� 
IsReadOnly . ��Z� ���� *StartIPAddr+  $ 结束IP��$	 150Q� �� .R��� $��0q�
������  . ��Z� ���� *	EndIPAddr+0  *System.Windows.Controls.DataGridTextColumn  $ 描述��$	 150Q�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
FilterDesc+