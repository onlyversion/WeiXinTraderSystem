   M S B A M L   `   `   `  ����J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gss.PopUpWindow.ConverterGss.PopUpWindow.Converter  5   	   &     Gss.PopUpWindow.TradingDayWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   1cvt'clr-namespace:Gss.PopUpWindow.Converter  5   	     � WindowStartupLocation$  CenterOwner=�5   	    � WindowStyle$ 
ToolWindow=�6-    � Title$ 交易日信息��5   	   $	��260��6   $	��300��6$    � 	Resources 5         Ok �� Text 
 Cancel1   +Gss.PopUpWindow.Converter.WeekEnumConverter  WeekCvt5   /Gss.PopUpWindow.Converter.DateLongTimeConverter  LongTimeCvt��%�   &	        &	       &	 @     &	 S     �� 5	   
   $ 确定��6%   �� 5
   
   $ 取消��6)     5   
   6      5   
   6$   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      67     5   
   -   5        # [ 5      6;   .��5      ]� .+�5   
   �� $��Bottom=�6    �� Orientation$ 
Horizontal=�6-   $��Right=�6F   .+�5      �� $��确定��6   $��88��6"   $��5q�6-   #��[  68    �� 	IsDefault . 6V   �� 5      $��取消��6   $��88��6"   $��5q�6-   #��[ 68   	 �� IsCancel	 . 6Z   5      �� 5   
   $
��Auto=�6   .��5      �  5      
 �� 
TargetType �� Property �� Value��%�   '��       �� 5      "
 ��6   .�5      ��  � ��$ 2q�63   �� 5       � ��$ Right=�6@   �� 5        � ��$
 Bold"�67   5!      5"       � RowDefinitions 5#      �� 5$      $
��Auto �6$   �� 5%      $
��Auto �6$   �� 5&      $
��Auto �6$   �� 5'      $
��Auto �6$   �� 5(      $
��Auto �6$   �� 5)      $
��Auto �6$    � ColumnDefinitions 5+      �� 5,      $
��Auto �6'   �� 5-      $��* �6'   .+�50      �� $��	名称：��6   �� 51      $��1��6   $��启用交易：��6%   �� 52      $��2��6   $��开盘时间：��6%   �� 53      $��3��6   $��收盘时间：��6%   �� 54      $��4��6   $��行情编码：��6%   �� 55      $��5��6   $��描述信息：��6%   �� 58      $��1��6   $��2q�6,   $��Center=�67   ��59      �� *Week+ �� 	Converter# [ �� 5:      $��1��6   $��1��6(   $��2q�68   $��Center=�5;   8    d� 	IsChecked 6   �� *
AllowTrade+68   "  Xceed.Wpf.Toolkit.TimePicker  5<      $��2��6"   $��1��6/      TimeInterval$
 1:00h�6?      	Watermark$ 输入开盘时间��6S      Format$ Custom=�6f      FormatString$ HH:mm:ss��6v   $��2q�6�      Value 5=      �� *	StartTime+ �� Mode$ TwoWay=�# [   5>      $��3��6"   $��1��6/   $
 1:00h�6?   $ 输入收盘时间��6S   $ Custom=�6f   $ HH:mm:ss��6v   $��2q�6�      	StartTime$ 00:59:59h�5?         EndTime$ 23:59:59h�63    5@      �� *	EndTime+$ TwoWay=�# [ �� 5B      $��4��6   $��1��6'    �� TextWrapping$ WrapWithOverflow=�67    �� AcceptsReturn .  �� MinLines$ 3��6l    �� 
IsReadOnly . $��2q�6�   ��5C      �� *	StockCode+$ OneWay=��� 5E      $��5��6   $��1��6'   $ WrapWithOverflow=�67    . $ 3��6l    �� 	MaxLength$	 100��6y   $��2q�6�   ��5F      �� *	DescMsg+$ TwoWay=�5G      5H      5I      5J      