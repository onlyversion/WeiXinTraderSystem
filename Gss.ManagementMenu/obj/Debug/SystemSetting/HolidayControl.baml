   M S B A M L   `   `   `  ����M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter  5      E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter 5      5    /Gss.ManagementMenu.SystemSetting.HolidayControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :cvt*clr-namespace:Gss.ManagementMenu.Converter     5      HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  5      -   5          +� IsFocusScope  .  � 	Resources 5	         
ViewDetail �� Text 
 Delete 
 AddCmd  
RefreshCmd  BoolVisibilityCvt2  ,Gss.Common.Converter.DateTimeFormatConverter  DateTimeCvt  	CmHoliday m� Command m� CommandTarget �� Path �� RelativeSource �� AncestorType  
CmHoliday2)  #System.Windows.Controls.DataGridRow �� 
TargetType  DataGridRowBaseStyle	 �� BasedOn
 �� Property �� Value&   System.Windows.Controls.DataGrid 	 DataGridStyle��%�  &	        &	 &     &	 L     &	 l     &	 �     &	 �     &	 �     7   7  7  7  &	 (    7  7  '  �    7  7  '  �    7 	 7  �� 5
   
   $ 显示详细��6-   �� 5   
   $ 删除记录��6)   �� 5   
   $ 新增��6)   �� 5   
   $ 刷新��6-   �� 5   
   6'     5   
   6(   �� 5   
   .@�5      m� 8    6   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   .@�5      m� 8    6   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   "  6   8	   .�5      -   5        �� 5      
 �@�ContextMenu8  6,   �� 5       
 � ��$ 26��6*   �� 5!      
 � ��$ Center=�62   5"      �� 5#   
   "  6   8	   .�5$      �� 
 �@�ContextMenu8  6,   5%      5'       J� CommandBindings 5)      )  #System.Windows.Input.CommandBinding  5*   
   -   5           Command# [  5*      6?     5+   
   -   5        # [ 5+      6;     5,   
   -   5        # [ 5,      6;     5-   
   -   5        # [ 5-      6?   .��50      ]� .+�59   
   %  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy 6   �� *IsLoadingHolidayInfo+   BusyContent 5:      �� 5;      $��加载中...��6   $��20(�6*   $
��Bold"�68   $��Center=�6J   $��Center=�6e   .��5=        -   5          Name$ DgShow��5=         AutoGenerateColumns .     SelectionMode$ Single=�6C      
IsReadOnly .    CanUserResizeRows .  ��5>      �� *HolidayInfoes+   Columns 5?      4  .System.Windows.Controls.DataGridTemplateColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$ 	节日名��6-      CellTemplate 5B      �� 5C      .R�5D   "   �� $��0q�6;   
������  �� 
IsReadOnly . ��6*   Z� ��5E   *   �� *HolidayName+5F      5H      0  *System.Windows.Controls.DataGridTextColumn  5I      $ 开始时间��6)      MinWidth$ 80Q�6}   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 67   �� *	StartTime+ �� 	Converter# [ 6}     5J      $ 结束时间��6)   $ 80Q�6{    67   �� *	EndTime+# [ 6{     5K      $ 编码��6)   $	 150Q�6S    65   �� *	StockCode+6S     5L      $ 描述��6)   $	 150Q�6Q    65   �� *	DescMsg+6Q   5N      5O      5P      5Q      