   M S B A M L   `   `   `  ���� J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gss.PopUpWindow.ConverterGss.PopUpWindow.Converter  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter S.clr-namespace:Gss.PopUpWindow.ValidationHelper Gss.PopUpWindow.ValidationHelper  K*clr-namespace:Gss.PopUpWindow.CustomCotrolGss.PopUpWindow.CustomCotrol  G CGss.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.EntitiesGss.Entities.ValidationHelper ;    5Gss.PopUpWindow.AccountInfoModule.ClientBasicInfoPart   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     7cvt'clr-namespace:Gss.PopUpWindow.Converter     6sys&clr-namespace:System;assembly=mscorlib     HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     >val.clr-namespace:Gss.PopUpWindow.ValidationHelper     :cus*clr-namespace:Gss.PopUpWindow.CustomCotrol     VValiHelpAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.Entities       � 	Resources  0   *Gss.PopUpWindow.Converter.SexEnumConverter 
  SexCvt8   2Gss.PopUpWindow.Converter.CertificateEnumConverter  CertificateCvt7   1Gss.PopUpWindow.Converter.ClientTypeEnumConverter  ClientTypeCvt2  ,Gss.Common.Converter.DateTimeFormatConverter  DateTimeCvt��%<   &	        &	      &	 
     &	              .���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
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
TargetType �� Property �� Value  TextBoxStyle �� BasedOn �� Triggers P� Property	 P� Value
 �� Path �� Self �� RelativeSource��%m  '��       '�� U     7  '�� )    �� " ��.���  � ��$ Center=���  � ��$ Right=���  � ��$ 2q��� " ��8   .���  � ��$ Center=���  � ��$	 120����  � ��$ 2q� P�  �@=�HasError	 . . ���  �@�ToolTip �� $2
 ,(Validation.Errors).CurrentItem.ErrorContent�# Z �� " ��.���  � ��$ 2q�.+��� $��0��$��0��$��	姓名：���� -    ��Name$ 
TbUserName��$��0��$��1��.������ $
 AccInfo.UserName� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.���� $��0��$��2��$��	性别：���� $��0��$��3�� �� SelectedValue �� *AccInfo.Sex+$ PropertyChanged=�$ TwoWay=� �� 	Converter# [  .@���男����女���� $��3��$��0��$��证件号码：���� -   $ TbCertificateNumber��$��3��$��1��.������ $
 AccInfo.CertificateNumber�$ TwoWay=�$ PropertyChanged=�.���� $��2��$��0��$��所属会员：��/   )Gss.PopUpWindow.CustomCotrol.AutoComboBox  -     Name$ TbDealer��$
��AUTO��$��2��$��1��$��24��   DisplayName$ OrgNameAndOrgCode��   SelectedValuePath$ OrgName��   ItemsSource �� *
POrgList+ ��  �� AncestorLevel$ 1�� �� AncestorType$ WindowL� �� Mode$ FindAncestor=�   SelectedValue �� $
 AccInfo.OrgName�$ TwoWay=�$ PropertyChanged=��� $��2��$��2��$��	手机：���� -   $ TbPhone��$��2��$��3��.������ $
 AccInfo.CellPhoneNumber�$ TwoWay=�$ PropertyChanged=�.��