   M S B A M L   `   `   `  ���� E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter  J FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulldCclr-namespace:Gss.PopUpWindow.CustomCotrol;assembly=Gss.PopUpWindowGss.PopUpWindow.CustomCotrol O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  Gss.ManagementMenu6   0Gss.ManagementMenu.DataManager.ExperienceControl   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     L	converter6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     \customCotrolCclr-namespace:Gss.PopUpWindow.CustomCotrol;assembly=Gss.PopUpWindow     9system&clr-namespace:System;assembly=mscorlib       � 	Resources  2   ,Gss.Common.Converter.DateTimeFormatConverter   DateTimeCvt  
ViewDetail �� Text 
 Delete 
 AddCmd  menu m� Command m� CommandTarget �� Path �� RelativeSource �� AncestorType 	 menu2)  #System.Windows.Controls.DataGridRow �� 
TargetType  DataGridRowBaseStyle �� BasedOn	 �� Property
 �� Value&   System.Windows.Controls.DataGrid  DataGridStyle��%�  &	        &	      &	       &	 ;     &	 V     7  7  7  &	 /    7  '  �    7  7  '  �    7  7    �� $ 查看体验券���� $ 删除体验券���� $ 新增体验券���� -   .@�m� 8    �� $ PlacementTarget� �� $ ContextMenuL�m� 8   �� $ PlacementTarget� �� $ ContextMenuL�m� 8   �� $ PlacementTarget� �� $ ContextMenuL��� -   .@�m� 8    �� $ PlacementTarget� �� $ ContextMenuL��� "  8   .�-   �� 	 �@�ContextMenu8
  �� 	 � ��$
 26���� "  8   .��� 	 �@�ContextMenu8
  �� 	 � ��$
 26�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [   -   # [ .��]� .+�� $��2q�$	��Top=�  ��%^   '��       �� " ��.��� 	 � ��$
 Center=��� 	 � ��$
 2q��� 	 � ��

 �   �.+���  �� Orientation$ 
Horizontal=�.+��� $��	类型：���� -   $��cmbType�� �� SelectedIndex$ 0��$��Center=�$��2q�$��88��.@���
全部����开户送券����充值送券���� $��10q�$ 
Horizontal=�.+��� $��启用状态：���� -   $��cmdState��$ 0��$��Center=�$��2q�$��88��.@���
全部����
启用����	未启用���� $ 
Horizontal=�.+��� $��到期时间:��(  "System.Windows.Controls.DatePicker  -	   $��dpTime��|�.  $��2q�$��Center=�$	��120���� -
   $��查询��$��60��$��26��$	��5,2q�$
��Left=�  -   $��dgGrid��   AutoGenerateColumns .     SelectionMode$ Single=�   
IsReadOnly .    CanUserResizeRows .     Columns 4  .System.Windows.Controls.DataGridCheckBoxColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70    Header$ 是否有效��1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding �� *	Effective+0
  *System.Windows.Controls.DataGridTextColumn
  $ 70 $ 类型�� �� *Name+
  $ 70 $ 金额�� �� *	Annount+
  $ 70 $ 充值金额�� �� *
Rceharge+
  $ 70 $ 张数�� �� *Num+
  $	 140 $ 开始日期�� �� *	StartDate+ �� 	Converter# [  
  $	 140 $ 结束日期�� �� *	EndDate+# [  
  $	 140 $ 到期时间�� �� *EffectiveTime+# [  