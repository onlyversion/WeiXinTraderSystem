   M S B A M L   `   `   `  ���� M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Gss.ManagementMenu.AccountManager.Order'Gss.ManagementMenu.AccountManager.Order  E AGss.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO6clr-namespace:Gss.Common.Converter;assembly=Gss.CommonGss.Common.Converter =    7Gss.ManagementMenu.AccountManager.Order.OrderInfoWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Eloc5clr-namespace:Gss.ManagementMenu.AccountManager.Order     L	converter6clr-namespace:Gss.Common.Converter;assembly=Gss.Common     -   $��orderInfoWindow��  � WindowStyle$  
ToolWindow=� � Title$ 订单信息��$	��600��$
��1000�� � WindowStartupLocation$ CenterScreen=� � 	Resources .  (Gss.Common.Converter.PercentageConverter   PercentageConverter��%   &	          .���  � RowDefinitions �� $��* ��� $��35 �.+��� .@��� $��在手订单��.��9   3Gss.ManagementMenu.AccountManager.Order.MarketOrder     FundInformation �� *FundInformation+ �� ElementName$ orderInfoWindow�� �� Mode$ TwoWay=�   AccountName �� *AccountName+$ orderInfoWindow��$ TwoWay=��� $��平仓历史��.��@   :Gss.ManagementMenu.AccountManager.Order.MarketOrderHistory  	   AccountName	 �� *AccountName+$ orderInfoWindow��$ TwoWay=��� $��1��
 �� Orientation$
 
Horizontal=� � DataContext �� *FundInformation+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ WindowL�.+��� $��	账户：���� $��0,5,0,0q�
���   �����  �� Path$ AccountName� �� $ FindAncestor=�$ WindowL��� $��账户结余：���� $��0,5,0,0q�
���   ����� $ AccountBalance� �� StringFormat$ n���� $��冻结资金：���� $��0,5,0,0q�
���   ����� $ DongJieMoney�$ n���� $��浮动盈亏：���� $��0,5,0,0q�
���  ������ $ LossOrProfit�$ n���� $��净资金余额：���� $��0,5,0,0q�
���   ����� $ 	NetAssets�$ n���� $��	保证金���� $��0,5,0,0q�
���   ����� $ OccupiedDeposit�$ n���� $��可用资金���� $��0,5,0,0q�
���   ����� $ AvailableDeposit�$ n���� $��风险系数：���� $��0,5,0,0q�
���   ����� $ RiskCoefficient� �� 	Converter# [  $
 {0}%��