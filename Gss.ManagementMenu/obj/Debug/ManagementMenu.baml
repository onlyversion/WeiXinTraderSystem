   M S B A M L   `   `   `  ����M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:Gss.ManagementMenu.AccountManager.Clerk'Gss.ManagementMenu.AccountManager.Clerk  5      U/clr-namespace:Gss.ManagementMenu.AccountManager!Gss.ManagementMenu.AccountManager  5      Q-clr-namespace:Gss.ManagementMenu.TradeManagerGss.ManagementMenu.TradeManager  5      S.clr-namespace:Gss.ManagementMenu.SystemSetting Gss.ManagementMenu.SystemSetting  5      O,clr-namespace:Gss.ManagementMenu.DataManagerGss.ManagementMenu.DataManager  5      K*clr-namespace:Gss.ManagementMenu.ConverterGss.ManagementMenu.Converter  5      S.clr-namespace:Gss.ManagementMenu.CustomControl Gss.ManagementMenu.CustomControl  5	      c6clr-namespace:Gss.ManagementMenu.AccountManager.Dealer(Gss.ManagementMenu.AccountManager.Dealer  5
      Y1clr-namespace:Gss.ManagementMenu.TakeGoodsManager#Gss.ManagementMenu.TakeGoodsManager  5      ]3clr-namespace:Gss.ManagementMenu.AccountManager.Org%Gss.ManagementMenu.AccountManager.Org  5      '    !Gss.ManagementMenu.ManagementMenu   5      <my5clr-namespace:Gss.ManagementMenu.AccountManager.Clerk  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      BaccMgr/clr-namespace:Gss.ManagementMenu.AccountManager     5      BtradeMgr-clr-namespace:Gss.ManagementMenu.TradeManager     5      E
sysSetting.clr-namespace:Gss.ManagementMenu.SystemSetting     5      @dataMgr,clr-namespace:Gss.ManagementMenu.DataManager     5      :cvt*clr-namespace:Gss.ManagementMenu.Converter     5      >cus.clr-namespace:Gss.ManagementMenu.CustomControl     5	      IDealer6clr-namespace:Gss.ManagementMenu.AccountManager.Dealer     5
      NTakeGoodsManager1clr-namespace:Gss.ManagementMenu.TakeGoodsManager     5      COrg3clr-namespace:Gss.ManagementMenu.AccountManager.Org     5      -   5          � 	Resources  5      A   ;Gss.ManagementMenu.Converter.BooleanNullVisibilityConverter   BoolNullVisibilityCvt  BoolVisibilityCvt �� 
TargetType �� Property �� Value6   0Gss.ManagementMenu.CustomControl.GssTreeViewItem �� Orientation �� RelativeSource �� AncestorType  LbStyle��%3  &	        &	      'Q� &     '  w     &	 �      5   
   6-   �� 5   
   6'   �� 5   
   " Q�6   .�5      ��  �@�Cursor$
 Hand��6'   5      �� 5   
   "  6   .�5      ��  � �� 5      �� 5      .R�5      �� $ 
Horizontal=�6%   $��2q�6>   .+�5      �� $��2q�5   $   ��5   $   �� *Icon+ �� $ cus:GssTreeViewItemL���5   $   �� *
IconSize+ �� $ cus:GssTreeViewItemL�5   $   �� 5      $��Center=�6(   $��2q�6C   ��5   (   �� *Title+ �� $ cus:GssTreeViewItemL���5   (   �� *	TitleSize+ �� $ cus:GssTreeViewItemL���5    (   �� *TitleWeight+ �� $ cus:GssTreeViewItemL�5!      5"      5$      5%      �� 5'   
   " ��6   .�5(      ��  � ��$ 5q�6'   5)      5+      .@�5.        -   5          Name$ tvAccMgr��5.   -    Q� 
IsExpanded . 	   Title$	 账户管理��6?   
   TitleWeight$

 Bold"�6M      Icon$= 7/Gss.ManagementMenu;component/Images/AccountManager.png��6`   y�5/      �� *AccountManager+ �� 	Converter# [  .@�5?   
     $	 客户管理��6   $< 6/Gss.ManagementMenu;component/Images/ClientAccount.png��6+   y�5@      �� *ClientAccountManager+# [    View 5A      <   6Gss.ManagementMenu.AccountManager.ClientAccountControl  5B      5D        5K   
   $	 	微会员��6   $9 3/Gss.ManagementMenu;component/Images/OrgManager.png��6*   y�5L      �� *
OrgManager+# [  5M      =   7Gss.ManagementMenu.AccountManager.Org.OrgManagerControl  5N      5P        5Q   
   $	 会员账户��6   $< 6/Gss.ManagementMenu;component/Images/DealerAccount.png��6+   y�5R      �� *DealerAccountManager+# [  5S      C   =Gss.ManagementMenu.AccountManager.Dealer.DealerAccountControl  5T      5V        5W   
   $	 	管理员��6   $= 7/Gss.ManagementMenu;component/Images/ManagerAccount.png��6*   y�5X      �� *AdminAccountManager+# [  5Y      ;   5Gss.ManagementMenu.AccountManager.AdminAccountControl  5Z      5\      5`        5c      -   5        $ 
tvTradeMgr��5c   -    . $	 交易管理��6A   $

 Bold"�6O   $; 5/Gss.ManagementMenu;component/Images/TradeManager.png��6b   y�5d      �� *IsTradeManagerEnabled+# [  .@�5u   
     $	 在手订单��6   $: 4/Gss.ManagementMenu;component/Images/MarketOrder.png��6+   y�5v      �� *AllowViewMarketOrder+# [  5w      1   +Gss.ManagementMenu.TradeManager.MarketOrder  5x      5z        5�   
   $	 入库订单��6   $: 4/Gss.ManagementMenu;component/Images/Warehousing.png��6+   y�5�      �� *AllowViewWarehousing+# [  5�      6   0Gss.ManagementMenu.TradeManager.WarehousingOrder  5�      5�        5�   
   $	 平仓历史��6   $? 9/Gss.ManagementMenu;component/Images/ChargebackRecord.png��6+   y�5�      �� *AllowViewChargebackRecord+# [  5�      6	   0Gss.ManagementMenu.TradeManager.ChargebackRecode	  5�      5�        5�   
   $	 资金明细��6   $9 3/Gss.ManagementMenu;component/Images/FundReport.png��6+   y�5�      �� *AllowFundReport+# [  5�      0
   *Gss.ManagementMenu.TradeManager.FundReport
  5�      5�        5�   
   $	 对冲交易��6   $B </Gss.ManagementMenu;component/Images/HedgingTransactions.png��6+   y�5�      �� *AllowViewHedgingTransactions+# [  5�      0   *Gss.ManagementMenu.TradeManager.HedgeTrade  5�      5�        5�   
   $	 会员报表��6   $< 6/Gss.ManagementMenu;component/Images/DealerAccount.png��6-   y�5�      �� *AllowJujian+# [  5�      8   2Gss.ManagementMenu.TradeManager.InterofficeManager  5�      5�        5�   
   $	 出金处理��6   $5 //Gss.ManagementMenu;component/Images/ChuJin.png��6+   y�5�      �� *TradeChuJin+# [  5�      4   .Gss.ManagementMenu.TradeManager.PaymentManager  5�      5�        5�   
   $	 解约处理��6   $: 4/Gss.ManagementMenu;component/Images/Termination.png��6,   y�5�      �� *TradeTermination+# [  5�      1   +Gss.ManagementMenu.TradeManager.Termination  5�      5�        5�   
   $	 导出报表��6   $? 9/Gss.ManagementMenu;component/Images/ExportStatements.png��6+   y�5�      �� *AllowExportStatement+# [  5�      6   0Gss.ManagementMenu.TradeManager.ExportStatements  5�      5�        5�   
   $	 	交割单��6   $< 6/Gss.ManagementMenu;component/Images/DeliverOrders.png��6*   y�5�      �� *DeliverOrder+# [  5�      9   3Gss.ManagementMenu.TradeManager.DeliveryGoodsReport  5�      5�        5�   
   $	 	提货单��6   $= 7/Gss.ManagementMenu;component/Images/TakeGoodsOrder.png��6*   y�5�      �� *
TihuoOrder+# [  5�      5   /Gss.ManagementMenu.TradeManager.TakeGoodsReport  5�      5�        5�   
   $	 	买跌单��6   $9 3/Gss.ManagementMenu;component/Images/BackOrders.png��6*   y�5�      �� *HuiGouOrder+# [  5�      5   /Gss.ManagementMenu.TradeManager.BackGoodsReport  5�      5�        5�   
   $	 金生金单��6   $7 1/Gss.ManagementMenu;component/Images/JgjOrder.png��6+   y�5�      �� *
JgjOrder+# [  5�      4   .Gss.ManagementMenu.TradeManager.JgjGoodsReport  5�      5�      5�        5�      -   5        $ tvSysSet��5�   -    . $	 系统设置��6?   $

 Bold"�6M   $= 7/Gss.ManagementMenu;component/Images/SystemSettings.png��6`   y�5�      �� *IsSystemSettingsEnabled+# [   5�   
   �� 5�      -   5        $��lbSysSet��5�      $��Center=�6&   $	��Top=�6C   
������ $��0q�6t   $��0,20,0,0q�6�   #��[ 5�      ��5�      �� 5�      .R�5�      d�  d� 	IsChecked 6'   �� *
IsSelected+ �� Mode$ TwoWay=�y�6U   �� *
Visibility+.��5�      �� $ 
Horizontal=�6)   .+�5�   "   �� $��32��6@   ��6(   �� *Icon+6@   �� 5�   "   $��22(�6C   $
��Bold"�6Q   ��6,   �� *Title+6Q   5�      5�      5�      5�      .@�5�   
     $	 客户分组��6   $? 9/Gss.ManagementMenu;component/Images/PrivilegeManager.png��6+   y�5�      �� *GroupManager+# [  5�      1   +Gss.ManagementMenu.SystemSetting.UserGroups  5�      5�        5�   
   $	 交易日管理��6   $A ;/Gss.ManagementMenu;component/Images/TradingDaySettings.png��6,   y�5�      �� *AllowTradingDaySettings+# [  5�      8   2Gss.ManagementMenu.SystemSetting.TradingDayControl  5�      5�        5�   
   $	 节假日管理��6   $> 8/Gss.ManagementMenu;component/Images/HolidaySettings.png��6,   y�5�      �� *AllowHolidaysSettings+# [  5�      5   /Gss.ManagementMenu.SystemSetting.HolidayControl  5�      5�        5�   
   $	 交易设置管理��6   $B </Gss.ManagementMenu;component/Images/TransactionSettings.png��6-   y�5�      �� *AllowTransactionSettings+# [  5�      <   6Gss.ManagementMenu.SystemSetting.TradingSettingControl  5�      5�        5  
   $	 新闻公告��6   $: 4/Gss.ManagementMenu;component/Images/ReleaseNews.png��6+   y�5     �� *AllowReleaseNews+# [  5     2   ,Gss.ManagementMenu.SystemSetting.NewsControl  5     5       5  
   $	 理财师说��6   $= 7/Gss.ManagementMenu;component/Images/ProductManager.png��6+   y�5	     �� *AllowArticlesInfo+# [  5
     :   4Gss.ManagementMenu.SystemSetting.ArticlesInfoControl  5     5       5  
   $	 广告��6   $9 3/Gss.ManagementMenu;component/Images/Experience.png��6)   y�5     �� *AllowAdvert+# [  5     4   .Gss.ManagementMenu.SystemSetting.AdvertControl  5     5       5  
   $	 日志记录��6   $8 2/Gss.ManagementMenu;component/Images/LogRecord.png��6+   y�5     �� *AllowViewLog+# [  5     5   /Gss.ManagementMenu.SystemSetting.LogInfoControl  5     5!       5"  
   $	 IP地址过滤��6   $> 8/Gss.ManagementMenu;component/Images/IPAddressFilter.png��6-   y�5#     �� *EnableIPAddressFiltering+# [  5$     :   4Gss.ManagementMenu.SystemSetting.IPAddrFilterControl  5%     5'       5(  
   $	 MAC地址过滤��6   $? 9/Gss.ManagementMenu;component/Images/MACAddressFilter.png��6.   y�5)     �� *EnableMACAddressFiltering+# [  5*     7   1Gss.ManagementMenu.SystemSetting.MACFilterControl  5+     5-       5.  
   $	 角色管理��6   $: 4/Gss.ManagementMenu;component/Images/RoleManager.png��6+   y�5/     �� *EnableRoleManager+# [  50     9   3Gss.ManagementMenu.SystemSetting.RoleManagerControl  51     53       54  
   $	 权限管理��6   $? 9/Gss.ManagementMenu;component/Images/PrivilegeManager.png��6+   y�55     �� *EnablePrivilegeManager+# [  56     >   8Gss.ManagementMenu.SystemSetting.PrivilegeManagerControl  57     59     5<       5?     -   5        $ 	tvDataMgr��5?  -    . $	 数据管理��6@   $

 Bold"�6N   $: 4/Gss.ManagementMenu;component/Images/DataManager.png��6a   y�5@     �� *IsDataManagerEnabled+# [  .@�5Q  
     $	 商品管理��6   $= 7/Gss.ManagementMenu;component/Images/ProductManager.png��6+   y�5R     �� *IsProductManagerEnabled+# [  5S     7    1Gss.ManagementMenu.DataManager.ProductInfoControl   5T     5V       5W  
   $	 	体验券��6   $9 3/Gss.ManagementMenu;component/Images/Experience.png��6*   y�5X     �� *EffectiveEnabled+# [  5Y     6!   0Gss.ManagementMenu.DataManager.ExperienceControl!  5Z     5\       5]  
   $	 历史数据��6   $: 4/Gss.ManagementMenu;component/Images/HistoryData.png��6+   y�5^     �� *IsHistoryDataManagerEnabled+# [  5_     1"   +Gss.ManagementMenu.TradeManager.HistoryData"  5`     5b       5c  
   $	 
汇率/水��6   $@ :/Gss.ManagementMenu;component/Images/ExchangeRateWater.png��6+   y�5d     �� *ExchangeRateWater+# [  5e     9#   3Gss.ManagementMenu.DataManager.RateWaterInfoControl#  5f     5h     5j       5m     -   5        $ tvTakeGoodsAccept��5m  -    . $	 提货受理��6H   $

 Bold"�6V   $> 8/Gss.ManagementMenu;component/Images/TakeGoodsAccept.png��5n     y�5o     �� *TiHuoShouLi+# [  .@�5  
     $	 绑定账号��6   $= 7/Gss.ManagementMenu;component/Images/BindingAccount.png��6+   y�5�     �� *BangDingUser+# [  5�     @$   :Gss.ManagementMenu.TakeGoodsManager.BindingAccountCountrol$  5�     5�       5�  
   $	 提货��6   $9 3/Gss.ManagementMenu;component/Images/TakeOrders.png��6)   y�5�     �� *TiHuo+# [  5�     ;%   5Gss.ManagementMenu.TakeGoodsManager.TakeGoodsCountrol%  5�     5�       5�  
   $	 受理明细��6   $; 5/Gss.ManagementMenu;component/Images/ShouLiMingXi.png��6+   y�5�     �� *ShouLiMingXi+# [  5�     =&   7Gss.ManagementMenu.TakeGoodsManager.AcceptDetailControl&  5�     5�     5�     5�     