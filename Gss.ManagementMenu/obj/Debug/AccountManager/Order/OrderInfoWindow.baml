   M S B A M L   `   `   `  ����M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Gss.ManagementMenu.AccountManager.Order'Gss.ManagementMenu.AccountManager.Order  5   	   E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter 5   	   =    7Gss.ManagementMenu.AccountManager.Order.OrderInfoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Eloc5clr-namespace:Gss.ManagementMenu.AccountManager.Order     5   	   L	converter6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     5   	   -   5        $��orderInfoWindow��5   2     � WindowStyle$  
ToolWindow=�5   	    � Title$ 订单信息��5      $	��600��6   $
��1000��6%    � WindowStartupLocation$ CenterScreen=�6J    � 	Resources 5	      .  (Gss.Common.Converter.PercentageConverter   PercentageConverter��%   &	          5
   
   6(   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��35 �6   .+�5   
   �� .@�5      �� $��在手订单��6   .��5      9   3Gss.ManagementMenu.AccountManager.Order.MarketOrder     FundInformation 6"   �� *FundInformation+ �� ElementName$ orderInfoWindow�� �� Mode$ TwoWay=�   AccountName 6y   �� *AccountName+$ orderInfoWindow��$ TwoWay=�5      �� 5      $��平仓历史��6   .��5      @   :Gss.ManagementMenu.AccountManager.Order.MarketOrderHistory  	   AccountName	 6*   �� *AccountName+$ orderInfoWindow��$ TwoWay=�5      5!      �� 5"   
   $��1��6   
 �� Orientation$
 
Horizontal=�6"    � DataContext 6<   �� *FundInformation+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ WindowL�.+�5#      �� $��	账户：��6   �� 5$      $��0,5,0,0q�6   
���   ���6*   ��  �� Path$ AccountName� �� $ FindAncestor=�$ WindowL�6�   �� 5%      $��账户结余：��6   �� 5&      $��0,5,0,0q�6   
���   ���6)   �� $ AccountBalance� �� StringFormat$ n��6]   �� 5(      $��冻结资金：��6   �� 5)      $��0,5,0,0q�6   
���   ���6)   �� $ DongJieMoney�$ n��6[   �� 5+      $��浮动盈亏：��6   �� 5,      $��0,5,0,0q�6   
���  ����6)   �� $ LossOrProfit�$ n��6[   �� 5-      $��净资金余额：��6   �� 5.      $��0,5,0,0q�6   
���   ���6)   �� $ 	NetAssets�$ n��6X   �� 5/      $��	保证金��6   �� 50      $��0,5,0,0q�6   
���   ���6)   �� $ OccupiedDeposit�$ n��6^   �� 53      $��可用资金��6   �� 54      $��0,5,0,0q�6   
���   ���6)   �� $ AvailableDeposit�$ n��6_   �� 55      $��风险系数：��6   �� 56      $��0,5,0,0q�6   
���   ���6)   �� $ RiskCoefficient� �� 	Converter# [  $
 {0}%��6�   58      59      5:      