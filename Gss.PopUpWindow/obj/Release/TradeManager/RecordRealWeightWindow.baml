   M S B A M L   `   `   `  ����   Gss.PopUpWindow9    3Gss.PopUpWindow.TradeManager.RecordRealWeightWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -   $	��acc��  � SizeToContent$  Height=� � 
ResizeMode$ CanMinimize=� � Title$ 买跌检测��$	��170��$	��300�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ 
ToolWindow=� � 	Resources  �� 
TargetType   TextBoxStyle �� BasedOn �� Property	 �� Value
 �� Triggers P� Property P� Value �� Path �� Self �� RelativeSource��%�   '��       7   �� " ��8   .���  � ��$	 Stretch=���  � ��$	 Center=���  � ��$	 5,2,10,2q�
 P�  �@=�HasError . . ���  �@�ToolTip	 �� $2 ,(Validation.Errors).CurrentItem.ErrorContent�# Z .����  �� CornerRadius$ 8��$��1q�$��10q�
����=H�._��  � RowDefinitions �� $��45 ��� $��25 ���  � ColumnDefinitions �� $��80 ��� $��* �.+��� $��实际重量：��$��
10,15,10,0q�$��25���� $��1��$��2��$9��3注意：白银单位为千克，其它单位为克��$��	30,2,10,0q�$��25��
���  ���� $��1��$��
0,10,10,10q�$��25��$��80��$
��Auto��.������ $ 
RealWeight� �� ElementName$	 acc�� �� UpdateSourceTrigger$ PropertyChanged=�.���� $��2��$��1�� �� Orientation$ 
Horizontal=�.+��� -   $��btnOk��$��1��$��1��$��60��$��25��$��5q�$��确定���� -   $��	btnCancel��$��1��$��1��$��60��$��25��$��5q�$��取消��