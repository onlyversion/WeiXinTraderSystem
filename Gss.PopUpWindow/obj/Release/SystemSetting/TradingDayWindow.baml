   M S B A M L   `   `   `  ���� J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gss.PopUpWindow.ConverterGss.PopUpWindow.Converter  &     Gss.PopUpWindow.TradingDayWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  1cvt'clr-namespace:Gss.PopUpWindow.Converter    � WindowStartupLocation$  CenterOwner=� � WindowStyle$ 
ToolWindow=� � Title$ 交易日信息��$	��260��$	��300�� � 	Resources    Ok �� Text 
 Cancel1   +Gss.PopUpWindow.Converter.WeekEnumConverter  WeekCvt5   /Gss.PopUpWindow.Converter.DateLongTimeConverter  LongTimeCvt��%V   &	        &	      &	 $     &	 )     �� $ 确定���� $ 取消��     J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [ .��]� .+��� $��Bottom=� �� Orientation$ 
Horizontal=�$��Right=�.+��� $��确定��$��88��$��5q�#��[   �� 	IsDefault . �� $��取消��$��88��$��5q�#��[ 	 �� IsCancel	 . �� $
��Auto=�.���  
 �� 
TargetType �� Property �� Value��%]   '��       �� "
 ��.���  � ��$ 2q���  � ��$ Right=���  � ��$
 Bold"� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��	名称：���� $��1��$��启用交易：���� $��2��$��开盘时间：���� $��3��$��收盘时间：���� $��4��$��行情编码：���� $��5��$��描述信息：���� $��1��$��2q�$��Center=����� *Week+ �� 	Converter# [ �� $��1��$��1��$��2q�$��Center=� d� 	IsChecked �� *
AllowTrade+"  Xceed.Wpf.Toolkit.TimePicker  $��2��$��1��   TimeInterval$
 1:00h�   	Watermark$ 输入开盘时间��   Format$ Custom=�   FormatString$ HH:mm:ss��$��2q�   Value �� *	StartTime+ �� Mode$ TwoWay=�# [   $��3��$��1��$
 1:00h�$ 输入收盘时间��$ Custom=�$ HH:mm:ss��$��2q�   	StartTime$ 00:59:59h�   EndTime$ 23:59:59h� �� *	EndTime+$ TwoWay=�# [ �� $��4��$��1�� �� TextWrapping$ WrapWithOverflow=� �� AcceptsReturn .  �� MinLines$ 3�� �� 
IsReadOnly . $��2q����� *	StockCode+$ OneWay=��� $��5��$��1��$ WrapWithOverflow=� . $ 3�� �� 	MaxLength$	 100��$��2q����� *	DescMsg+$ TwoWay=�