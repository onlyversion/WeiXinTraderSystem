   M S B A M L   `   `   `  ���� J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.PopUpWindow.CustomCotrolGss.PopUpWindow.CustomCotrol  /    )Gss.PopUpWindow.CustomCotrol.AutoComboBox   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     <local*clr-namespace:Gss.PopUpWindow.CustomCotrol     @d2http://schemas.microsoft.com/expression/blend/2008     -   $��UserC��  � 	Resources     SearchToggleButton �� 
TargetType ��Name F�Name �� Triggers P� Property P� Value �� 
TargetName �� Property	 �� Value��%  &	        �� " d�.R��� $ Border��
������ 
���   �$��1,0,0,0q�._�F� $ Arrow��
���   �$��Center=�$��Center=�$��16��$��16��|�.  "���� 	=  	= � �  	= � z  � 	 P�  �@J�IsMouseOver . . ��� $ Border�� � ��	 �	#FFB6C1D3.��� .+��� -   $��
borderRoot��$��1q�
���   �._�� 
 � ColumnDefinitions
 �� $��1* ��� $
��Auto �.+��� -   $	��Tbx��$��Center=�$��Center=�$��0q�
������ ��Z� ���� *
KeyWords+ �� ElementName$ UserC�� �� UpdateSourceTrigger$ PropertyChanged=�d� -   $��
Btn_Search��$��1��#��[  � $��Bottom=�$��20������ *	IsPopOpen+$ UserC������ *ActualWidth+$ 
borderRoot��.���� 
���   �$��1,0,1,1q�._��� -   $	��Lst��
������� �� SelectedValuePath �� *SelectedValuePath+$ UserC�� �� SelectedValue �� *SelectedValue+ �� Mode$ TwoWay=�$ PropertyChanged=�$ UserC������ *ItemsSource+$ UserC�� �� SelectedItem �� *	CurItem+$ TwoWay=�$ PropertyChanged=�$ UserC������ .R�7   1Gss.PopUpWindow.CustomCotrol.HeightLightTextBlock  ����    KeyWords �� *
KeyWords+ �� RelativeSource ��  �� AncestorLevel$ 1�� �� AncestorType/   )Gss.PopUpWindow.CustomCotrol.AutoComboBox"   �� Mode$ FindAncestor=�