   M S B A M L   `   `   `  ���� G  CShoppingCart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ShoppingCartShoppingCart      ShoppingCart.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:ShoppingCart     V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  $	��600��$
��1080��  � WindowStartupLocation$  CenterScreen=� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=�.��� .+�� -   $��windowLogin��$y�	Collapsed=� � RowDefinitions �� �� $	��19* �.+�� -   $��0��$	��Top=����	#FF4572A0$��2��.+���  �� Orientation$ 
Horizontal=�$��Right=�.+��� -   ��Z� ��Z� .��'  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowMinimize=��� -   ��Z� ��Z� .��  $ Power=��� -   ��Z� ��Z� .��  $ SwapHorizontalBold=�$��25��$��25��� -    �Name$ Login��$y�Visible=�$��1��.+��� ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.��� 	 � Color$	 	#FF2281D1��� $	 	#FF34268A��
 � Offset$
 1Q�� $	 	#FF33288B��$
 0.546Q��  �� $	��91* ��� $
��368* ��� $	��59* ��� $
��129* � � ColumnDefinitions �� $
��395* ��� $
��283* ��� $
��394* �.+�� $��1��$��1�� J� RenderTransformOrigin$ 0.5,0.5&�.+��� $��1��$��1��
������� �� RadiusX$ 20�� �� RadiusY$ 20���� $��1��$��0��$ 0.5,0.5&�.+��� -   $��	loginText��$y�	Collapsed=�$��LOGIN��$��Center=�$	��Top=�$��25q�
�������$��30(��� -   $��regText��$y�Visible=�$��REGISTRATION��$��Center=�$	��Top=�$��25q�
�������$��30(��� -	   $��	checkText��$y�	Collapsed=�$��Please wait sms code��$��Center=�$	��Top=�$��25q�
�������$��24(��� $��Center=�$��1��$��0��.+��� -
   $��loginTextBox��$y�	Collapsed=�$��20 10 20 10q�
���   �)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Phone�� %  !MaterialDesignFloatingHintTextBox#��[  $��Champagne & Limousines)�$��20(��� -   $��
regTextBox��$y�Visible=�$��20 10 20 10q�
���   �$ Phone��#��[  $��Champagne & Limousines)�$��20(��� -   $��checkTextBox��$y�	Collapsed=�$��20 10 20 10q�
���   �$ SMS code��#��[  $��Champagne & Limousines)�$��20(�G� -    G�Name$ passwordReg��$y�Visible=�$��20 10 20 10q�
���   �$ Password�� ) %MaterialDesignFloatingHintPasswordBox#��[ $��Champagne & Limousines)�$��20(�G� -   $ passwordLog��$y�	Collapsed=�$��20 10 20 10q�
���   �$ Password��#��[ $��Champagne & Limousines)�$��20(��� $��0��$��1��$��Bottom=�.+��� -    ��Name$ 
loginEnter��$y�	Collapsed=�$��20 10 20 20q�$��Bottom=�$��LOGIN���� -   $ regEnter��$y�Visible=�$��20 10 20 20q�$��Bottom=�$��ACCEPT���� -   $ 
checkEnter��$y�	Collapsed=�$��20 10 20 20q�$��Bottom=�$��ACCEPT��� -   $��	mainPanel��$y�Visible=� �� �� $	��19* �.+�� -   $��0��$	��Top=����	#FF4572A0$��2��.+��� $ 
Horizontal=�$
��Left=�.+��� ��Z� ��Z� .��  $ Account=��� $ 
Horizontal=�$��Right=�.+��� -   ��Z� ��Z� .��  $ WindowMinimize=��� -   ��Z� ��Z� .��  $ WindowMaximize=��� -   ��Z� ��Z� .��  $ Power=��� $��Nike Sneakers Mart��$��Center=�$��Center=�
�������$��18(�� $	��Top=����	#FF679CC9$��1��$��76�� �� $
��107* ��� $
��331* ��� $
��102* �.+��� $��0��$��20 0 0 0q�$��SneakerS��$��Center=�$
��Left=�$��40(�
�������$��Harlow Solid Italic)��� $ Vertical=�$��1��.+��� $ SEARCH��$��Center=�$��
40 20 40 0q�
�������$��20(��� $ 
Horizontal=�$��Right=�$��
0,20,50,20q�$��Center=�$��2��.+��� -   $��buttonForOpenCartMenu�����	#FF679CC9���	#FF679CC9���	#FF679CC9+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth0=�.���� $H��Bhttp://www.stickpng.com/assets/images/5a6601baeace967f8e026b9f.png���� -   $��countItemsInCart��
�������$��18(�$��0��$��Center=��� -   $��gridAdd��$
��Left=�$	��479��$��
199,81,0,0q�$��1��$	��Top=�$	��871��.@�� $	��Top=�
�������$	��420��$	��823�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 20Q�   ShadowDepth$ 1Q�.+��� $��Assets/92886_179403_1.jpg��$
��Left=�$��21,0,0,0q��� $��542,70,0,70q�$
��Left=�$	��263��.+��� $��BOi NEXT DOOR��$��18(�$	��0 5q����	#FF6A6A6A�� $ ��D8 10.5-3 BASKETBALL SHOES��$��22(�$
��Wrap=����	#FF6A6A6A�� $��$ 95.99��$��20(�$
��0 15q����	#FFC7C7C7�� ���	#FF4572A0���	#FF4572A0$��SHOP NOW��$
��0 20q�� -   $��cartMenu��$y�	Collapsed=�.+�� -   $��0��$	��Top=����	#FF4572A0$��2��.+��� $ 
Horizontal=�$
��Left=�.+��� ��Z� ��Z� .��  $ Account=��� $ 
Horizontal=�$��Right=�.+��� -   ��Z� ��Z� .��  $ WindowMinimize=��� -   ��Z� ��Z� .��  $ WindowMaximize=��� -   ��Z� ��Z� .��  $ Power=��� $��Nike Sneakers Mart��$��Center=�$��Center=�
�������$��18(�� .+��� $
��1080��$��30��$��Center=�$	��Top=�$��0,32,0,0q����	#FF43A9FD.+��� $~��x   Count                    Name                                            Unit price                      Amount price��$��20(��� -   $��cartListBox��$
��0,62q�.@�� 
�������$��70��$
��1060�� �� $
��170* ��� $
��302* ��� $
��202* ��� $
��177* ��� $
��209* �   $ 20Q�$ 1Q�.+��� $��2��
���   �$��30(�$��Center=�$��40��$
��0,15q��� $��Hama Astana��$��1��
���   �$��30(�$��Center=�$��40��$
��0,15q��� $��200тг��$��2��
���   �$��30(�$��Center=�$��40��$
��0,15q��� $��200тг��$��3��
���   �$��30(�$��Center=�$��40��$
��0,15q�$��2���� -    $��4��$��20q�
���  ��$��Удалить���� -!   $��12,558,882,10q�$
��Back���� $��203,558,691,10q�$	��Pay��