   M S B A M L   `   `   `  ����W  SPixileGoggsUI -RESURRECTION-, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PixileGoggsUI__RESURRECTION_PixileGoggsUI__RESURRECTION_  5   	   .    (PixileGoggsUI__RESURRECTION_.ComplexPlot   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   <local*clr-namespace:PixileGoggsUI__RESURRECTION_     5   	     � Title$  ComplexPlot��5   	   $
��1000��6   $
��1000��6+    � AllowsTransparency$
 True��5	   	    � WindowStyle$
 None=�5
   	    � 
ResizeMode$ NoResize=�5   	   ��5      �� 5   
    �� ImageSource$6 0pack://siteoforigin:,,,./Resources/Images/BG.png��6    �� Opacity$ 	0.7313051Q�6T    j� Stretch$
 Fill=�6h   6y    � Triggers 5      :� 5   
    :� RoutedEvent$ Window.Loaded��6   .[�5      �� .��5      �� .��5      W� 	 �� TargetProperty$
	 Left�6&   
 W� From	
 -10006G   	 W� To 06T    g� Duration$ 0:0:0.8D�6[    g� FillBehavior$ HoldEnd=�6n    W� EasingFunction 5      -  'System.Windows.Media.Animation.SineEase  5      7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode$ 	EaseInOut=�6'   5      5      5      5      .��5      � .+�5   
   � $��	0 0 0 950q�6   .+�5       �� $��35��6   $?��9pack://siteoforigin:,,,./Resources/Icons/FourierGoggs.png��6   $�� 18 6q�6b   $
��Left=�6q   $	��Top=�6�   6�   �� 5!      -   5        
�������$��20(�5!   ,   $��60,14,100,10q�6:   ,*PixileGoggsUI -RESURRECTION- Complex World6�   �� 5"      -   5        
�������$��23(�5"   ,   $��Right=�6:   $��Center=�6V   $��35��6q   X6�   5#      � 5$   
   $��10 60 10 10q�6   ���#dcdde1.+�5%      � $��1q�6   
�������.+�5(      � $	��310��6   $	��Top=�6$   .+�5)      �� $��Complex Functions��6   $��15(�6:   .��5*      �� $	��310��6%   $
��Left=�61   $��1q�6L   .+�5+      �� $��1q�6(   Complex Function w=F(z)=6M   �� 6X   -   5        $��	CFunction��5+   k   $��1q�6`   .��6|   z^2+16�   �� 5,      $��1q�6(   Origin Coordinates6G   �� 6R   -   5        $��OriginCoord��5,   e   $��1q�6Z   .��6x   0,06}   �� 5-      $��1q�6(   Scale Factor6A   �� 6L   -   5        $��CScaleFactor��5-   _   $��1q�6T   .��6s   16v   �� 5.      $��1q�6(   Real Part Range6D   �� 6O   -   5        $��
CRealRange��5.   b   $��1q�6W   .��6t   
-100,1006~   �� 5/      $��1q�6(   Imaginary Part Range6I   �� 6T   -   5        $��CImRange��5/   g   $��1q�6\   .��6w   
-100,1006�   �� 50      $��1q�6(   Modulus Range6B   �� 6M   -   5        $��	CModRange��50   `   $��1q�6U   .��6q   1006v   51      52      �� 53      $��Additional Options��6   $��15(�6;   $	��320��6I   $
��1 20q�6U   $��Center=�6c   .��54      �� $	��303��6%   $��1q�61   .+�55      �� 
Part Type:65   �� 6@   -	   5        $��	CPartType��55   H   .��6Y   66\   �� 56      Part Rotation:69   �� 6D   -
   5        $��	CRotation��56   L   .��6]   06`   �� 57      Color:61   �� 6<   -   5        $��CColor��57   D   .��6R   426V   �� 58      *(Step Length Divisor: Left-[0.1,77]-Right6S   �� 59      -   5        $��StepLengthSlider��59   %    � Maximum$ 77Q�6h    � Minimum$	 0.1Q�6u   6�   �� 5:      -   5        $��CurrentStepLength��5:   _   $��Right=�6(   $��Center=�6D   Current: 0.16�   �� 5;      -   5        $��IsPlotOrigin��5;   '    d� 	IsChecked$
 TrueY�6;   .��6L   Plot Origin ?6[   5<      5=      �� 5>      $��Plotting Options��6   $��15(�69   $	��320��6G   $
��2 20q�6S   $��Right=�6a   .��5?      �� $��1q�6%   .+�5@      9� $��Mapping Modes��6'   .��5A   "   �� $
��12 0q�6-   .+�5B   &   	� -   5        $��
RbRealAxis��5B   F   $��	Real axis��62   $
 TrueY�6X   6k   	� 5C   &   -   5        $��RbImaginaryAxis��5C   K   $��Imaginary axis��62   $ FalseY�6b   6v   	� 5D   &   -   5        $��RbComplexRange��5D   J   $��Complex range��62   $ FalseY�6`   6t   	� 5E   &   -   5        $��RbUnitCircle��5E   H   $��Unit Circle��62   $ FalseY�6\   6p   5F   #   5G      9� 5H      $��
Algorithms��6'   .��5I   "   �� $
��12 0q�6-   .+�5J   &   	� -   5        $��AlPixileGoggs��5J   Y   $"��PixileGoggsUI -RESURRECTION-��62   $
 TrueY�6n   6�   	� 5K   &   -   5        $��AlMandelbrot��5K   U   $��Mandelbrot's Convergence��62   $ FalseY�6i   6}   5L   #   5M      5N      5O      �� 5Q      -   5        $��PlotFunction��5Q      $	��300��61   $��30��6=   $��Right=�6I   $��Bottom=�6e   $��	0 0 12 30q�6�   $
��Plot��6�   6�   5R      � 5S      $	��620��6   $��Bottom=�6$   .+�5T      �� $��Pictures To Parts��6   $��15(�6:   .��5U      �� $	��310��6#   $
��Left=�6/   $	��Top=�6J   $	��130��6b   $��2q�6o   $��Options��6z   .��5V      �� $��2q�6)   .+�5W   "   �� -   5        $��	SelectPic��5W   N   $��30��6)   $��Select picture��65   6a   �� 5X   "   -   5        $��
CurrentPic��5X   ,   Currently Selected: nullptr6[   �� 5Y   "   $��1q�6,   Origin Coordinates6K   �� 6V   -   5        $��	PicOrigin��5Y   i   $��1q�6^   .��6z   0,06   5Z      5[      5]      �� 5_      $	��310��6   $
��Left=�6+   $	��Top=�6F   $	��130��6^   $��8,150q�6k   $��Transformations��6z   $��15(�6�   .��5`      �� $��2q�6%   .+�5a      �� -   5        $��EnableTrans��5a   '   $��Enable?��6:   $ FalseY�6L   6`   �� 5b      $��1q�6(   Complex Function l=F(z)=6M   �� 6X   -   5        $��TransFunction��5b   k   $��1q�6`   .��6�   z^26�   5c      5d      �� 5e      -   5        $��DrawPic��5e      $	��300��6,   $��30��68   $��Right=�6D   $��Bottom=�6`   $��	0 0 12 30q�6{   $��Draw Picture��6�   6�   � 5f      $	��620��6   $	��500��6'   $��Right=�64   $	��Top=�6P   $��26,38q�6h   
�������.+�5g      �� -   5        $��
PicPreview��5g       64   5h      5i      5j      5k      6   5l      