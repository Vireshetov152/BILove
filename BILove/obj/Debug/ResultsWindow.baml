   M S B A M L   `   `   `  ����A  =BILove, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BILoveBILove  5   	       BILove.ResultsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:BILove     5   	     � Title$  ResultsWindow��5   	   $	��500��6   $	��500��6,   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $��2* �6   �� 5      .+�5   
   �� $��Center=�6   .+�5      �� $��Center=�6    �� TextAlignment$ Center=�65   $��24(�6L   $��Here is your couple: ��6Z   �� 5      -   5         ��Name$ coupleNameTextBlock��5      $��Center=�65   $ Center=�6R   $��Italic$�6i   $��30(�6|   $��Wait a while longer��6�   5      �� 5   
   $��1��6   .+�5      �� -   5         ��Name$ coupleImage��5      $��Center=�6)   $��Center=�6F   $	��200��6a   $	��200��6m   5      �� 5   
   $��2��6   $��0 30 0 0q�6"   .+�5      �� -   5        $��40��5      $	��200��6!   $��Center=�6-   $��20(�6H   
�������
����  �$��OK��6{   ��5      �� 5       �� 
TargetType" ��6    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value . . �5   "   �� 	 �� Property	 � ��
 �� Value
 5   &   �� 5   *    �� 
TargetType" ��6:   .R�5   .   �� 
����·�
����  �$��1q�6^   ._�5    2   �� $��Center=�6C   $��Center=�6`   5!   /   5"   +   5$   #   5%      5'      5)      5*      5+      5,      