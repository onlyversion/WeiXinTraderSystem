   M S B A M L   `   `   `  ���� J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gss.PopUpWindow.ConverterGss.PopUpWindow.Converter  E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK4clr-namespace:Gss.Common.Utility;assembly=Gss.CommonGss.Common.Utility O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem G CGss.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.EntitiesGss.Entities.ValidationHelper '    !Gss.PopUpWindow.ProductInfoWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     7cvt'clr-namespace:Gss.PopUpWindow.Converter     X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  >uti4clr-namespace:Gss.Common.Utility;assembly=Gss.Common  0sys&clr-namespace:System;assembly=mscorlib  PValiHelpAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.Entities    � WindowStartupLocation$  CenterOwner=� � WindowStyle$ 
ToolWindow=� � SizeToContent$ Height=� � Title$ 商品信息详情��$	��600��$	��640�� � 	Resources    Ok �� Text 
 Cancel9   3Gss.PopUpWindow.Converter.ProductStateEnumConverter  ProductStateCvt5   /Gss.PopUpWindow.Converter.DateLongTimeConverter  LongTimeCvt �� 
TargetType �� Property �� Value  TextBoxStyle	 �� BasedOn$  Xceed.Wpf.Toolkit.DoubleUpDown0  *Gss.Common.Utility.DoubleUpDownInputFilter%  Xceed.Wpf.Toolkit.IntegerUpDown2  ,Gss.Common.Utility.IntergerUpDownInputFilter��%X  &	        &	      &	 $     &	 )     '�� .     '�� h     '�� �     7  '�� �     '  8    '  �    �� $ 确定���� $ 取消��    �� " ��.���  � ��$ 3q���  � ��$
 Bold"��� " ��.���  � ��$ 2q���  � ��$ Right=���  � ��$
 Bold"��� " ��8	   .���  � ��$ 2q���  � ��$ Normal"��� " ��.���  � ��$ 2q���  � ��$ Normal"��� "  .���  � ��$ 2q���  � ��$ Normal"���  �@ 	DigitOnly . �� "  .���  � ��$ 2q���  � ��$ Normal"���  �@ 	DigitOnly$
 TrueX�
 J� CommandBindings
 )  #System.Windows.Input.CommandBinding  -      Command# [    -   # [ .��]� .+��� $��Bottom=� �� Orientation$ 
Horizontal=�$��Right=�.+��� $��确定��$��88��$��5q�#��[   �� 	IsDefault . �� $��取消��$��88��$��5q�#��[  �� IsCancel . �� .+��� $��基本信息��.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �.+��� $��商品名称：���� $��1��$��行情编码：���� -   $��TbName��$��1������ *ProductName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� -   $��CbStockCode��$��1��$��1��{��� *IsNew+ �� RelativeSource ��  �� AncestorType$ WindowL� �� Mode$ FindAncestor=����� *RawMaterialsCodeList+ �� $ WindowL�$ FindAncestor=� �� SelectedItem �� *	StockCode+$ TwoWay=�$ PropertyChanged=��� $��2��$��商品编码：���� -   $��TbProductCode��$��3��{��� *IsNew+ �� $ WindowL�$ FindAncestor=����� *ProductCode+$ TwoWay=�$ PropertyChanged=��� $��交易控制��.���  �� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $��3* ��� $
��Auto ��� $��2* �.+��� $��交易状态：���� $��1��$��价格区间：���� $��2��$��最大时差：���� $��1��$��2q�$��Normal"�$	��207��$
��Left=� �� *State+ �� 	Converter# [ .@���正常交易����	只报价����	只买涨����	只买跌����全部禁止���� $��1��$��1��$ 
Horizontal=�$��2q�.+�  �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$ C2��$��88��   Minimum$
 0.01X�   	Increment$
 0.01X��	  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 	  Value �� *AllowMinPrice+$ TwoWay=��� $	��到��  $ C2��$��88��$ 1X� �� *AllowMaxPrice+$ TwoWay=��� $��1��$��2��$ 
Horizontal=�$��2q�.+�  $	��180���
  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]] 
  Minimum$ 0X��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value �� *AllowMaxTimeDeviation+�� $	��秒���� $��交易设置��$��3q�.���  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �.+��� $��	点差：���� $��1��$��	点值：���� $��1��$��2��$��重量单位：���� $��4��$��交易工费公式：��  $��1��$ 0X� �� *Spread+$ TwoWay=�  $��1��$��1��$ 0X�$
 0.01X�$ F2�� �� *
PointValue+$ TwoWay=�  $��3��$��1��$ 0X�$ 0.001X� �� *
WeightUnit+$ TwoWay=��� $��1��$��4�� �� TextWrapping$ WrapWithOverflow=�.������  �� Path$ TransactionFeeFormula�$ TwoWay=�  �� ValidationRules  4  .Gss.Entities.ValidationHelper.StringLengthRule  !   	MaxLength$! 50��.���� $��2��$��点差基值：���� $��2��$��4��$��保证金计算公式：��%  Xceed.Wpf.Toolkit.DecimalUpDown  $��0��$��3���  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]"   Minimum$" 0X�#   	Increment$
# 0.01X��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]$   Value$ �� *SpreadBaseValue+$ TwoWay=��� $��3��$��4��$ WrapWithOverflow=�.������ $ DepositFormula�$ TwoWay=�    $! 50��.��