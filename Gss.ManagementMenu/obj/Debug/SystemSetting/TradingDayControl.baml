   M S B A M L   `   `   `  ����J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null^@clr-namespace:Gss.PopUpWindow.Converter;assembly=Gss.PopUpWindowGss.PopUpWindow.Converter  5       Gss.ManagementMenu8   2Gss.ManagementMenu.SystemSetting.TradingDayControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      SpopCvt@clr-namespace:Gss.PopUpWindow.Converter;assembly=Gss.PopUpWindow     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  5      -   5          +� IsFocusScope  .  � 	Resources 5         
ViewDetail �� Text  
RefreshCmd  BoolVisibilityCvt1   +Gss.PopUpWindow.Converter.WeekEnumConverter  WeekCvt  CmTradingDayInfo m� Command m� CommandTarget �� Path �� RelativeSource �� AncestorType)  #System.Windows.Controls.DataGridRow �� 
TargetType  DataGridRowBaseStyle	 �� BasedOn
 �� Property �� Value��%8  &	        &	 &     &	 F     &	 Y     &	 l     7   7  '  4    7  7  �� 5	   
   $ 显示详细��6-   �� 5
   
   $ 刷新��6-   �� 5   
   6'     5   
   6#   �� 5   
   .@�5      m� 8    6   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   "  6   8	   .�5      -   5        �� 5      
 �@�ContextMenu8  6,   �� 5      
 � ��$ 26��6*   �� 5      
 � ��$ Center=�62   5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6?     5   
   -   5        # [ 5      6?   .��5!      ]� .+�5'   
   �  � RowDefinitions 5(      �� 5)      $
��auto �6    �� 5*      $��1* �6    .+�5,      � .+�5-      �� $��商品名称：��6   $��2q�6(   �� 5.      $	��180��6    �� SelectedValuePath$ 	StockCode��6R   ��6+   �� *ProductInfoes+ �� SelectedValue 5/      �� *TradingDaySearchCode+��50      �� 51      .R�52      ��  �� Orientation$ 
Horizontal=�6)   .+�53   "   �� ��6,   �� *ProductName+�� 54   "   $��-��6,   �� 55   "   ��6,   �� *	StockCode+56      57      59      �� 5;      $��60��6F   $��26��6Q   $	��5,2q�6]   ��6   �� *GetTradingDayInfoCommand+.��6k   查询6o   5<      %  Xceed.Wpf.Toolkit.BusyIndicator  5=      $��1��6L      IsBusy 6!   �� *IsLoadingTradingDayInfo+   BusyContent 5>      �� 5?      $��加载中...��6    $��20(�6.   $
��Bold"�6<   $��Center=�6N   $��Center=�6i   .��5A      &   System.Windows.Controls.DataGrid  -   5          Name$ DgShow��5A         AutoGenerateColumns .     SelectionMode$ Single=�6G      
IsReadOnly .    CanUserResizeRows .  ��5B      �� *TradingDayInfoes+   Columns 5C      4  .System.Windows.Controls.DataGridCheckBoxColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ 交易��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *
AllowTrade+0	  *System.Windows.Controls.DataGridTextColumn	  5E      $ 名称��6-      MinWidth$ 80Q�6v    69   �� *Week+ �� 	Converter# [ 6v   	  5F      $ 开盘时间��6-   $ 80Q�6Y    6;   �� *	StartTime+6Y   	  5G      $ 收盘时间��6-   $ 80Q�6W    6;   �� *	EndTime+6W   	  5H      $ 行情编码��6-   $ 80Q�6Y    6;   �� *	StockCode+6Y   	  5I      $ 描述��6-   $	 150Q�6U    69   �� *	DescMsg+6U   5K      5L      5M      5O      5P      