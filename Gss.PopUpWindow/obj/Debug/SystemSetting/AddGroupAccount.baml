   M S B A M L   `   `   `  ����J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Gss.PopUpWindow.ValidationHelper Gss.PopUpWindow.ValidationHelper  5   	   3    -Gss.PopUpWindow.SystemSetting.AddGroupAccount   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   E
Validation.clr-namespace:Gss.PopUpWindow.ValidationHelper     5   	   -   5        $	��win��5   2     � Title$  用户添加到分组��6	   $	��195��6   $	��382��6&    � WindowStartupLocation$ CenterScreen=�6=    � WindowStyle$ 
ToolWindow=�6b   .��5      � .+�5   
   �� -   5        $��label1��5   Z   $��分组名称：��6   $��24��6    $
��Left=�6,   $��	42,20,0,0q�6G   $	��Top=�6h   $��68��6�   �� 5   
   -   5        $��label2��5   Z   $��客户账户：��6   $��24��6    $
��Left=�6,   $��	42,50,0,0q�6G   $	��Top=�6h   $��68��6�   �� 5	   
   -   5        $��textBox2��5	   M   $��25��6   $
��Left=�6   $��
107,49,0,0q�69   $	��Top=�6]   $	��155��6u   .��6�   ��5
      �� 5       �� Path$ Account�6    �� UpdateSourceTrigger$ PropertyChanged=�6)    �� ElementName$	 win��6O    �� ValidationRules 5      7   1Gss.PopUpWindow.ValidationHelper.StringLengthRule  5         	MinLength$ 1��66      	MaxLength$ 16��6D   5      .��5      5      �� 5   
   -   5        $��
textBlock1��5   O   $��18��6   $
��Left=�6    $��
111,24,0,0q�6;   $	��Top=�6�   $	��131��6�   ��6a   �� *UserGroupName+	 �� Mode$	 OneWay=�6�   �� 5   
   -   5        $��button1��5   Z   $��确 定��6   $��24��6   $
��Left=�6+   $��
86,108,0,0q�6F   $	��Top=�6i   $��64��6�   6�   �� 5   
   -   5        $��button2��5   [   $��取 消��6   $��24��6   $
��Left=�6+   $��183,108,0,0q�6F   $	��Top=�6j   $��64��6�   6�   5      5      