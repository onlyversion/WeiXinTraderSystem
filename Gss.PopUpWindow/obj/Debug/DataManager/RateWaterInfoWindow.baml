   M S B A M L   `   `   `  ����E  AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK4clr-namespace:Gss.Common.Utility;assembly=Gss.CommonGss.Common.Utility  5   	    Gss.PopUpWindow)   #Gss.PopUpWindow.RateWaterInfoWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   >uti4clr-namespace:Gss.Common.Utility;assembly=Gss.Common  5   	     � WindowStartupLocation$  CenterOwner=�5   	    � WindowStyle$ 
ToolWindow=�6-    � Title$ 汇率/水信息详情��5   	   $	��220��6   $	��300��6'    � 	Resources 5         Ok �� Text 
 Cancel �� 
TargetType �� Property �� Value$  Xceed.Wpf.Toolkit.DoubleUpDown0   *Gss.Common.Utility.DoubleUpDownInputFilter��%�  &	        &	       '�� @     '�� �     '�� C    '  �    �� 5	   
   $ 确定��6%   �� 5
   
   $ 取消��6)   �� 5   
   " ��6   .�5      ��  � ��$ 2q�6'   �� 5       � ��$ Right=�64   �� 5       � ��$
 Bold"�6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 2q�6'   �� 5       � ��$ Normal"�6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 2q�6'   �� 5       � ��$ Normal"�6+   �� 5       � ��$ Center=�62   5      �� 5   
   "  6   .�5      ��  �@ 	DigitOnly . 6F   �� 5       � ��$ 2q�6'   5      5       J� CommandBindings 5!      )  #System.Windows.Input.CommandBinding  5"   
   -   5        	   Command#	 [  5"      6]     5#   
   -   5        #	 [ 5#      6;   .��5&      ]� .+�5'   
   �� $��Bottom=�6   
 �� Orientation$
 
Horizontal=�6-   $��Right=�6F   .+�5(      �� $��确定��6   $��88��6"   $��5q�6-   #��[  68    �� 	IsDefault . 6V   �� 5)      $��取消��6   $��88��6"   $��5q�6-   #��[ 68    �� IsCancel . 6Z   5*      � 5+   
    � RowDefinitions 5,      �� 5-      $
��Auto �6    �� 5.      $
��Auto �6    �� 5/      $
��Auto �6     � ColumnDefinitions 51      �� 52      $
��Auto �6#   �� 53      $��* �6#   .+�56      �� $��行情编码：��6   �� 57      $��1��6   $��	汇率：��6!   �� 58      $��2��6   $��水：��6!   �� 5;      $��1��6   ��5<      �� *	StockCode+  5=      $��1��6    $��1��60   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0X�6=      	Increment$ 0.0001X�6I      FormatString$ F4��6\   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 5>      �� *Rate+ �� Mode$ TwoWay=�  5?      $��1��6    $��2��60    5@      �� *Water+$ TwoWay=�5A      5B      5C      