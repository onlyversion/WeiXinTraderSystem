   M S B A M L   `   `   `  ���� J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Gss.PopUpWindow.ConverterGss.PopUpWindow.Converter  5    /Gss.PopUpWindow.AccountInfoModule.FundsInfoPart   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     7cvt'clr-namespace:Gss.PopUpWindow.Converter       � 	Resources  ;   5Gss.PopUpWindow.Converter.ContractStatusEnumConverter   ContractStatusCvt1   +Gss.PopUpWindow.Converter.BankEnumConverter  BankCvt��%   &	        &	          .���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �   �� 
TargetType �� Property �� Value  TextBoxStyle �� BasedOn��%�   '��       '�� U     7  �� " ��.���  � ��$ Center=���  � ��$ Right=���  � ��$ 2q��� " ��8   .���  � ��$ Center=���  � ��$	 120����  � ��$ 2q�.+��� $��0��$��0��$��	账号：���� $��0��$��1��{�.  ���� *FundsAccount+�� $��4��$��2��$��签约状态：���� $��4��$��3��{�.  ���� *ContractStatus+ �� 	Converter# [  �� $��2��$��0��$��开户行：���� $��2��$��1��{�.  ���� *
OpenBank+�� $��3��$��0��$��持卡人：���� $��3��$��1��{�.  ���� *BankAccountName+�� $��4��$��0��$��银行卡号：���� $��4��$��1��{�.   ^� 	Placement$ Bottom=����� *BankCardNumber+	 � ToolTip	 �� 
 �� Path$

 Text� �� RelativeSource ��  �� Mode$
 Self=��� $��0��$��2��$��账户余额：���� $��0��$��3��{�.  ���� *CurrentBalance+�� $��3��$��2��$��保证金：���� $��3��$��3��{�.  ���� *OccupiedDeposit+�� $��2��$��2��$��预付款：���� $��2��$��3��{�.  ���� *FrozenDeposit+�� $��5��$��0��$��冻结资金：���� $��5��$��1������ *DongJieMoney+