   M S B A M L   `   `   `  ����M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  5      <    6Gss.ManagementMenu.SystemSetting.TradingSettingControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  5      7my.clr-namespace:Gss.ManagementMenu.CustomControl  5      -   5          � 	Resources  5         Add �� Text 
 Delete  Edit  Refresh  cMenuDataGridRow m� Command m� CommandTarget �� Path �� RelativeSource �� AncestorType  cMenuDataGrid)  #System.Windows.Controls.DataGridRow �� 
TargetType  DataGridRowBaseStyle �� BasedOn	 �� Property
 �� Value&   System.Windows.Controls.DataGrid  DataGridStyle��%&  &	        &	       &	 @     &	 `     &	 �     7  7  &	 V    7  '  �    7  7  '  e    7  7  �� 5   
   $ 添加��6&   �� 5	   
   $ 删除��6)   �� 5
   
   $ 编辑��6'   �� 5   
   $ 刷新��6*   �� 5   
   -   5        .@�5      m� 8    6   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   -   5        .@�5      m� 8    6   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   "  6   8   .�5      -   5        �� 5      	 �@�ContextMenu8
  6,   �� 5      	 � ��$
 26��6*   5      �� 5   
   "  6   8   .�5      �� 	 �@�ContextMenu8
  6,   5      5!       J� CommandBindings 5#      )  #System.Windows.Input.CommandBinding  5$   
   -   5           Command# [  5$      68     5%   
   -   5        # [ 5%      69     5&   
   -   5        # [ 5&      6;     5'   
   -   5        # [ 5'      6<   .��5)      ]� .+�5*   
   �  � RowDefinitions 5+      �� 5,      $
��auto �6    �� 5-      $
��auto �6    �� 5.      $��* �6    .+�51      %  Xceed.Wpf.Toolkit.BusyIndicator  $��2��6H      IsBusy 6!   �� *IsLoadingClientList+   BusyContent 52      �� 53      $��加载中...��6    $��20(�6.   $
��Bold"�6<   $��Center=�6N   $��Center=�6i   .��55        -	   5        $��dataGrid��55         AutoGenerateColumns .     SelectionMode$ Single=�6G      
IsReadOnly .    CanUserResizeRows .  ��56      �� *TradeConfigInfoList+   Columns 57      4  .System.Windows.Controls.DataGridTemplateColumn  59      ,  &System.Windows.Controls.DataGridColumn   Header$ 名称��61      CellTemplate 5:      �� 5;   "   .R�5<   &   �� $��0q�6?   
������  �� 
IsReadOnly . ��6.   Z� ��5=   *   �� *	ObjName+5>   #   5@        5B      $ 名称编码��61    5C      �� 5D   "   .R�5E   &   �� $��0q�6?   
������  . ��6.   Z� ��5F   *   �� *	ObjCode+5G   #   5I      0  *System.Windows.Controls.DataGridTextColumn  5J      $	 值��6-      MinWidth$	 150Q�6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *
ObjValue+6U     5K      $ 备注��6-      Width5	  /System.Windows.Controls.DataGridLengthConverter$ *	 6T    69   �� *Remark+6T   5M      5N      5O      5S      5T      