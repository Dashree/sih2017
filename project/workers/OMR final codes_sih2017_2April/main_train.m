%% Train the system
clear all
close all
clc

x=imread('C:\OMR final codes_sih2017\Mast.jpg');%%OMR_final.jpg
x1=rgb2gray(x);

x1_level=graythresh(x1);

BW = im2bw(x1,x1_level);
%x1=medfilt2(x);

%[master_width, master_height, roll_no_segment, Centre_Code_segment, Answer_segment, Image_segment, Image_seg, roll_No, Centre_ID, Ans_Seg]=Train_System(BW);

[master_width, master_height, roll_no_segment, Centre_Code_segment, Answer_segment, Image_segment, Image_seg, roll_No, Centre_ID, Ans_Seg]=Train_System_New(BW,x);
[column] = Answer_Columns(Answer_segment);

[answer_key]=Master_Answer_Key(column);

save;