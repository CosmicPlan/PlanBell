   M S B A M L   `   `   `  ����C  ?PlanBell, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PlanBellPlanBell  5      ;"clr-namespace:PlanBell.Views.PagesPlanBell.Views.Pages  5      '    !PlanBell.Views.Windows.MainWindow   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:PlanBell     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      4pages"clr-namespace:PlanBell.Views.Pages     5      A =Wpf.Ui, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null/ui&http://schemas.lepo.co/wpfui/2022/xaml  5	        � Title$  
MainWindow��5
      $
��1230��5      $	��730��5        Wpf.Ui.Controls.UiWindow!   ExtendsContentIntoTitleBar$
 True��5         WindowBackdropType$
 Mica=�5         WindowCornerPreference$ Round=�5       � WindowStartupLocation$ CenterScreen=�5       � 	Resources 5       $   NavigationStoreFocusVisualStyle1 �� 
TargetType �� Property �� Value	 �� 
TargetType��%�   &	        �� 5   
   " ��69   .�5      ��  � �� 5      �� 5      "	 ��6&   .R�5      � 5      5      5      5      .��5      � 
 � RowDefinitions
 5   
   �� 5      $
��Auto �6   �� 5       $��* �6   .+�5#   
   � -   5         �Name$ RootMainGrid��5$      $��1��5%      $��0q�5&       � ColumnDefinitions 5'      �� 5(      $
��Auto �6#   �� 5)      $��* �6#   .+�5-      %  Wpf.Ui.Controls.NavigationStore  -   5          Name$ RootNavigation��5.      $��0��5/      $��6,0,6,0q�50       � FocusVisualStyle# �   51      /  )Wpf.Ui.Controls.Navigation.NavigationBase   Precache$ False��54         SelectedPageIndex$ -1��55         TransitionDuration$	 200��56         TransitionType$ FadeInWithSlide=�57         Frame 52      ��  �� ElementName$ 	RootFrame��   Items 59      $  Wpf.Ui.Controls.NavigationItem     Cache$
 True��5:      $��首页��5;         Icon$ Home48=�5<         PageTag$ 	dashboard��5=         PageType   PlanBell.Views.Pages.Home"  5>      4  .Wpf.Ui.Controls.Navigation.NavigationSeparator  5?        5@      $��日程计划��5A      $��50(�5B      $ Fluent24=�5C      '   !PlanBell.Views.Pages.SchedulePlan"  5D        5E      $��番茄工作��5F      $��6(�5G      $ ClockAlarm24=�5H      '   !PlanBell.Views.Pages.PomodoroWork"  5I        5K      $��健康��5L      $��50(�5M      $ Doctor24=�5N      !	   PlanBell.Views.Pages.Health" 	 5O         Footer 5T        $��设置��5U      $ 
Settings24=�5V      #
   PlanBell.Views.Pages.Settings" 
 5W        5X      -   5        $��主题��5Z      $ DarkTheme24=�5[      5]      �� 5`      $��1��5a         ControlFillColorDefaultBrush#���  5b       �� CornerRadius$ 8,0,0,0��5c      ._�5d      � 
 5e      �� 5f      $
��Auto �6(   �� 5g      $��* �6(   .+�5i       � -   5          �Name$ 	RootFrame��5i      $��1��6/      Wpf.Ui.Controls.Breadcrumb  5j      $��0��5k      $��18q�5l      $
��Left=�5m      $	��Top=�5n      $��24(�5o         
Navigation 5p      �� $ RootNavigation��  Wpf.Ui.Controls.Snackbar  5r      -   5          Name$ RootSnackbar��5s         Title$ Hello World!��5t      $��1��5u      $	��600��5v          
Appearance$  	Secondary=�5w      !   CloseButtonEnabled$
! True��5x      "   Icon$" PuzzlePiece24=�5y      #   Message$`# ZRemember that the Heat Death of Universe is coming someday, no time to explain - let's go!��5z      $   Timeout$
$ 5000��5{      5|      5}      5~      � 5�   
   -   5        $ RootWelcomeGrid��5�      $��1��5�      $y�Hidden=�5�       5�      �� 5�      $��* �6#   �� 5�      $��* �6#   .+�5�      � $��0��6   .+�5�      �� $	��180��5�      % �� BitmapScalingMode$% HighQuality=�5�      $4��.pack://application:,,,/Resources/geo_icons.png��5�      5�      �� 5�      $��1��6   $��Center=�6)   .+�5�      "  Wpf.Ui.Controls.ProgressRing  &   IsIndeterminate$
& True��6"   �� 5�      $��0,12,0,0q�5�      $��16(�5�      $��Medium"�5�      $$��程序正在加载中.........��5�      ' �� TextAlignment$' Center=�5�      $
��Wrap=�5�      5�      5�        Wpf.Ui.Controls.Dialog  5�   
   -   5        (  Name$( 
RootDialog��5�      )   Title$) WPF UI��5�      $��0��5�      $��2��5�      *   ButtonLeftName$* 确认��5�      +   ButtonRightName$+ 取消��5�        Wpf.Ui.Controls.TitleBar  5�   
   ,   Title$ , PlanBell - 番茄钟助手��5�      $��0��5�      -   ForceShutdown$- False��5�      .   Icon$0. *pack://application:,,,/Resources/wpfui.png��5�      /   MinimizeToTray$/ False��5�      0   	ShowClose$
0 True��5�      1   ShowHelp$1 False��5�      2   ShowMaximize$
2 True��5�      3   ShowMinimize$
3 True��5�      4   UseSnapLayout$
4 True��5�      5   Tray5 5�         Wpf.Ui.Controls.NotifyIcon  5�      -   5        6   FocusOnLeftClick$
6 True��5�      7   Icon$07 *pack://application:,,,/Resources/wpfui.png��5�      8   MenuOnRightClick$
8 True��5�      9   TooltipText$9 WPF UI��5�      :   Menu: 5�      �� 5�      .@�5�        Wpf.Ui.Controls.MenuItem  -	   5        $
��Home��5�   !   ;   
SymbolIcon$; 	Library28=�5�   !   
< � Tag$
< home��5�   !     5�      -
   5        $
��Save��5�   !   $; Save24=�5�   !   $
< save��5�   !     5�      -   5        $
��Open��5�   !   $; Folder28=�5�   !   $
< open��5�   !   �� 5�        5�      -   5        $��Reload��5�   !   $; ArrowClockwise24=�5�   !   $< reload��5�   !   5�      5�      5�      5�      5�      