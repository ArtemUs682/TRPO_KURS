   M S B A M L   `   `   `  ����?  ;Kurs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KursKurs  5   	       Kurs.RequestInfoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Kurs     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Инфо о заявке��5	       � WindowStartupLocation$ CenterScreen=�6    � AllowsTransparency . $��473.613��6s   $��219.05��6�    � WindowStyle$
 None=�6�   ��6]   Z� .��5
      � -   5         J� RenderTransformOrigin$ 
0.547,0.51&�5
      .+�5   
   �� 
���   �$��1q�6%   $
��Left=�69    �� CornerRadius$ 20��6T   $	��473��6f   $	��Top=�6s   $	��219��6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFDC8C00��6#   	 � Offset$	 0Q�65   � 5      $ 	#FFEE2E1B��6#   $	 1Q�65   5      5      �� 5   
   -   5        
 ��Name$
 CloseBtn��5      $��×��6#   $��
182,10,0,0q�6/   $��22��6C   ���	#FFF15138���	#FFE4320B���	#BFFFDBDB$��22��6�   $
��Bold"�6�   $
��Left=�6�   $	��Top=�6�   $��Center=�6�   $��0,-2,0,0q�6	   � UseLayoutRounding . ��. $��Center=�6Z  $��14(�6|  6�  �� 5   
   -   5        $
 TurnBtn��5      $	��–��6"   $��
158,10,0,0q�6.   $��23��6B   ���	#FFDE9253���	#FFA2613B���	#BFFFDBDB$��22��6�   $
��Bold"�6�   $
��Left=�6�   $	��Top=�6�   $��Center=�6�   $��0q�6   . ��. $��Center=�6R  $��14(�6t  6�  �� 5   
   -   5         ��Name$ ClientComboBox��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Клиент��6+   $
��Left=�6S   $��	14,44,0,0q�6n   $	��Top=�6�   $	��190��6�   $��30��6�   $��18(�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DateBox��5      $ Дата��6&   $
��Left=�6L   $��	14,92,0,0q�6g   $	��Top=�6z   $	��190��6�   $��30��6�   $��18(�6�   �� 5   
   -   5        $ TypesComboBox��5      $ Тип заявки��6*   $
��Left=�6V   $��
14,140,0,0q�6q   $	��Top=�6�   $	��190��6�   $��29��6�   $��18(�6�   �� 5   
   -   5         ��Name$ 
DescripBox��5      $ Описание��6&   $
��Left=�6P   $	��121��6k   $��
14,187,0,0q�6x    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��190��6�   $��18(�6�   �� 5   
   -   5        $ WorkerComboBox��5      $ Рабочий��6+   $
��Left=�6T   $��
14,327,0,0q�6o   $	��Top=�6�   $	��190��6�   $��30��6�   $��18(�6�   �� 5   
   -	   5        $ StatusComboBox��5      $ Статус��6+   $
��Left=�6S   $��
14,375,0,0q�6n   $	��Top=�6�   $	��190��6�   $��30��6�   $��18(�6�   �� 5   
   -
   5        $
 AddBut��5      $"��💾      Сохранить��6!   $
��Left=�6=   $��
14,418,0,0q�6X   $	��Top=�6l   $	��190��6�   ���	#FFFF7900$��2q�6�   $
��Left=�6�   $��Center=�6�   $��3,2,3,3q�6�   $��38��6  $��18(�6  $��Segoe UI Semilight)�6+  $��Normal"�6K  $��Italic$�6_  ���	#7F2CCB136�  5       5!      