%%% OMR TEST
%%% %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

%% Load Model Answer %%%%%%%%%%%%%%%
%%% Define test image path %%%%%%%%%%%%%%%%%%%%%%%%%

clc; clear all; close all;
load('D:\OCR\Model_answer')
 x=imread('D:\OCR\test.jpg');
 x1=rgb2gray(x);
  x1=medfilt2(x1);
%x1=imread('D:\OCR\OMR2.jpg');
imshow(x1,[])
x1_gray=graythresh(x1);
x1_level=graythresh(x1);
BW = im2bw(x1,x1_level);
figure, imshow(BW);
[a, b]=size(BW);
inv_BW=1.-BW;
figure, imshow(inv_BW);

 Hr_Profile=sum(inv_BW,1)./a;
 Vr_Profile=sum(inv_BW,2)./b;
[a1, b1]=size(Hr_Profile);
for i=1:b1
 if Hr_Profile(1, i)>0.02
     Hr_Profile(1, i)=1;
 else Hr_Profile(1, i)=0;
 end
end
 
 [a2, b2]=size(Vr_Profile);
for i=1:a2
 if Vr_Profile(i)>0.02
     Vr_Profile(i)=1;
 else Vr_Profile(i)=0;
 end
end
x=Hr_Profile;
y=Vr_Profile;
%x=[0 0 0 0 1 1 1 1 1 0 0 0 1 1 1 1 0 0 0 1 1 1 1 0 0 0 0 1 1 1 0 0 0];
dx=diff(x);
j=1;
for i=1:length(dx)
if dx(i)==1
    x1(j)=i;
    j=j+1;
else if dx(i)==-1
        x1(j)=i;
        j=j+1;
    end
end
end 

%y=[0 0 0 0 1 1 1 1 1 0 0 0 1 1 1 1 0 0 0 1 1 1 1 0 0 0 0 0];
dy=diff(y);
j=1;
for i=1:length(dy)
if dy(i)==1
    y1(j)=i;
    j=j+1;
else if dy(i)==-1
        y1(j)=i;
        j=j+1;
    end
end
end 
z1=find(dx);
z2=find(dy);
no_questions=length(z2)/2;
no_options=length(z1)/2;


for i=0:no_questions-1
    k=2*i+1;
    for j=0:no_options-1
        p=2*j+1;
      z{i+1,j+1}=BW(z2(k):z2(k+1), z1(p):z1(p+1));
    end
end
% eliminate the columb of question numbers and row of options
[r1, c1]=size(z);
new_z=z(2:r1, c1-3:c1);




% obtain the percentage of number of black pixels in every segment
[rr, cc]=size(new_z);




for i=1:rr
    for j=1:cc
        im=new_z{i,j};
    cw = sum(im(:));
    cb = numel(im) - cw;
    black_percent{i, j}=(100*cb)/numel(im);
    if black_percent{i,j}>50
        black_percent{i,j}=1;
    else black_percent{i,j}=0;
    end
    end
end







actual_answer=black_percent;
result_1=cell2mat(Model_answer)-cell2mat(actual_answer);
correct_answers=0;
for i=1:rr
if result_1(i, :)==0
result(i)='c';
correct_answers=correct_answers+1;
else result(i)='W';
end
end


