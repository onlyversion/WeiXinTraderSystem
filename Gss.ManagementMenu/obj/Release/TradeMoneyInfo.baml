   M S B A M L   `   `   `  ����   Gss.ManagementMenu'    !Gss.ManagementMenu.TradeMoneyInfo   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     $	��520��$	��300��.��� .+�&   System.Windows.Controls.DataGrid  -   $��dataGrid��    AutoGenerateColumns  .     SelectionMode$ Single=�   
IsReadOnly .    CanUserResizeRows .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   MinWidth$ 80Q�   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto    Header$ 时间��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Opertime+4  .System.Windows.Controls.DataGridTemplateColumn  $ 客户账号��$ 60Q�$ * 	   CellTemplate	 �� .R��� $��0q�
������ 
 �� 
IsReadOnly
 . ��Z� ���� *	Account+  $ 40Q�$
 Auto $ 操作�� �� *Reason+  $ 40Q�$
 Auto $ 状态�� �� *State+  $ 60Q�$
 Auto $ 变动金额�� �� *ChangeValue+  $ 50Q�$
 Auto $ 	原金额�� �� *
OldValue+  $ 50Q�$
 Auto $ 	新金额�� �� *
NewValue+