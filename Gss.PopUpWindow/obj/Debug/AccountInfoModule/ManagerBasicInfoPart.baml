   M S B A M L   `   `   `  ����J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gss.PopUpWindow.ConverterGss.PopUpWindow.Converter  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      G CGss.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.EntitiesGss.Entities.ValidationHelper 5      <    6Gss.PopUpWindow.AccountInfoModule.ManagerBasicInfoPart   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      7cvt'clr-namespace:Gss.PopUpWindow.Converter     5      6sys&clr-namespace:System;assembly=mscorlib     5      VValiHelpAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.Entities     5        � 	Resources  5      0   *Gss.PopUpWindow.Converter.SexEnumConverter 
  SexCvt��%   &	          5   
   6   5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6     5   
    �� 
TargetType �� Property �� Value  TextBoxStyle �� BasedOn��%�  '��       '�� �     7  '�� /    �� 5      " ��6   .�5      ��  � ��$ Center=�66   �� 5       � ��$ Right=�68   �� 5        � ��$ 2q�6+   5!      �� 5"      " ��6   8   .�5#      ��  � ��$ Center=�66   �� 5$       � ��$	 120��6-   �� 5%       � ��$ 2q�6+   5&      �� 5'      " ��6   .�5(      ��  � ��$ 2q�6+   5)      5*      .+�5+   
   �� $��0��6   $��0��6   $��	姓名：��6-   �� 5,   
   -   5         ��Name$ TbName��5,   /   $��0��6   $��1��6   .��6?   ��5-      �� 5.       �� Path$ UserName�6   	 �� Mode$	 TwoWay=�6*   
 �� UpdateSourceTrigger$
 PropertyChanged=�68   52      .��53      54      �� 56   
   $��0��6   $��2��6   $��	性别：��6-   �� 57   
   -   5         ��Name$ CbSex��57   0   $��0��6   $��3��6     �� SelectedValue 6?   �� *Sex+$	 TwoWay=� �� 	Converter# [  .@�58      ��男��6   ��59      女��6   5:      �� 5<   
   $��1��6   $��0��6   $��身份证：��6-   �� 5=   
   -   5        $ 
TbIDNumber��5=   /   $��1��6   $��1��6   .��6C   ��5>      �� 5?      $ CertificateNumber�6   $	 TwoWay=�63   $
 PropertyChanged=�6A    �� ValidationRules 5@      3  -Gss.Entities.ValidationHelper.StringRegexRule  5A         	MaxLength$ 18��63      	MinLength$ 1��6B   ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated .    
HasChinese .     HasUnderline .  6�   5C      .��5D      5E      �� 5G   
   $��3��6   $��0��6   $��	手机：��6-   �� 5H   
   -   5        $ TbPhone��5H   /   $��3��6   $��1��6   .��6@   ��5I      �� 5J      $ CellPhoneNumber�6   $	 TwoWay=�61   $
 PropertyChanged=�6?   5N      .��5O      5P      �� 5R   
   $��3��6   $��2��6   $��	固话：��6-   �� 5S   
   -   5        $ TbTelephoneNumber��5S   /   $��3��6   $��3��6   .��6J   ��5T      �� 5U      $ TelephoneNumber�6   $	 TwoWay=�61   $
 PropertyChanged=�6?    5V        5X      $ 11��63    .    IsNumberOnly . 6b   5Z      .��5[      5\      �� 5^   
   $��1��6   $��2��6   $��	邮箱：��6-   �� 5_   
   -   5        $ TbEmail��5_   /   $��1��6   $��3��6   .��6@   ��5`      �� 5a      $ Email�6   $	 TwoWay=�6'   $
 PropertyChanged=�65   5e      .��5f      5g      �� 5k   
   $��6��6   $��0��6   $��	地址：��6-   �� 5l   
   -   5        $ 	TbAddress��5l   C   $��6��6   $��1��6   $��3��6/   .��6V   ��5m      �� 5n      $ Address�6   $	 TwoWay=�6)   $
 PropertyChanged=�67   5r      .��5s      5t      �� 5u   
   $��7��6   $��0��6   $��	备注：��6-   $	��Top=�6;   �� 5v   
   -   5        $ TbRemark��5v   C   $��7��6   $��1��6   $��3��6/    �� AcceptsReturn .  �� MinLines$ 2��6j   .��6x   ��5w      �� 5x      $ Remark�6   $	 TwoWay=�6(   $
 PropertyChanged=�66    5y      4  .Gss.Entities.ValidationHelper.StringLengthRule  5{         	MaxLength$	 200��64      	MinLength$ 0��6D    . 6R   5}      .��5~      5      5�      5�      