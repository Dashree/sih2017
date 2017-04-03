
function [C_First, C_Last, R_First,R_Last]= Test_Image_Boundry(B)
 %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
% B=imread('E:\OMR final codes_sih2017\NewStudent1.jpg');%%OMR_final.jpg
%x_test = imresize(B, [master_height, master_width]);
x1=rgb2gray(B);
x1_level=graythresh(x1);
BW_test = im2bw(x1,x1_level);
BW_edge = edge(BW_test);
BW_edge=medfilt2(BW_edge);

[a b]=size(BW_edge);
% Detecting vetrical lines
Hr_Image=BW_edge(floor(a/2-a/4):floor(a/2+a/4),:);
se = strel('line',5,0);
BWV = imdilate(Hr_Image,se);
Vr_Profile=sum(BWV,1)./max(sum(BWV,1));


% detecting horixontal lines
Vr_Image=BW_edge(:, floor(b/2-b/4):floor(b/2+b/4));
se = strel('line',5,90);
BWH = imdilate(Vr_Image,se);
Hr_Profile=sum(BWH,2)./max(sum(BWH,2));


[a1, b1]=size(Hr_Profile);
for i=1:a1
 if Hr_Profile(i, 1)>0.5
     Hr_Profile(i, 1)=1;
 else Hr_Profile(i, 1)=0;
 end
end
 
 [a2, b2]=size(Vr_Profile);
for i=1:b2
 if Vr_Profile(i)>0.5
     Vr_Profile(i)=1;
 else Vr_Profile(i)=0;
 end
end

C_First=find(Vr_Profile, 1, 'first');
C_Last=find(Vr_Profile, 1, 'last');

R_First=find(Hr_Profile, 1, 'first');
R_Last=find(Hr_Profile, 1, 'last');

