   M S B A M L   `   `   `  ���� M  IGss.ManagementMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:Gss.ManagementMenu;assembly=Gss.ManagementMenuGss.ManagementMenu  N JGss.ProductInfoView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullV>clr-namespace:Gss.ProductInfoView;assembly=Gss.ProductInfoViewGss.ProductInfoView oJclr-namespace:Gss.ManagementMenu.CustomControl;assembly=Gss.ManagementMenu Gss.ManagementMenu.CustomControl  gFclr-namespace:Gss.ManagementMenu.Converter;assembly=Gss.ManagementMenuGss.ManagementMenu.Converter   XSSystem   XSSystem.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     g cXceed.Wpf.AvalonDock.Themes.Aero, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4[ WXceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4?
avalonDock,http://schemas.xceed.com/wpf/xaml/avalondock   LmgrMenu<clr-namespace:Gss.ManagementMenu;assembly=Gss.ManagementMenu   NpdtView>clr-namespace:Gss.ProductInfoView;assembly=Gss.ProductInfoView   VcusJclr-namespace:Gss.ManagementMenu.CustomControl;assembly=Gss.ManagementMenu   X	converterFclr-namespace:Gss.ManagementMenu.Converter;assembly=Gss.ManagementMenu   -     � Title$!  湘商微中心管理系统��$	��800��$	��960�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=�$��12(� � Icon$$ /XSSystem;component/appico.ico�� � 	Resources A   ;Gss.ManagementMenu.Converter.BooleanNullVisibilityConverter   BoolNullVisibilityCvt 	 About  ModifyPassword2   ,Gss.ManagementMenu.CustomControl.PopupButton �� 
TargetType �� Property �� Value �� 
TargetType	 � RowDefinitions
 � ColumnDefinitions �� Path �� RelativeSource � PlacementTarget �� Triggers P� Property P� Value �� 
TargetName��%  &	        &	      &	 
     '         �� �� �� "  .���  � ��$ 30����  � �� �� "  .R�� $��
gridLayOut��	 �� $��1* �
 �� $��0 ��� $��1* �.+��� $��bd��$��1��
������ ._��� $��Center=�$��Center=�� $	��Top=����� $ 	IsPopOpen� �� *TemplatedParent+ �� $ .� �� *TemplatedParent+.��>� ���� $ PopupWindow� �� *TemplatedParent+ P�  �@J�IsMouseOver . . ��� $ 
gridLayOut�� � ��
 ����� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command# [   -   # [ .��� 	 �� $
��Auto ��� $��* ��� $
��Auto �.+�� 
 �� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto �.+��� $"��/XSSystem;component/logo.png�� J� Opacity$ 0Q�$��30,0,0,0q� � LayoutTransform ��  �� ScaleX$	 0.7Q� �� ScaleY$	 0.7Q� � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.[��� .���� .��W�  �� TargetProperty$ Opacity� W� From$ 0X�	 W� To$ 1X� g� 	BeginTime$ 0:0:0.5X� g� Duration$ 0:0:1.3D�:� $ Mouse.MouseEnter��.[��� .���� .��W� $ Opacity�$ 1X�$
 0.35X�$ 0:0:00X�$ 0:0:0.5D�W� $ Opacity�$
 0.35X�$ 1X�$ 0:0:0.5X�$ 0:0:1D��� $��1��$��	20,0,10,0q�$��28(�$
��Bold"�$ 0Q�$��Center=� J� RenderTransformOrigin$ 0.5,0.5&�$��YouYuan)�$!��湘商微中心管理系统�� �� $	 1.5Q�z�V� .~�T� -   #SampleBrowserTranslateTransform��  T� Y$  -2Q��� -   RenderScale�� :� $ FrameworkElement.Loaded��.[��� .���� .��W� ! �� 
TargetName$%! SampleBrowserTranslateTransform��" g� DecelerationRatio$	" 0.7Q�$ X�$	 250X�$ 0X�$ 0:0:0.5X�$ 0:0:1.3D�W� $ Opacity�$ 0X�$
 0.65X�$ 0:0:0.5X�$ 0:0:1.3D�:� $ Mouse.MouseEnter��.[��� .���� .��W� $! RenderScale��$ ScaleX�$ 1X�$
 1.05X�$ 0:0:00X�$ 0:0:0.3D�W� $! RenderScale��$ ScaleY�$ 1X�$
 1.05X�$ 0:0:0X�$ 0:0:0.3D�W� $! RenderScale��$ ScaleX�$
 1.05X�$ 1X�$ 0:0:0.3X�$ 0:0:0.3D�W� $! RenderScale��$ ScaleY�$
 1.05X�$ 1X�$ 0:0:0.3X�$ 0:0:0.3D��� $��2��# �� Orientation$# 
Horizontal=�$��Right=�.+��� $��5q�#��[ $��76��$��76��.���� .+��� $-��'/XSSystem;component/Image/密码锁.png���� $��修改密码��$��Center=��� $��3��$# 
Horizontal=�$��Right=�.+��� $��5q�#��[ $��76��$��76��.���� .+��� $(��"/XSSystem;component/Image/help.png���� $��帮助��$��Center=�)  #Xceed.Wpf.AvalonDock.DockingManager  $��1��$   AllowMixedOrientation$ . %   Theme% +  %Xceed.Wpf.AvalonDock.Themes.AeroTheme  &   Layout.& ,  &Xceed.Wpf.AvalonDock.Layout.LayoutRoot  '   	RootPanel.' -  'Xceed.Wpf.AvalonDock.Layout.LayoutPanel  (   Orientation$( Vertical=��  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.ILayoutPanelElement, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]])   Children.)   $( 
Horizontal=�.) 6	  0Xceed.Wpf.AvalonDock.Layout.LayoutAnchorablePane	  �
  �Xceed.Wpf.AvalonDock.Layout.LayoutPositionableGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]* 
  	DockWidth$	* 200 ��  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]+   Children.+ 2  ,Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable  /  )Xceed.Wpf.AvalonDock.Layout.LayoutContent,   Title$, 管理菜单��-   CanClose- .  .   CanHide. .  /   Content./ '   !Gss.ManagementMenu.ManagementMenu  -   0  Name$0 	TvManager��1 � DataContext1 �� *AccountAuthority+4  .Xceed.Wpf.AvalonDock.Layout.LayoutDocumentPane  -   DocumentPane���  �Xceed.Wpf.AvalonDock.Layout.LayoutGroup`1[[Xceed.Wpf.AvalonDock.Layout.LayoutContent, Xceed.Wpf.AvalonDock, Version=2.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4]]2   Children.2   -   MainContainer��- .  3   CanFloat3 .  4   CanAutoHide4 .  $, 主界面展示��./ �� 
�������._��� ���� *SelectedItem.View+5 �� ElementName$5 	TvManager��	  $	* 320 �.+   6   	ContentId$6 4��$, 商品列表��- .  . .  ./ )  #Gss.ProductInfoView.ProductInfoView  �� -	   $��AccountInfoContainer��$��0,1,0,0q�
�������$��2��$��4��7 �� CornerRadius$7 2��$��3,0,3,0q�y��� *'%AccountAuthority.EnableTradeMoneyInfo+8 �� 	Converter#8 [  ._�� 
 �� $��1* ��� $��10 ��� $��80 �.+�� 
������ $��1��.+�F� -
   9 F�Name$9 ArrowR1��$y�	Collapsed=�
�������$��Center=�$��Center=�"����     	= � 	=     � z  	= 	F� -   $9 ArrowR2��
�������$��Center=�$��Center=�"����        � z     � 	=  	= 	  -   $
��PBtn��$��2��$��出入金/解约��:   PopupWindow: >� -   $��UC_Accountcement��.��'   !Gss.ManagementMenu.TradeMoneyInfo  