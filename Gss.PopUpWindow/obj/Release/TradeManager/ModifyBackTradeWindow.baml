   M S B A M L   `   `   `  ����   Gss.PopUpWindow8    2Gss.PopUpWindow.TradeManager.ModifyBackTradeWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -   $	��acc��  � WindowStartupLocation$  CenterScreen=� � SizeToContent$ Height=� � 
ResizeMode$ CanMinimize=� � WindowStyle$ 
ToolWindow=� � Title$ 处理买跌单��$	��160��$	��300��.����  �� CornerRadius$ 8��$��1q�$��10q�
����=H�._��  � RowDefinitions �� $��50 ���  � ColumnDefinitions �� $��80 ��� $��* �.+��� $��付款时间：��$��10q�$��25��(  "System.Windows.Controls.DatePicker  $��1��$��
0,10,10,10q�$��25��|�.  $��80��$
��Auto��   SelectedDate �� *	PayTime+	 �� ElementName$		 acc���� $��1��$��1��
 �� Orientation$
 
Horizontal=�.+��� -   $��btnOk��$��1��$��1��$��60��$��25��$��5q�$��确定���� -   $��	btnCancel��$��1��$��1��$��60��$��25��$��5q�$��取消��