   M S B A M L   `   `   `  ���� G  CGss.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.EntitiesGss.Entities.ValidationHelper   Gss.PopUpWindow'   !Gss.PopUpWindow.HolidayInfoWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f42tk)http://schemas.xceed.com/wpf/xaml/toolkit  PValiHelpAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.Entities  -     � WindowStartupLocation$  CenterOwner=� � WindowStyle$ 
ToolWindow=� � SizeToContent$ Height=� � Title$ 节假日信息��$	��240��$	��320�� � 	Resources    Ok �� Text 
 Cancel��%8   &	        &	      �� $ 确定���� $ 取消�� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [ .��]� .+��� $��Bottom=� �� Orientation$ 
Horizontal=�$��Right=�.+��� $��确定��$��88��$��5q�#��[  �� $��取消��$��88��$��5q�#��[ 	 �� IsCancel	 . �� $
��Auto=�.��� 
 � RowDefinitions
 �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* �  �� 
TargetType �� Property �� Value  TextBoxStyle �� BasedOn��%�   '��       '�� S     7  �� " ��.���  � ��$ Right=���  � ��$ 2q���  � ��$
 Bold"��� " ��8   .���  � ��$ Center=���  � ��$	 120����  � ��$ 2q�.+��� $��0��$��0��$��节日名称：���� $��1��$��0��$��开始时间：���� $��2��$��0��$��结束时间：���� $��3��$��0��$��行情编码：���� $��4��$��0��$��节日描述：���� -    ��Name$ 	TbHoliday��$��0��$��1��.������  �� Path$ HolidayName� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� ValidationRules 3   -Gss.Entities.ValidationHelper.StringRegexRule  ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated .    	MinLength$ 1��   	MaxLength$ 50��.��&   Xceed.Wpf.Toolkit.DateTimePicker  $��2q�$��1��$��1���  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value �� *	StartTime+$ TwoWay=�  $��2q�$��2��$��1�� �� *	EndTime+$ TwoWay=�� $��1��$��3��
 �� $��30 ��� $
��auto � �� �� $��30 �.+��� -   $��txtCode�� �� 
IsReadOnly . .������ $ 	StockCode�$ TwoWay=�$ PropertyChanged=�    . $ 1��$	 100��.���� -   $��1��.��设置�� -   $��sp��$��1��$��2��.+�� -   $��wp���� $��Center=�$ 
Horizontal=�.+��� -	   .��确定�� -
   $
��20,0q�.��取消�� $��4��$��2��$��1�� �� MinLines$ 3�� �� 	MaxLength$	 100�� �� AcceptsReturn .  �� TextWrapping$ WrapWithOverflow=�.������ $ DescMsg�$ TwoWay=�$ PropertyChanged=� 4   .Gss.Entities.ValidationHelper.StringLengthRule   .    	MinLength$ 1��   	MaxLength$	 200��.��