   M S B A M L   `   `   `  ���� J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gss.PopUpWindow.ConverterGss.PopUpWindow.Converter  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem K*clr-namespace:Gss.PopUpWindow.CustomCotrolGss.PopUpWindow.CustomCotrol  S.clr-namespace:Gss.PopUpWindow.ValidationHelper Gss.PopUpWindow.ValidationHelper  G CGss.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.EntitiesGss.Entities.ValidationHelper ;    5Gss.PopUpWindow.AccountInfoModule.DealerBasicInfoPart   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     7cvt'clr-namespace:Gss.PopUpWindow.Converter     6sys&clr-namespace:System;assembly=mscorlib     :cus*clr-namespace:Gss.PopUpWindow.CustomCotrol     >val.clr-namespace:Gss.PopUpWindow.ValidationHelper     VValiHelpAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.Entities       � 	Resources  8   2Gss.PopUpWindow.Converter.CertificateEnumConverter   CertificateCvt��%   &	          .���  � RowDefinitions �� $
��Auto ��� $
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
TargetType �� Property �� Value  TextBoxStyle �� BasedOn �� Triggers P� Property	 P� Value
 �� Path �� Self �� RelativeSource��%m  '��       '�� U     7  '�� )    �� " ��.���  � ��$ Center=���  � ��$ Right=���  � ��$ 2q��� " ��8   .���  � ��$ Center=���  � ��$	 120����  � ��$ 2q� P�  �@=�HasError	 . . ���  �@�ToolTip �� $2
 ,(Validation.Errors).CurrentItem.ErrorContent�# Z �� " ��.���  � ��$ 2q�.+��� $��1��$��0��$��证件类型：���� -    ��Name$ CbCertificate��$��1��$��1�� �� SelectedValue �� *AccInfo.CeritificateEnum+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� 	Converter# [  .@���	身份证����
其它���� $��1��$��2��$��证件号码：���� -    ��Name$ TbCertificateNumber��$��1��$��3��.������ $
 AccInfo.CertificateNumber�$ TwoWay=�$ PropertyChanged=� �� ValidationRules 3  -Gss.Entities.ValidationHelper.StringRegexRule  ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated .    	MinLength$ 1��   	MaxLength$ 30��   
HasChinese .     HasUnderline .  .���� $��2��$��2��$��	姓名：���� $��2��$��3��.������ $
 AccInfo.UserName�$ TwoWay=�$ PropertyChanged=�    . $ 1��$ 30��.���� $��2��$��0��$��所属会员：��/   )Gss.PopUpWindow.CustomCotrol.AutoComboBox  -     Name$ TbDealer��$��2��$��1��$��25��   DisplayName$ OrgNameAndOrgCode��   ItemsSource �� *
POrgList+ ��  �� AncestorLevel$ 1�� �� AncestorType$ WindowL� �� Mode$ FindAncestor=�   CurItem �� *
CurOrgInfo+$ TwoWay=� �� $ 1��$ WindowL�$ FindAncestor=��� $��4��$��0��$��	手机：���� -   $ TbPhone��$��4��$��1��.������ $
 AccInfo.CellPhoneNumber�$ TwoWay=�$ PropertyChanged=�.���� $��4��$��2��$��	固话：���� -   $ TbTelephoneNumber��$��4��$��3��.������ $
 AccInfo.TelephoneNumber�$ TwoWay=�$ PropertyChanged=�    . $ 11��    IsNumberOnly  . .���� $��5��$��0��$��	邮箱：���� -   $ TbEmail��$��5��$��1��$��3��.������ $
 AccInfo.Email�$ TwoWay=�$ PropertyChanged=�.���� $��6��$��0��$��	地址：���� -   $ 	TbAddress��$��6��$��1��$��3��.������ $
 AccInfo.Address�$ TwoWay=�$ PropertyChanged=�.���� $��7��$��0��$��	备注：��$	��Top=��� $��7��$��1��$��3��! �� AcceptsReturn! . .������ $
 AccInfo.Remark�$ TwoWay=�$ PropertyChanged=� 4  .Gss.Entities.ValidationHelper.StringLengthRule   . "   	MinLength$" 0��#   	MaxLength$	# 200��.��