   M S B A M L   `   `   `  ����G  CSimple paint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Simple_paintSimple_paint  5   	       Simple_paint.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Simple_paint     5   	   -   5          � Title$  Simple Paint��5   	   $	��784��6   $
��1382��6+    � Icon$ Image/paint.png��68    � Cursor$ Arrow��6m   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��137 �6   �� 5      $��* �6   .+�5   
   �� $��1��6   .��5      �� -   5         ��Name$ paintCanvas��5      
������� � ContextMenu 5      �� 5      .@�5      m� $
��Copy��6#   5      m� 5      $��Paste��6#   5      m� 5      $	��Cut��6#   5      5      5      5       +  %System.Windows.Controls.Ribbon.Ribbon  5!   
   -   5          Name$	 rib��5!         ApplicationMenu 5)      :  4System.Windows.Controls.Ribbon.RibbonApplicationMenu  5*      ��5+      �� 5,       �� ImageSource$ Image/File-btn.png��6%   .@�5/      >  8System.Windows.Controls.Ribbon.RibbonApplicationMenuItem  -   5        $��_Open��5/   0   	 m� InputGestureText$	 Ctrl+O��6?   3  -System.Windows.Controls.Ribbon.RibbonMenuItem
   ImageSource$
 Image/Open-icon.png��6Y   6{     50      $��_Save��60   $	 Ctrl+S��6?   $
 Image/save.png��6Y     51      $��S_ave As��60   $
 Image/Save-as-icon.png��6B     52      $��_About��60   $
 Image/About.png��6@     53      $��_Exit��60   $
 Image/Exit.png��6?   55      .@�58      .  (System.Windows.Controls.Ribbon.RibbonTab  -   5        $��tabHome��58      $
��Home��6'   .@�59      0  *System.Windows.Controls.Ribbon.RibbonGroup  -   5        $��Image��59      $��Image��6+   .@�5:      1  +System.Windows.Controls.Ribbon.RibbonButton  -   5        $��Select��5:   #   $��-5,8,-14,-24q�61   ��5;      �� 5<       j� Stretch$ Uniform=�6)   $ Image/DottedPath1.jpg��6;      MouseOverBackground 5>      �� 5?      $ Uniform=�6)   $ Image/DottedPath1.jpg��6;      FocusedBackground 5A      �� 5B      $ Uniform=�6)   $ Image/DottedPath1.jpg��6;   5D      5E        5G      -   5        $��grTool��5G      $��Tools��6,   .@�5H      �  5I      �� 5J      $
��Auto �6,   �� 5K      $
��Auto �6,   .+�5N      � $��0��6    � ColumnDefinitions 5O      �� 5P   "   $
��Auto �63   �� 5Q   "   $
��Auto �63   �� 5R   "   $��* �63   .+�5U        -	   5        $��	btnPencil��5U   ;   $��0��6+   $��30��6L   $��20��6W    � ToolTip$ Pencil��6c      PressedBackground 5V   "   �� 5W   &   $ Uniform=�61   $ Image/Pencil-icon.png��6C    5Y   "   �� 5Z   &   $ Image/Pencil-icon.png��61   $ Uniform=�6U    5\   "   �� 5]   &   $ Image/Pencil-icon.png��61   $ Uniform=�6U   ��5_   "   �� 5`   &   $ Image/Pencil-icon.png��61   $ Uniform=�6U   5b        5d      -
   5        $��	btnErazer��5d   +   $��30��6<   $��2��6G    5e   "   �� 5f   &   $ Uniform=�61   $ Image/eraser.png��6C    5h   "   �� 5i   &   $ Image/eraser.png��61   $ Uniform=�6P    5k   "   �� 5l   &   $ Uniform=�61   $ Image/eraser.png��6C   ��5n   "   �� 5o   &   $ Image/eraser.png��61   $ Uniform=�6P   5q      5r      � 5s      $��1��6    5t      �� 5u   "   $
��Auto �63   �� 5v   "   $
��Auto �63   .+�5x        -   5          Name$ 	btnBucket��5x   ;   $��0��6+   $��30��6N   $��20��6Y   $ Bucket��6e    5y   "   �� 5z   &   $ Image/Fill Color.png��61   $ Uniform=�6T    5|   "   �� 5}   &   $ Image/Fill Color.png��61   $ Uniform=�6T    5   "   �� 5�   &   $ Image/Fill Color.png��61   $ Uniform=�6T   ��5�   "   �� 5�   &   $ Image/Fill Color.png��61   $ Uniform=�6T   5�        5�      -   5        $ btnText��5�   ;   $��1��6+   $��30��6L   $��20��6W   $
��Bold"�6c   $��16(�6u    5�   "   �� 5�   &   $ Uniform=�61   $ Image/A.png��6C    5�   "   �� 5�   &   $ Uniform=�61   $ Image/A.png��6C    5�   "   �� 5�   &   $ Image/A.png��61   $ Uniform=�6K   ��5�   "   �� 5�   &   $ Image/A.png��61   $ Uniform=�6K   5�      5�      5�      5�        5�      -   5          Name$ grBrush��5�      $��Brush��6/   $��0q�6>   .@�5�        -   5        $ btnBrush��5�   #   $��Stretch=�66   $��50��6T   $��66��6_   $ Brush��6k    5�      �� 5�      $ Image/brush.png��6)   $ UniformToFill=�6G    5�      �� 5�      $ Image/brush.png��6)   $ UniformToFill=�6G    5�      �� 5�      $ Image/brush.png��6)   $ UniformToFill=�6G   ��5�      �� 5�      $ Image/brush.png��6)   $ UniformToFill=�6G   5�      5�        5�      -   5        $��grShapes��5�      $	��110��6.   $��Shapes��6:   
�������$��0q�6]   .@�5�      �  5�      �� 5�      $
��Auto �6,   �� 5�      $
��Auto �6,   �� 5�      $��* �6,   .+�5�      � $��0��6    5�      �� 5�   "   $
��Auto �63   �� 5�   "   $
��Auto �63   �� 5�   "   $��* �63   .+�5�        -   5        $��0��5�   +   $��20��6;   $��30��6G   $
 Line��6R    5�   "   �� 5�   &   $ Uniform=�61   $! Image/Editing-Line-icon.png��6C    5�   "   �� 5�   &   $ Uniform=�61   $! Image/Editing-Line-icon.png��6C    5�   "   �� 5�   &   $! Image/Editing-Line-icon.png��61   $ Uniform=�6[   ��5�   "   �� 5�   &   $! Image/Editing-Line-icon.png��61   $ Uniform=�6[   5�        5�      -   5        $��1��5�   +   $��30��6;   $��20��6F   $ Ellipse��6R    5�   "   �� 5�   &   $ Image/Ellipse.png��61   $ Uniform=�6Q    5�   "   �� 5�   &   $ Image/Ellipse.png��61   $ Uniform=�6Q    5�   "   �� 5�   &   $ Image/Ellipse.png��61   $ Uniform=�6Q   ��5�   "   �� 5�   &   $ Image/Ellipse.png��61   $ Uniform=�6Q   5�        5�      -   5        $��2��5�   +   $��30��6;   $��20��6F   $ 	Rectangle��6R    5�   "   �� 5�   &   $ Image/Rectangle.png��61   $ Uniform=�6S    5�   "   �� 5�   &   $ Image/Rectangle.png��61   $ Uniform=�6S    5�   "   �� 5�   &   $ Image/Rectangle.png��61   $ Uniform=�6S   ��5�   "   �� 5�   &   $ Image/Rectangle.png��61   $ Uniform=�6S   5�      5�      � 5�      $��1��6    5�      �� 5�   "   $
��Auto �63   �� 5�   "   $
��Auto �63   �� 5�   "   $��* �63   .+�5�        -   5        $��btnTriangle��5�   ;   $��0��6+   $��30��6N   $��20��6Y   $ Triangle��6e    5�   "   �� 5�   &   $ Image/Triangle.png��61    5�   "   �� 5�   &   $ Image/Triangle.png��61    5�   "   �� 5�   &   $ Image/Triangle.png��61   $ Uniform=�6R   ��5�   "   �� 5�   &   $ Image/Triangle.png��61   5�        5�      -   5        $��btnArrow��5�   ;   $��1��6+   $��30��6K   $��20��6V   $ Arrow��6b    5�   "   �� 5�   &   $ Image/Arrow.png��61   $ UniformToFill=�6O    5�   "   �� 5   &   $ Image/Arrow.png��61   $ UniformToFill=�6O    5  "   �� 5  &   $ Image/Arrow.png��61   $ UniformToFill=�6O   ��5  "   �� 5  &   $ Image/Arrow.png��61   $ UniformToFill=�6O   5       5
     -   5        $��btnHeart��5
  ;   $��2��6+   $��30��6K   $��20��6V   $ Heart��6b    5  "   �� 5  &   $ Image/Heart.png��61    5  "   �� 5  &   $ Image/Heart.png��61    5  "   �� 5  &   $ Image/Heart.png��61   ��5  "   �� 5  &   $ Image/Heart.png��61   5     5     5     5       5     -   5        $��grThickness��5     $
��Size��61   .@�5     �  5      �� 5!     $
��Auto �6,   �� 5"     $��* �6,   .+�5$     �� $��0��6    $��70��6-   $��50��68   $��Image/Thicknesses.png��6D   $��UniformToFill=�6c   �� 5%     -   5         ��Name$ cbxThickness��5%  1   $��1��6#   $
��Left=�6G   $	��Top=�6b   $��70��6z   $��20��6�    �� MaxDropDownHeight$
 1000��6�   ��5&     �� 5'  "   $ Image/Thickness1.png��6-   .@�5)     �� $��_____________��6+   $
 1 px��6C   ��5*  "   �� 5+  &   $ Image/Thickness1.png��61   5-     �� 5.     $��30��6+   $��70��67   $
 3 px��6B   ��5/  "   �� 50  &   $ Image/Thickness3.png��61   52     �� 53     $��30��6+   $��70��67   $
 5 px��6B   ��54  "   �� 55  &   $ Image/Thickness5.png��61   57     �� 58     $��30��6+   $��70��67   $
 7 px��6B   ��59  "   �� 5:  &   $ Image/Thickness7.png��61   5<     5=     5>     5?       5A     -   5        $��grColor��5A     $��Colors��6-   .@�5B     �  5C     �� 5D     $
��Auto �6/   �� 5E     $
��Auto �6/   �� 5F     $��* �6/   �� 5G     $
��Auto �6/   .+�5I     � $��0��6    5J     �� 5K  "   $
��Auto �60   �� 5L  "   $��* �60   .+�5N     �� -   5        $��	btnColor1��5N  $   $��40��65   $��40��6@   $��0��6L   
���   �5O     �� 5P     $��Current Color��6$   $��1��6<   5Q     � 5S     $��1��6   $��
5, 0, 0, 0q�6/    5T     �� 5U  "   $
��Auto �60   �� 5V  "   $
��Auto �60   �� 5W  "   $
��Auto �60   .+�5Y       $��0��6+   $��20��68   $��20��6C   
���   �$
��Left=�6b   
 �   �
 �   �6�     5Z     $��0��6+   $��20��68   $��20��6C   
�������$
��Left=�6b   $��23, 0, 0, 0q�6}   
 �����
 �����6�     5[     $��0��6+   $��20��68   $��20��6C   ���	#FF880015$
��Left=�6f   $��46, 0, 0, 0q�6�    �	#FF880015 �	#FF8800156�     5\     $��0��6+   $��20��68   $��20��6C   ���	#FFED1C24$
��Left=�6f   $��69, 0, 0, 0q�6�    �	#FFED1C24 �	#FFED1C246�     5]     $��0��6+   $��20��68   $��20��6C   ���	#FF22B14C$
��Left=�6f   $��92, 0, 0, 0q�6�    �	#FF22B14C �	#FF22B14C6�     5^     $��0��6+   $��20��68   $��20��6C   ���	#FF00A2E8$
��Left=�6f   $��115, 0, 0, 0q�6�    �	#FF00A2E8 �	#FF00A2E86�     5_     $��0��6+   $��20��68   $��20��6C   ���	#FF3F48CC$
��Left=�6f   $��138, 0, 0, 0q�6�    �	#FF3F48CC �	#FF3F48CC6�     5`     $��0��6+   $��20��68   $��20��6C   ���	#FFA349A4$
��Left=�6f   $��161, 0, 0, 0q�6�    �	#FFA349A4 �	#FFA349A46�     5a     $��0��6+   $��20��68   $��20��6C   
���  ��$
��Left=�6`   $��184, 0, 0, 0q�6{   
 �  ��
 �  ��6�     5b     $��0��6+   $��20��68   $��20��6C   ���	#FFFF7F27$
��Left=�6f   $��207, 0, 0, 0q�6�    �	#FFFF7F27 �	#FFFF7F276�     5d     $��1��6+   $��20��68   $��20��6C   
���  ��$
��Left=�6`   $��
0, 2, 0, 0q�6{   
 �  ��
 �  ��6�     5e     $��1��6+   $��20��68   $��20��6C   ���	#FFFF1E1E$
��Left=�6f   $��23, 2, 0, 0q�6�    �	#FFFF1E1E �	#FFFF1E1E6�     5f     $��1��6+   $��20��68   $��20��6C   ���	#FFFF3C3C$
��Left=�6f   $��46, 2, 0, 0q�6�    �	#FFFF3C3C �	#FFFF3C3C6�     5g     $��1��6+   $��20��68   $��20��6C   ���	#FFFF5A5A$
��Left=�6f   $��69, 2, 0, 0q�6�    �	#FFFF5A5A �	#FFFF5A5A6�     5h     $��1��6+   $��20��68   $��20��6C   ���	#FFFF7878$
��Left=�6f   $��92, 2, 0, 0q�6�    �	#FFFF7878 �	#FFFF78786�     5i     $��1��6+   $��20��68   $��20��6C   ���	#FFFF9696$
��Left=�6f   $��115, 2, 0, 0q�6�    �	#FFFF9696 �	#FFFF96966�     5j     $��1��6+   $��20��68   $��20��6C   ���	#FFFFB4B4$
��Left=�6f   $��138, 2, 0, 0q�6�    �	#FFFFB4B4 �	#FFFFB4B46�     5k     $��1��6+   $��20��68   $��20��6C   ���	#FFFFD2D2$
��Left=�6f   $��161, 2, 0, 0q�6�    �	#FFFFD2D2 �	#FFFFD2D26�     5l     $��1��6+   $��20��68   $��20��6C   ���	#FFFFF0F0$
��Left=�6f   $��184, 2, 0, 0q�6�    �	#FFFFF0F0 �	#FFFFF0F06�     5m     $��1��6+   $��20��68   $��20��6C   
�������$
��Left=�6b   $��207, 2, 0, 0q�6}   
 �����
 �����6�     5o     $��2��6+   $��20��68   $��20��6C   
��� � �$
��Left=�6a   
 � � �
 � � �6�     5p     $��2��6+   $��20��68   $��20��6C   ���	#FF00F500$
��Left=�6f   $��23, 2, 0, 0q�6�    �	#FF00F500 �	#FF00F5006�     5q     $��2��6+   $��20��68   $��20��6C   ���	#FF00E100$
��Left=�6f   $��46, 2, 0, 0q�6�    �	#FF00E100 �	#FF00E1006�     5r     $��2��6+   $��20��68   $��20��6C   ���	#FF00D700$
��Left=�6f   $��69, 2, 0, 0q�6�    �	#FF00D700 �	#FF00D7006�     5s     $��2��6+   $��20��68   $��20��6C   ���	#FF00CD00$
��Left=�6f   $��92, 2, 0, 0q�6�    �	#FF00CD00 �	#FF00CD006�     5t     $��2��6+   $��20��68   $��20��6C   ���	#FF00C300$
��Left=�6f   $��115, 2, 0, 0q�6�    �	#FF00C300 �	#FF00C3006�     5u     $��2��6+   $��20��68   $��20��6C   ���	#FF00B900$
��Left=�6f   $��138, 2, 0, 0q�6�    �	#FF00B900 �	#FF00B9006�     5v     $��2��6+   $��20��68   $��20��6C   ���	#FF00AF00$
��Left=�6f   $��161, 2, 0, 0q�6�    �	#FF00AF00 �	#FF00AF006�     5w     $��2��6+   $��20��68   $��20��6C   ���	#FF00AF00$
��Left=�6f   $��184, 2, 0, 0q�6�    �	#FF00AF00 �	#FF00AF006�     5x     $��2��6+   $��20��68   $��20��6C   ���	#FF00A500$
��Left=�6f   $��207, 2, 0, 0q�6�    �	#FF00A500 �	#FF00A5006�   5z     � 5{     $��2��6    5|     �� 5}  "   $
��Auto �60   �� 5~  "   $��* �60   .+�5�       -   5        $��btnEditColor��5�  8   $��0��6+   $��40��6L   $��40��6W   $��10, 0, 0, 0q�6c   ��5�  "   �� 5�  &   $ Image/EditColor.png��61   $ UniformToFill=�6S    5�  "   �� 5�  &   $ Image/EditColor.png��61   $ UniformToFill=�6S    5�  "   �� 5�  &   $ Image/EditColor.png��61   $ UniformToFill=�6S   5�     �� 5�     $��1��6$   $��Edit Colors��62   $��
5, 0, 0, 0q�6H   5�     5�     5�       5�     -   5        $��	Undo_Redo��5�     $��	Undo/Redo��6/   .@�5�     �  5�     �� 5�     $
��Auto �6/   �� 5�     $��* �6/   .+�5�       -   5        $��btnUndo��5�  7   $��0��6'   $��40��6F   $��40��6Q   $��
0,10,0,-10q�6]   ��5�     �� 5�  "   $ Image/Undo.png��6-   $ UniformToFill=�6J    5�     �� 5�  "   $ Image/Undo.png��6-   $ UniformToFill=�6J    5�     �� 5�  "   $ Image/Undo.png��6-   $ UniformToFill=�6J   5�       5�     -   5        $��btnRedo��5�  7   $��1��6'   $��40��6F   $��40��6Q   $	��Top=�6]   $
��Left=�6u   $��
0,10,0,-10q�6�   ��5�     �� 5�  "   $ Image/Redo.png��6-   $ UniformToFill=�6J    5�     �� 5�  "   $ Image/Redo.png��6-   $ UniformToFill=�6J    5�     �� 5�  "   $ Image/Redo.png��6-   $ UniformToFill=�6J   5�     5�     5�     5�     5�     5�     5�     