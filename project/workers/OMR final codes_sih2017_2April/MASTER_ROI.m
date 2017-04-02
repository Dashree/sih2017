clear all
close all

clc
%x=imread('E:\OCR\OCR_Master.jpg');%%OMR_final.jpg
x=imread('E:\OCR\img111025.jpg');%%OMR_final.jpg
%x1=rgb2gray(x);
   x1=medfilt2(x);
%x1=imread('D:\OCR\OMR3.jpg');
%imshow(x1,[])
x1_gray=graythresh(x1);
x1_level=graythresh(x1);
BW = im2bw(x1,x1_level);
%figure, imshow(BW);
[a, b]=size(BW);
inv_BW=~BW;
%figure, imshow(inv_BW);
h = msgbox('Mark the segment for Roll Number');
waitfor(h);
f1=figure;
imshow(inv_BW);
p=ginput(2);
% get x and y coordinated as integr
roll_No(1) =min(floor(p(1)), floor(p(2))); % xmin
roll_No(2) =min(floor(p(3)), floor(p(4))); % ymin
roll_No(3) =max(ceil(p(1)), ceil(p(2))); % xmax
roll_No(4) =max(ceil(p(3)), ceil(p(4))); % ymax
close(f1);
% get the cropped image
roll_no_segment =BW(roll_No(2):roll_No(4), roll_No(1):roll_No(3));
f2=figure;
imshow(roll_no_segment)
%[file, path]=uiputfile('*.mat', 'Save Workspace as');
uisave({'roll_no_segment'},'roll_no_segment');
 h = msgbox('roll_no_segment saved successfully now mark the segment for Centre Code');
 waitfor(h);
 close(f2);
 %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
 f3=figure;
 imshow(inv_BW);
p=ginput(2);
% get x and y coordinated as integr
Centre_ID(1) =min(floor(p(1)), floor(p(2))); % xmin
Centre_ID(2) =min(floor(p(3)), floor(p(4))); % ymin
Centre_ID(3) =max(ceil(p(1)), ceil(p(2))); % xmax
Centre_ID(4) =max(ceil(p(3)), ceil(p(4))); % ymax
close(f3);
% get the cropped image
Centre_Code_segment =BW(Centre_ID(2):Centre_ID(4), Centre_ID(1):Centre_ID(3));
f4=figure;
imshow(Centre_Code_segment)
%[file, path]=uiputfile('*.mat', 'Save Workspace as');
uisave({'Centre_Code_segment'},'Centre_Code_segment');
 h = msgbox('Centre Code segment saved successfully now mark the segment for Answer Segment');
  waitfor(h);
  close(f4);
 %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
 f5=figure;
 imshow(inv_BW);
p=ginput(2);
% get x and y coordinated as integr
Ans_Seg(1) =min(floor(p(1)), floor(p(2))); % xmin
Ans_Seg(2) =min(floor(p(3)), floor(p(4))); % ymin
Ans_Seg(3) =max(ceil(p(1)), ceil(p(2))); % xmax
Ans_Seg(4) =max(ceil(p(3)), ceil(p(4))); % ymax
close(f5);
% get the cropped image
Answer_segment =BW(Ans_Seg(2):Ans_Seg(4), Ans_Seg(1):Ans_Seg(3));
f6=figure;
imshow(Answer_segment)
%[file, path]=uiputfile('*.mat', 'Save Workspace as');
uisave({'Answer_segment'},'Answer_segment');
 h = msgbox('Answer_segment saved successfully');
 waitfor(h);
  close(f6);
 