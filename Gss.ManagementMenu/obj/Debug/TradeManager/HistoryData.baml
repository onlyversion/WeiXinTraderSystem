   M S B A M L   `   `   `  ����M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      1    +Gss.ManagementMenu.TradeManager.HistoryData   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >cus.clr-namespace:Gss.ManagementMenu.CustomControl     5      6sys&clr-namespace:System;assembly=mscorlib     5      -   5          � 	Resources  5
         DataFromEnum S� 
MethodName S� 
ObjectType  System.Enum  AlterCmd �� Text  BoolVisibilityCvt  	CmHisData m� Command m� CommandTarget �� Path �� RelativeSource �� AncestorType)  #System.Windows.Controls.DataGridRow	 �� 
TargetType  DataGridRowBaseStyle
 �� BasedOn �� Property �� Value��%�  &	        &	 6     &	 V     &	 i     7  '  �     7  7  S� 5   
   $ 	GetValues��62   "  6I   5      �� 5   
   $ 修改��6+   �� 5   
   6'   �� 5   
   .@�5      m� 8    6   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   "	  6   8
   .�5      ��  �@�ContextMenu8  6,   �� 5       � ��$ 26��6*   �� 5       � ��$ Center=�62   5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5    
   -   5           Command# [ 5       6=   .��5#      �  � RowDefinitions 5$   
   �� 5%      $
��auto �6   �� 5&      $
��auto �6   �� 5'      $
��343* �6   .+�5)   
   �  � Orientation$ 
Horizontal=�6   $��0,5,0,0q�6-   .+�5*      �� $��商品名称：��6   $��Center=�6$   �� 5+      $	��100��6    �� DisplayMemberPath$ ProductName��6L    �� SelectedValuePath$ 	StockCode��6l   ��6&   �� *ProductInfoes+ �� SelectedValue 6�   �� *'%GetHistoryDataCondition.ProductNumber+5-      �� 5/      $��	周期：��6   $��Center=�6"   �� 50      $	��100��6   ��6&   �� *CycleSource+ 6J   �� *GetHistoryDataCondition.Cycle+52      �� 54      $��开始时间：��6   $��Center=�6$   (  "System.Windows.Controls.DatePicker  55      $��Center=�6   |�.     SelectedDate 64   �� *#!GetHistoryDataCondition.StartTime+6p   �� 57      $��结束时间：��6   $��Center=�6$     58      $��Center=�6   |�.   64   �� *!GetHistoryDataCondition.EndTime+6m   �� 5:      $��周期时间：��6   $��Center=�6$   �� 5;      $	��120��6m   ��6   �� *" GetHistoryDataCondition.weektime+ �� UpdateSourceTrigger$ PropertyChanged=�6m   �� 5<      $��60��6   $��26��6    $	��5,2q�6,   $��查询��69   $��Center=�6F   ��6a   �� *GetHisDatasCommand+5?      5   /Gss.ManagementMenu.CustomControl.DataPagePicker  5@   
   5   /Gss.ManagementMenu.CustomControl.DataPagePicker   PageChanged$ dataPage_PageChanged��6*   $��1��6      CurrentPageItemCount 6O   �� *Items.Count+ �� ElementName$ DgResult��   	PageCount 5A       �� *#!GetHistoryDataCondition.PageCount+ �� Mode$ TwoWay=�   PageSize 6d   �� *" GetHistoryDataCondition.PageSize+$ TwoWay=�   	PageIndex 5B       �� *#!GetHistoryDataCondition.PageIndex+$ TwoWay=�&   System.Windows.Controls.DataGrid  5D   
   -   5        $��DgResult��5D      $��2��6      AutoGenerateColumns .     SelectionMode$ Single=�6<      
IsReadOnly .     CanUserResizeRows  .  ��5E      �� *
HisDataLst+! �� SelectedItem! 66   �� *
CurHisData+"   Columns" 5H      0  *System.Windows.Controls.DataGridTextColumn  5J      ,	  &System.Windows.Controls.DataGridColumn# 	  Header$# 	开盘价��6&   $ 	  MinWidth$	$ 100Q�6Q   1
  +System.Windows.Controls.DataGridBoundColumn% 
  Binding% 63   �� *	Openprice+6Q     5K      $# 	最高价��6%   $	$ 100Q�6P   % 62   �� *	Highprice+6P     5L      $# 	最低价��6%   $	$ 100Q�6O   % 62   �� *
Lowprice+6O     5M      $# 	收盘价��6%   $	$ 100Q�6Q   % 62   �� *
Closeprice+6Q   4  .System.Windows.Controls.DataGridTemplateColumn  5O      $# 时间��6)   $	$ 100Q�65   &   CellTemplate& 5P      �� 5Q      .R�5R      �� $��0q�67   
������ ' �� 
IsReadOnly' . ��6&   Z� ��6v   �� *
Weektime+5S      5U      5Y      5Z      5[      