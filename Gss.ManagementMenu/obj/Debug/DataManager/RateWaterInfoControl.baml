   M S B A M L   `   `   `  ����  Gss.ManagementMenu9    3Gss.ManagementMenu.DataManager.RateWaterInfoControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  5      -   5          +� IsFocusScope  .  � 	Resources 5         
ViewDetail �� Text  
RefreshCmd  CmRateWaterInfo m� Command m� CommandTarget �� Path �� RelativeSource �� AncestorType)  #System.Windows.Controls.DataGridRow �� 
TargetType  DataGridRowBaseStyle	 �� BasedOn
 �� Property �� Value��%�  &	        &	 &     &	 F     7   7  '      7  7  �� 5   
   $ 详细信息��6-   �� 5	   
   $ 刷新��6-   �� 5   
   .@�5      m� 8    6   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   "  6   8	   .�5      -   5        �� 5      
 �@�ContextMenu8  6,   �� 5      
 � ��$ 26��6*   5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6?     5   
   -   5        # [ 5      6?   .��5      ]� .+�5"   
   %  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy 6   �� *IsLoadingRateWaterInfoList+   BusyContent 5#      �� 5$      $��加载中...��6   $��20(�6*   $
��Bold"�68   $��Center=�6J   $��Center=�6e   .��5&      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     SelectionMode$ Single=�63      
IsReadOnly .    CanUserResizeRows .  ��5'      �� *RateWaterInfoes+   Columns 5(      4  .System.Windows.Controls.DataGridTemplateColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ 行情名称��6-      CellTemplate 5+      �� 5,      .R�5-   "   �� $��0q�6;   
������  �� 
IsReadOnly . ��6*   Z� ��5.   <   �� *	StockCode+5/      51      0  *System.Windows.Controls.DataGridTextColumn  52      $ 汇率��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Rate+  53      $	 水��6)    64   �� *Water+55      56      57      58      