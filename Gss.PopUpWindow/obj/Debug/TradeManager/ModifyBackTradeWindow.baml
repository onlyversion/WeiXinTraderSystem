   M S B A M L   `   `   `  ����  Gss.PopUpWindow8    2Gss.PopUpWindow.TradeManager.ModifyBackTradeWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5        $	��acc��5   0     � WindowStartupLocation$  CenterScreen=�5   	    � SizeToContent$ Height=�6.    � 
ResizeMode$ CanMinimize=�5   	    � WindowStyle$ 
ToolWindow=�6"    � Title$ 处理买跌单��5   	   $	��160��6   $	��300��6$   .��5      ��  �� CornerRadius$ 8��6   $��1q�6   $��10q�62   
����=H�._�5   
   �  � RowDefinitions 5	      �� 5
      $��50 �6    �� 5       � ColumnDefinitions 5      �� 5      $��80 �6#   �� 5      $��* �6#   .+�5      �� $��付款时间：��6   $��10q�6%   $��25��61   (  "System.Windows.Controls.DatePicker  5      $��1��6J   $��
0,10,10,10q�6Z   $��25��6n   |�.  $��80��6�   $
��Auto��6�      SelectedDate 6   �� *	PayTime+	 �� ElementName$		 acc��6�   �� 5      $��1��6   $��1��6&   
 �� Orientation$
 
Horizontal=�66   .+�5      �� -   5        $��btnOk��5   7   $��1��6   $��1��6&   $��60��6Z   $��25��6e   $��5q�6s   $��确定��6~   �� 5      -   5        $��	btnCancel��5   7   $��1��6   $��1��6&   $��60��6b   $��25��6m   $��5q�6{   $��取消��6�   5      5      5      5      