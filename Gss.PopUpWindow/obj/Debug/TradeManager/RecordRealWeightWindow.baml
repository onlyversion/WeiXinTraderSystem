   M S B A M L   `   `   `  ����  Gss.PopUpWindow9    3Gss.PopUpWindow.TradeManager.RecordRealWeightWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5        $	��acc��5   /     � SizeToContent$  Height=�5   	    � 
ResizeMode$ CanMinimize=�5   	    � Title$ 买跌检测��5   	   $	��170��6   $	��300��6#    � WindowStartupLocation$ CenterScreen=�6:    � WindowStyle$ 
ToolWindow=�6_    � 	Resources 5       �� 
TargetType   TextBoxStyle �� BasedOn �� Property	 �� Value
 �� Triggers P� Property P� Value �� Path �� Self �� RelativeSource��%w  '��       7   �� 5	   
   " ��6   8   .�5
      ��  � ��$	 Stretch=�64   �� 5       � ��$	 Center=�62   �� 5       � ��$	 5,2,10,2q�6'   
 5      P� 5       �@=�HasError . . �5      ��  �@�ToolTip	 5      �� 5      $2 ,(Validation.Errors).CurrentItem.ErrorContent�6&   # Z 6Z   5      5      5      5      .��5      ��  �� CornerRadius$ 8��6   $��1q�6   $��10q�62   
����=H�._�5   
   �  � RowDefinitions 5      �� 5      $��45 �6    �� 5      $��25 �6    �� 5       � ColumnDefinitions 5      �� 5       $��80 �6#   �� 5!      $��* �6#   .+�5#      �� $��实际重量：��6   $��
10,15,10,0q�6%   $��25��69   �� 5$      $��1��6   $��2��6%   $9��3注意：白银单位为千克，其它单位为克��69   $��	30,2,10,0q�6R   $��25��6e   
���  ��6q   �� 5%      $��1��6   $��
0,10,10,10q�6'   $��25��6;   $��80��6H   $
��Auto��6V   .��6c   ��5&      �� 5'      $ 
RealWeight�6    �� ElementName$	 acc��60    �� UpdateSourceTrigger$ PropertyChanged=�6B   5)      .��5*       5+      �� 5,      $��2��6   $��1��6&    �� Orientation$ 
Horizontal=�66   .+�5-      �� -   5        $��btnOk��5-   7   $��1��6   $��1��6&   $��60��6Z   $��25��6e   $��5q�6s   $��确定��6~   �� 5.      -   5        $��	btnCancel��5.   7   $��1��6   $��1��6&   $��60��6b   $��25��6m   $��5q�6{   $��取消��6�   5/      50      51      52      