   M S B A M L   `   `   `  ���� E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK4clr-namespace:Gss.Common.Utility;assembly=Gss.CommonGss.Common.Utility   Gss.PopUpWindow1   +Gss.PopUpWindow.ModifyOrderAllowStoreWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  >uti4clr-namespace:Gss.Common.Utility;assembly=Gss.Common  $	��300��  � SizeToContent$  Height=� � WindowStyle$ 
ToolWindow=� � Title$ 能否入库�� � 
ResizeMode$ CanMinimize=� � WindowStartupLocation$ CenterOwner=� � 	Resources    BoolVisibilityCv  Ok �� 
TargetType �� Property �� Value��%�   &	        &	      '�� 
     �� �� �� " ��.���  � ��$ 10,0,0,0q���  � ��$
 Bold"���  � ��$
 left=���  � ��$ Center=�	 J� CommandBindings	 )  #System.Windows.Input.CommandBinding  -   
   Command#
 [ .����  �� CornerRadius$ 8��$��1q�$��10q�
����=H�._��� .+��� .+�� $��5q� � ColumnDefinitions �� $
��Auto ��� $��* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��订单号：��$��Right=�$	��2,5q��� $��0��$��1��$	��2,5q����� *	OrderID+�� $��商品名称：��$��Right=�$��1��$��0��$	��2,5q��� $��1��$��1��$	��2,5q����� *ProductName+�� $��能否入库：��$��Right=�$��2��$��0��$	��2,5q��� $��2��$��1��$��Center=�$
��Left=�$��20,0,0,0q� d� 	IsChecked �� *
AllowStore+ �� Mode$ TwoWay=��  �� $��* ��� $
��Auto �.+��� -   $
��BtOk��$��1��$��确定��#��[  �� 	IsDefault . $	��120��$��Right=�$��5q�