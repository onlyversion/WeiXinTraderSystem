   M S B A M L   `   `   `  ����E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK4clr-namespace:Gss.Common.Utility;assembly=Gss.CommonGss.Common.Utility  5   	    Gss.PopUpWindow1   +Gss.PopUpWindow.ModifyOrderAllowStoreWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   >uti4clr-namespace:Gss.Common.Utility;assembly=Gss.Common  5   	   $	��300��5   	     � SizeToContent$  Height=�6    � WindowStyle$ 
ToolWindow=�6-    � Title$ 能否入库��5   	    � 
ResizeMode$ CanMinimize=�5   	    � WindowStartupLocation$ CenterOwner=�6"    � 	Resources 5	         BoolVisibilityCv  Ok �� 
TargetType �� Property �� Value��%  &	        &	      '�� &     �� 5
   
   6'   �� 5   
   6   �� 5   
   " ��6   .�5      ��  � ��$ 10,0,0,0q�6'   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 left=�64   �� 5       � ��$ Center=�62   5      5      	 J� CommandBindings	 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        
   Command#
 [ 5      6]   .��5      ��  �� CornerRadius$ 8��6   $��1q�6   $��10q�62   
����=H�._�5   
   �� .+�5      �� .+�5      � $��5q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6+   �� 5       $��* �6+    � RowDefinitions 5"      �� 5#      $
��Auto �6(   �� 5$      $
��Auto �6(   �� 5%      $
��Auto �6(   .+�5'      �� $��订单号：��6    $��Right=�6,   $	��2,5q�6H   �� 5(      $��0��6    $��1��6-   $	��2,5q�6=   ��5)   $   �� *	OrderID+�� 5*      $��商品名称：��6    $��Right=�6-   $��1��6I   $��0��6V   $	��2,5q�6f   �� 5+      $��1��6    $��1��6-   $	��2,5q�6=   ��5,   $   �� *ProductName+�� 5-      $��能否入库：��6    $��Right=�6-   $��2��6I   $��0��6V   $	��2,5q�6f   �� 5.      $��2��6   $��1��6,   $��Center=�6<   $
��Left=�6W   $��20,0,0,0q�6r    d� 	IsChecked 6�   �� *
AllowStore+ �� Mode$ TwoWay=�5/      � 51       52      �� 53      $��* �6+   �� 54      $
��Auto �6+   .+�56      �� -   5        $
��BtOk��56      $��1��6)   $��确定��69   #��[ 6F    �� 	IsDefault . $	��120��6u   $��Right=�6�   $��5q�6�   57      58      59      5:      5;      