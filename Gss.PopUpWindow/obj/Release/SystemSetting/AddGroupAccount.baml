   M S B A M L   `   `   `  ���� J  FGss.PopUpWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Gss.PopUpWindow.ValidationHelper Gss.PopUpWindow.ValidationHelper  3    -Gss.PopUpWindow.SystemSetting.AddGroupAccount   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     E
Validation.clr-namespace:Gss.PopUpWindow.ValidationHelper     -   $	��win��  � Title$  用户添加到分组��$	��195��$	��382�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ 
ToolWindow=�.��� .+��� -   $��label1��$��分组名称：��$��24��$
��Left=�$��	42,20,0,0q�$	��Top=�$��68���� -   $��label2��$��客户账户：��$��24��$
��Left=�$��	42,50,0,0q�$	��Top=�$��68���� -   $��textBox2��$��25��$
��Left=�$��
107,49,0,0q�$	��Top=�$	��155��.������  �� Path$ Account� �� UpdateSourceTrigger$ PropertyChanged=� �� ElementName$	 win�� �� ValidationRules 7   1Gss.PopUpWindow.ValidationHelper.StringLengthRule     	MinLength$ 1��   	MaxLength$ 16��.���� -   $��
textBlock1��$��18��$
��Left=�$��
111,24,0,0q�$	��Top=�$	��131������ *UserGroupName+	 �� Mode$	 OneWay=��� -   $��button1��$��确 定��$��24��$
��Left=�$��
86,108,0,0q�$	��Top=�$��64���� -   $��button2��$��取 消��$��24��$
��Left=�$��183,108,0,0q�$	��Top=�$��64��