   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    Gss.PopUpWindow2   ,Gss.PopUpWindow.DataManager.ExperienceWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9system&clr-namespace:System;assembly=mscorlib     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5        $	��Icc��5   .     � WindowStartupLocation$  CenterOwner=�5   	    � WindowStyle$ 
ToolWindow=�6-    � Title$ 	体验券��5   	   $	��250��6   $	��500��6"    � 	Resources 5       �� 
TargetType �� Property �� Value��%}   '��       �� 5	   
   " ��6   .�5
      ��  � ��$ Center=�62   �� 5       � ��$ Right=�64   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $��80 �6   �� 5      �� 5      $��80 �6   �� 5      .+�5   
   �� $��0��6   $��0��6!   $��	类型：��61   �� 5   
   -   5        	 ��Name$	 CbSex��5   0   $��0��6   $��1��6    
 �� SelectedIndex$
 1��5       �� SelectedValue 5   ?   �� *CurExperienceInformation.Name+ �� ElementName$	 Icc��.@�5      ��开户送券��6"   ��5       充值送券��6"   5!      �� 5"   
   $��0��6   $��2��6!   $��	启用：��61   �� 5#   
   $��0��6   $��3��6    $��Center=�60    d� 	IsChecked 6K   �� *$"CurExperienceInformation.Effective+$	 Icc���� 5%   
   $��1��6   $��0��6!   $��充值金额：��61   �� 5&   
   -   5        $��txtRceharge��5&   s   $��1��6   $��1��6   ��6/   �� *#!CurExperienceInformation.Rceharge+$	 Icc��6s   �� 5(   
   $��1��6   $��2��6!   $��赠送金额：��61   �� 5)   
   $��1��6   $��3��6   ��6/   �� *" CurExperienceInformation.Annount+$	 Icc���� 5+   
   $��2��6   $��0��6!   $��开始日期：��61   (  "System.Windows.Controls.DatePicker  5,   
   $��2��6   $��1��6"   |�.  $��2q�6E   $��Center=�6P      SelectedDate 5-      �� *	StartDate+$	 Icc���� 5/   
   $��2��6   $��2��6!   $��结束日期：��61     50   
   $��2��6   $��3��6"   |�.  $��2q�6E   $��Center=�6P    51      �� *	EndDate+$	 Icc���� 53   
   $��3��6   $��0��6!   $��	张数：��61   $  Xceed.Wpf.Toolkit.DoubleUpDown  54   
   -   5        $��DudCount��54      $��3��6,   $��1��69   $	��2,5q�6I   $��20��6V   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   SelectAllOnGotFocus .    	Increment$ 1X�55   k   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 6   �� *CurExperienceInformation.Num+$	 Icc�� 56       �� Triggers P� Property P� Value �� Path �� Self �� RelativeSource��%�   '        �� 57      "  6    58      P� 59       �@=�HasError . . �5:      ��  �@�ToolTip 5;   "   �� 5<   &   $2 ,(Validation.Errors).CurrentItem.ErrorContent�6.   # Z 6b   5>      5?      5A      5B      5C      �� 5E   
   $��3��6   $��2��6!   $��到期日期：��61     5F   
   $��3��6   $��3��6"   |�.  $��2q�6E   $��Center=�6P    5G      �� *EffectiveTime+$	 Icc���� 5I   
   $��4��6   $��0��6"   $��4��62    �� Orientation$ 
Horizontal=�6F   $��Right=�6_   .+�5J      �� -   5        $��btnOk��5J   3   $��1��6   $��1��6"   $��60��6V   $��25��6a   $��5q�6o   $��确定��6z   �� 5K      -   5        $��	btnCancel��5K   3   $��1��6   $��1��6"   $��60��6^   $��25��6i   $��5q�6w   $��取消��6�   5L      5M      5N      