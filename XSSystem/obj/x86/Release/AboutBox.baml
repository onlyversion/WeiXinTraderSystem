   M S B A M L   `   `   `  ����   XSSystem    XSSystem.AboutBox   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     
idAboutBox��   AboutDialogStyle#���     � WindowStartupLocation$  CenterOwner=� � Title ��  �� RelativeSource �� *Self+ �� Mode$ OneTime=� �� Path$ ProductTitle� � 	Resources   aboutProvider � XPath � IsAsynchronous,  &System.Windows.Data.DataSourceProvider   IsInitialLoadEnabled  	aboutLogo	 �� 
TargetType
 �� Property �� Value  DisplayAreaStyle  BackgroundStyle �� EndPoint � Offset � Color  ParagraphSeparator  LinkLabelStyle  ReadOnlyDescStyle  OkButtonStyle��%�  &	       &	 �     &	  �     &	 �    &	 �    '�� �    &	 �    &	 �    &	     &	 �    � $ ApplicationInfo�� .   . .����<ApplicationInfo xmlns="">
                    <Link Uri="http://www.91gold.com/">更多信息</Link>
                </ApplicationInfo>        �� $��Logo.png��$	��130���� "	 �.��� 
 � ��$
 Auto���� 
 � ��$	 420���� 
 �@�ShowInTaskbar .  �� 
 �@�
ResizeMode$ NoResize=��� 
 �@�WindowStyle$ SingleBorderWindow=��� 
 �@�SizeToContent$ Height=��� "	 ��.��� 
 � ��$ 
10,10,10,5q��� "	 ��.��� 
 � �� �� $	 0,1&�.��� $ 0Q�$ 	LightBlue��� $
 0.55Q�$ White��� $
 0.85Q�$ White��� $ 1Q�$ 	LightBlue���� "	 ��.��� 
 � ��$ 0q��� "	 ��.��� 
 � ��$ 0,10,0,0q��� .��� 
 � ��$ 0q��� 
 � ��$ Center=��� "	 ��.��� 
 �@��MinLines$ 6���� 
 �@��MaxLines$ 6���� 
 �@��
IsReadOnly . �� 
 �@��TextWrapping$ WrapWithOverflow=��� #
 �@��VerticalScrollBarVisibility$ Visible=��� "	 ��.��� 
 � ��$ 75���� 
 � ��$	 0,5q��� 
 � ��$ Right=��� 
 �@��	IsDefault . �� 
 �@��IsCancel . .���� 
clientArea��#��[ .+���  �� ResourceKey$ 	aboutLogo���� displayArea��#��[  � DataContext ��  �� *FindAncestor+ �� AncestorType" �$ OneTime=�.+��� -    ��Name$ productName��productName������ $ OneTime=�$ Product��� versionArea�� �� Orientation$ 
Horizontal=�.+��� -   $ versionLabel��VersionLabel��$��	版本 - ���� -   $ version��version������ $ OneTime=�$ Version��� -   $ 	copyright��	copyright������ $ OneTime=�$ 	Copyright��� -   $ company��company������ $ OneTime=�$ Company��� -   $ reserved��reserved��$��保留所有权利。���� -   $
 info��info��#��[ $��产品详细：���� -    ��Name$ description��description��#��[ ���� $ OneTime=�$ Description�]� 
buttonArea��.+��� -	    ��Name$ okButton��okButton��#��[ $��OK���� -
   $ productLink��productLink��#��[ .���� -    ��Name$ 	hyperlink��	hyperlink��#��[ ���� $ OneTime=�$ LinkUri�.�.��� ���� $ OneTime=�$ LinkText�