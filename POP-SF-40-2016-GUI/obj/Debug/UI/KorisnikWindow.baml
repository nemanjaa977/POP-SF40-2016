   M S B A M L   `   `   `  ����M  IPOP-SF-40-2016-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:POP_SF_40_2016_GUI.UIPOP_SF_40_2016_GUI.UI  5   	   *    $POP_SF_40_2016_GUI.UI.KorisnikWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:POP_SF_40_2016_GUI.UI     5   	     � Title$  KorisnikWindow��5   	   $��340.479��6    $��546.404��61    � 
ResizeMode$ NoResize=�6A    � WindowStartupLocation$ CenterScreen=�6W   ���	#FFA9D0CE.��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgKorisnik��5
      $
��Left=�6'      CanUserAddRows .     CanUserReorderColumns .     CanUserResizeColumns .  $	��191��6�   $��	10,10,0,0q�6�   $	��Top=�6�   $	��520��6�      
IsReadOnly .  �� SelectedItem 6�   �� 	 �� Path$	 IzabranKorisnik�6=  �� 5   
   -   5        
 ��Name$
 btnDodaj��5      $��Dodaj��6#   $
��Left=�63   $��23��6N   $��
10,278,0,0q�6Z   $	��Top=�6n   $��73��6�   ���	#FF00FF03���	#FF2BFF00
�������6�   �� 5   
   -   5        $
 	btnIzmeni��5      $��Izmeni��6$   $
��Left=�65   $��23��6P   $��
88,278,0,0q�6\   $	��Top=�6p   $��73��6�   
����������	#FF00D631���	#FF00E7136�   �� 5   
   -   5        $
 
btnIzbrisi��5      $��Izbrisi��6%   $
��Left=�67   $��23��6R   $��166,278,0,0q�6^   $	��Top=�6s   $��73��6�   
�������
���  ��
���  ��6�   �� 5   
   -   5        $
 
btnZatvori��5      $��Zatvori��6%   $
��Left=�67   $��23��6R   $��457,278,0,0q�6^   $	��Top=�6s   $��73��6�   
���  ��
���  ��
�������6�   �� 5   
   $��	Sortirati��6   $��13(�6$   $
��Left=�62   $��24��6M   $��333,223,0,0q�6Y   $	��Top=�6n   $��64��6�   �� 5   
   -   5         ��Name$ cbSortKorisnik��5      $
��Left=�6+   $��24��6F   $��402,223,0,0q�6R   $	��Top=�6g   $	��104��6   6�   �� 5   
   -   5        $
 btnPretragaKorisnik��5      $��Pretraga��6.   $��12(�6A   $
��Left=�6O   $��24��6j   $��146,223,0,0q�6v   $	��Top=�6�   $��75��6�   
����������	#FF18FF00���	#FF00FF036�   �� 5   
   -   5        $��tbPretragaKorisnik��5   -   $
��Left=�6   $��24��6G   $��
10,223,0,0q�6S    �� TextWrapping$
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��131��6�   �� 5   
   -	   5        $
 btnOSveziKor��5      $��Osvezi��6'   $
��Left=�68   $��24��6S   $��226,223,0,0q�6_   $	��Top=�6t   $��75��6�   
����������	#FF16EA00���	#FF00EB036�   5      5      