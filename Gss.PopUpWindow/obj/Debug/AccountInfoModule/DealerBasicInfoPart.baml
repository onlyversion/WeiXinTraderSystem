   M S B A M L   `   `   `  ����J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gss.PopUpWindow.ConverterGss.PopUpWindow.Converter  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      K*clr-namespace:Gss.PopUpWindow.CustomCotrolGss.PopUpWindow.CustomCotrol  5      S.clr-namespace:Gss.PopUpWindow.ValidationHelper Gss.PopUpWindow.ValidationHelper  5      G CGss.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.EntitiesGss.Entities.ValidationHelper 5      ;    5Gss.PopUpWindow.AccountInfoModule.DealerBasicInfoPart   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      7cvt'clr-namespace:Gss.PopUpWindow.Converter     5      6sys&clr-namespace:System;assembly=mscorlib     5      :cus*clr-namespace:Gss.PopUpWindow.CustomCotrol     5      >val.clr-namespace:Gss.PopUpWindow.ValidationHelper     5      VValiHelpAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.Entities     5        � 	Resources  5	      8   2Gss.PopUpWindow.Converter.CertificateEnumConverter   CertificateCvt��%   &	          5
   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6     5   
    �� 
TargetType �� Property �� Value  TextBoxStyle �� BasedOn �� Triggers P� Property	 P� Value
 �� Path �� Self �� RelativeSource��%]  '��       '�� �     7  '�� �    �� 5       " ��6   .�5!      ��  � ��$ Center=�66   �� 5"       � ��$ Right=�68   �� 5#       � ��$ 2q�6+   5$      �� 5%      " ��6   8   .�5&      ��  � ��$ Center=�66   �� 5'       � ��$	 120��6-   �� 5(       � ��$ 2q�6+    5)      P� 5*       �@=�HasError	 . . �5+      ��  �@�ToolTip 5,      �� 5-   "   $2
 ,(Validation.Errors).CurrentItem.ErrorContent�6*   # Z 6^   5/      50      52      �� 53      " ��6   .�54      ��  � ��$ 2q�6+   55      56      .+�5<   
   �� $��1��6   $��0��6   $��证件类型：��6-   �� 5=   
   -   5         ��Name$ CbCertificate��5=   0   $��1��6   $��1��6     �� SelectedValue 6G   �� *AccInfo.CeritificateEnum+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� 	Converter# [  .@�5>      ��	身份证��6   ��5?      
其它��6   5@      �� 5B   
   $��1��6   $��2��6   $��证件号码：��6-   �� 5C   
   -   5         ��Name$ TbCertificateNumber��5C   /   $��1��6   $��3��6   .��6L   ��5D      �� 5E      $
 AccInfo.CertificateNumber�6   $ TwoWay=�6;   $ PropertyChanged=�6I    �� ValidationRules 5F      3  -Gss.Entities.ValidationHelper.StringRegexRule  5H      ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated .    	MinLength$ 1��6S      	MaxLength$ 30��6a      
HasChinese .     HasUnderline .  6�   5J      .��5K      5L      �� 5N   
   $��2��6   $��2��6   $��	姓名：��6-   �� 5O   
   $��2��6   $��3��6   .��60   ��5P      �� 5Q      $
 AccInfo.UserName�6   $ TwoWay=�62   $ PropertyChanged=�6@    5R        5T       . $ 1��6S   $ 30��6a   5V      .��5W      5X      �� 5`   
   $��2��6   $��0��6   $��所属会员：��6-   /   )Gss.PopUpWindow.CustomCotrol.AutoComboBox  5b   
   -   5          Name$ TbDealer��5b   9   $��2��6   $��1��6(   $��25��6L      DisplayName$ OrgNameAndOrgCode��5e         ItemsSource 5c      �� *
POrgList+ ��  �� AncestorLevel$ 1�� �� AncestorType$ WindowL� �� Mode$ FindAncestor=�   CurItem 5d      �� *
CurOrgInfo+$ TwoWay=� �� $ 1��$ WindowL�$ FindAncestor=�5e      �� 5v   
   $��4��6   $��0��6   $��	手机：��6-   �� 5w   
   -   5        $ TbPhone��5w   /   $��4��6   $��1��6   .��6@   ��5x      �� 5y      $
 AccInfo.CellPhoneNumber�6   $ TwoWay=�69   $ PropertyChanged=�6G   5}      .��5~      5      �� 5�   
   $��4��6   $��2��6   $��	固话：��6-   �� 5�   
   -   5        $ TbTelephoneNumber��5�   /   $��4��6   $��3��6   .��6J   ��5�      �� 5�      $
 AccInfo.TelephoneNumber�6   $ TwoWay=�69   $ PropertyChanged=�6G    5�        5�       . $ 11��6T       IsNumberOnly  . 6c   5�      .��5�      5�      �� 5�   
   $��5��6   $��0��6   $��	邮箱：��6-   �� 5�   
   -   5        $ TbEmail��5�   C   $��5��6   $��1��6   $��3��6/   .��6T   ��5�      �� 5�      $
 AccInfo.Email�6   $ TwoWay=�6/   $ PropertyChanged=�6=   5�      .��5�      5�      �� 5�   
   $��6��6   $��0��6   $��	地址：��6-   �� 5�   
   -   5        $ 	TbAddress��5�   C   $��6��6   $��1��6   $��3��6/   .��6V   ��5�      �� 5�      $
 AccInfo.Address�6   $ TwoWay=�61   $ PropertyChanged=�6?   5�      .��5�      5�      �� 5�   
   $��7��6   $��0��6   $��	备注：��6-   $	��Top=�6;   �� 5�   
   $��7��6   $��1��6   $��3��6/   ! �� AcceptsReturn! . .��6[   ��5�      �� 5�      $
 AccInfo.Remark�6   $ TwoWay=�60   $ PropertyChanged=�6>    5�      4  .Gss.Entities.ValidationHelper.StringLengthRule  5�       . "   	MinLength$" 0��6T   #   	MaxLength$	# 200��6b   5�      .��5�      5�      5�      5�      