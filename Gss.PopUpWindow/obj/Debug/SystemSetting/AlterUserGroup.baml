   M S B A M L   `   `   `  ����J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Gss.PopUpWindow.ValidationHelper Gss.PopUpWindow.ValidationHelper  5   
   2    ,Gss.PopUpWindow.SystemSetting.AlterUserGroup   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   E
Validation.clr-namespace:Gss.PopUpWindow.ValidationHelper     5   
     � Title$  修改用户组��5   	   $	��214��6   $	��409��6$    � WindowStartupLocation$ CenterScreen=�60    � WindowStyle$ 
ToolWindow=�6U   .��5      � -   5        $��	grid_Root��5       � ColumnDefinitions 5   
   �� 5	      $	��108 �6   �� 5
      $��1* �6   �� 5      $��90 �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � BindingGroup 5   
   &   System.Windows.Data.BindingGroup  5      .+�5   
   �� $��客户组名称:��6   $��Right=�6#   $��Center=�6?   �� 5   
   $��下单滑点:��6   $��1��6!   $��Right=�6.   $��Center=�6J   �� 5   
   $��平仓滑点:��6   $��2��6!   $��Right=�6/   $��0��6K   $��Center=�6[   �� 5   
   $��下单延迟(秒):��6   $��1��6$   $��2��61   $��Right=�6C   $��Center=�6_   �� 5   
   $��平仓延迟(秒):��6   $��2��6$   $��Right=�62   $��2��6N   $��Center=�6^   �� 5   
   $!��平仓后下单间隔(秒):��6   $��Right=�6(   $��3��6D   $��Center=�6Q   �� 5!   
   $��1��6   $��3��6"   $��5,2,2,2q�66   .��6G   ��5"      �� 5#       �� Path$ UserGroupName�6    �� ValidationRules 5$      7   1Gss.PopUpWindow.ValidationHelper.StringLengthRule  5%         	MinLength$ 1��66   	   	MaxLength$	 16��6D   5'      .��5(      5)      �� 5+   
   $��Center=�6   $��Right=�60   $��5q�6L   $��默认分组��6W   $��2��6f   $��3��6v   
 d� 	IsChecked
 5,      �� *IsDefaultGroup+5.      �� 5/   
   $��1��6   $��1��6"   .��6/   ��50      �� 51      $ PlaceOrderSlipPoint�6    52      4   .Gss.PopUpWindow.ValidationHelper.IsPlusIntRule  53      55      .��56      58      �� 59   
   $��1��6   $��2��6"   .��60   ��5:      �� 5;      $ FlatOrderSlipPoint�6    5<        5=      5?      .��5@      5A      �� 5B   
   $��3��6   $��1��6"   .��60   ��5C      �� 5D      $ DelayPlaceOrder�6    5E      3   -Gss.PopUpWindow.ValidationHelper.IsDoubleRule  5F      5H      .��5I      5J      �� 5K   
   $��3��6   $��2��6#   .��61   ��5L      �� 5M      $ DelayFlatOrder�6    5N        5O      5Q      .��5R      5S      �� 5T   
   $��1��6   $��3��6#   .��61   ��5U      �� 5V      $ AfterSecond�6    5W        5X      5Z      .��5[      5\      �� 5^   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��4��6K   $��4��6X   $��0��6l   .+�5_      �� -   5        $��30��5_   ,   $��60��68   .��6C   	确 定6H   �� 5`      -   5        $
��10,0q�5`      $��30��68   $��60��6D   .��6O   	取 消6T   5a      5c      5d      