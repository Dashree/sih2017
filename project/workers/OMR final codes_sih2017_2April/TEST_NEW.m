
clear all
clc
close all
load;
clear x;
clear x1,
clear x1_level

B=imread('C:\OMR final codes_sih2017\NewStudent4.jpg');%%OMR_final.jpg
% Obtain test image boundry
[C_First, C_Last, R_First,R_Last]= Test_Image_Boundry(B);
%x_test = imresize(B, [master_height, master_width]);
x1=rgb2gray(B);
%x1_test=medfilt2(x_test);
x1_level=graythresh(x1);
BW_test = im2bw(x1,x1_level);
%figure, imshow(BW);
Student_roll_no_segment =BW_test(roll_No(2)+R_First:roll_No(4)+R_First, roll_No(1)+C_First:roll_No(3)+ C_First);
Student_Centre_Code_segment =BW_test(Centre_ID(2)+R_First:Centre_ID(4)+R_First, Centre_ID(1) + C_First:Centre_ID(3)+ C_First);
Student_Answer_segment =BW_test(Ans_Seg(2)+R_First:Ans_Seg(4)+R_First, Ans_Seg(1) + C_First:Ans_Seg(3) + C_First);
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% Get roll no. of a student
[R_N] = Roll_Number(Student_roll_no_segment)

%  Get centre no. 
[C_N] = Centre_Code(Student_Centre_Code_segment)

%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
[Student_Answer_column] = Answer_Columns_Test(Student_Answer_segment);


[Result_column]=Evaluate_Answer(Student_Answer_column);


Final_result=cell2mat(Result_column)
% [v1, v2]=size(Final_result);
% Q=1:v2;




