   M S B A M L   `   `   `  ����F  BkurscachWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:kurscachWPFkurscachWPF  5   	       kurscachWPF.LogIn   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:kurscachWPF     5   	   -   5          �Name$  MainWindow1��5   	    � Title$ Log In��5   	   $��203.563��6   $	��244��6)    � Topmost .  � 
ResizeMode$ NoResize=�6D    � Icon$9 3pack://siteoforigin:,,,/Resources/Work-PNG-File.ico��6Z    � 	Resources 5	         ControlStyle1 �� 
TargetType �� Property �� Value	 J� SnapsToDevicePixels
 �� StrokeDashArray��%�   &	        �� 5
   
   " ��6&   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   	 . #��� ��6J   $��1��6�   $	
 1 2R�6�   5      5      5      5      .��5      �� -   5         ��Name$ 
MainBorder��5      
�������$��1q�5      $��0,0,0,1q�6!   ._�5   
   � $��0,0,0,-1q�6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5      �  � Color$ 	#FFF1F1E8��6#    � Offset$ 1Q�65   � 5      $ 
WhiteSmoke��6#   $ 0.004Q�66   5       � ColumnDefinitions 5       �� 5!      .+�5#      �� -   5        $�� ��5#      $��187,20,10,0q�6    $	��Top=�65   $��34��6M    � Cursor$
 Hand��6�   ��6Y   Z� ��6p   Z� ��5%      �� 5&       �� 
TargetType" ��6&   .R�5'      �� .+�5(      �� $��image1��6$   $��Resources/multiply(1).png��62   $
��None=�6U   $y�	Collapsed=�6d   �� 5)      $��image2��6$   $��Resources/multiply2.png��62   $
��None=�6S   $y�Visible=�6b   5*       �� Triggers 5+      P� 5,       P� Property �@J�IsMouseOver P� Value . . �5-   "   ��  �� 
TargetName$ image1��6)    � y�$ Visible=�6S   �� 5.   "   $ image2��6)    � y�$ 	Collapsed=�6U   5/      51      53      �� 54      $��
Логин��6   $
��Left=�6$   $��
10,54,0,54q�6?   �� 55      $��Пароль��6   $
��Left=�6%   $��	10,82,0,0q�6@   $	��Top=�6S   $��32��6k   �� 56      $��Вход��6   $��14(�6#   ���	#FF5E636A$��96,13,69,54q�6H    K� ZIndex$ 1��6s   ��6]   Z� 6s   �� 57      -   5         ��Name$ Login��57      $
��Left=�6%   $��22��6@   $��	67,57,0,0q�6L    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��147��6�   G� 58      -   5         G�Name$ Password��58      $
��Left=�6,   $��	67,86,0,0q�6G   $	��Top=�6Z   $	��147��6r   �� 59      -   5         ��Name$ Confirm��59      $��
Войти��6&   $��10,120,124,22q�66   $��Center=�6M   $��32��6h   
�������$��Dubai Light)�6�   $��16(�6�    � FocusVisualStyle# �   6�   ��6�   Z� ��5:      �� 5;      $ 0.5,1&�6*   $ RelativeToBoundingBox=�6;   $ 0.5,0&�6_   .��5<      � $ 	#FFF3F3F3��6'   � 5=      $ 	#FFD87777��6'   � 5>      $ 	#FFC15656��6'   $ 0.996Q�69   5?      5A      �� 5B      -   5        $	 REG��5B      $��Регистрация��6"   $��124,120,10,22q�68   $��Center=�6O   $��32��6j   
�������$��Dubai Light)�6�   $��16(�6�   # �   6�   ��6�   Z� ��5C      �� 5D      $ 0.5,1&�6*   $ RelativeToBoundingBox=�6;   $ 0.5,0&�6_   .��5E      � $ 	#FFF3F3F3��6'   � 5F      $ 	#FFD87777��6'   � 5G      $ 	#FFC15656��6'   $ 0.996Q�69   5H      5J      5L      5M      5N      