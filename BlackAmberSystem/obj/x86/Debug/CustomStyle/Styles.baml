   M S B A M L   `   `   `  ����a  ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   LoginWindowStyle  �� 
TargetType �� Triggers :� RoutedEvent �� TargetProperty W� From	 W� To g� 	BeginTime g� Duration �� Property	 �� Value  LoginWindowGridStyle
 �� ImageSource  BasedTextBoxStyle �� BasedOn �� 
TargetType,    &Microsoft.Windows.Themes.ListBoxChrome   Name    BorderBrush    BorderThickness    
Background J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName �� Path �� Self �� RelativeSource  TextBoxStyle m� Command�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      UthemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero  5      %
  &	        &	 �    &	 V    &	     7  '�� *    7  '�� 5	    �� 5      "  �6%    5   
   :� 5      $ FrameworkElement.Loaded��6   .[�5      �� .��5	      �� .��5
      W� $ Opacity�6*   $	 0.3X�6N   $ 1X�6Y   $ 0X�6`   $ 0:0:0.5D�6n   5      5      5      .�5   
   ��  �@�Icon$,	 &/BlackAmberSystem;component/appico.ico��6!   �� 5   
    � ��	 �#b3dffa6'   �� 5   
    �@�Title$$	 黑琥珀微中心管理系统��6"   5      �� 5      "  �6)   .�5   
   ��  � ��	 5      �� 5      $6
 0/BlackAmberSystem;component/Image/LoginImage.jpg��6   5      5      �� 5      "  ��69    6&   Z� .�5   
   ��  � ��$	 26��6#   �� 5   
    � ��#	 � ��6'   �� 5   
    � ��#	 � ��6'   �� 5   
    � ��	 �	#FFBBC1CB6(   �� 5    
    � ��$	 1q�6,   �� 5!   
    � ��$	 1q�6$   �� 5"   
    �@J�	AllowDrop	 . 6&   �� 5#   
    �@�FocusVisualStyle	 6-   Z� �� 5$   
    �@��PanningMode$	 VerticalFirst=�65   �� 5%   
    �@��IsFlicksEnabled	 .  63   �� 5&   
    � ��$	 5,2,2,2q�6#   �� 5'   
    � ��	 5(      �� 5)      " ��6"   .R�5*         $ Bd��6+   # z��67   # z��6c   # z��5+       . ._�5.      �� $ PART_ContentHost��6'   # z 6A   5/       50      P� 51       � {� .  . �52      �� $ Bd��6;   #	 � ��6K    �@  
Background�� 53      #	 � ��6;    � ��54      P� 55       �@��
IsReadOnly . . �56      �� $ Bd��6;   #	 � ��6K    �@  
Background�� 57      #	 � ��6;    � ��58      5:      5<       5=   
   P� 5>       �@=�HasError . . �5?      ��  �@�ToolTip	 5@      �� 5A      $2 ,(Validation.Errors).CurrentItem.ErrorContent�6"   # Z 6V   5C      5D      5G      �� 5I      "  ��6!   8   .�5J   
   ��  �@�ContextMenu	 5K      �� 5L      .@�5M      m� $��复制��6   $
 Copy��6+   m� 5N      $��剪切��6   $	 Cut��6+   m� 5O      $��粘贴��6   $ Paste��6+   5P      5R      5S      �� 5T      "  ��6   8   .�5U   
   ��  �@�ContextMenu	 5V      �� 5W      .@�5X      m� $��复制��6   $
 Copy��6+   m� 5Y      $��剪切��6   $	 Cut��6+   m� 5Z      $��粘贴��6   $ Paste��6+   5[      5]      5^      �� 5`      "  ��6    5a   
   P� 5b       �@��HasItems .  . �5c      ��  � y�$	 	Collapsed=�6/   5d      5f      5g      