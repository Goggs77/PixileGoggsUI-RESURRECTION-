   M S B A M L   `   `   `  ����W  SPixileGoggsUI -RESURRECTION-, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PixileGoggsUI__RESURRECTION_PixileGoggsUI__RESURRECTION_  5   	   0    *PixileGoggsUI__RESURRECTION_.LinearARender   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   <local*clr-namespace:PixileGoggsUI__RESURRECTION_     5   	     � Title$  LinearARender��5   	   $	��839��6   $	��616��6,    � AllowsTransparency$
 True��5	   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	    � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$
 Left�6&    W� From	 -10006G   	 W� To 06T   	 g� Duration$	 0:0:0.8D�6[   
 g� FillBehavior$
 HoldEnd=�6n    W� EasingFunction 5      -  'System.Windows.Media.Animation.SineEase  5      7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode$ 	EaseInOut=�6'   5      5      5      5      ��5      �� 5   
    �� Color$ #1f1e33��6    �� Opacity$ 	0.7313051Q�6*   6@   .��5      � .+�5   
   �� -   5        $��17(�5      
�������$	��Top=�66   $��	592 5 0 0q�6N   X6�   � 5   
   -   5        $��
0 0 46 809q�5      .+�5       �� $��17(�6   
�������$��Center=�6;   $��12 0 0 0q�6V   Linear Render6x   5!      � 5#   
   
�������$��3 32 3 3q�6"   .+�5$      9� $��7q�6   $��Modes��6"   $��14(�61   .��5%      �� .+�5&      	� -   5        $��Orthographic��5&       d� 	IsChecked$
 TrueY�62   .��6C   Orthographic6Q   	� 5'      -   5        $��Perspective��5'      $ FalseY�61   .��6C   Pseudo-perspective6W   5(      5)      �� 5*      -   5        $
��Help��5*   �   $��Right=�6   $	��Top=�61   $	��100��6I   $��31��6U   $��	5 5 109 5q�6a   $
��Help��6t   6�   �� 5+      -   5        $��	DrawScene��5+   �   $��Right=�6   $	��Top=�61   $	��100��6I   $��31��6U   $��5 5 6 5q�6a   $��
Draw Scene��6r   6�   �� 5,      6   �� 5-      $��Scene��6   $��14(�6&   $��	0 100 0 0q�64   .��5.      �� -   5        $��SceneBox��5.       �� AcceptsReturn$
 True��6*    �� 
AcceptsTab$
 True��6?   .��6h   50      51      52      53      54      