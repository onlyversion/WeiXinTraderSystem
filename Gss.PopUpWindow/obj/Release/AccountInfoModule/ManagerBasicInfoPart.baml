   M S B A M L   `   `   `  ���� J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gss.PopUpWindow.ConverterGss.PopUpWindow.Converter  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem G CGss.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.EntitiesGss.Entities.ValidationHelper <    6Gss.PopUpWindow.AccountInfoModule.ManagerBasicInfoPart   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     7cvt'clr-namespace:Gss.PopUpWindow.Converter     6sys&clr-namespace:System;assembly=mscorlib     VValiHelpAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.Entities       � 	Resources  0   *Gss.PopUpWindow.Converter.SexEnumConverter 
  SexCvt��%   &	          .���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �   �� 
TargetType �� Property �� Value  TextBoxStyle �� BasedOn��%�   '��       '�� U     7  '�� �     �� " ��.���  � ��$ Center=���  � ��$ Right=���  � ��$ 2q��� " ��8   .���  � ��$ Center=���  � ��$	 120����  � ��$ 2q��� " ��.���  � ��$ 2q�.+��� $��0��$��0��$��	姓名：���� -    ��Name$ TbName��$��0��$��1��.������  �� Path$ UserName�	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�.���� $��0��$��2��$��	性别：���� -    ��Name$ CbSex��$��0��$��3�� �� SelectedValue �� *Sex+$	 TwoWay=� �� 	Converter# [  .@���男����女���� $��1��$��0��$��身份证：���� -   $ 
TbIDNumber��$��1��$��1��.������ $ CertificateNumber�$	 TwoWay=�$
 PropertyChanged=� �� ValidationRules 3  -Gss.Entities.ValidationHelper.StringRegexRule     	MaxLength$ 18��   	MinLength$ 1��,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated .    
HasChinese .     HasUnderline .  .���� $��3��$��0��$��	手机：���� -   $ TbPhone��$��3��$��1��.������ $ CellPhoneNumber�$	 TwoWay=�$
 PropertyChanged=�.���� $��3��$��2��$��	固话：���� -   $ TbTelephoneNumber��$��3��$��3��.������ $ TelephoneNumber�$	 TwoWay=�$
 PropertyChanged=�   $ 11�� .    IsNumberOnly . .���� $��1��$��2��$��	邮箱：���� -   $ TbEmail��$��1��$��3��.������ $ Email�$	 TwoWay=�$
 PropertyChanged=�.���� $��6��$��0��$��	地址：���� -   $ 	TbAddress��$��6��$��1��$��3��.������ $ Address�$	 TwoWay=�$
 PropertyChanged=�.���� $��7��$��0��$��	备注：��$	��Top=��� -   $ TbRemark��$��7��$��1��$��3�� �� AcceptsReturn .  �� MinLines$ 2��.������ $ Remark�$	 TwoWay=�$
 PropertyChanged=� 4  .Gss.Entities.ValidationHelper.StringLengthRule     	MaxLength$	 200��   	MinLength$ 0�� . .��