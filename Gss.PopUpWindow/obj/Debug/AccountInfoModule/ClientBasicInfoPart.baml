   M S B A M L   `   `   `  ����J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gss.PopUpWindow.ConverterGss.PopUpWindow.Converter  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter 5      S.clr-namespace:Gss.PopUpWindow.ValidationHelper Gss.PopUpWindow.ValidationHelper  5      K*clr-namespace:Gss.PopUpWindow.CustomCotrolGss.PopUpWindow.CustomCotrol  5      G CGss.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.EntitiesGss.Entities.ValidationHelper 5	      ;    5Gss.PopUpWindow.AccountInfoModule.ClientBasicInfoPart   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      7cvt'clr-namespace:Gss.PopUpWindow.Converter     5      6sys&clr-namespace:System;assembly=mscorlib     5      HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     5      >val.clr-namespace:Gss.PopUpWindow.ValidationHelper     5      :cus*clr-namespace:Gss.PopUpWindow.CustomCotrol     5      VValiHelpAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.Entities     5	        � 	Resources  5
      0   *Gss.PopUpWindow.Converter.SexEnumConverter 
  SexCvt8   2Gss.PopUpWindow.Converter.CertificateEnumConverter  CertificateCvt7   1Gss.PopUpWindow.Converter.ClientTypeEnumConverter  ClientTypeCvt2  ,Gss.Common.Converter.DateTimeFormatConverter  DateTimeCvt��%t   &	        &	      &	 &     &	 9       5   
   6     5   
   6'     5   
   6&     5   
   6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5    
   �� 5!      $
��Auto �6   �� 5"      $��* �6   �� 5#      $
��Auto �6   �� 5$      $��* �6     5&   
    �� 
TargetType �� Property �� Value  TextBoxStyle �� BasedOn �� Triggers P� Property	 P� Value
 �� Path �� Self �� RelativeSource��%]  '��       '�� �     7  '�� �    �� 5'      " ��6   .�5(      ��  � ��$ Center=�66   �� 5)       � ��$ Right=�68   �� 5*       � ��$ 2q�6+   5+      �� 5,      " ��6   8   .�5-      ��  � ��$ Center=�66   �� 5.       � ��$	 120��6-   �� 5/       � ��$ 2q�6+    50      P� 51       �@=�HasError	 . . �52      ��  �@�ToolTip 53      �� 54   "   $2
 ,(Validation.Errors).CurrentItem.ErrorContent�6*   # Z 6^   56      57      59      �� 5:      " ��6   .�5;      ��  � ��$ 2q�6+   5<      5=      .+�5>   
   �� $��0��6   $��0��6   $��	姓名：��6-   �� 5?   
   -   5         ��Name$ 
TbUserName��5?   /   $��0��6   $��1��6   .��6C   ��5@      �� 5A      $
 AccInfo.UserName�6    �� Mode$ TwoWay=�62    �� UpdateSourceTrigger$ PropertyChanged=�6@   5E      .��5F      5G      �� 5H   
   $��0��6   $��2��6   $��	性别：��6-   �� 5I   
   $��0��6   $��3��6     �� SelectedValue 60   �� *AccInfo.Sex+$ PropertyChanged=�$ TwoWay=� �� 	Converter# [  .@�5J      ��男��6   ��5K      女��6   5L      �� 5N   
   $��3��6   $��0��6   $��证件号码：��6-   �� 5O   
   -   5        $ TbCertificateNumber��5O   /   $��3��6   $��1��6   .��6L   ��5P      �� 5Q      $
 AccInfo.CertificateNumber�6   $ TwoWay=�6;   $ PropertyChanged=�6I   5U      .��5V      5W      �� 5r   
   $��2��6   $��0��6   $��所属会员：��6-   /   )Gss.PopUpWindow.CustomCotrol.AutoComboBox  5~   
   -   5          Name$ TbDealer��5~   E   $
��AUTO��6   $��2��6(   $��1��65   $��24��6X      DisplayName$ OrgNameAndOrgCode��5�         SelectedValuePath$ OrgName��6;      ItemsSource 5      �� *
POrgList+ ��  �� AncestorLevel$ 1�� �� AncestorType$ WindowL� �� Mode$ FindAncestor=�   SelectedValue 5�      �� 5�      $
 AccInfo.OrgName�6   $ TwoWay=�61   $ PropertyChanged=�6?   5�      5�      �� 5�   
   $��2��6   $��2��6   $��	手机：��6-   �� 5�   
   -   5        $ TbPhone��5�   /   $��2��6   $��3��6   .��6@   ��5�      �� 5�      $
 AccInfo.CellPhoneNumber�6   $ TwoWay=�69   $ PropertyChanged=�6G   5�      .��5�      5�      5     5     