   M S B A M L   `   `   `  ����J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null^@clr-namespace:Gss.PopUpWindow.Converter;assembly=Gss.PopUpWindowGss.PopUpWindow.Converter  5       Gss.ManagementMenu7   1Gss.ManagementMenu.DataManager.ProductInfoControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      SpopCvt@clr-namespace:Gss.PopUpWindow.Converter;assembly=Gss.PopUpWindow     5      X TXceed.Wpf.Toolkit, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xckt)http://schemas.xceed.com/wpf/xaml/toolkit  5      -   5          +� IsFocusScope  .  � 	Resources 5         BoolVisibilityCvt  
ViewDetail �� Text 
 Delete  ManualPrice 
 AddCmd  
RefreshCmd9   3Gss.PopUpWindow.Converter.ProductStateEnumConverter  ProductStateCvt  CmProductInfo m� Command m� CommandTarget �� Path �� RelativeSource �� AncestorType ��Name	 �� 
TargetType
 �� Triggers �� Binding �� Value �� Property �� Value � DataContext �� Mode �� 	Converter)  #System.Windows.Controls.DataGridRow  DataGridRowBaseStyle �� BasedOn��%�  &	        &	      &	 9     &	 _     &	 �     &	 �     &	 �     &	 �     7  7  7  7   7  '  �    7  7  �� 5	   
   6'   �� 5
   
   $ 详细信息��6-   �� 5   
   $ 删除商品��6)   �� 5   
   $ 手工报价��6.   �� 5   
   $ 新增��6)   �� 5   
   $ 刷新��6-     5   
   6+   �� 5   
   .@�5      m� 8    6   �� $ PlacementTarget� �� $ ContextMenuL�6�   �� 5      $ 
SpMenuItem��6   ��5      �� 5      "	 ��6   
 5      �� 5       6*   �� *AccInfo.AccountName+	 admin6R   .a�5   "   ��  � y�$ 	Collapsed=�6I   5      5      5      m� 5      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5*      8   6   �� *DataContext+ �� $ UserControlL�$ FindAncestor=�y�5+      �� *%#AccountAuthority.ManualPriceEnabled+8   5,      �� $ PlacementTarget� �� $ ContextMenuL�6�   m� 5-      8   6   �� $ PlacementTarget� �� $ ContextMenuL�6�   5/      �� 51   
   "	  6   8   .�52      -   5        �� 53       �@�ContextMenu8  6,   �� 54       � ��$ 26��6*   55      56       J� CommandBindings 58      )  #System.Windows.Input.CommandBinding  59   
   -   5           Command# [ 59      6?     5:   
   -   5        # [ 5:      6;     5;   
   -   5        # [ 5;      6@     5<   
   -   5        # [ 5<      6;     5=   
   -   5        # [ 5=      6?   .��5@      ]� .+�5I   
   %  Xceed.Wpf.Toolkit.BusyIndicator     IsBusy 6   �� *IsLoadingProductInfoList+   BusyContent 5J      �� 5K      $��加载中...��6   $��20(�6*   $
��Bold"�68   $��Center=�6J   $��Center=�6e   .��5M      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     SelectionMode$ Single=�63      
IsReadOnly .    CanUserResizeRows .  ��5N      �� *ProductInfoes+   Columns 5O      4  .System.Windows.Controls.DataGridTemplateColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6-      Header$ 名称��68      CellTemplate 5R      �� 5S      .R�5T   "   �� $��0q�6;   
������  �� 
IsReadOnly . ��6*   Z� ��5U   <   �� *ProductName+5V      5X      0	  *System.Windows.Controls.DataGridTextColumn	  5Y      $ 70 6*   $ 状态��65   1
  +System.Windows.Controls.DataGridBoundColumn  
  Binding  6A   �� *State+# [ 	  5Z      $ 70 6)   $ 点差��64     6@   �� *Spread+	  5[      $ 70 6*   $ 点值��65     6A   �� *
PointValue+	  5\      $ 70 6)   $ 点差基值��64     6B   �� *SpreadBaseValueString+	  5]      $ 70 6)   $ 	最小价��64     6A   �� *AllowMinPrice+	  5^      $ 70 6)   $ 	最大价��64     6A   �� *AllowMaxPrice+	  5_      $	 100 6*   $ 最大时差(秒)��66     6G   �� *AllowMaxTimeDeviation+5b      5c      5d      5e      