   M S B A M L   `   `   `  ����J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Gss.PopUpWindow.AccountInfoModule!Gss.PopUpWindow.AccountInfoModule  5   	   E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter 5   	   -    'Gss.PopUpWindow.ClientAccountInfoWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   E	accModule/clr-namespace:Gss.PopUpWindow.AccountInfoModule     5   	   HcmCvt6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     5   	     � WindowStartupLocation$  CenterOwner=�5   	    � WindowStyle$ 
ToolWindow=�6-    � Title$ 客户账户资料��5   	   $	��600��6    � SizeToContent$ WidthAndHeight=�6(    � BindingGroup 5	      &   System.Windows.Data.BindingGroup  5
   
      Name$ BindingG��6    � 	Resources 5         Ok �� Text 
 Cancel3  -Gss.Common.Converter.BooleanInvertedConverter  BoolInvertCvt��%q   &	        &	       &	 @     �� 5   
   $ 确定��6%   �� 5   
   $ 取消��6)     5   
   6)   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        	   Command#	 [  5      6]     5   
   -   5        #	 [ 5      6;   .��5      � 
 � RowDefinitions
 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� .@�5      �� $��基本资料��6   .��5&      �� $
��Auto=�6   $
��Auto=�6B   .��5'      �� -   5         ��Name$ SpInfo��5'   !    � DataContext 61   �� *.+{�5(   !   �� *
IsReadOnly+ �� RelativeSource ��  �� AncestorType$ WindowL� �� Mode$ FindAncestor=� �� 	Converter# [ .+�5)      7   1Gss.PopUpWindow.AccountInfoModule.AccountInfoPart  -   5          Name$ AccInfoPart��5)   4    6I   �� *	AccInfo+;   5Gss.PopUpWindow.AccountInfoModule.ClientBasicInfoPart  5*      -   5          Name$ BasicInfoPart��5*   8   5+      5,      5-      �� 5.      $��交易控制��6   .��5/      �� $
��Auto=�6   $
��Auto=�6B   {�50      �� *
IsReadOnly+ �� $ WindowL�$ FindAncestor=�# [ .��51      ?   9Gss.PopUpWindow.AccountInfoModule.TransactionSettingsPart   68   �� *TransactionSettings+52      53      5:      �� 5;   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5<      �� $��确定��6   $��88��6"   $��5q�6-   #��[  68   �� 5=      $��取消��6   $��88��6"   $��5q�6-   #��[ 68    �� IsCancel . 6Z   5>      5?      5@      