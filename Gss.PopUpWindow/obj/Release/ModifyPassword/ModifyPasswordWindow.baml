   M S B A M L   `   `   `  ���� G  CGss.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA0clr-namespace:Gss.Entities;assembly=Gss.EntitiesGss.Entities   Gss.PopUpWindow9   3Gss.PopUpWindow.ModifyPassword.ModifyPasswordWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     CHelper0clr-namespace:Gss.Entities;assembly=Gss.Entities       � WindowStartupLocation$  CenterScreen=� � Title$ 修改密码��$	��400��$	��500�� � WindowStyle$ 
ToolWindow=� � 	Resources    Password �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value
 �� Path �� Self �� RelativeSource��%G  &	        '��      'G� *     �� �� " ��.���  � ��
 �   ��� " G�.���  � ��$ 5q���  � ��$ 16(���  � ��$ 25����  � ��$ Stretch=���  � ��$ Center=� P�  �@=�HasError	 . . ���  �@�ToolTip �� $2
 ,(Validation.Errors).CurrentItem.ErrorContent�# Z  J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [  .��� .+��� ���	#FFC7C8C7 �� CornerRadius$ 5��$��1q� � DataContext �� *AccountInfo+._�� -   $
��grid��$��Stretch=�$��20q� � RowDefinitions �� $
��auto ��� $
��auto ��� $��13 ��� $��30 ��� $��1 ���  � ColumnDefinitions �� $��* ��� $	��600 ��� $��* �.+��� $
��Left=�$��Bottom=�$��3��$��1��$��0,0,0,5q�$��16��$��17���� $��3��$��1��$��20,0,0,5q�$��密码修改��$
��Bold"�$��Bottom=�$
��Left=��� $��4��$��0��$��3�����	#FFD5D5D5	 �� X1$ 0��	 �� Y1$ 0��	 �� Y2$ 0��	 �� X2 �� *ActualWidth+ �� ElementName$
 grid�� �� Mode$ OneWay=�� $��5��$��1��$��20,0,0,0q� �� $��30 ��� $��40 ��� $��40 ��� $��40 ��� $��40 � �� $��80 ��� $��* �.+��� $��0��$��0��$��密码类型：��$��Center=�$��5,0,0,0q��� -   $��0��$��1�� �� Orientation$ 
Horizontal=�.+�	� $��登陆密码��$��5q� d� 	IsChecked$
 TrueY�	� $��资金密码��$��5q�$y�Hidden=��� $��旧密码：��$��1��G� -   $��PbOld��$��1��$	��150��$
��Left=�$��1��$   Gss.Entities.PasswordBoxHelper   Attach .  �� $	 acc��   Password �� $
 SureTradePwd�$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� $��新密码：��$��2��G� -   $��PbNew��$��2��$��1��$	��150��$
��Left=��� $��新密码确认：��$��3��G� -   $��PbNewConfirm��$��3��$��1��$	��150��$
��Left=��� $��确认修改��#��[  $��4�����#043c77
�������$��2��$	��150��$��30��$
��Left=� �� 	IsDefault . 
������ G� -   $��cbrush��$y�	Collapsed=�