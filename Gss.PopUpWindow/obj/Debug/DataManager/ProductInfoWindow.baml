   M S B A M L   `   `   `  ����J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gss.PopUpWindow.ConverterGss.PopUpWindow.Converter  5   	   E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK4clr-namespace:Gss.Common.Utility;assembly=Gss.CommonGss.Common.Utility 5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	   G CGss.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.EntitiesGss.Entities.ValidationHelper 5   	   '    !Gss.PopUpWindow.ProductInfoWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   7cvt'clr-namespace:Gss.PopUpWindow.Converter     5   	   X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   >uti4clr-namespace:Gss.Common.Utility;assembly=Gss.Common  5   	   0sys&clr-namespace:System;assembly=mscorlib  5   	   PValiHelpAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.Entities  5   	     � WindowStartupLocation$  CenterOwner=�5	   	    � WindowStyle$ 
ToolWindow=�6-    � SizeToContent$ Height=�5
   	    � Title$ 商品信息详情��5   	   $	��600��6   $	��640��6%    � 	Resources 5         Ok �� Text 
 Cancel9   3Gss.PopUpWindow.Converter.ProductStateEnumConverter  ProductStateCvt5   /Gss.PopUpWindow.Converter.DateLongTimeConverter  LongTimeCvt �� 
TargetType �� Property �� Value  TextBoxStyle	 �� BasedOn$  Xceed.Wpf.Toolkit.DoubleUpDown0  *Gss.Common.Utility.DoubleUpDownInputFilter%  Xceed.Wpf.Toolkit.IntegerUpDown2  ,Gss.Common.Utility.IntergerUpDownInputFilter��%�  &	        &	       &	 @     &	 S     '�� f     '�� �     '�� g    7  '�� �    '  J    '  �    �� 5   
   $ 确定��6%   �� 5   
   $ 取消��6)     5   
   6(     5   
   6$   �� 5   
   " ��6   .�5      ��  � ��$ 3q�6'   �� 5       � ��$
 Bold"�6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 2q�6'   �� 5       � ��$ Right=�64   �� 5       � ��$
 Bold"�6+   5      �� 5   
   " ��6   8	   .�5      ��  � ��$ 2q�6'   �� 5       � ��$ Normal"�6+   5       �� 5!   
   " ��6   .�5"      ��  � ��$ 2q�6'   �� 5#       � ��$ Normal"�6+   5%      �� 5&   
   "  6   .�5'      ��  � ��$ 2q�6'   �� 5(       � ��$ Normal"�6+   �� 5*       �@ 	DigitOnly . 6F   5+      �� 5,   
   "  6   .�5-      ��  � ��$ 2q�6'   �� 5.       � ��$ Normal"�6+   �� 50       �@ 	DigitOnly$
 TrueX�6H   51      52      
 J� CommandBindings
 54      )  #System.Windows.Input.CommandBinding  55   
   -   5           Command# [  55      6]     56   
   -   5        # [ 56      6;   .��59      ]� .+�5:   
   �� $��Bottom=�6    �� Orientation$ 
Horizontal=�6-   $��Right=�6F   .+�5;      �� $��确定��6   $��88��6"   $��5q�6-   #��[  68    �� 	IsDefault . 6V   �� 5<      $��取消��6   $��88��6"   $��5q�6-   #��[ 68    �� IsCancel . 6Z   5=      �� 5>   
   .+�5?      �� $��基本信息��6   .��5@      �  � RowDefinitions 5A      �� 5B      $
��Auto �6(   �� 5C      $
��Auto �6(   �� 5D      $
��Auto �6(   �� 5E      $
��Auto �6(   �� 5F      $
��Auto �6(   �� 5G      $
��Auto �6(   �� 5H      $
��Auto �6(   �� 5I      $
��Auto �6(    � ColumnDefinitions 5K      �� 5L      $
��Auto �6+   �� 5M      $��* �6+   �� 5N      $
��Auto �6+   �� 5O      $��* �6+   .+�5R      �� $��商品名称：��6   �� 5S      $��1��6   $��行情编码：��6)   �� 5Z      -   5        $��TbName��5Z   .   $��1��6   ��5[      �� *ProductName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5]      -   5        $��CbStockCode��5]   �   $��1��6   $��1��6�   {�6/   �� *IsNew+ �� RelativeSource ��  �� AncestorType$ WindowL� �� Mode$ FindAncestor=���6�   �� *RawMaterialsCodeList+ �� $ WindowL�$ FindAncestor=� �� SelectedItem 5^      �� *	StockCode+$ TwoWay=�$ PropertyChanged=�5m      �� 5p      $��2��6   $��商品编码：��6,   �� 5t      -   5        $��TbProductCode��5t   .   $��3��6   {�6C   �� *IsNew+ �� $ WindowL�$ FindAncestor=���5u      �� *ProductCode+$ TwoWay=�$ PropertyChanged=�5�      5�      �� 5�      $��交易控制��6   .��5�      �  5�      �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(    5�      �� 5�      $
��Auto �6+   �� 5�      $��3* �6+   �� 5�      $
��Auto �6+   �� 5�      $��2* �6+   .+�5�      �� $��交易状态：��6   �� 5�      $��1��6   $��价格区间：��6)   �� 5�      $��2��6   $��最大时差：��6)   �� 5�      $��1��6   $��2q�6/   $��Normal"�6;   $	��207��6O   $
��Left=�6[    5�   #   �� *State+ �� 	Converter# [ .@�5�      ��正常交易��6+   ��5�      	只报价��6*   ��5�      	只买涨��6*   ��5�      	只买跌��6*   ��5�      全部禁止��6+   5�      �� 5�      $��1��6!   $��1��61   $ 
Horizontal=�6>   $��2q�6W   .+�5�        �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$ C2��6,   $��88��6>      Minimum$
 0.01X�6L      	Increment$
 0.01X�6[   �	  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 	  Value 5�   0   �� *AllowMinPrice+$ TwoWay=��� 5�      $	��到��6      5�      $ C2��6,   $��88��6>   $ 1X�6L    5�   0   �� *AllowMaxPrice+$ TwoWay=�5�      �� 5�      $��1��6!   $��2��61   $ 
Horizontal=�6>   $��2q�6W   .+�5�        $	��180��6-   �
  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 
  Minimum$ 0X�6<   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 5�   1   �� *AllowMaxTimeDeviation+�� 5�      $	��秒��6    5�      5�      5�      �� 5�      $��交易设置��6   $��3q�6%   .��5�      �  5�      �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(    5�      �� 5�      $
��Auto �6+   �� 5�      $��* �6+   �� 5�      $
��Auto �6+   �� 5�      $��* �6+   .+�5�      �� $��	点差：��6   �� 5�      $��1��6   $��	点值：��6)   �� 5�      $��1��6   $��2��6)   $��重量单位：��69   �� 5�      $��4��6   $��交易工费公式：��6)     5�      $��1��6)   $ 0X�69    5�   )   �� *Spread+$ TwoWay=�  5�      $��1��6(   $��1��68   $ 0X�6E   $
 0.01X�6Q   $ F2��6b    5�   (   �� *
PointValue+$ TwoWay=�  5�      $��3��6(   $��1��68   $ 0X�6E   $ 0.001X�6Q    5�   (   �� *
WeightUnit+$ TwoWay=��� 5�      $��1��6   $��4��6.    �� TextWrapping$ WrapWithOverflow=�6;   .��6[   ��5�      �� 5�       �� Path$ TransactionFeeFormula�6&   $ TwoWay=�6C     �� ValidationRules  5�   "   4  .Gss.Entities.ValidationHelper.StringLengthRule  5�   &   !   	MaxLength$! 50��6@   5�      .��5�   (   5�      �� 5�      $��2��6   $��点差基值：��6,   �� 5�      $��2��6   $��4��6,   $��保证金计算公式：��69   %  Xceed.Wpf.Toolkit.DecimalUpDown  5�      $��0��6)   $��3��66   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]"   Minimum$" 0X�6F   #   	Increment$
# 0.01X�6R   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]$   Value$ 5�   (   �� *SpreadBaseValue+$ TwoWay=��� 5	     $��3��6   $��4��6.   $ WrapWithOverflow=�6<   .��6\   ��5
     �� 5     $ DepositFormula�6&   $ TwoWay=�6<     5  "     5  &   $! 50��6@   5     .��5  (   5     5     5      5!     5"     5#     