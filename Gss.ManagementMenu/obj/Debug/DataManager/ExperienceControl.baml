   M S B A M L   `   `   `  ����E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter  5      J FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulldCclr-namespace:Gss.PopUpWindow.CustomCotrol;assembly=Gss.PopUpWindowGss.PopUpWindow.CustomCotrol 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5       Gss.ManagementMenu6   0Gss.ManagementMenu.DataManager.ExperienceControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      L	converter6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     5      \customCotrolCclr-namespace:Gss.PopUpWindow.CustomCotrol;assembly=Gss.PopUpWindow     5      9system&clr-namespace:System;assembly=mscorlib     5        � 	Resources  5      2   ,Gss.Common.Converter.DateTimeFormatConverter   DateTimeCvt  
ViewDetail �� Text 
 Delete 
 AddCmd  menu m� Command m� CommandTarget �� Path �� RelativeSource �� AncestorType 	 menu2)  #System.Windows.Controls.DataGridRow �� 
TargetType  DataGridRowBaseStyle �� BasedOn	 �� Property
 �� Value&   System.Windows.Controls.DataGrid  DataGridStyle��%�  &	        &	      &	 <     &	 e     &	 �     7  7  7  &	 �    7  '  :    7  7  '  �    7  7    5   
   6,   �� 5   
   $ 查看体验券��6-   �� 5   
   $ 删除体验券��6)   �� 5   
   $ 新增体验券��6)   �� 5   
   -   5        .@�5      m� 8    6   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   -   5        .@�5      m� 8    6   �� $ PlacementTarget� �� $ ContextMenuL�6�   5      �� 5   
   "  6   8   .�5      -   5        �� 5      	 �@�ContextMenu8
  6,   �� 5      	 � ��$
 26��6*   5      �� 5    
   "  6   8   .�5!      �� 	 �@�ContextMenu8
  6,   �� 5"      	 � ��$
 26��6*   5#      5$       J� CommandBindings 5&      )  #System.Windows.Input.CommandBinding  5'   
   -   5           Command# [ 5'      6?     5(   
   -   5        # [ 5(      6;     5)   
   -   5        # [ 5)      6;   .��5,      ]� .+�5-   
   � $��2q�6   $	��Top=�6     5.      ��%�   '��       �� 5/      " ��6   .�50      �� 	 � ��$
 Center=�6:   �� 51      	 � ��$
 2q�6/   �� 52      	 � ��

 �   �63   53      54      .+�55      ��  �� Orientation$ 
Horizontal=�6   .+�56      �� $��	类型：��6   �� 57      -   5        $��cmbType��57       �� SelectedIndex$ 0��6*   $��Center=�6<   $��2q�6W   $��88��6b   .@�58      ��
全部��6(   ��59      开户送券��6*   ��5:      充值送券��6*   5;      5<      �� 5>      $��10q�6   $ 
Horizontal=�6%   .+�5?      �� $��启用状态：��6   �� 5@      -   5        $��cmdState��5@      $ 0��6+   $��Center=�6=   $��2q�6X   $��88��6c   .@�5A      ��
全部��6(   ��5B      
启用��6(   ��5C      	未启用��6)   5D      5E      �� 5H      $ 
Horizontal=�6   .+�5I      �� $��到期时间:��6   (  "System.Windows.Controls.DatePicker  5J      -	   5        $��dpTime��5J      |�.  $��2q�6>   $��Center=�6I   $	��120��6d   5K      �� 5L      -
   5        $��查询��5L      $��60��6#   $��26��6.   $	��5,2q�6:   $
��Left=�6G   6d   5M        5N   
   -   5        $��dgGrid��5O         AutoGenerateColumns .     SelectionMode$ Single=�5N   /      
IsReadOnly .    CanUserResizeRows .     Columns 5P      4  .System.Windows.Controls.DataGridCheckBoxColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6*      Header$ 是否有效��65   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6C   �� *	Effective+0
  *System.Windows.Controls.DataGridTextColumn
  5R      $ 70 6%   $ 类型��60    6<   �� *Name+
  5S      $ 70 6&   $ 金额��61    6=   �� *	Annount+
  5T      $ 70 6%   $ 充值金额��60    6>   �� *
Rceharge+
  5U      $ 70 6%   $ 张数��60    6<   �� *Num+
  5V      $	 140 6%   $ 开始日期��61    6?   �� *	StartDate+ �� 	Converter# [  
  5W      $	 140 6&   $ 结束日期��62    6@   �� *	EndDate+# [  
  5Y      $	 140 6&   $ 到期时间��62    6@   �� *EffectiveTime+# [  5]      5^      5_      