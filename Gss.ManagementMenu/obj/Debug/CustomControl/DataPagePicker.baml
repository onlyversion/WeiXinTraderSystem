   M S B A M L   `   `   `  ����  Gss.ManagementMenu5    /Gss.ManagementMenu.CustomControl.DataPagePicker   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��dp��5      $��Stretch=�6     J� CommandBindings  5      )  #System.Windows.Input.CommandBinding  5	   
   -   5           Command$ 	FirstPage��5	      6Z     5
   
   -   5        $ PreviousPage��5
      6`     5   
   -   5        $ NextPage��5      6X     5   
   -   5        $ LastPage��5      6X     5   
   -   5        $ Refresh��5      6+   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5   
   �� -   5        $��
cbPageSize��5   .   $��Center=�6   $��50��6@   $��5,0,0,0q�6N    � ToolTip$ 每页显示数量��6_   $
��Left=�6p   $��40��6�   ��5      ��  �� Path$ PageSizeItems� �� ElementName$ dp�� �� SelectedItem 5      �� $ PageSize� �� Mode$ TwoWay=�$ dp���� 5   
   $��1��6   $��Center=�6%   $ 
Horizontal=�6@   $��5,0,0,0q�6Y   {�5      �� $ 	PageCount�$ dp�� � 	Resources 5      	 �� 
TargetType
 �� Property �� Value �� 
TargetType J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName��%�  '��       '�� i    �� 5      "	 ��6   .�5      �� 
 � �� 5      �� 5      " ��6.   .R�5   "   �� $��	container��63   #��z��6D   #��z��6�   ��.  . #��z��6�    5   "   P� 5   &    � {� .  . �5   *   �� # � ��6G   
 � ���� 5   *   $ 	container��6Q   
 �@J�Opacity$
 0.35Q�6D   6Q   5   '   5!      5#      5$      �� 5%      "	 ��6   .�5&      �� 
 � ��$ 15��6.   �� 5'      
 � ��$ 15��6/   5(      5)      .+�5*      �� $��	FirstPage��6   $ 首页��6)   $��2q�66   .��5+      �� $4��./Gss.ManagementMenu;component/Images/First.png��6   $
��None=�6P   5,      �� 5-      $��PreviousPage��6   $ 	前一页��6,   $��2q�6:   .��5.      �� $6��0/Gss.ManagementMenu;component/Images/Preview.png��6   $
��None=�6R   5/      �� 50      -   5        $��tbPageIndex��50   !   $��50��6   $��2q�64   ��53      �� *	PageIndex+$ TwoWay=�$ dp���� 54      $��NextPage��6   $ 	下一页��6(   $��2q�66   .��55      �� $3��-/Gss.ManagementMenu;component/Images/Next.png��6   $
��None=�6O   56      �� 57      $��LastPage��6   $ 尾页��6(   $��2q�65   .��58      �� $3��-/Gss.ManagementMenu;component/Images/Last.png��6   $
��None=�6O   59      �� 5:      $��Refresh��6   $ 刷新��6'   $��2q�64   .��5;      �� $5��//Gss.ManagementMenu;component/Images/Reload.png��6   $
��None=�6Q   5<      5=      �� 5>   
   $��2��6   $��Center=�6$   $��5,0,0,0q�6?   	共有 �� 5?      $��Center=�6   ���#287cd9��66   �� $ 	PageCount�$ dp��6f    页5@      �� 5A   
   $��2��6   $��Center=�6$   $��5,0,0,0q�6?   当前页有 �� 5B      $��Center=�6   ���#287cd9��68   �� $ CurrentPageItemCount�$ dp��6s    项5C      5D      5~      