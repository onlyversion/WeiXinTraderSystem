   M S B A M L   `   `   `  ����J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Gss.PopUpWindow.AccountInfoModule!Gss.PopUpWindow.AccountInfoModule  5   	   +    %Gss.PopUpWindow.ClientFundsInfoWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   E	accModule/clr-namespace:Gss.PopUpWindow.AccountInfoModule     5   	   -   5        $	��win��5   <     � WindowStartupLocation$  CenterOwner=�5   	    � WindowStyle$ 
ToolWindow=�6-    � Title$ 客户资金信息��5   	   $	��550��6    � SizeToContent$ Height=�6%    � 	Resources 5         Ok �� Text 
 Cancel��%T   &	        &	       �� 5   
   $ 确定��6%   �� 5	   
   $ 取消��6)   5
       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      67     5   
   -   5        # [ 5      6;   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   5   /Gss.PopUpWindow.AccountInfoModule.FundsInfoPart  �� 5   
   $��1��6   	 �� Orientation$	 
Horizontal=�6"   $��Right=�6;   .+�5      �� $��确定��6   $��88��6"   $��5q�6-   #��[  68   y�6V   �� *BtnOkVisibility+
 �� ElementName$	
 win���� 5      $��取消��6   $��88��6"   $��5q�6-   #��[ 68    �� IsCancel . 6[   5      5      5      