   M S B A M L   `   `   `  ����G  CGss.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.EntitiesGss.Entities.ValidationHelper  5   	    Gss.PopUpWindow'   !Gss.PopUpWindow.HolidayInfoWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42tk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   PValiHelpAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.Entities  5   	   -   5          � WindowStartupLocation$  CenterOwner=�5   	    � WindowStyle$ 
ToolWindow=�6-    � SizeToContent$ Height=�5   	    � Title$ 节假日信息��5   	   $	��240��6   $	��320��6$    � 	Resources 5	         Ok �� Text 
 Cancel��%T   &	        &	       �� 5
   
   $ 确定��6%   �� 5   
   $ 取消��6)   5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6]     5   
   -   5        # [ 5      6;   .��5      ]� .+�5   
   �� $��Bottom=�6    �� Orientation$ 
Horizontal=�6-   $��Right=�6F   .+�5      �� $��确定��6   $��88��6"   $��5q�6-   #��[  68   �� 5      $��取消��6   $��88��6"   $��5q�6-   #��[ 68   	 �� IsCancel	 . 6Z   5      �� 5   
   $
��Auto=�6   .��5      � 
 � RowDefinitions
 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$    � ColumnDefinitions 5!      �� 5"      $
��Auto �6'   �� 5#      $��* �6'    5&       �� 
TargetType �� Property �� Value  TextBoxStyle �� BasedOn��%E  '��       '�� �     7  �� 5'      " ��6   .�5(      ��  � ��$ Right=�6@   �� 5)       � ��$ 2q�63   �� 5*       � ��$
 Bold"�67   5+      �� 5,      " ��6   8   .�5-      ��  � ��$ Center=�6>   �� 5.       � ��$	 120��65   �� 5/       � ��$ 2q�63   50      51      .+�54      �� $��0��6   $��0��6%   $��节日名称：��65   �� 55      $��1��6   $��0��6%   $��开始时间：��65   �� 56      $��2��6   $��0��6%   $��结束时间：��65   �� 57      $��3��6   $��0��6%   $��行情编码：��65   �� 58      $��4��6   $��0��6%   $��节日描述：��65   �� 5;      -   5         ��Name$ 	TbHoliday��5;   7   $��0��6   $��1��6'   .��6J   ��5<      �� 5=       �� Path$ HolidayName�6"    �� Mode$ TwoWay=�65    �� UpdateSourceTrigger$ PropertyChanged=�6C    �� ValidationRules 5>      3   -Gss.Entities.ValidationHelper.StringRegexRule  5?   "   ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated .    	MinLength$ 1��6[      	MaxLength$ 50��6i   5A      .��5B   $   5D      &   Xceed.Wpf.Toolkit.DateTimePicker  5I      $��2q�6%   $��1��6Y   $��1��6f   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 61   �� *	StartTime+$ TwoWay=�6f     5J      $��2q�6%   $��2��6X   $��1��6e    61   �� *	EndTime+$ TwoWay=�6e   � 5L      $��1��6   $��3��6'   
 5M      �� 5N      $��30 �6(   �� 5O      $
��auto �6(    5Q      �� 5R      �� 5S      $��30 �6+   .+�5U      �� -   5        $��txtCode��5U       �� 
IsReadOnly . .��6@   ��5V      �� 5W      $ 	StockCode�6&   $ TwoWay=�67   $ PropertyChanged=�6E    5X   "     5Y   &    . $ 1��6_   $	 100��6m   5[      .��5\   (   5]      �� 5_      -   5        $��1��5_      .��6B   设置6F   �� 5`      -   5        $��sp��5`   B   $��1��6!   $��2��6.   .+�5a      � -   5        $��wp��5a   %   5b      �� 5c      $��Center=�6%   $ 
Horizontal=�6B   .+�5d      �� -	   5        .��5d   8   确定6<   �� 5e      -
   5        $
��20,0q�5e   %   .��6J   取消6N   5f      5g      5i      �� 5j      $��4��6   $��2��6'   $��1��68    �� MinLines$ 3��6H    �� 	MaxLength$	 100��6U    �� AcceptsReturn .  �� TextWrapping$ WrapWithOverflow=�6z   .��5k      ��5l      �� 5m      $ DescMsg�6"   $ TwoWay=�61   $ PropertyChanged=�6?    5n      4   .Gss.Entities.ValidationHelper.StringLengthRule  5o   "    .    	MinLength$ 1��6\      	MaxLength$	 200��6j   5q      .��5r   $   5s      5t      5u      5v      5w      