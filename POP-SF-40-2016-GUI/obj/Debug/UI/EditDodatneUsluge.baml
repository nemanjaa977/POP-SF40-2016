   M S B A M L   `   `   `  ����M  IPOP-SF-40-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_40_2016_GUI.UIPOP_SF_40_2016_GUI.UI  5   	   -    'POP_SF_40_2016_GUI.UI.EditDodatneUsluge   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_40_2016_GUI.UI     5   	     � Title$  EditDodatneUsluge��5   	   $��214.268��6#   $��515.777��64    � 
ResizeMode$ NoResize=�6D    � WindowStartupLocation$ CenterScreen=�6Z   
���   �
�������.��5	      � $��0,0,-0.4,2.2q�6    � RowDefinitions 5
   
   �� 5      $
��138* �6   �� 5      $	��85* �6   .+�5   
   �� $��Naziv:��6   $
��Left=�6!   $��33��6<   $��	36,33,0,0q�6H   $	��Top=�6[   $	��111��6s   $��20(�6   �� 5   
   $��Cena:��6   $
��Left=�6    $��33��6;   $��	36,80,0,0q�6G   $	��Top=�6Z   $	��111��6r   $��20(�6~   �� 5   
   -   5         ��Name$ tbNaziv��5      $
��Left=�6#   $��33��6>   $��
182,33,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6�   $	��282��6�   $��15(�6�   ��6r   ��  �� Path$ Naziv�6�   �� 5   
   -   5        $ tbCena��5      $
��Left=�6"   $��33��6=   $��
182,80,0,0q�6I   $
 Wrap=�6]   $	��Top=�6q   $	��282��6�   $��15(�6�   .��6�   ��5      �� 5      $
 Cena�6    �� UpdateSourceTrigger$ PropertyChanged=�6&    �� ValidationRules 5      ,  &POP_SF_40_2016_GUI.UI.ValidationDouble  5      5      .��5      5      �� 5   
   -   5        	 ��Name$	 
btnZatvori��5      $��Zatvori��6%   $
��Left=�67   $��31��6R   $��36,28.2,0,0q�6^   $��1��6s   $	��Top=�6�   $��95��6�   
�������
���  ��
���  ��6�   �� 5   
   -   5        $	 
btnSacuvaj��5      $��Sacuvaj��6%   $
��Left=�67   $��31��6R   $��369,28.2,0,0q�6^   $��1��6t   $	��Top=�6�   $��95��6�   
����������	#FF35FF01���	#FF0FFF006�   5      5      