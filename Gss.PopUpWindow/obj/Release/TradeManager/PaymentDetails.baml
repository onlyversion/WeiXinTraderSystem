   M S B A M L   `   `   `  ����   Gss.PopUpWindow1    +Gss.PopUpWindow.TradeManager.PaymentDetails   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -   $	��win��  � Title$  出入金详情��$	��456��$	��896�� � WindowStyle$ 
ToolWindow=� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ WidthAndHeight=� � 	Resources  �� 
TargetType �� Property �� Value��%b   '��       '�� '     �� " ��.���  � ��$ Center=��� " ��.���  � ��$ Center=�.��� $��10q� � RowDefinitions �� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��30 ��� $��50 ��� $��1* �	 � ColumnDefinitions	 �� $��80 ��� $��1* ��� $��25 ��� $��70 ��� $��1* �.+��� $��0��$��3��.��所属组织：�� $��1��$��3��.��用户账号：�� $��3��$��3��.��银行卡号：�� $��4��$��3��.��开户行：�� $��5��$��3��.��	金额：�� $��6��$��3��.��	状态：�� $��0��$��4������ *ChuJinInfo.OrgName+
 �� ElementName$	
 win���� $��1��$��4������ *ChuJinInfo.Account+$	
 win���� $��3��$��4������ *ChuJinInfo.BankCard+$	
 win���� $��4��$��4������ *ChuJinInfo.OpenBank+$	
 win���� $��5��$��4������ *ChuJinInfo.Amt+$	
 win���� $��6��$��4������ *ChuJinInfo.StateString+$	
 win���� $
��0,10q�$��7��$��4�� �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $��60��$��26��$��付 款��{��� *IsCmdEnable+$	
 win���� -   $��60��$
��10,0q�$��26��$��退 回��{��� *
CanJuJue+$	
 win���� $��0��.��入金总和：�� $��1��$��0��.��出金总和：�� $��1��
���  ������ *InFundInfo.AMT+$	
 win���� $��1��$��1��
���  ������ *OutFundInfo.AMT2+$	
 win���� $��2��$��0��$��8��$��2��.+��� .��最近出金记录�� $��20��$
��0,10q����� *OutFundInfo.TOderLst+$	
 win������ .R��� $ 
Horizontal=�$��5q�$��15��.+��� $��Center=�$��35��.��出金�� $��Center=�
���  ��$��80������ *Amt+�� $��Center=�$��35��.��时间�� $��Center=�
���  ������ *OpTime+ �� StringFormat$ yyyy-MM-dd HH:mm:ss���� .��最近入金记录�� $
��0,10q�$��20������ *InFundInfo.TOderLst+$	
 win������ .R��� $ 
Horizontal=�$��5q�$��15��.+��� $��Center=�$��35��.��入金�� $��Center=�
���  ��$��80������ *Amt+�� $��Center=�$��35��.��时间�� $��Center=�
���  ������ *OpTime+$ yyyy-MM-dd HH:mm:ss��