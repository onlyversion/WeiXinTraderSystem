   M S B A M L   `   `   `  ����  Gss.ManagementMenu'    !Gss.ManagementMenu.TradeMoneyInfo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $	��520��5      $	��300��6+   .��5      � .+�5	   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGrid��5	          AutoGenerateColumns  .     SelectionMode$ Single=�6?      
IsReadOnly .    CanUserResizeRows .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   MinWidth$ 80Q�6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 63      Header$ 时间��6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6L   �� *
Opertime+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ 客户账号��6)   $ 60Q�67   $ * 6E   	   CellTemplate	 5      �� 5      .R�5      �� $��0q�67   
������ 
 �� 
IsReadOnly
 . ��6&   Z� ��5   <   �� *	Account+5      5        5      $ 40Q�6%   $
 Auto 63   $ 操作��6@    6L   �� *Reason+  5      $ 40Q�6%   $
 Auto 63   $ 状态��6@    6L   �� *State+  5      $ 60Q�6%   $
 Auto 63   $ 变动金额��6@    6N   �� *ChangeValue+  5      $ 50Q�6%   $
 Auto 63   $ 	原金额��6@    6M   �� *
OldValue+  5      $ 50Q�6%   $
 Auto 63   $ 	新金额��6@    6M   �� *
NewValue+5      5      5      