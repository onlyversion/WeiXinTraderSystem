   M S B A M L   `   `   `  ����J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Gss.PopUpWindow.CustomCotrolGss.PopUpWindow.CustomCotrol  5      /    )Gss.PopUpWindow.CustomCotrol.AutoComboBox   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      <local*clr-namespace:Gss.PopUpWindow.CustomCotrol     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        $��UserC��5   4     � 	Resources  5	         SearchToggleButton �� 
TargetType ��Name F�Name �� Triggers P� Property P� Value �� 
TargetName �� Property	 �� Value��%�  &	        �� 5
   
   " d�65   .R�5      �� $ Border��5      
������ 
���   �$��1,0,0,0q�5      ._�5      F� $ Arrow��5      
���   �$��Center=�5      $��Center=�5      $��16��6*   $��16��65   |�.  "���� 	=  	= � �  	= � z  � 	6S   5       5      P� 5       �@J�IsMouseOver . . �5      �� $ Border��6    � ��	 �	#FFB6C1D36G   5      5      5      .��5      � .+�5   
   �� -   5        $��
borderRoot��5      $��1q�6#   
���   �._�5       � 
 � ColumnDefinitions
 5!      �� 5"      $��1* �6'   �� 5#      $
��Auto �6'   .+�5%      �� -   5        $	��Tbx��5&   4   $��Center=�5%   ,   $��Center=�6N   $��0q�6i   
������ ��6   Z� ��5&   ?   �� *
KeyWords+ �� ElementName$ UserC�� �� UpdateSourceTrigger$ PropertyChanged=�5'   9   d� 5)      -   5        $��
Btn_Search��5)       $��1��62   #��[  6[   5+      5,      � 5-   
   $��Bottom=�6@   $��20��6S   ��6   �� *	IsPopOpen+$ UserC����6b   �� *ActualWidth+$ 
borderRoot��.��5.      �� 
���   �$��1,0,1,1q�6)   ._�5/      �� -   5        $	��Lst��5/      
������� �� SelectedValuePath 50      �� *SelectedValuePath+$ UserC�� �� SelectedValue 51      �� *SelectedValue+ �� Mode$ TwoWay=�$ PropertyChanged=�$ UserC����52      �� *ItemsSource+$ UserC�� �� SelectedItem 54      �� *	CurItem+$ TwoWay=�$ PropertyChanged=�$ UserC����56      �� 57      .R�58      7   1Gss.PopUpWindow.CustomCotrol.HeightLightTextBlock  ��69   ��    KeyWords 6K   �� *
KeyWords+ �� RelativeSource ��  �� AncestorLevel$ 1�� �� AncestorType/   )Gss.PopUpWindow.CustomCotrol.AutoComboBox"   �� Mode$ FindAncestor=�59      5<      5=      5>      5?      5@      