   M S B A M L   `   `   `  ����   Gss.ManagementMenu5    /Gss.ManagementMenu.CustomControl.DataPagePicker   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -   $��dp��$��Stretch=�  J� CommandBindings  )  #System.Windows.Input.CommandBinding  -      Command$ 	FirstPage��  -   $ PreviousPage��  -   $ NextPage��  -   $ LastPage��  -   $ Refresh��.����  �� Orientation$ 
Horizontal=�.+��� -   $��
cbPageSize��$��Center=�$��50��$��5,0,0,0q� � ToolTip$ 每页显示数量��$
��Left=�$��40������  �� Path$ PageSizeItems� �� ElementName$ dp�� �� SelectedItem �� $ PageSize� �� Mode$ TwoWay=�$ dp���� $��1��$��Center=�$ 
Horizontal=�$��5,0,0,0q�{��� $ 	PageCount�$ dp�� � 	Resources 	 �� 
TargetType
 �� Property �� Value �� 
TargetType J� SnapsToDevicePixels �� Triggers P� Property P� Value �� 
TargetName��%  '��       '�� �     �� "	 ��.��� 
 � �� �� " ��.R��� $��	container��#��z��#��z����.  . #��z�� P�  � {� .  . ��� # � ��
 � ���� $ 	container��
 �@J�Opacity$
 0.35Q��� "	 ��.��� 
 � ��$ 15���� 
 � ��$ 15��.+��� $��	FirstPage��$ 首页��$��2q�.���� $4��./Gss.ManagementMenu;component/Images/First.png��$
��None=��� $��PreviousPage��$ 	前一页��$��2q�.���� $6��0/Gss.ManagementMenu;component/Images/Preview.png��$
��None=��� -   $��tbPageIndex��$��50��$��2q����� *	PageIndex+$ TwoWay=�$ dp���� $��NextPage��$ 	下一页��$��2q�.���� $3��-/Gss.ManagementMenu;component/Images/Next.png��$
��None=��� $��LastPage��$ 尾页��$��2q�.���� $3��-/Gss.ManagementMenu;component/Images/Last.png��$
��None=��� $��Refresh��$ 刷新��$��2q�.���� $5��//Gss.ManagementMenu;component/Images/Reload.png��$
��None=��� $��2��$��Center=�$��5,0,0,0q�	共有 �� $��Center=����#287cd9���� $ 	PageCount�$ dp�� 页�� $��2��$��Center=�$��5,0,0,0q�当前页有 �� $��Center=����#287cd9���� $ CurrentPageItemCount�$ dp�� 项