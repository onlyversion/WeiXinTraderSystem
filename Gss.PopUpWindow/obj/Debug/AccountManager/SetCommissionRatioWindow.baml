   M S B A M L   `   `   `  ����G  CGss.Entities, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullcAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.EntitiesGss.Entities.ValidationHelper  5   	    Gss.PopUpWindow=   7Gss.PopUpWindow.AccountManager.SetCommissionRatioWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ^validationHelperAclr-namespace:Gss.Entities.ValidationHelper;assembly=Gss.Entities     5   	   -   5        $	��win��5   	     � Title$  返佣比例��5   	   $	��180��6   $	��330��6#    � WindowStartupLocation$ CenterScreen=�6/    � WindowStyle$ 
ToolWindow=�6T    � 	Resources 5       
  Submit �� 
TargetType �� Property �� Value��%  &	        '��      '	� �     �� 5   
   6   �� 5	   
   " ��6   .�5
      ��  � ��$ Right=�64   �� 5       � ��$ Center=�62   5      �� 5   
   " 	�6   .�5      ��  � ��$
 Left=�64   �� 5       � ��$ Center=�62   5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command# [  5      6e   .��5      � $��	0,10,10,0q�6   	 � RowDefinitions	 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��50 �6   
 � ColumnDefinitions
 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5!   
   �� $��0��6   $��0��6!   $��一级返佣比例：��61   �� 5"   
   $��0��6   $��1��6   .��60   ��5#      �� 5$       �� Path$ Ratio1�6    �� ElementName$	 win��6(    �� Mode$ TwoWay=�6:    �� UpdateSourceTrigger$ PropertyChanged=�6H    �� ValidationRules 5%      +   %Gss.Entities.ValidationHelper.NumRule  5&         	IsInteger .  ,  &System.Windows.Controls.ValidationRule   ValidatesOnTargetUpdated .    MaxValue$ 1X�6e   5(      .��5)      5*      �� 5+   
   $��1��6   $��0��6!   $��二级返佣比例：��61   �� 5,   
   $��1��6   $��1��6   .��60   ��5-      �� 5.      $ Ratio2�6   $	 win��6(   $ TwoWay=�6:   $ PropertyChanged=�6H    5/        50       .   . $ 1X�6e   52      .��53      54      �� 55   
   $��2��6   $��0��6!   $��三级返佣比例：��61   �� 56   
   $��2��6   $��1��6   .��60   ��57      �� 58      $ Ratio3�6   $	 win��6(   $ TwoWay=�6:   $ PropertyChanged=�6H    59        5:       .   . $ 1X�6e   5<      .��5=      5>      �� 5E   
    �� Orientation$ 
Horizontal=�6   $��4��6.   $��2��6;   $��Center=�6O   .+�5F      �� $��确定��6   #��[  6"   $��60��6D   $��26��6O   �� 5G      -   5        $��	btnCancel��5G   "   $��取消��6   $��60��63   $��26��6>    �� IsCancel . $��10,0,0,0q�6r   5H      5I      5J      