function [master_width, master_height, roll_no_segment, Centre_Code_segment, Answer_segment, Image_segment, Image_seg, roll_No, Centre_ID, Ans_Seg]=Train_System_New(BW,x)

% Inpur X is the preprocessed image, i.e median filtered.

%x=imread('E:\OCR\OCR_Master.jpg');%%OMR_final.jpg
%x=imread('E:\OCR\img111025.jpg');%%OMR_final.jpg
%x1=rgb2gray(x);
%   x1=medfilt2(x);
%x1=imread('D:\OCR\OMR3.jpg');
%imshow(x1,[])

%figure, imshow(BW);

[a, b]=size(BW);
master_width=b;
master_height=a;
%inv_BW=~BW;
%figure, imshow(inv_BW);

h = msgbox('Mark the boundries of the image (ROI)');
waitfor(h);
f1=figure;
imshow(x);
p=ginput(2);
% get x and y coordinated as integr
Image_seg(1) =min(floor(p(1)), floor(p(2))); % xmin
Image_seg(2) =min(floor(p(3)), floor(p(4))); % ymin
Image_seg(3) =max(ceil(p(1)), ceil(p(2))); % xmax
Image_seg(4) =max(ceil(p(3)), ceil(p(4))); % ymax
close(f1);
% get the cropped image
Image_segment=BW(Image_seg(2):Image_seg(4), Image_seg(1):Image_seg(3));
f2=figure;
imshow(Image_segment)
%[file, path]=uiputfile('*.mat', 'Save Workspace as');
uisave({'Image_segment'},'Image_segment');
 h = msgbox('Image_segment saved successfully now mark the segment for Roll Number');
 waitfor(h);
 close(f2);
New_Image_segment=x(Image_seg(2):Image_seg(4), Image_seg(1):Image_seg(3));

h = msgbox('Mark the segment for Roll Number');
waitfor(h);
f1=figure;
imshow(New_Image_segment);
p=ginput(2);
% get x and y coordinated as integr
roll_No(1) =min(floor(p(1)), floor(p(2))); % xmin
roll_No(2) =min(floor(p(3)), floor(p(4))); % ymin
roll_No(3) =max(ceil(p(1)), ceil(p(2))); % xmax
roll_No(4) =max(ceil(p(3)), ceil(p(4))); % ymax
close(f1);
% get the cropped image
roll_no_segment =Image_segment(roll_No(2):roll_No(4), roll_No(1):roll_No(3));
f2=figure;
imshow(roll_no_segment)
%[file, path]=uiputfile('*.mat', 'Save Workspace as');
uisave({'roll_no_segment'},'roll_no_segment');
 h = msgbox('roll_no_segment saved successfully now mark the segment for Centre Code');
 waitfor(h);
 close(f2);
 %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
 f3=figure;
 imshow(New_Image_segment);
p=ginput(2);
% get x and y coordinated as integr
Centre_ID(1) =min(floor(p(1)), floor(p(2))); % xmin
Centre_ID(2) =min(floor(p(3)), floor(p(4))); % ymin
Centre_ID(3) =max(ceil(p(1)), ceil(p(2))); % xmax
Centre_ID(4) =max(ceil(p(3)), ceil(p(4))); % ymax
close(f3);
% get the cropped image
Centre_Code_segment =Image_segment(Centre_ID(2):Centre_ID(4), Centre_ID(1):Centre_ID(3));
f4=figure;
imshow(Centre_Code_segment)
%[file, path]=uiputfile('*.mat', 'Save Workspace as');
uisave({'Centre_Code_segment'},'Centre_Code_segment');
 h = msgbox('Centre Code segment saved successfully now mark the segment for Answer Segment');
  waitfor(h);
  close(f4);
 %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
 f5=figure;
 imshow(New_Image_segment);
p=ginput(2);
% get x and y coordinated as integr
Ans_Seg(1) =min(floor(p(1)), floor(p(2))); % xmin
Ans_Seg(2) =min(floor(p(3)), floor(p(4))); % ymin
Ans_Seg(3) =max(ceil(p(1)), ceil(p(2))); % xmax
Ans_Seg(4) =max(ceil(p(3)), ceil(p(4))); % ymax
close(f5);
% get the cropped image
Answer_segment =Image_segment(Ans_Seg(2):Ans_Seg(4), Ans_Seg(1):Ans_Seg(3));
f6=figure;
imshow(Answer_segment)
%[file, path]=uiputfile('*.mat', 'Save Workspace as');
uisave({'Answer_segment'},'Answer_segment');
 h = msgbox('Answer_segment saved successfully');
 waitfor(h);
  close(f6);