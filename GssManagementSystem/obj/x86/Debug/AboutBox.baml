   M S B A M L   `   `   `  ����  JxSystem    JxSystem.AboutBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      
idAboutBox��   AboutDialogStyle#���   5        � WindowStartupLocation$  CenterOwner=�60    � Title 5      ��  �� RelativeSource �� *Self+ �� Mode$ OneTime=� �� Path$ ProductTitle� � 	Resources 5        aboutProvider � XPath � IsAsynchronous,  &System.Windows.Data.DataSourceProvider   IsInitialLoadEnabled  	aboutLogo	 �� 
TargetType
 �� Property �� Value  DisplayAreaStyle  BackgroundStyle �� EndPoint � Offset � Color  ParagraphSeparator  LinkLabelStyle  ReadOnlyDescStyle  OkButtonStyle��%Y  &	       &	 �     &	      &	 \    &	 �    '�� �    &	 *    &	 x    &	 �    &	 
    � 5   
   $ ApplicationInfo��60    .   . .��5	      ��<ApplicationInfo xmlns="">
                    <Link Uri="http://www.91gold.com/">更多信息</Link>
                </ApplicationInfo>        5      �� 5   
   $��Logo.png��6"   $	��130��64   �� 5   
   "	 �6)   .�5      �� 
 � ��$
 Auto��6'   �� 5      
 � ��$	 420��6&   �� 5      
 �@�ShowInTaskbar .  6.   �� 5      
 �@�
ResizeMode$ NoResize=�6+   �� 5      
 �@�WindowStyle$ SingleBorderWindow=�6,   �� 5      
 �@�SizeToContent$ Height=�6.   5      �� 5   
   "	 ��6)   .�5      �� 
 � ��$ 
10,10,10,5q�6'   5      �� 5   
   "	 ��6(   .�5      �� 
 � �� 5      �� 5      $	 0,1&�6*   .��5      � $ 0Q�6'   $ 	LightBlue��62   � 5       $
 0.55Q�6'   $ White��65   � 5!      $
 0.85Q�6'   $ White��65   � 5"      $ 1Q�6'   $ 	LightBlue��62   5#      5%      5&      �� 5'   
   "	 ��6   .�5(      �� 
 � ��$ 0q�6(   5)      �� 5*   
   "	 ��6+   .�5+      �� 
 � ��$ 0,10,0,0q�6(   5,      �� 5-   
   .�5.      �� 
 � ��$ 0q�60   �� 5/      
 � ��$ Center=�6:   50      �� 51   
   "	 ��6*   .�52      �� 
 �@��MinLines$ 6��6)   �� 53      
 �@��MaxLines$ 6��6)   �� 54      
 �@��
IsReadOnly . 6+   �� 55      
 �@��TextWrapping$ WrapWithOverflow=�6-   �� 56      #
 �@��VerticalScrollBarVisibility$ Visible=�6<   57      �� 58   
   "	 ��6&   .�59      �� 
 � ��$ 75��6)   �� 5:      
 � ��$	 0,5q�6'   �� 5;      
 � ��$ Right=�6/   �� 5<      
 �@��	IsDefault . 6*   �� 5=      
 �@��IsCancel . 6)   5>      5?      .��5@      �� 
clientArea��#��[ 6$   .+�5A   
   ��  �� ResourceKey$ 	aboutLogo��6   �� 5B   
   displayArea��#��[ 6)    � DataContext 5C      ��  �� *FindAncestor+ �� AncestorType" �$ OneTime=�.+�5D      �� -   5         ��Name$ productName��5D      productName����6=   �� $ OneTime=�$ Product��� 5E      versionArea�� �� Orientation$ 
Horizontal=�6-   .+�5F      �� -   5        $ versionLabel��5F      VersionLabel��$��	版本 - ��6C   �� 5G      -   5        $ version��5G      version����69   �� $ OneTime=�$ Version�5H      �� 5I      -   5        $ 	copyright��5I      	copyright����69   �� $ OneTime=�$ 	Copyright��� 5J      -   5        $ company��5J      company����65   �� $ OneTime=�$ Company��� 5K      -   5        $ reserved��5K      reserved��$��保留所有权利。��67   �� 5L      -   5        $
 info��5L      info��#��[ 6/   $��产品详细：��5M      �� 5N      -   5         ��Name$ description��5N      description��#��[ 5O      ��5N   ?   �� $ OneTime=�$ Description�5O      ]� 5P      
buttonArea��.+�5Q      �� -	   5         ��Name$ okButton��5Q      okButton��#��[ 6<   $��OK��5R      �� 5S      -
   5        $ productLink��5S      productLink��#��[ 6A   .��5T      �� -   5         ��Name$ 	hyperlink��5T       	hyperlink��#��[ 6y   ��6E   �� $ OneTime=�$ LinkUri�.�5U   V   .�5V      �� ��6$   �� $ OneTime=�$ LinkText�5W      5X      5Y      5Z      5[      5\      