   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   C ?ZDSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ZdSystem.ConverterZdSystem.Converter 5   	      ZdSystem.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6(   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6j   6sys&clr-namespace:System;assembly=mscorlib     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   0	converter clr-namespace:ZdSystem.Converter  5   	   -   5        $	��460��5   	   $	��650��6     � AllowsTransparency  .  � Title$' !中鼎伟业微中心管理系统��6p    � 
ResizeMode$ CanMinimize=�5   
    � WindowStartupLocation$ CenterScreen=�6#    � WindowStyle$
 None=�6H    � Icon$$ /ZDSystem;component/appico.ico��6[    � 	Resources 5
       	  Login �� Text 
 Cancel  Back  BoolVisibilityCvt1 +ZdSystem.Converter.AccountTypeEnumConverter  
AccTypeCvt��%�   &	        &	       &	 @     &	 `     &	 s     �� 5   
   $ 登录��6(   �� 5   
   $ 取消��6)   �� 5   
   $ 返回��6'   �� 5   
   6'     5   
   6-   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        	   Command#	 [  5   F   6g     5   
   -   5        #	 [ 5      6;     5   
   -   5        #	 [ 5      69   .��5*      �   LoginWindowGridStyle#��[ 6   
 � RowDefinitions
 5+   
   �� 5,      $��25 �6   �� 5-      $��* �6   �� 5.      $	��100 �6   �� 5/      $��40 �6   .+�52   
   �� $��Right=�6    �� Orientation$ 
Horizontal=�61    53       �� 
TargetType �� BasedOn �� Property �� Value��%�   '��       �� 54      " ��6+    6   Z� .�56      ��  � ��$ 20��6/   �� 57       � ��$ 30��6.   �� 58       � ��
 ���� 63   �� 59       � ��$ 0q�68   5:      5;      .+�5<      �� -   5        
������ $	��Top=�5<   F   .��5=      �� $��11��6   $��14��6$   $��Image\缩小.png��6/   5>      �� 5?      -   5        
������ $	��Top=�5?   C   .��5@      �� $��11��6   $��14��6$   $��Image\关闭.png��6/   5A      5B      � 5D   
   $��1��6   .+�5F      � y�6   �� *ReadyToLogin+ �� RelativeSource ��  �� AncestorType" � �� Mode$ FindAncestor=� �� 	Converter# [  � ColumnDefinitions 5G      �� 5H      $	��200 �6'   �� 5I      $	��200 �6'   �� 5J      $	��100 �6'   
 5L      �� 5M      $	��160 �6$   �� 5N      $��40 �6$   �� 5O      $��40 �6$   �� 5P      $��0 �6$   �� 5Q      $��40 �6$   �� 5R      $��1* �6$   .+�5[      (  "Xceed.Wpf.Toolkit.WatermarkTextBox  -   5          Name$ TbAccountName��5[   (   $��1��6?   $��1��6O   $��30��6\   $��2q�6h   $	��100��6s      SelectAllOnGotFocus . $��Center=�6     	Watermark$ 用户账号��6*  ��6�   �� *AccountName+ �� Mode$ TwoWay=� �� $ WindowL�$ FindAncestor=�6*  G� 5\      -   5         G�Name$ 
PbPassword��5\      $��1��62   $��2��6B   $��30��6O   $��2q�6[   $	��100��6f   $��Center=�6u   �� 5^      -	   5        $��cmbServeceAddress��5^   U   $��1��6   $��4��6+   $��30��68   $��0,0,0,0q�6D   .@�5_      �� $��交易服务器��6#    �� 
IsSelected . 63   �� 5`      $��模拟服务器��6#   $y�	Collapsed=�63   5a      �� 5e      $��2��6   $��1��6+   $
��10,0q�68   $��记住用户名��6F   $��Center=�6�    d� 	IsChecked 6V   �� *RememberUserName+$ TwoWay=� �� $ WindowL�$ FindAncestor=�6�   �� 5f      $��2��6   $��2��6+   $
��10,0q�68   $��记住密码��6F   $��Center=�6�    6U   �� *RememberPassword+$ TwoWay=� �� $ WindowL�$ FindAncestor=�6�   5j      � 5m      $��0,0,0,10q�6   y�6%   �� *	Logging+ �� " �$ FindAncestor=�# [ 
 5n      �� 5o      $	��230 �6$   �� 5p      $
��Auto �6$   �� 5q      $��* �6$   .+�5s      �� $��0,0,0,40q�6   $��Center=�6.   $��正在登录...��6K   $��Bottom=�6Z   � 5t      $��1��6   $��9��6+    � IsIndeterminate . $��Bottom=�6M   5u      � 5w      y�6   �� *LoginFailed+ �� " �$ FindAncestor=�# [ .+�5x      �� $
��Auto=�6   .��5y      �� $��0,0,0,40q�6    $��Center=�62   $��WrapWithOverflow=�6�   $��Bottom=�6�   ��6O   �� *ErrorMessage+ �� " �$ FindAncestor=�6�   5z      5|      5}      � 5~   
   $��2��6   
������  5      �� 5�      $	��200 �6#   �� 5�      $	��200 �6#   �� 5�      $	��100 �6#    5�      ��%�   '��       �� 5�      " ��6   .�5�      ��  � ��$ 26��6/   �� 5�       � ��$	 200��6.   �� 5�       � ��
 ���F�63   �� 5�       � ��$
 Bold"�63   �� 5�       � ��$	 Top=�6:   5�      5�      .+�5�      �� $��Center=�6   $��1��60   $	��200��6@   ���#f3c273���#f3c273$��0q�6w   #��[  6�   $��登录��6�    �� 	IsDefault . y�6�   �� *ReadyToLogin+ �� " �$ FindAncestor=�# [ �� 5�      $��Center=�6   $��1��60   $	��200��6@   #��[ 6L   $��取消��6n    �� IsCancel . y�6�   �� *	Logging+ �� " �$ FindAncestor=�# [ �� 5�      $��Center=�6   $��1��60   $	��200��6@   #��[ 6L   $��返回��6l   y�6y   �� *LoginFailed+ �� " �$ FindAncestor=�# [ 5�      � 5�   
   $��3��6   ���	#FFF6CF10 5�      �� 5�      $��35 �6#   �� 5�      $��* �6#   �� 5�      $	��240 �6#   �� 5�      $��* �6#   �� 5�      $��35 �6#   5�      5�      5�      