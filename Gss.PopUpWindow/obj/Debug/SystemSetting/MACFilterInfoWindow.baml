   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   G CGss.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.EntitiesGss.Entities.ValidationHelper 5   	    Gss.PopUpWindow)   #Gss.PopUpWindow.MACFilterInfoWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   PValiHelpAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.Entities  5   	     � WindowStartupLocation$  CenterOwner=�5   	    � WindowStyle$ 
ToolWindow=�6-    � Title$ MAC地址过滤信息��5   	   $	��240��6   $	��300��6(    � 	Resources 5	         Ok �� Text 
 Cancel��%T   &	        &	       �� 5
   
   $ 确定��6%   �� 5   
   $ 取消��6)   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6]     5   
   -   5        # [ 5      6;   .��5      ]� .+�5   
   �� $��Bottom=�6    �� Orientation$ 
Horizontal=�6-   $��Right=�6F   .+�5      �� $��确定��6   $��88��6"   $��5q�6-   #��[  68    �� 	IsDefault . 6V   �� 5      $��取消��6   $��88��6"   $��5q�6-   #��[ 68   	 �� IsCancel	 . 6Z   5      �� 5   
   $
��Auto=�6   .��5      �  5      
 �� 
TargetType �� Property �� Value  TextBoxStyle �� BasedOn��%E  '��       '�� �     7  �� 5      "
 ��6   .�5      ��  � ��$ Right=�6@   �� 5       � ��$ 2q�63   �� 5       � ��$
 Bold"�67   5      �� 5       "
 ��6   8   .�5!      ��  � ��$ Center=�6>   �� 5"       � ��$	 120��65   �� 5#       � ��$ 2q�63   5$      5%       � RowDefinitions 5'      �� 5(      $
��Auto �6$   �� 5)      $
��Auto �6$    � ColumnDefinitions 5+      �� 5,      $
��Auto �6'   �� 5-      $��* �6'   .+�51      �� $��0��6   $��0��6%   $��MAC：��65   �� 52      $��1��6   $��0��6%   $��	描述：��65   %  Xceed.Wpf.Toolkit.MaskedTextBox  55      $��0��6%   $��1��62      Mask$ aa:aa:aa:aa:aa:aa��6B   $��2q�6[   4  .Xceed.Wpf.Toolkit.Primitives.ValueRangeTextBox   ValueDataType" ��6f      InsertKeyMode$ 	Overwrite=�6�      Value 56   %   �� *
MACAddress+ �� Mode$ TwoWay=��� 57      $��1��6   $��1��6'    �� MinLines$ 2��67   $��2q�6E    �� TextWrapping$ WrapWithOverflow=�6P    �� AcceptsReturn . .��6�   ��58      �� 59       �� Path$ 
FilterDesc�6"   $ TwoWay=�64    �� ValidationRules 5:      4  .Gss.Entities.ValidationHelper.StringLengthRule  5;   "      	MinLength$ 0��6<      	MaxLength$	 200��6J   ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated . 6Z   5=      .��5>   $   5?      5@      5A      5B      5C      