   M S B A M L   `   `   `  ����  Gss.ManagementMenu7    1Gss.ManagementMenu.SystemSetting.MACFilterControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  5      -   5          +� IsFocusScope  .  � 	Resources 5         
ViewDetail �� Text 
 Delete 
 AddCmd  
RefreshCmd  BoolVisibilityCvt  CmMacFilter m� Command m� CommandTarget �� Path �� RelativeSource �� AncestorType  CmMacFilter2)  #System.Windows.Controls.DataGridRow �� 
TargetType  DataGridRowBaseStyle	 �� BasedOn
 �� Property �� Value&   System.Windows.Controls.DataGrid  DataGridStyle��%l  &	        &	 &     &	 L     &	 l     &	 �     &	 �     7   7  7  7  &	     7  7  '  �    7  7  '  �    7  7  �� 5   
   $ 显示详细��6-   �� 5	   
   $ 删除记录��6)   �� 5
   
   $ 新增��6)   �� 5   
   $ 刷新��6-   �� 5   
   6'   �� 5   
   .@�5      m� 8    6   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   .@�5      m� 8    6   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   "  6   8	   .�5      -   5        �� 5      
 �@�ContextMenu8  6,   �� 5      
 � ��$ 26��6'   �� 5      
 � ��$ Center=�62   5      �� 5!   
   "  6   8	   .�5"      �� 
 �@�ContextMenu8  6,   5#      5$       J� CommandBindings 5&      )  #System.Windows.Input.CommandBinding  5'   
   -   5           Command# [  5'      6?     5(   
   -   5        # [ 5(      6;     5)   
   -   5        # [ 5)      6;     5*   
   -   5        # [ 5*      6?   .��5-      ]� .+�56   
   %  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy 6   �� *IsLoadingMACFilterInfo+   BusyContent 57      �� 58      $��加载中...��6   $��20(�6*   $
��Bold"�68   $��Center=�6J   $��Center=�6e   .��5:        -   5          Name$ DgShow��5:         AutoGenerateColumns .     SelectionMode$ Single=�6C      
IsReadOnly .    CanUserResizeRows .  ��5;      �� *MACFilterInfoes+   Columns 5<      4  .System.Windows.Controls.DataGridTemplateColumn  5>      ,  &System.Windows.Controls.DataGridColumn   Header$ MACIP��6-      MinWidth$	 150Q�6<      CellTemplate 5?      �� 5@      .R�5A   "   �� $��0q�6;   
������  �� 
IsReadOnly . ��6*   Z� ��5B   *   �� *
MACAddress+5C      5E      0  *System.Windows.Controls.DataGridTextColumn  5F      $ 描述��6)   $	 150Q�6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
FilterDesc+6T   5H      5I      5J      5K      