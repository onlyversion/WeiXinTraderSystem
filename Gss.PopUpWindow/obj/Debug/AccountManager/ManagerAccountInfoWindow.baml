   M S B A M L   `   `   `  ����J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Gss.PopUpWindow.AccountInfoModule!Gss.PopUpWindow.AccountInfoModule  5   	   Q-clr-namespace:Gss.PopUpWindow.AuthorityModuleGss.PopUpWindow.AuthorityModule  5   	   .    (Gss.PopUpWindow.ManagerAccountInfoWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   E	accModule/clr-namespace:Gss.PopUpWindow.AccountInfoModule     5   	   C	autModule-clr-namespace:Gss.PopUpWindow.AuthorityModule     5   	     � WindowStartupLocation$  CenterOwner=�5   	    � WindowStyle$ 
ToolWindow=�6-    � SizeToContent$ Height=�5   
    � 
ResizeMode$ CanMinimize=�5   	    � Title$ 管理员账户资料��5	   	   $	��550��6   $	��500��6%    � 	Resources 5
         Ok �� Text 
 Cancel��%T   &	        &	       �� 5   
   $ 确定��6%   �� 5   
   $ 取消��6)   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6]     5   
   -   5        # [ 5      6;   .��5      � 	 � RowDefinitions	 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� .@�5      �� $��基本资料��6   .��5      �� $
��Auto=�6   $��Disabled=�6B   .��5      �� -   5        
 ��Name$
 SpInfo��5   !    � DataContext 61   �� *	AccInfo+.+�5      7   1Gss.PopUpWindow.AccountInfoModule.AccountInfoPart  -   5          Name$ AccInfoPart��5   4   <   6Gss.PopUpWindow.AccountInfoModule.ManagerBasicInfoPart  5      5      5       5!      �� 52      $��登录信息��6   .��53      �� $
��Auto=�6   $��Disabled=�6B   .��54      �� -   5        $
 SpLogin��54   !    62   �� *	AccInfo+.+�55      5   /Gss.PopUpWindow.AccountInfoModule.LoginInfoPart  56      57      58      59      �� 5:   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5;      �� $��确定��6   $��88��6"   $��5q�6-   #��[  68   �� 5<      $��取消��6   $��88��6"   $��5q�6-   #��[ 68    �� IsCancel . 6Z   5=      5>      5?      