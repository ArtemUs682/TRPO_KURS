   M S B A M L   `   `   `  ����?  ;Kurs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KursKurs  5   	       Kurs.ReceiptsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Kurs     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Квитанции��5	       � WindowStartupLocation$ CenterScreen=�6    � AllowsTransparency . $��440.535��6h   $��765.952��6y    � WindowStyle$
 None=�6�   ��6R   Z� .��5
      � -   5         J� RenderTransformOrigin$ 
0.547,0.51&�5
      .+�5   
   �� 
���   �$��1q�6%   $
��Left=�69    �� CornerRadius$ 20��6T   $	��443��6f   $	��Top=�6s   $	��768��6�   $��
0,0,-336,0q�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFDC8C00��6#   	 � Offset$	 0Q�65   � 5      $ 	#FFEE2E1B��6#   $	 1Q�65   5      5      �� 5   
   -   5        
 ��Name$
 CloseBtn��5      $��×��6#   $��727,9,-317,0q�6/   $��22��6E   ���	#FFF15138���	#FFE4320B���	#BFFFDBDB$��22��6�   $
��Bold"�6�   $
��Left=�6�   $	��Top=�6�   $��Center=�6�   $��0,-2,0,0q�6   � UseLayoutRounding . ��. $��Center=�6\  $��14(�6~  6�  �� 5   
   -   5        $
 TurnBtn��5      $	��–��6"   $��703,9,-294,0q�6.   $��23��6D   ���	#FFDE9253���	#FFA2613B���	#BFFFDBDB$��22��6�   $
��Bold"�6�   $
��Left=�6�   $	��Top=�6�   $��Center=�6�   $��0q�6
   . ��. $��Center=�6T  $��14(�6v  6�  &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DG��5      $
��Left=�6   $	��397��6:   $��10,36,-326,0q�6G   $	��Top=�6]   $	��748��6u   �� 5   
   -   5         ��Name$ 	SearchBox��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ФИО клиента��6%   $
��Left=�6R   $��31��6m   $��18,1,0,0q�6y    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��190��6�   $��18(�6�   �� 5   
   -   5        $
 	SearchBtn��5      $
��🔍��6%   $��	209,9,0,0q�62   $��23��6E   ���	#FF4AB6C1���	#FF309E99���	#BFFFDBDB$��22��6�   $
��Bold"�6�   $
��Left=�6�   $	��Top=�6�   $
��Left=�6�   $��2,-1,0,0q�6	   . ��. $	��Top=�6Z  $��18(�6y  6�  5      5      